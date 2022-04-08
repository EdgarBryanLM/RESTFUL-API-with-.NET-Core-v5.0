using SocialMedia.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
  public interface  IUnitofWork:IDisposable
    {

        IPostRepositori PostRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<Comment> CommentRepository { get; }

        void SaveChangues();

        Task SaveChangesAsync();
    }
}
