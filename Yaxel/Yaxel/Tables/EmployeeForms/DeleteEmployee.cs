using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yaxel.Tables.EmployeeForms
{
    public partial class DeleteEmployee : Form
    {
        List<int> selectedRowsId;
        public DeleteEmployee(List<int> delItems)
        {
            InitializeComponent();
            selectedRowsId = delItems;
        }

        private void DeleteEmployee_Load(object sender, EventArgs e)
        {

        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                List<Classes.Employee> employees = new List<Classes.Employee>();

                foreach (var item in selectedRowsId)
                {
                    employees.Add(context.Employees.Where(c => c.Id == item).ToList().ElementAt(0));
                }

                context.Employees.RemoveRange(employees);
                context.SaveChanges();
            }

            Close();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
