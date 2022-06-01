using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ctrlz.Classes;
using Microsoft.AspNetCore.Authorization;

namespace ctrlz.Pages.Paintings
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly Model.AuthDbContext _context;

        public DetailsModel(Model.AuthDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
