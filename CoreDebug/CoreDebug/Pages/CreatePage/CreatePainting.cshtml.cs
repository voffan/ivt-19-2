using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoreDebug.Data;
using CoreDebug.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreDebug.Pages.CreatePage
{
    public class CreatePaintingModel : PageModel
    {
        private readonly MyDbContext _Painting;
        [BindProperty]
        public Painting Painting { get; set; }
        public CreatePaintingModel(MyDbContext db)
        {
            _Painting = db;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _Painting.Paintings.Add(Painting);
                await _Painting.SaveChangesAsync();
                return RedirectToPage("/MainPages/Paintings");
            }
            return Page();
        }
    }
}
