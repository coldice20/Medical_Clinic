using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Medical_Clinic.Data;
using Medical_Clinic.Models;

namespace Medical_Clinic.Pages.MedicalRecords
{
    public class DetailsModel : PageModel
    {
        private readonly Medical_Clinic.Data.Medical_ClinicContext _context;

        public DetailsModel(Medical_Clinic.Data.Medical_ClinicContext context)
        {
            _context = context;
        }

        public MedicalRecord MedicalRecord { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalrecord = await _context.MedicalRecord.FirstOrDefaultAsync(m => m.RecordID == id);
            if (medicalrecord == null)
            {
                return NotFound();
            }
            else
            {
                MedicalRecord = medicalrecord;
            }
            return Page();
        }
    }
}
