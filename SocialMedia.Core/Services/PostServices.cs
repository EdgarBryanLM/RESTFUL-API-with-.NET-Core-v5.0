using Microsoft.Extensions.Options;
using SocialMedia.Core.CustomEntitis;
using SocialMedia.Core.Entidades;
using SocialMedia.Core.Exepciones;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.QueryFilters;
using System;
using System.Linq;

using System.Threading.Tasks;

namespace SocialMedia.Core.Services
{
    public class PostServices : IPostServices
    {

        private readonly IUnitofWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;



        public PostServices(IUnitofWork unitofWork,IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitofWork;
            _paginationOptions = options.Value;
        }

        public async Task<bool> DeletePost(int id)
        {
             await _unitOfWork.PostRepository.Delete(id);
            return true;
        }

        public async Task<Post> GetPost(int id)
        {
           return await _unitOfWork.PostRepository.GetById(id);
        }

        public PagedList<Post> GetPosts(POSTQueryFilter filters)
        {
                var posts= _unitOfWork.PostRepository.GetAll();


            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPagenumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;
            if (filters.UserId != null)
            {
                posts = posts.Where(x => x.UserId == filters.UserId);
            }


            if (filters.Date != null)
            {
                posts = posts.Where(x => x.Date.ToShortDateString() == filters.Date?.ToShortDateString());
            }

            if (filters.Description != null)
            {
                posts = posts.Where(x => x.Description.ToLower().Contains(filters.Description.ToLower()));
            }

            var pagedPosts = PagedList<Post>.Create(posts,filters.PageNumber,filters.PageSize);

            return pagedPosts;
        }

        public async Task InsertPost(Post post)
        {
            var user = await _unitOfWork.UserRepository.GetById(post.UserId);
            if(user == null)
            {
                throw new BusinessException("Usuario no existe");
            }

            var userPost = await _unitOfWork.PostRepository.GetPostsByuser(post.UserId);
            if (userPost.Count() < 10)
            {
                var lastPost = userPost.OrderByDescending(x=>x.Date).FirstOrDefault();
                TimeSpan resultado = (TimeSpan)(  DateTime.Now - lastPost.Date);
                if (resultado.TotalDays< 7)
                {
                    throw new BusinessException("No estas habilitado para publicar");

                }

            }

            if (post.Description.Contains("sexo"))
            {
                throw new BusinessException("Publicacion no adecuada");

            }

            await _unitOfWork.PostRepository.Add(post);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdatePost(Post post)
        {
             _unitOfWork.PostRepository.Update(post);
           await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
