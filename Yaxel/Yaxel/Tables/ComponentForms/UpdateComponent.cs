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

namespace Yaxel.Tables.ComponentForms
{
    public partial class UpdateComponent : Form
    {
        private int componentId;
        List<Classes.Attribute> attributes = new List<Classes.Attribute>();

        public UpdateComponent(int id)
        {
            InitializeComponent();

            componentId = id;
        }

        private void UpdateComponent_Load(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                Classes.Component component = context.Components.Include(c => c.Computers).Include(c => c.Attributes).ToList().Find(c => c.Id == componentId);

                textBox1.Text = component.Model;

                comboBoxTypeComponent.DataSource = new BindingSource(EnumTranslator.DescriptionAttributes<ComponentType>.RetrieveAttributes(), null);
                comboBoxTypeComponent.DisplayMember = "Key";
                comboBoxTypeComponent.ValueMember = "Value";

                comboBoxTypeComponent.SelectedIndex = (int)component.ComponentType;

                comboBoxManufacturer.DataSource = context.Manufacturers.ToList();
                comboBoxManufacturer.DisplayMember = "Name";
                comboBoxManufacturer.ValueMember = "Id";

                comboBoxManufacturer.SelectedValue = component.ManufacturerId;

                attributeTypeComboBox.DataSource = new BindingSource(EnumTranslator.DescriptionAttributes<AttrType>.RetrieveAttributes(), null);
                attributeTypeComboBox.DisplayMember = "Key";
                attributeTypeComboBox.ValueMember = "Value";

                // Атрибуты

                dataGridView1.Columns.Add("Type", "Тип");
                dataGridView1.Columns.Add("Value", "Значение");

                dataGridView1.Columns[0].Width = 179;
                dataGridView1.Columns[1].Width = 178;
                dataGridView1.RowTemplate.Height = 28;

                foreach (Classes.Attribute a in component.Attributes)
                {
                    dataGridView1.Rows.Add(a.AttrTypeTranslation, a.Name);
                }

                attributes.AddRange(component.Attributes);

                // Компьютеры

                DataGridViewImageCell PeripheryImageCell = new DataGridViewImageCell();
                PeripheryImageCell.Value = new Bitmap(25, 25);
                Graphics.FromImage((Image)PeripheryImageCell.Value).DrawImage(Image.FromFile("../../Resources/Periphery.png"), new Rectangle(0, 0, 25, 25));

                List<Computer> computers = context.Computers.Include(c => c.Employee).ToList();

                dataGridView2.Columns.Add(new DataGridViewCheckBoxColumn());
                dataGridView2.Columns.Add("Id", "Id");
                dataGridView2.Columns.Add("Name", "Имя компьютера");
                dataGridView2.Columns.Add("Status", "Статус");
                dataGridView2.Columns.Add("Employee", "Сотрудник");
                dataGridView2.Columns.Add(new DataGridViewImageColumn());

                dataGridView2.Columns[0].Width = 25;
                dataGridView2.Columns[1].Width = 50;
                dataGridView2.Columns[2].Width = 91;
                dataGridView2.Columns[3].Width = 91;
                dataGridView2.Columns[4].Width = 90;
                dataGridView2.Columns[5].Width = 50;
                dataGridView2.RowTemplate.Height = 28; // 440 43

                foreach (Computer c in computers)
                {
                    dataGridView2.Rows.Add(component.Computers.Contains(c), c.Id, c.Name, c.CompStatus, c.Employee.Name, PeripheryImageCell.Value);
                }
            }
        }

        private void addAttributeButton_Click(object sender, EventArgs e)
        {
            attributes.Add(new Classes.Attribute
            {
                AttrType = (AttrType)Enum.Parse(typeof(AttrType), (string)attributeTypeComboBox.SelectedValue),
                Name = attributeValueTextBox.Text,
                ComponentId = 0
            });

            Classes.Attribute a = attributes.LastOrDefault();
            dataGridView1.Rows.Add(a.AttrTypeTranslation, a.Name);

            attributeTypeComboBox.SelectedIndex = 0;
            attributeValueTextBox.Text = "";
        }

        private void deleteAttributeButton_Click(object sender, EventArgs e)
        {
            List<int> delIndex = new List<int>();

            dataGridView1.EndEdit();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                    delIndex.Add(row.Index);
                }
            }
            delIndex.Reverse();
            foreach (int i in delIndex)
            {
                attributes.RemoveAt(i);
                dataGridView1.Rows.RemoveAt(i);
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                Classes.Component component = context.Components.Include(c => c.Computers).Include(c => c.Attributes).ToList().Find(c => c.Id == componentId);

                component.Model = textBox1.Text;
                component.ComponentType = (ComponentType)Enum.Parse(typeof(ComponentType), (string)comboBoxTypeComponent.SelectedValue);
                component.ManufacturerId = (int)comboBoxManufacturer.SelectedValue;

                dataGridView2.EndEdit();
                component.Computers.Clear();
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        component.Computers.Add(context.Computers.ToList().Find(c => c.Id == (int)row.Cells[1].Value));
                    }
                }

                context.SaveChanges();             
            }

            //using (var context = new YaxelContext())
            //{
            //    List<Classes.Attribute> currentAttributes = context.Attributes.Where(a => a.ComponentId == componentId).ToList();
            //    context.Attributes.RemoveRange(currentAttributes);

            //    foreach (var at in attributes)
            //    {
            //        at.ComponentId = componentId;
            //    }

            //    context.Attributes.AddRange(attributes);
            //    context.SaveChanges();
            //}
            Close();
        }
    }
}
