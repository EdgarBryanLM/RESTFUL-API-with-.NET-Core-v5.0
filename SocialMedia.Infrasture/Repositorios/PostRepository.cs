using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entidades;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrasture.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Infrasture.Repositorios
{
    public class PostRepository : BaseRepository<Post>, IPostRepositori
    {
        public PostRepository(SocialMediaContext contexto):base(contexto)
        {
            
        }
        public async Task<IEnumerable<Post>> GetPostsByuser(int userId)
        {
            return await _entities.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
