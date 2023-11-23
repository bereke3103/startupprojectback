using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IResumeRepository User { get; }
        IRegisterRepository Register { get; }
        ILoginRepository Login { get; }
        ICommentRepository Comment { get; }
        INewsRepository News { get; }

        Task SaveAsync();
    }
}
