using SocialMedia.Core.CustomEntitis;
using SocialMedia.Core.Entidades;
using SocialMedia.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostServices
    {
        Task InsertPost(Post post);
        PagedList<Post> GetPosts(POSTQueryFilter filters);
        Task<Post> GetPost(int id);
        Task<bool> DeletePost(int id);
        Task<bool> UpdatePost(Post post);
    }
}