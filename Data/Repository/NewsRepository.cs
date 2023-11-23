using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class NewsRepository : Repository<NewsModel>, INewsRepository
    {
        private readonly ApplicationDbContext _db;
        public NewsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(NewsModel news)
        {
            throw new NotImplementedException();
        }
    }
}
