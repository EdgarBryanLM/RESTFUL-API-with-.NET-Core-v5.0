using SocialMedia.Core.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task <T> GetById(int id);
        IEnumerable<T> GetAll();
        void Update(T entity);
        Task Delete(int id);
        Task Add(T entity);

    }
}
