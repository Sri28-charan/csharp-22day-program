using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentSchedulingModule
{
    internal class Appointment
    {
        public string PatientName { get; set; }
        public string Department { get; set; }
        public string Doctor { get; set; }
        public string TimeSlot { get; set; }

    }
}
