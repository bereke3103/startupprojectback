using Models;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IResumeRepository : IRepository<ResumeModel>
    {
        Task<List<ResumeListByIdGetVM>> GetResumeListByIdGet(int id);
        Task<ResumeGetVM> CreateResumeById(ResumeCreateVM resume);
        void Update(ResumeModel user);
    }
}
