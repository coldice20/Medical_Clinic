using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Medical_Clinic.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }

        [Required]
        public int PatientID { get; set; }
        [ReadOnly(true)]
        public Patient? Patient { get; set; }

        [Required]
        public int DoctorID { get; set; }
        [ReadOnly(true)]
        public Doctor? Doctor { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [MaxLength(255)]
        public string Reason { get; set; }
    }
}