using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingAndCostEstimationModule
{
    internal class Bill
    {

        public const decimal ConsultationFee = 500;
        public const decimal BloodTestFee = 200;
        public const decimal XRayFee = 1000;
        public const decimal AdmissionFee = 2000;

        public string PatientName { get; set; }
        public int Age { get; set; }
        public decimal BaseAmount { get; set; }
        public decimal Discount{ get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }

    }
}
