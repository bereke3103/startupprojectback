using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace StrProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            var result = await _unitOfWork.User.GetAll();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(UserCreateVM model)
        {
            UserModel newEntity = new UserModel()
            {
                Nickname = model.Nickname,
                FirstName = model.FirstName,
                LastName = model.LastName,
                WorkPlace = model.WorkPlace,
                Stack = model.Stack,
            };

            await _unitOfWork.User.AddAsync(newEntity);
            await _unitOfWork.SaveAsync();

            return Ok(newEntity);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync(int id, UserUpdateVM model)
        {
            var foundUser = _unitOfWork.User.Get(u => u.Id == id);
            if (foundUser == null)
            {
                return NotFound();
            } 
            else
            {
                foundUser.Nickname = model.Nickname;
                foundUser.FirstName = model.FirstName;
                foundUser.LastName = model.LastName;
                foundUser.WorkPlace = model.WorkPlace;
                foundUser.Stack = model.Stack;

                _unitOfWork.User.Update(foundUser);
                await _unitOfWork.SaveAsync();
                return Ok(foundUser);
            }
        }
    }
}
