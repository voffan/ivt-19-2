using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoreDebug.Data;
using CoreDebug.Classes;
using Microsoft.EntityFrameworkCore;

namespace CoreDebug.Views.Home
{
    public class PaintingsModel : PageModel
    {
        private readonly MyDbContext _context;
        public List<Painting> Painting { get; set; }
        public PaintingsModel(MyDbContext db)
        {
            _context = db;
        }
        public void OnGet()
        {
            Painting = _context.Paintings.AsNoTracking().ToList();
        }
    }
}