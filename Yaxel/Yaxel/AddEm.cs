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
    public partial class AddEm : Form
    {
        public AddEm()
        {
            InitializeComponent();
        }

        string name, login, password;

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                var em = new Employee();
                em.Name = textBox1.Text;
                em.Login = textBox2.Text;
                em.Position = (Position)Enum.Parse(typeof(Position), (string)comboBox1.SelectedValue);
                em.Password = textBox3.Text;

                context.Employees.Add(em);
                context.SaveChanges();
            }
        }

        private void AddEm_Load(object sender, EventArgs e)
        {

            comboBox1.DataSource = new BindingSource(DescriptionAttributes<Position>.RetrieveAttributes(), null);
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";

        }
    }
}
