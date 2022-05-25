using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ctrlz.Classes;
using ctrlz.Data;
using ctrlz.Pages.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ctrls.Authorization;

namespace ctrlz.Pages.Employees
{
    public class CreateModel : DI_BasePageModel
    {
        private readonly ctrlz.Data.MyDbContext _context;

        public CreateModel(
          MyDbContext context,
          IAuthorizationService authorizationService,
          UserManager<IdentityUser> userManager)
          : base(context, authorizationService, userManager)
        {
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Employee.OwnerID = UserManager.GetUserId(User);

            // requires using ContactManager.Authorization;
            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                        User, Employee,
                                                        ContactOperations.Create);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
