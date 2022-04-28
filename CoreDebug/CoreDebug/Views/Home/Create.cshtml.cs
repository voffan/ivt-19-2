using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoreDebug.Data;
using CoreDebug.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreDebug.Views.Home
{
    public class CreateModel : PageModel
    {
        private readonly MyDbContext _context;
        [BindProperty]
        public Painting Painting { get; set; }
        public CreateModel(MyDbContext db)
        {
            _context = db;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Paintings.Add(Painting);
                await _context.SaveChangesAsync();
                return RedirectToPage("Paintings");
            }
            return Page();
        }
    }
}
