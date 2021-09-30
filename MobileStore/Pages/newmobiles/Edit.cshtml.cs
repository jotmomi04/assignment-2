using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MobileStore.NewPhones;

namespace MobileStore.Pages_newmobiles
{
    public class EditModel : PageModel
    {
        private readonly newMobilesContext _context;

        public EditModel(newMobilesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public NewMobiles NewMobiles { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NewMobiles = await _context.NewMobiles.FirstOrDefaultAsync(m => m.ID == id);

            if (NewMobiles == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(NewMobiles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewMobilesExists(NewMobiles.ID))
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

        private bool NewMobilesExists(int id)
        {
            return _context.NewMobiles.Any(e => e.ID == id);
        }
    }
}
