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
    public class DetailsModel : PageModel
    {
        private readonly newMobilesContext _context;

        public DetailsModel(newMobilesContext context)
        {
            _context = context;
        }

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
    }
}
