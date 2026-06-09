using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalSignsMontoringModule
{
    internal class Details
    {
        public string PatientName { get; set; }
        public double Temperature { get; set; }
        public int OxygenLevel { get; set; }
        public int PulseRate { get; set; }
    }

}
