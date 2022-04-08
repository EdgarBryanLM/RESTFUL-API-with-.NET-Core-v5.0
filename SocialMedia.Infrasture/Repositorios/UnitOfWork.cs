using SocialMedia.Core.Entidades;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrasture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrasture.Repositorios
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly SocialMediaContext _context;
        private readonly IPostRepositori _postRepositori;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Comment> _commentRepository;
        public UnitOfWork(SocialMediaContext context)
        {
            _context = context;
        }

        public IPostRepositori PostRepository => _postRepositori?? new PostRepository(_context);
        public IRepository<User> UserRepository => _userRepository ?? new BaseRepository<User>(_context);
        public IRepository<Comment> CommentRepository => _commentRepository ?? new BaseRepository<Comment>(_context);

        public void Dispose()
        {
            if (_context!=null)
            {
                _context.Dispose();
            }
        }
        public void SaveChangues()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}
