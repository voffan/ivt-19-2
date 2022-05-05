using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoreDebug.Data;
using CoreDebug.Classes;
using Microsoft.EntityFrameworkCore;

namespace CoreDebug.Pages.MainPages
{
    public class AuthorsModel : PageModel
    {
        private readonly MyDbContext _Author;
        public List<Author> Author { get; set; }
        public AuthorsModel(MyDbContext db)
        {
            _Author = db;
        }
        public void OnGet()
        {
            Author = _Author.Authors.AsNoTracking().ToList();
        }
    }
}