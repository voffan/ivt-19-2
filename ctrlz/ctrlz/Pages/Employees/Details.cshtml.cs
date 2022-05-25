using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ctrlz.Classes;
using ctrlz.Data;

namespace ctrlz.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly ctrlz.Data.MyDbContext _context;

        public DetailsModel(ctrlz.Data.MyDbContext context)
        {
            _context = context;
        }

        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employees.FirstOrDefaultAsync(m => m.Id == id);

            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
