using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ctrlz.Classes;
using ctrlz.Data;

namespace ctrlz.Pages.Paintings
{
    public class IndexModel : PageModel
    {
        private readonly ctrlz.Data.MyDbContext _context;

        public IndexModel(ctrlz.Data.MyDbContext context)
        {
            _context = context;
        }

        public IList<Painting> Painting { get;set; }

        public async Task OnGetAsync()
        {
            Painting = await _context.Paintings
                .Include(p => p.Author)
                .Include(p => p.Genre)
                .Include(p => p.Location).ToListAsync();
        }
    }
}
