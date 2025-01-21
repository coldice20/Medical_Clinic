using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Medical_Clinic.Data;
using Medical_Clinic.Models;

namespace Medical_Clinic.Pages.MedicalRecords
{
    public class CreateModel : PageModel
    {
        private readonly Medical_Clinic.Data.Medical_ClinicContext _context;

        public CreateModel(Medical_Clinic.Data.Medical_ClinicContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PatientID"] = new SelectList(_context.Patient, "PatientID", "FirstName");
            return Page();
        }

        [BindProperty]
        public MedicalRecord MedicalRecord { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MedicalRecord.Add(MedicalRecord);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
