using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSummaryReportModule
{
    internal class PatientRecord
    {

        public string Name { get; set; }
        public string Department { get; set; }
        public decimal BillAmount { get; set; }
        public string Status { get; set; }

    }
}
