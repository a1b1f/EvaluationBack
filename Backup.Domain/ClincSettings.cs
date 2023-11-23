using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backup.Domain
{
    public class ClincSettings
    {
        public string ConnectionStrings { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string RecordCollection { get; set; } = string.Empty;
    }
}
