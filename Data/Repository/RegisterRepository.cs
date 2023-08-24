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
    public class RegisterRepository : Repository<RegisterModel>, IRegisterRepository
    {
        private readonly ApplicationDbContext _db;
        public RegisterRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }
       

        public async Task RegisterAsync(RegisterVM model)
        {
            var foundUser = await _db.Registers.FirstOrDefaultAsync(r => r.Login == model.Login);
            if (foundUser != null)
            {
                throw new Exception("Такой пользователь уже существует");
            }

            RegisterModel registerModel = new RegisterModel()
            {
                Login = model.Login,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
            };

            await _db.AddAsync(registerModel);

            await _db.SaveChangesAsync();
            
        }
    }
}
