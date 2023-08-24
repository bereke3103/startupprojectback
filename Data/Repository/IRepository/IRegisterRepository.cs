using Models;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IRegisterRepository : IRepository<RegisterModel>
    {
        Task RegisterAsync(RegisterVM model);
    }
}
