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
    public partial class ListAttribute : Form
    {
        int id;
        public ListAttribute(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void ListAttribute_Load(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                List<Classes.Attribute> attributes = context.Attributes.Include(a => a.Component).Where(c => c.ComponentId == id).ToList();

                dataGridView1.Columns.Add("Id", "Id");
                dataGridView1.Columns.Add("AttrType", "Тип атрибута");
                dataGridView1.Columns.Add("Value", "Значение");
                dataGridView1.Columns.Add("Model", "Модель компонента");

                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 120;
                dataGridView1.Columns[2].Width = 80;
                dataGridView1.Columns[3].Width = 147;
                dataGridView1.RowTemplate.Height = 28;

                foreach (Classes.Attribute a in attributes)
                {
                    dataGridView1.Rows.Add(a.Id, a.AttrTypeTranslation, a.Name, a.Component.Model);
                }
            }
        }
    }
}
