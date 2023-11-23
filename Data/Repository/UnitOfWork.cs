using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IResumeRepository User { get; private set; }

        public IRegisterRepository Register { get; private set; }

        public ILoginRepository Login { get; private set; }

        public ICommentRepository Comment { get; private set; }

        public INewsRepository News { get; private set; }

        public UnitOfWork(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            User = new ResumeRepository(_db);
            Register = new RegisterRepository(_db);
            Login = new LoginRepository(_db, configuration);
            Comment = new CommentRepository(_db);
            News = new NewsRepository(_db);
       
        }

        public async Task SaveAsync()
        {
          await _db.SaveChangesAsync();
        }
    }
}
