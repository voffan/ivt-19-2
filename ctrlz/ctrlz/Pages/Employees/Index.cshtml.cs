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
    public class IndexModel : DI_BasePageModel
    {
        private readonly ctrlz.Data.MyDbContext _context;

        public IndexModel(
        MyDbContext context,
        IAuthorizationService authorizationService,
        UserManager<IdentityUser> userManager)
        : base(context, authorizationService, userManager)
        {
        }

        public IList<Employee> Employee { get;set; }

        public async Task OnGetAsync()
        {
            var employees = from c in _context.Employees
                           select c;

            var isAuthorized = User.IsInRole(Constants.ContactManagersRole) ||
                               User.IsInRole(Constants.ContactAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);

            // Only approved contacts are shown UNLESS you're authorized to see them
            // or you are the owner.
            if (!isAuthorized)
            {
                employees = employees.Where(c => c.Position == Position.Administrator
                                            || c.OwnerID == currentUserId);
            }

            Employee = await employees.ToListAsync();
        }
    }
}

