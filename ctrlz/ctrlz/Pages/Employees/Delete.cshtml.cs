using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ctrlz.Classes;
using ctrlz.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ctrls.Authorization;

namespace ctrlz.Pages.Employees
{
    public class DeleteModel : DI_BasePageModel
    {
        private readonly ctrlz.Data.MyDbContext _context;

        public DeleteModel(
        MyDbContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Employee = await _context.Employees.FirstOrDefaultAsync(
                                             m => m.Id == id);
            if (id == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                User, Employee,
                                                ContactOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var employee = await Context
                .Employees.AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, employee,
                                                     ContactOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            Context.Employees.Remove(employee);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
