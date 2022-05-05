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
    public class CreateAuthorModel : PageModel
    {
        private readonly MyDbContext _Author;
        [BindProperty]
        public Author Author { get; set; }
        public CreateAuthorModel(MyDbContext db)
        {
            _Author = db;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _Author.Authors.Add(Author);
                await _Author.SaveChangesAsync();
                return RedirectToPage("/MainPages/Authors");
            }
            return Page();
        }
    }
}
