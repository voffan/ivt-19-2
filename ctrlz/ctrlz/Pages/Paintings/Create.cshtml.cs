using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ctrlz.Classes;
using Microsoft.AspNetCore.Authorization;

namespace ctrlz.Pages.Paintings
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly Model.AuthDbContext _context;

        public CreateModel(Model.AuthDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name");
        ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Name");
        ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Painting Painting { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Paintings.Add(Painting);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
