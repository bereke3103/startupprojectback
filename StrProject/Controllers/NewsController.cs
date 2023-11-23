using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModel;

namespace StrProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _db;

        public NewsController(IUnitOfWork unitOfWork, ApplicationDbContext db)
        {
            _unitOfWork = unitOfWork;
            _db = db;
        }

        [HttpGet("getnews")]
        public async Task<IActionResult> GetNewsAsync ()
        {
            var result = await _unitOfWork.News.GetAll();

            return Ok(result);
        }


        [HttpPost("createnews")]

        public async Task<IActionResult> CreateNewsAsync(NewsCreateVM model)
        {
            NewsModel vm = new NewsModel()
            {
                Title = model.Title,
                Description = model.Description,
            };

            await _unitOfWork.News.AddAsync(vm);
            await _unitOfWork.SaveAsync();

            return Ok(vm);

        }

    }
}
