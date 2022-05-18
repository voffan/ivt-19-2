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

namespace Yaxel.Tables.Lists
{
    public partial class AttributeList : Form
    {
        private int componentId;
        public AttributeList(int id)
        {
            InitializeComponent();

            componentId = id;
        }

        private void AttributeList_Load(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                Classes.Component component = context.Components.Include(c => c.Attributes).ToList().Find(c => c.Id == componentId);
                List<Classes.Attribute> attributes = component.Attributes.ToList();

                dataGridView1.Columns.Add("Id", "Id");
                dataGridView1.Columns.Add("AttrType", "Тип атрибута");
                dataGridView1.Columns.Add("Value", "Значение");

                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = 329;
                dataGridView1.Columns[2].Width = 328;
                dataGridView1.RowTemplate.Height = 28; // 800 43

                foreach (Classes.Attribute a in attributes)
                {
                    dataGridView1.Rows.Add(a.Id, a.AttrTypeTranslation, a.Name);
                }
            }
        }
    }
}
