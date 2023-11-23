using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDBContext RepositoryContext;
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UnitOfWork(ApplicationDBContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public Task<int> CompleteAsync()
        {
            return RepositoryContext.SaveChangesAsync();
        }

        public IRepositoryBase<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IRepositoryBase<T>;
            }

            IRepositoryBase<T> repo = new RepositoryBase<T>(RepositoryContext);
            repositories.Add(typeof(T), repo);
            return repo;
        }
        public int Complete()
        {
            return RepositoryContext.SaveChanges();
        }
    }
}
