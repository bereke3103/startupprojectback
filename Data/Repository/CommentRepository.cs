using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.ViewModel;
using Models.ViewModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CommentRepository : Repository<CommentModel>, ICommentRepository
    {
        private readonly ApplicationDbContext _db;
        public CommentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<List<GetAllResumesByUserIdByCommentIdVM>> GetAllCommentsForUser(RequestCommentByUserIdByCommentId model)
        {
            var commentsFromBack = await _db.Comments
                .Where(c => c.UserId == model.UserId)
                .Where(c => c.ResumeId == model.ResumeId).ToListAsync();

            List<GetAllResumesByUserIdByCommentIdVM> comments = new List<GetAllResumesByUserIdByCommentIdVM>();

            foreach (var comment in commentsFromBack)
            {
                var author = await _db.Users.FirstOrDefaultAsync(u=>u.Id == comment.AuthroId);
                comments.Add(new GetAllResumesByUserIdByCommentIdVM()
                {
                    Author = author.Login,
                    Id = comment.Id,
                    Comment = comment.Comment,
                    CreatedComment = comment.CreatedComment,
                });
            }

            return comments;
        }


        public async Task<ResponseCreatingCommentVM> CreateCommentForUserIdByResumeId(RequestCreatingCommentVM model)
        {
            if(string.IsNullOrEmpty(model.Comment))
            {
                throw new Exception("Нельзя сохранять пустые комментарий");
            }

            CommentModel comment = new CommentModel() 
            { 
                AuthroId = model.AuthorId,
                Comment = model.Comment,
                UserId = model.UserId,
                ResumeId = model.ResumeId,
            };

            await _db.Comments.AddAsync(comment);
            await _db.SaveChangesAsync();


            ResponseCreatingCommentVM returninModel = new ResponseCreatingCommentVM()
            {
                Id = comment.Id,
                Comment = model.Comment,
            };

            return returninModel;
        }

        public void Update(CommentModel comment)
        {
            throw new NotImplementedException();
        }
    }
}
