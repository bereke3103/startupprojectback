using DataAccess.Repository.IRepository;
using Models;
using Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public async Task<UserModel> GetUsersAsync()
        {
            UserModel users = (UserModel)await _userRepository.GetAll();
            return users;
        }
    }
}
