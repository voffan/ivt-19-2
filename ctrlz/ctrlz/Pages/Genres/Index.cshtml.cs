﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ctrlz.Classes;
using ctrlz.Model;
using Microsoft.AspNetCore.Authorization;

namespace ctrlz.Pages.Genres
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ctrlz.Model.AuthDbContext _context;

        public IndexModel(ctrlz.Model.AuthDbContext context)
        {
            _context = context;
        }

        public IList<Genre> Genre { get;set; }

        public async Task OnGetAsync()
        {
            Genre = await _context.Genres.ToListAsync();
        }
    }
}
