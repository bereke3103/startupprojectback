using Models;
using Models.ViewModel.Request;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface ICommentRepository : IRepository<CommentModel>
    {
        void Update(CommentModel comment);
        Task<List<GetAllResumesByUserIdByCommentIdVM>> GetAllCommentsForUser(RequestCommentByUserIdByCommentId model);
        Task<ResponseCreatingCommentVM> CreateCommentForUserIdByResumeId(RequestCreatingCommentVM model);
    }
}
