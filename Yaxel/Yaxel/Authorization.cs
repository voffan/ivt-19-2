using System;
using System.Linq;
using System.Windows.Forms;
using Yaxel.Classes;

namespace Yaxel
{
    public partial class Authorization : Form
    {
        //private static Authorization inst;
        //public static Authorization GetForm
        //{
        //    get
        //    {
        //        if (inst == null || inst.IsDisposed)
        //            inst = new Authorization();
        //        return inst;
        //    }
        //}

        string login, password;

        public Authorization()
        {
            InitializeComponent();
        }

        private void Authorization_Load(object sender, EventArgs e)
        {
            this.KeyUp += Authorization_KeyUp;

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

                if (context.Manufacturers.ToList().Count == 0)
                {
                    Manufacturer manufacturer = new Manufacturer();
                    manufacturer.Name = "Baikal";

                    context.Manufacturers.Add(manufacturer);
                    context.SaveChanges();
                }
            }

        }

        private void Authorization_KeyUp(object sender, KeyEventArgs e)
        {
            MessageBox.Show("asd");
            if (e.KeyCode == Keys.Enter) enterButton_Click(sender, e);
        }

        private void enterButton_Click(object sender, EventArgs e)
        {            
            login = loginBox.Text;
            password = passwordBox.Text;

            using (var context = new YaxelContext())
            {
                if (context.Employees.Any(em => em.Login == login && em.Password == password && em.Position == Position.Sysadmin))
                {
                    //Authorization.GetForm.Hide();
                    //MultiList.GetForm.ShowDialog();
                    //Authorization.GetForm.Show();
                    MultiList multiList = new MultiList();
                    Hide();
                    multiList.ShowDialog();
                    Show();
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
