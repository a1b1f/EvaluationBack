using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.Domain
{
    public class BackupDBContext :DbContext
    {
        public BackupDBContext(DbContextOptions<BackupDBContext> options) : base(options)
        {

        }
        public DbSet<Records> BackUpRecords { get; set; }
    }
}
