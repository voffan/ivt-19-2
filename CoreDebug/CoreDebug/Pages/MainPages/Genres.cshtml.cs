using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoreDebug.Data;
using CoreDebug.Classes;
using Microsoft.EntityFrameworkCore;

namespace CoreDebug.Pages.MainPages
{
    public class GenreModel : PageModel
    {
        private readonly MyDbContext _Genre;
        public List<Genre> Genre { get; set; }
        public GenreModel(MyDbContext db)
        {
            _Genre = db;
        }
        public void OnGet()
        {
            Genre = _Genre.Genres.AsNoTracking().ToList();
        }
    }
}