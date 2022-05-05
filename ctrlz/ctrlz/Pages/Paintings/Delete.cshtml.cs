﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly ctrlz.Data.MyDbContext _context;

        public DeleteModel(ctrlz.Data.MyDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Painting = await _context.Paintings.FindAsync(id);

            if (Painting != null)
            {
                _context.Paintings.Remove(Painting);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
