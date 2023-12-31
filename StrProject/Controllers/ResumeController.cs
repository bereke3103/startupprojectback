﻿using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace StrProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _db;
        public ResumeController(IUnitOfWork unitOfWork, ApplicationDbContext db)
        {
            _unitOfWork = unitOfWork;
            _db = db;
        }

        [HttpGet("getusers")]
        public async Task<IActionResult> GetUsersAsync()
        {
            var result = await _unitOfWork.User.GetAll();

            return Ok(result);
        }


        [HttpPost("createuser")]
        public async Task<IActionResult> CreateUserAsync(ResumeCreateVM model)
        {
            ResumeModel newEntity = new ResumeModel()
            {
                Nickname = model.Nickname,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Workplace = model.Workplace,
                Stack = model.Stack,
            };

            await _unitOfWork.User.AddAsync(newEntity);
            await _unitOfWork.SaveAsync();

            return Ok(newEntity);
        }
        

        [HttpPut("updateuser")]
        public async Task<IActionResult> UpdateUserAsync(int id, ResumeUpdateVM model)
        {
            var foundUser = _unitOfWork.User.Get(u => u.Id == id);
            if (foundUser == null)
            {
                return NotFound();
            } 
            else
            {
                foundUser.Nickname = model.Nickname;
                foundUser.Firstname = model.Firstname;
                foundUser.Lastname = model.Lastname;
                foundUser.Workplace = model.Workplace;
                foundUser.Stack = model.Stack;

                _unitOfWork.User.Update(foundUser);
                await _unitOfWork.SaveAsync();
                return Ok(foundUser);
            }
        }

        [HttpGet("getuserbyid")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = _unitOfWork.User.Get(user => user.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }

        [HttpGet("getlistofwwnresumes")]
        public async Task<IActionResult> GetListOfOwnResumes(int id)
        {
            var response = await _unitOfWork.User.GetResumeListByIdGet(id);
            if (response == null)
            {
                throw new Exception("Произошла ошибка");
            }

            return Ok(response);

        }

        [HttpPost("createresumebyid")]
        public async Task<IActionResult> CreateResumeById(ResumeCreateVM model)
        {
            var response = await _unitOfWork.User.CreateResumeById(model);
            if (response == null)
            {
                throw new Exception("Произошла ошибка");
            }
            return Ok(response);
        }
    }
}
