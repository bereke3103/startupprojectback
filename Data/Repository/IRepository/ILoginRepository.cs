using Models;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface ILoginRepository : IRepository<UserModel>
    {
        Task<TokenAndIdVM> LoginAsync(UserVM model);
    }
}
