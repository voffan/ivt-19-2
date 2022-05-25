using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ctrlz.Classes;
using ctrlz.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ctrls.Authorization;

namespace ctrlz.Pages.Employees
{
    public class EditModel : DI_BasePageModel
    {
        private readonly ctrlz.Data.MyDbContext _context;

        public EditModel(
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
                                                      ContactOperations.Update); ;
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Fetch Contact from DB to get OwnerID.
            var employee = await _context
                .Employees.AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, employee,
                                                     ContactOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            Employee.OwnerID = employee.OwnerID;

            Context.Attach(Employee).State = EntityState.Modified;

            if (Employee.Position == Position.Administrator)
            {
                // If the contact is updated after approval, 
                // and the user cannot approve,
                // set the status back to submitted so the update can be
                // checked and approved.
                var canApprove = await AuthorizationService.AuthorizeAsync(User,
                                        Employee,
                                        ContactOperations.Approve);

                if (!canApprove.Succeeded)
                {
                    Employee.Position = Position.Handyman;
                }
            }

            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
