using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModel.Request;

namespace StrProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("getcommentsbyuserifromresume")]
        public async Task<IActionResult> GetCommentsByUserIdByResumeId([FromQuery]RequestCommentByUserIdByCommentId model)
        {
            var result = await _unitOfWork.Comment.GetAllCommentsForUser(model);

            return Ok(result);
        }

        [HttpPost("creatingcomment")]
        public async Task<IActionResult> CreateComment(RequestCreatingCommentVM model)
        {
            var response = await _unitOfWork.Comment.CreateCommentForUserIdByResumeId(model);

            return Ok(response);
        }
    }
}
