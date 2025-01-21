using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Medical_Clinic.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Prenumele trebuie sa inceapa cu majuscula (ex. Ana)!")]
        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Numele trebuie sa inceapa cu majuscula (ex. Pop)!")]
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        public string FullName { get { return this.FirstName + " " + this.LastName; } }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(100)]
        public string ContactInfo { get; set; }

    }
}