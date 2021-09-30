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
    public class IndexModel : PageModel
    {
        private readonly newMobilesContext _context;

        public IndexModel(newMobilesContext context)
        {
            _context = context;
        }

        public IList<NewMobiles> NewMobiles { get;set; }

        public async Task OnGetAsync()
        {
            NewMobiles = await _context.NewMobiles.ToListAsync();
        }
    }
}
