using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoreDebug.Data;
using CoreDebug.Classes;
using Microsoft.EntityFrameworkCore;

namespace CoreDebug.Pages.MainPages
{
    public class PaintingsModel : PageModel
    {
        private readonly MyDbContext _Painting;
        public List<Painting> Painting { get; set; }
        public PaintingsModel(MyDbContext db)
        {
            _Painting = db;
        }
        public void OnGet()
        {
            Painting = _Painting.Paintings.AsNoTracking().ToList();
        }
    }
}