using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ResumeRepository : Repository<ResumeModel>, IResumeRepository
    {
        private readonly ApplicationDbContext _db;
        public ResumeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<List<ResumeListByIdGetVM>> GetResumeListByIdGet(int id)
        {
            var user = await _db.Users.Include(r => r.Resumes).FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                throw new Exception("Такого пользователя не существует");
            }

            List<ResumeListByIdGetVM> resumeModel = new List<ResumeListByIdGetVM>();


            foreach (var foundResume in user.Resumes)
            {
                resumeModel.Add(new ResumeListByIdGetVM()
                {
                    Id=foundResume.Id,
                    Firstname = foundResume.Nickname, 
                    Lastname = foundResume.Lastname,
                    Stack = foundResume.Stack,
                    Workplace = foundResume.Workplace,
                    Nickname = foundResume.Nickname,
                });
            }

            return resumeModel;
        }

        public async Task<ResumeGetVM> CreateResumeById(ResumeCreateVM resume)
        {

            var user = await _db.Users.SingleOrDefaultAsync(u => u.Id == resume.UserId);
            if (user == null)
            {
                throw new Exception("Такого пользователя не существует");
            }

            ResumeModel creatingResumeModel = new ResumeModel()
            {
                UserId = resume.UserId,
                Nickname = resume.Nickname,
                Firstname = resume.Firstname, 
                Lastname = resume.Lastname,
                Workplace = resume.Workplace,
                Stack = resume.Stack,
            };

            await _db.Resumes.AddAsync(creatingResumeModel);
            await _db.SaveChangesAsync();

            ResumeGetVM response = new ResumeGetVM() 
            { 
                UserId = resume.UserId, 
                Firstname = resume.Firstname, 
                Lastname = resume.Lastname, 
                Nickname = resume.Nickname, 
                Stack = resume.Stack, 
                Workplace = resume.Workplace 
            };


            return response;
        }

        public void Update(ResumeModel user)
        {
           _db.Resumes.Update(user);
        }
    }
}
