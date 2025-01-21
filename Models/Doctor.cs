using System.ComponentModel.DataAnnotations;

namespace Medical_Clinic.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Numele trebuie sa inceapa cu majuscula (ex. Popa)!")]
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Specializarea trebuie sa inceapa cu majuscula (ex. Derma)!")]
        [Required, MaxLength(50)]
        public string Specialization { get; set; }

        [MaxLength(100)]
        public string ContactInfo { get; set; }
    }
}