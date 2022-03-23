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
    public partial class Authorization : Form
    {
        //public static Form[] forms = {
        //        null,
        //        new MainMenu()
        //    };

        private static Authorization inst;
        public static Authorization GetForm
        {
            get
            {
                if (inst == null || inst.IsDisposed)
                    inst = new Authorization();
                return inst;
            }
        }

        string login, password;

        public Authorization()
        {
            InitializeComponent();
        }

        private void Authorization_Load(object sender, EventArgs e)
        {
            //forms[0] = this;

            using (var context = new YaxelContext())
            {
                if (!context.Employees.Any(em => em.Login == "admin" && em.Password == ""))
                {
                    Employee employee = new Employee();
                    employee.Name = "admin";
                    employee.Login = "admin";
                    employee.Password = "";
                    employee.Position = Position.Sysadmin;

                    context.Employees.Add(employee);
                    context.SaveChanges();
                }
            }

        }

        private void enterButton_Click(object sender, EventArgs e)
        {            
            login = loginBox.Text;
            password = passwordBox.Text;

            using (var context = new YaxelContext())
            {
                if (context.Employees.Any(em => em.Login == login && em.Password == password && em.Position == Position.Sysadmin))
                {
                    //forms[1].Visible = true;
                    //forms[0].Visible = false;
                    MessageBox.Show("Nurgun conflictniy");
                    Authorization.GetForm.Hide();
                    MainMenu.GetForm.ShowDialog();
                    Authorization.GetForm.Show();
                    MessageBox.Show("Hello Wordl!");
                }
                else
                {
                    errorLabel.Visible = true;
                }
            }
        }

        private void loginBox_Enter(object sender, EventArgs e)
        {
            if (errorLabel.Visible)
                errorLabel.Visible = false;
        }

        private void passwordBox_Enter(object sender, EventArgs e)
        {
            if (errorLabel.Visible)
                errorLabel.Visible = false;
        }
    }
}
