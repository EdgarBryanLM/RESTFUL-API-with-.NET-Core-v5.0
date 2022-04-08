using SocialMedia.Core.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Infrasture.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUsers();
    }
}