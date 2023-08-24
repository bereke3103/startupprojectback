using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModel;

namespace StrProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public RegisterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterVM model)
        {
            await _unitOfWork.Register.RegisterAsync(model);
            return Ok("Вы успешно зарегистрировались");
        }
    }
}
