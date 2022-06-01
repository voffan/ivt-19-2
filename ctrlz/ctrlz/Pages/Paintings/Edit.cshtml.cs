using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ctrlz.Classes;
using Microsoft.AspNetCore.Authorization;

namespace ctrlz.Pages.Paintings
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly Model.AuthDbContext _context;

        public EditModel(Model.AuthDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Painting Painting { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Painting = await _context.Paintings
                .Include(p => p.Author)
                .Include(p => p.Genre)
                .Include(p => p.Location).FirstOrDefaultAsync(m => m.Id == id);

            if (Painting == null)
            {
                return NotFound();
            }
           ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Name");
           ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Name");
           ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Painting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaintingExists(Painting.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PaintingExists(int id)
        {
            return _context.Paintings.Any(e => e.Id == id);
        }
    }
}
