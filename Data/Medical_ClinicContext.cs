using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Medical_Clinic.Models;

namespace Medical_Clinic.Data
{
    public class Medical_ClinicContext : DbContext
    {
        public Medical_ClinicContext (DbContextOptions<Medical_ClinicContext> options)
            : base(options)
        {
        }

        public DbSet<Medical_Clinic.Models.Doctor> Doctor { get; set; } = default!;
        public DbSet<Medical_Clinic.Models.Patient> Patient { get; set; } = default!;
        public DbSet<Medical_Clinic.Models.Appointment> Appointment { get; set; } = default!;
        public DbSet<Medical_Clinic.Models.MedicalRecord> MedicalRecord { get; set; } = default!;
    }
}
