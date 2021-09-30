using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MobileStore.NewPhones;

namespace MobileStore.Pages_newmobiles
{
    public class DeleteModel : PageModel
    {
        private readonly newMobilesContext _context;

        public DeleteModel(newMobilesContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NewMobiles = await _context.NewMobiles.FindAsync(id);

            if (NewMobiles != null)
            {
                _context.NewMobiles.Remove(NewMobiles);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
