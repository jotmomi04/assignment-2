using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobileStore.NewPhones;

namespace MobileStore.Pages_newmobiles
{
    public class CreateModel : PageModel
    {
        private readonly newMobilesContext _context;

        public CreateModel(newMobilesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public NewMobiles NewMobiles { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.NewMobiles.Add(NewMobiles);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
