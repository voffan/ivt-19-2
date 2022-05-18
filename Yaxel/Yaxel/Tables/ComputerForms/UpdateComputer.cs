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
using Yaxel.Tables.ComponentForms;
using Yaxel.Tables.Lists;

namespace Yaxel.Tables.ComputerForms
{
    public partial class UpdateComputer : Form
    {
        private int compId;

        public UpdateComputer(int compId)
        {
            InitializeComponent();

            this.compId = compId;
        }


        private void UpdateComputer_Load(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                Computer computer = context.Computers.Include(c => c.Components).Include(c => c.Employee).ToList().Find(c => c.Id == compId);
                textBoxName.Text = computer.Name;

                comboBoxStatus.DataSource = new BindingSource(EnumTranslator.DescriptionAttributes<Status>.RetrieveAttributes(), null);
                comboBoxStatus.DisplayMember = "Key";
                comboBoxStatus.ValueMember = "Value";

                comboBoxStatus.SelectedIndex = (int)computer.Status;

                comboBoxEmployee.DataSource = context.Employees.ToList();
                comboBoxEmployee.DisplayMember = "Name";
                comboBoxEmployee.ValueMember = "Id";

                comboBoxEmployee.SelectedValue = computer.EmployeeId;

                // настройка dgv
                DataGridViewImageCell detailImageCell = new DataGridViewImageCell();
                detailImageCell.Value = new Bitmap(25, 25);
                Graphics.FromImage((Image)detailImageCell.Value).DrawImage(Image.FromFile("../../Resources/Detail_Icon.png"), new Rectangle(0, 0, 25, 25));

                dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn());
                dataGridView1.Columns.Add("Id", "Id");
                dataGridView1.Columns.Add("Model", "Модель");
                dataGridView1.Columns.Add("ComponentType", "Тип компонента");
                dataGridView1.Columns.Add(new DataGridViewImageColumn());

                dataGridView1.Columns[0].Width = 28;
                dataGridView1.Columns[1].Width = 100;
                dataGridView1.Columns[2].Width = 141;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 28;
                dataGridView1.RowTemplate.Height = 28;

                foreach (Classes.Component c in context.Components.ToList())
                {
                    if (computer.Components.ToList().Contains(c))
                        dataGridView1.Rows.Add(true, c.Id, c.Model, c.ComponentType, detailImageCell.Value);
                    else
                        dataGridView1.Rows.Add(false, c.Id, c.Model, c.ComponentType, detailImageCell.Value);
                }
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {            
            using (var context = new YaxelContext())
            {
                Computer computer = context.Computers.Include(c => c.Components).ToList().Find(c => c.Id == compId);

                computer.Name = textBoxName.Text;
                computer.Status = (Status)Enum.Parse(typeof(Status), (string)comboBoxStatus.SelectedValue);
                computer.EmployeeId = (int)comboBoxEmployee.SelectedValue;

                dataGridView1.EndEdit();
                computer.Components.Clear();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        computer.Components.Add(context.Components.ToList().Find(c => c.Id == (int)row.Cells[1].Value));
                    }
                }
                    
                context.SaveChanges();
            }

            Close();
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && (e.ColumnIndex == 4 && e.RowIndex > -1))
            {
                AttributeList listAttributeForm = new AttributeList((int)dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                listAttributeForm.ShowDialog();
            }
        }
    }
}
