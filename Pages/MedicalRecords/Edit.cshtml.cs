using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Medical_Clinic.Data;
using Medical_Clinic.Models;

namespace Medical_Clinic.Pages.MedicalRecords
{
    public class EditModel : PageModel
    {
        private readonly Medical_Clinic.Data.Medical_ClinicContext _context;

        public EditModel(Medical_Clinic.Data.Medical_ClinicContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MedicalRecord MedicalRecord { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalrecord =  await _context.MedicalRecord.FirstOrDefaultAsync(m => m.RecordID == id);
            if (medicalrecord == null)
            {
                return NotFound();
            }
            MedicalRecord = medicalrecord;
           ViewData["PatientID"] = new SelectList(_context.Patient, "PatientID", "FirstName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MedicalRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalRecordExists(MedicalRecord.RecordID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MedicalRecordExists(int id)
        {
            return _context.MedicalRecord.Any(e => e.RecordID == id);
        }
    }
}
