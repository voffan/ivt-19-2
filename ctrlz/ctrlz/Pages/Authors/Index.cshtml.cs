using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ctrlz.Classes;
using ctrlz.Data;

namespace ctrlz.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly ctrlz.Data.MyDbContext _context;

        public IndexModel(ctrlz.Data.MyDbContext context)
        {
            _context = context;
        }

        public string CurrentFilter { get; set; }

        public IList<Author> Author { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            CurrentFilter = searchString;
            IQueryable<Author> authorsIQ = from s in _context.Authors select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                authorsIQ = authorsIQ.Where(s => s.Name.Contains(searchString));
            }
            Author = await authorsIQ.ToListAsync();
        }
    }
}
