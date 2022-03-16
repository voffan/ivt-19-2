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
        object obj;

        public Form1()
        {
            InitializeComponent();

            //using (var context = new YaxelContext())
            //{
            //    var employee = new Employee();
            //    {
            //        employee.Name = "Monastyrev Nurgun";
            //        employee.Login = "ZeMonast";
            //        employee.Password = "qwerty";
            //        employee.Position = Position.Sysadmin;
            //    }

            //    context.Employees.Add(employee);
            //    context.SaveChanges();

            //    dataGridView1.Rows.Add(context.Employees.ToList());
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                dataGridView1.DataSource = context.Employees.ToList();
                obj = new Employee();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                dataGridView1.DataSource = context.Computers.ToList();
                obj = new Computer();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                dataGridView1.DataSource = context.Peripheries.ToList();
                obj = new Periphery();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                dataGridView1.DataSource = context.Components.ToList();
                obj = new Classes.Component();
            }
        }

        private void newNoteButton_Click(object sender, EventArgs e)
        {
            AddEm addEm = new AddEm();
            addEm.ShowDialog();
        }
    }
}
