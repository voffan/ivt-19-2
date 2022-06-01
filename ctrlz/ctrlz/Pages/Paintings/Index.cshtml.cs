using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ctrlz.Classes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace ctrlz.Pages.Paintings
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Model.AuthDbContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(Model.AuthDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
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
        public string SearchBy { get; set; }

        public PaginatedList<Painting> Painting { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, string searchBy, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            ValueSort = sortOrder == "Value" ? "value_desc" : "Value";
            AuthorSort = sortOrder == "Author" ? "author_desc" : "Author";
            GenreSort = sortOrder == "Genre" ? "genre_desc" : "Genre";
            LocationSort = sortOrder == "Location" ? "location_desc" : "Location";
            StatusSort = sortOrder == "Status" ? "status_desc" : "Status";

            CurrentFilter = searchString;
            SearchBy = searchBy;

            IQueryable<Painting> paintingsIQ = from s in _context.Paintings select s;

            if (!String.IsNullOrEmpty(searchString))
            {

                if (searchBy == "Name") {
                    paintingsIQ = paintingsIQ.Where(s => s.Name.Contains(searchString));
                }
                else if (searchBy == "Value")
                {
                    paintingsIQ = paintingsIQ.Where(s => s.Value.ToString().Contains(searchString));
                }
                else if (searchBy == "Author")
                {
                    paintingsIQ = paintingsIQ.Where(s => s.Author.Name.Contains(searchString));
                }
                else if (searchBy == "DateOfCreation")
                {
                    paintingsIQ = paintingsIQ.Where(s => s.DateOfCreation.ToString().Contains(searchString));
                }
                else if (searchBy == "Genre")
                {
                    paintingsIQ = paintingsIQ.Where(s => s.Genre.Name.Contains(searchString));
                }
                else if (searchBy == "Location")
                {
                    paintingsIQ = paintingsIQ.Where(s => s.Location.Name.Contains(searchString));
                }
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

            paintingsIQ = paintingsIQ.Include(s => s.Author);
            paintingsIQ = paintingsIQ.Include(s => s.Genre);
            paintingsIQ = paintingsIQ.Include(s => s.Location);

            var pageSize = Configuration.GetValue("PageSize", 4);
            Painting = await PaginatedList<Painting>.CreateAsync(paintingsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
