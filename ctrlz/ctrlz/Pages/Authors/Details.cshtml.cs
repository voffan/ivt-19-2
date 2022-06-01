using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ctrlz.Classes;
using Microsoft.AspNetCore.Authorization;

namespace ctrlz.Pages.Authors
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly Model.AuthDbContext _context;

        public DetailsModel(Model.AuthDbContext context)
        {
            _context = context;
        }

        public Author Author { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Author = await _context.Authors.FirstOrDefaultAsync(m => m.Id == id);

            if (Author == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
