using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Medical_Clinic.Models
{
    public class MedicalRecord
    {
        [Key]
        public int RecordID { get; set; }

        [Required]
        public int PatientID { get; set; }

        [ReadOnly(true)]
        public Patient? Patient { get; set; }

        [Required, MaxLength(255)]
        public string Diagnosis { get; set; }

        public string Treatment { get; set; }

        [Required]
        public DateTime RecordDate { get; set; }
    }
}