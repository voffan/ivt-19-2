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
    public class CreateGenreModel : PageModel
    {
        private readonly MyDbContext _Genre;
        [BindProperty]
        public Genre Genre { get; set; }
        public CreateGenreModel(MyDbContext db)
        {
            _Genre = db;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _Genre.Genres.Add(Genre);
                await _Genre.SaveChangesAsync();
                return RedirectToPage("/MainPages/Genres");
            }
            return Page();
        }
    }
}
