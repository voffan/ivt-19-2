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

namespace Yaxel.Tables.ComponentForms
{
    public partial class AddComponent : Form
    {
        public List<int> selectedComputersId = new List<int>();
        List <Classes.Attribute> attributes = new List <Classes.Attribute> ();

        public AddComponent()
        {
            InitializeComponent();
        }

        private void AddComponent_Load(object sender, EventArgs e)
        {
            SetDoubleBuffered(dataGridView1);

            comboBox2.DataSource = new BindingSource(EnumTranslator.DescriptionAttributes<ComponentType>.RetrieveAttributes(), null);
            comboBox2.DisplayMember = "Key";
            comboBox2.ValueMember = "Value";

            using (var context = new YaxelContext())
            {
                // Вывод список сотрудников в comboBox
                comboBox1.DataSource = context.Manufacturers.ToList();
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";

                attributeTypeComboBox.DataSource = new BindingSource(EnumTranslator.DescriptionAttributes<AttrType>.RetrieveAttributes(), null);
                attributeTypeComboBox.DisplayMember = "Key";
                attributeTypeComboBox.ValueMember = "Value";

                dataGridView1.DataSource = attributes;
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                Classes.Component component = new Classes.Component();
                component.Model = textBox1.Text;
                component.ComponentType = (ComponentType)Enum.Parse(typeof(ComponentType), (string)comboBox2.SelectedValue);

                component.ManufacturerId = (int)comboBox1.SelectedValue;
                component.Computers.AddRange(context.Computers.Where(c => selectedComputersId.Contains(c.Id)));

                context.Components.Add(component);
                context.SaveChanges();

                foreach (var at in attributes)
                {
                    at.ComponentId = component.Id;
                }

                context.Attributes.AddRange(attributes);
                context.SaveChanges();

                Close();
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

            dataGridView1.DataSource = attributes.ToList();

            attributeTypeComboBox.SelectedIndex = 0;
            attributeValueTextBox.Text = "";
        }


        private void deleteAttributeButton_Click(object sender, EventArgs e)
        {
            List<int> delIndex = new List<int> ();

            for (int i = attributes.Count - 1; i >= 0; i--)
            {
                if (dataGridView1.Rows[i].Selected)
                    delIndex.Add(i);
            }

            foreach (int i in delIndex) attributes.RemoveAt(i);

            dataGridView1.DataSource = attributes.ToList();
        }


        private void selectComputersButton_Click(object sender, EventArgs e)
        {
            SelectComputer selectComputer = new SelectComputer(this);
            selectComputer.ShowDialog();
        }

        private static void SetDoubleBuffered(Control c)
        {
            if (SystemInformation.TerminalServerSession)
                return;

            System.Reflection.PropertyInfo pDoubleBuffered =
                  typeof(Control).GetProperty(
                        "DoubleBuffered",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);

            pDoubleBuffered.SetValue(c, true, null);
        }
    }
}
