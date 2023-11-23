using Backup.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public class ClinicBackupRepo<T> : IRepositoryBase<T> where T : class
    {
        protected BackupDBContext BackupContext { get; set; }
        public ClinicBackupRepo(BackupDBContext BackupContext)
        {
            this.BackupContext = BackupContext;
        }
        public T Create(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindAll()
        {
            return this.BackupContext.Set<T>().AsNoTracking();
        }
    }
}
