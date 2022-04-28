using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yaxel.Classes;

namespace Yaxel.Tables.ComputerForms
{
    public partial class SelectComponent : Form
    {
        AddComputer parentForm;
        List<int> selectComponentsId = new List<int>();
        public SelectComponent(AddComputer f)
        {
            InitializeComponent();
            parentForm = f;
        }

        private void SelectComponent_Load(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                List<Component> componentsList = context.Components.ToList();

                dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn());
                dataGridView1.Columns.Add("Id", "Id");
                dataGridView1.Columns.Add("Model", "Модель");
                dataGridView1.Columns.Add("ComponentType", "Тип компонента");

                dataGridView1.Columns[1].Width = 25;
                dataGridView1.RowTemplate.Height = 28;

                foreach (Component c in componentsList)
                {
                    dataGridView1.Rows.Add(null, c.Id, c.Model, c.ComponentType);
                }
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            foreach (DataGridViewRow i in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(i.Cells[0].Value))
                    selectComponentsId.Add((int)i.Cells[1].Value);
            }

            parentForm.selectedComponentsId = this.selectComponentsId;
            Close();
        }
    }
}
