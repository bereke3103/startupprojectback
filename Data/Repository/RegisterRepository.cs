using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RegisterRepository : Repository<UserModel>, IRegisterRepository
    {
        private readonly ApplicationDbContext _db;
        public RegisterRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }
       

        public async Task RegisterAsync(UserVM model)
        {
            var foundUser = await _db.Users.FirstOrDefaultAsync(r => r.Login == model.Login);
            if (foundUser != null)
            {
                throw new Exception("Такой пользователь уже существует");
            }

            UserModel registerModel = new UserModel()
            {
                Login = model.Login,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
            };

            await _db.AddAsync(registerModel);

            await _db.SaveChangesAsync();
            
        }
    }
}
