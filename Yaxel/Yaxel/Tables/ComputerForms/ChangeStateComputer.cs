using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using Yaxel.Classes;

namespace Yaxel.Tables.ComputerForms
{
    public partial class ChangeStateComputer : Form
    {
        int computerId;
        public ChangeStateComputer(int id)
        {
            InitializeComponent();
            computerId = id;
        }

        private void ChangeStateComputer_Load(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                Computer computer = context.Computers.Include(c => c.Components).Include(c => c.Employee).ToList().Find(c => c.Id == computerId);
                comboBoxStatus.DataSource = new BindingSource(EnumTranslator.DescriptionAttributes<Status>.RetrieveAttributes(), null);
                comboBoxStatus.DisplayMember = "Key";
                comboBoxStatus.ValueMember = "Value";

                comboBoxStatus.SelectedIndex = (int)computer.Status;

                textBoxReason.Text = computer.ReasonRepair;

                dateTimePicker1.Value = computer.RepairTime == null ? DateTime.Today : (DateTime)computer.RepairTime;
            }
        }

        private void yaxelButton1_Click(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                Computer computer = context.Computers.Include(c => c.Components).Include(c => c.Employee).ToList().Find(c => c.Id == computerId);
                
                computer.Status = (Status)Enum.Parse(typeof(Status), (string)comboBoxStatus.SelectedValue);
                computer.ReasonRepair = textBoxReason.Text;
                computer.RepairTime = dateTimePicker1.Value;

                context.SaveChanges();
            }

            Close();
        }
    }
}
