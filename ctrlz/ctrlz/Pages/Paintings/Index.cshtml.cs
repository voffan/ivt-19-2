using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ctrlz.Classes;
using ctrlz.Data;

namespace ctrlz.Pages.Paintings
{
    public class IndexModel : PageModel
    {
        private readonly ctrlz.Data.MyDbContext _context;

        public IndexModel(ctrlz.Data.MyDbContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string ValueSort { get; set; }
        public string AuthorSort { get; set; }
        public string GenreSort { get; set; }
        public string LocationSort { get; set; }
        public string StatusSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Painting> Painting { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            Painting = await _context.Paintings
                .Include(p => p.Author)
                .Include(p => p.Genre)
                .Include(p => p.Location).ToListAsync();

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            ValueSort = sortOrder == "Value" ? "value_desc" : "Value";
            AuthorSort = sortOrder == "Author" ? "author_desc" : "Author";
            GenreSort = sortOrder == "Genre" ? "genre_desc" : "Genre";
            LocationSort = sortOrder == "Location" ? "location_desc" : "Location";
            StatusSort = sortOrder == "Status" ? "status_desc" : "Status";

            CurrentFilter = searchString;

            IQueryable<Painting> paintingsIQ = from s in _context.Paintings
                                              select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                paintingsIQ = paintingsIQ.Where(s => s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    paintingsIQ = paintingsIQ.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    paintingsIQ = paintingsIQ.OrderBy(s => s.DateOfCreation);
                    break;
                case "date_desc":
                    paintingsIQ = paintingsIQ.OrderByDescending(s => s.DateOfCreation);
                    break;
                case "Value":
                    paintingsIQ = paintingsIQ.OrderBy(s => s.Value);
                    break;
                case "value_desc":
                    paintingsIQ = paintingsIQ.OrderByDescending(s => s.Value);
                    break;
                case "Author":
                    paintingsIQ = paintingsIQ.OrderBy(s => s.Author);
                    break;
                case "author_desc":
                    paintingsIQ = paintingsIQ.OrderByDescending(s => s.Author);
                    break;
                case "Genre":
                    paintingsIQ = paintingsIQ.OrderBy(s => s.Genre);
                    break;
                case "genre_desc":
                    paintingsIQ = paintingsIQ.OrderByDescending(s => s.Genre);
                    break;
                case "Location":
                    paintingsIQ = paintingsIQ.OrderBy(s => s.Location);
                    break;
                case "location_desc":
                    paintingsIQ = paintingsIQ.OrderByDescending(s => s.Location);
                    break;
                case "Status":
                    paintingsIQ = paintingsIQ.OrderBy(s => s.Status);
                    break;
                case "status_desc":
                    paintingsIQ = paintingsIQ.OrderByDescending(s => s.Status);
                    break;
                default:
                    paintingsIQ = paintingsIQ.OrderBy(s => s.Name);
                    break;
            }

            Painting = await paintingsIQ.AsNoTracking().ToListAsync();
        }
    }

}
