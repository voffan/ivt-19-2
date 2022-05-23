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
using Yaxel.Tables.Lists;

namespace Yaxel.Tables.PeripheryForms
{
    public partial class UpdatePeriphery : Form
    {
        private int peripheryId;

        public UpdatePeriphery(int id)
        {
            InitializeComponent();

            peripheryId = id;
        }

        private void UpdatePeriphery_Load(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                Periphery periphery = context.Peripheries.Include(p => p.Computers).ToList().Find(p => p.Id == peripheryId);

                textBoxModel.Text = periphery.Model;

                comboBoxType.DataSource = new BindingSource(EnumTranslator.DescriptionAttributes<PeripheryType>.RetrieveAttributes(), null);
                comboBoxType.DisplayMember = "Key";
                comboBoxType.ValueMember = "Value";

                comboBoxType.SelectedIndex = (int)periphery.PeripheryType;

                comboBoxStatus.DataSource = new BindingSource(EnumTranslator.DescriptionAttributes<Status>.RetrieveAttributes(), null);
                comboBoxStatus.DisplayMember = "Key";
                comboBoxStatus.ValueMember = "Value";

                comboBoxStatus.SelectedIndex = (int)periphery.Status;

                comboBoxManufacturer.DataSource = context.Manufacturers.ToList();
                comboBoxManufacturer.DisplayMember = "Name";
                comboBoxManufacturer.ValueMember = "Id";

                comboBoxManufacturer.SelectedValue = periphery.ManufacturerId;

                //dvg

                DataGridViewImageCell detailImageCell = new DataGridViewImageCell();
                detailImageCell.Value = new Bitmap(25, 25);
                Graphics.FromImage((Image)detailImageCell.Value).DrawImage(Image.FromFile("../../Resources/Component.png"), new Rectangle(0, 0, 25, 25));

                List<Computer> computersList = context.Computers.Include(c => c.Employee).ToList();

                dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn());
                dataGridView1.Columns.Add("Id", "Id");
                dataGridView1.Columns.Add("Name", "Имя компьютера");
                dataGridView1.Columns.Add("Status", "Статус");
                dataGridView1.Columns.Add("Employee", "Сотрудник");
                dataGridView1.Columns.Add(new DataGridViewImageColumn());

                dataGridView1.Columns[0].Width = 28;
                dataGridView1.Columns[1].Width = 28;
                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[3].Width = 80;
                dataGridView1.Columns[4].Width = 91;
                dataGridView1.Columns[5].Width = 50;
                dataGridView1.RowTemplate.Height = 28; // 440 43

                foreach (Computer c in computersList)
                {
                    dataGridView1.Rows.Add(periphery.Computers.Contains(c), c.Id, c.Name, c.CompStatus, c.Employee.Name, detailImageCell.Value);
                }
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                Periphery periphery = context.Peripheries.Include(p => p.Computers).ToList().Find(p => p.Id == peripheryId);

                periphery.Model = textBoxModel.Text;
                periphery.PeripheryType = (PeripheryType)Enum.Parse(typeof(PeripheryType), (string)comboBoxType.SelectedValue);
                periphery.Status = (Status)Enum.Parse(typeof(Status), (string)comboBoxStatus.SelectedValue);
                periphery.ManufacturerId = (int)comboBoxManufacturer.SelectedValue;

                dataGridView1.EndEdit();
                periphery.Computers.Clear();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        periphery.Computers.Add(context.Computers.ToList().Find(c => c.Id == (int)row.Cells[1].Value));
                    }
                }

                context.SaveChanges();                
            }

            Close();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && (e.ColumnIndex == 5 && e.RowIndex > -1))
            {
                ComponentList form = new ComponentList((int)dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                form.ShowDialog();
            }
        }
    }
}
