using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class LoginRepository : Repository<RegisterModel>, ILoginRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;
        public LoginRepository(ApplicationDbContext db, IConfiguration configuration) : base(db)
        {
            _db = db;
            _configuration = configuration;
        }

        public async Task<string> LoginAsync(RegisterVM model)
        {
            var foundUser = await _db.Registers.FirstOrDefaultAsync(u=> u.Login == model.Login);
            if (foundUser == null)
            {
                throw new Exception("Неверный логин или пароль");
            }

            if (!BCrypt.Net.BCrypt.Verify(model.Password, foundUser.Password))
            {
                throw new Exception("Неверный пароль");
            }

            var token = CreateToken(foundUser);

            return token;
        }

        private string CreateToken(RegisterModel foundUser)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Key").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, foundUser.Login),
            };

            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: creds);

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }
    }
}
