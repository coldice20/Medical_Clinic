using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Medical_Clinic.Data;
using Medical_Clinic.Models;

namespace Medical_Clinic.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly Medical_Clinic.Data.Medical_ClinicContext _context;

        public IndexModel(Medical_Clinic.Data.Medical_ClinicContext context)
        {
            _context = context;
        }

        public IList<Appointment> Appointment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Appointment = await _context.Appointment
                .Include(a => a.Doctor)
                .Include(a => a.Patient).ToListAsync();
        }
    }
}
