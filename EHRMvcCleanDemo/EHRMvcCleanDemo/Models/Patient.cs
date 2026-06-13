using System.ComponentModel.DataAnnotations;

namespace EHRMvcCleanDemo.Models
{
    // Maps to Healthcare.Patients
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        public Guid PatientGuid { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;

        public string? SSN { get; set; } // PHI – never displayed
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        

        public bool? IsActive { get; set; }

      
        public string FullName => FirstName + " " + LastName;
    }
}
