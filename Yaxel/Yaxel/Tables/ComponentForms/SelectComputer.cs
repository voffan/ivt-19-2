using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows.Forms;
using Yaxel.Classes;

namespace Yaxel.Tables.ComponentForms
{
    public partial class SelectComputer : Form
    {
        AddComponent parentForm;
        List<int> selectComputersId = new List<int>();
        public SelectComputer(AddComponent f)
        {
            InitializeComponent();
            parentForm = f;
        }

        private void SelectComputer_Load(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                List<Computer> computersList = context.Computers.Include(em => em.Employee).ToList();

                dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn());
                dataGridView1.Columns.Add("Id", "Id");
                dataGridView1.Columns.Add("Name", "Имя компьютера");
                dataGridView1.Columns.Add("Status", "Статус");
                dataGridView1.Columns.Add("Employee", "Сотрудник");

                dataGridView1.Columns[1].Width = 25;
                dataGridView1.RowTemplate.Height = 28;

                foreach (Computer c in computersList)
                {
                    dataGridView1.Rows.Add(null, c.Id, c.Name, c.CompStatus, c.Employee.Name);
                }
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow i in dataGridView1.Rows)
            {
                if (i.Cells[0].Selected)
                    selectComputersId.Add((int)i.Cells[1].Value);
            }

            parentForm.selectedComputersId = this.selectComputersId;
            Close();
        }
    }
}
