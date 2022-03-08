using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yaxel.Classes;

namespace Yaxel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            using (var context = new YaxelContext())
            {
                var employee = new Employee();
                {
                    employee.Name = "Monastyrev Nurgun";
                    employee.Login = "ZeMonast";
                    employee.Password = "qwerty";
                    employee.Position = Position.Sysadmin;
                }

                context.Employees.Add(employee);
                context.SaveChanges();

                label1.Text = $"Id: {employee.Id}, Name: {employee.Name}";
            }
        }
    }
}
