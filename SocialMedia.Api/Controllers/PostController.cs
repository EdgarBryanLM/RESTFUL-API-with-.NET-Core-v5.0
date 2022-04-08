using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SocialMedia.Api.Responses;
using SocialMedia.Core.CustomEntitis;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entidades;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.QueryFilters;
using SocialMedia.Infrasture.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Authorize ]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
   
    public class PostController : ControllerBase
    {
        private readonly IPostServices _IPostRepositorio;
        private readonly IMapper _mapper;
        private readonly IUriService _uriServices;


        public PostController(IPostServices postRepositorio, IMapper mapper, IUriService uriServices)
        {
            _IPostRepositorio = postRepositorio;
            _mapper = mapper;
            _uriServices = uriServices;
        }   

        /// <summary>
        /// Regresa todos los posts de la base de datos
        /// </summary>
        /// <param name="filters">Filtros a aplicar</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetPosts))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type= typeof(ApiResponse<IEnumerable<PostDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetPosts([FromQuery]POSTQueryFilter filters) {

            var post =  _IPostRepositorio.GetPosts(filters);
            var postDto = _mapper.Map<IEnumerable<PostDto>>(post);


            var metadata = new metadata
            {
                TotalCount = post.TotalCount,
                PageSize = post.PageSize,
                CurrentPage = post.CurrentPage,
                TotalPages = post.TotalPages,
                HasNextPage = post.HasNextPage,
                HasPreviusPage = post.HasPreviusPage,
                NextPageUrl = _uriServices.getPostPaginationUri(filters, Url.RouteUrl(nameof(GetPosts))).ToString(),
                PreviousPageUrl = _uriServices.getPostPaginationUri(filters, Url.RouteUrl(nameof(GetPosts))).ToString()


            };
            var response = new ApiResponse<IEnumerable<PostDto>>(postDto)
            {
                meta=metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));


            return Ok(response);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {

            var post = await _IPostRepositorio.GetPost(id);
            var postDto = _mapper.Map<PostDto>(post);

            var response = new ApiResponse<PostDto>(postDto);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            await _IPostRepositorio.InsertPost(post);
            postDto = _mapper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postDto);

            return Ok(post);
        }


        [HttpPut]
        public async Task<IActionResult> Put(int id,PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);

            post.id = id;

            var result=await _IPostRepositorio.UpdatePost(post);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            
          var result=  await _IPostRepositorio.DeletePost(id);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }


    }
}
