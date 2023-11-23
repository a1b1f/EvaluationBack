using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRepositoryBase<T> Repository<T>() where T : class;
        Task<int> CompleteAsync();
        int Complete();

    }
}
