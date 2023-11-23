using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Records
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string Symptoms { get; set; }
        public string Diagnosis { get; set; }
        public string TreatmentPlan { get; set; }
        public DateTime Date { get; set; }
    }
}
