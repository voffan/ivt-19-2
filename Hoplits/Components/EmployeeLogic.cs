using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoplits.Classes;
using Hoplits.Cs;

namespace Hoplits.Components
{
    internal static class EmployeeLogic
    {
        public static Employee Login(string login, string pwd)
        {
            using (ApplicationContext c = new ApplicationContext())
            {
                Employee empl = c.Employees.Where(e => e.Login == login).FirstOrDefault();
                if (empl != null && empl.Password.CompareTo(pwd)!=0)
                {
                    return null;
                }
                return empl;
            }
        }
    }
}
