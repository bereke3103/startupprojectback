﻿using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModel;

namespace StrProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public LoginController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(UserVM model)
        {
            var token = await _unitOfWork.Login.LoginAsync(model);
 
            return Ok(token);
        }
    }
}
