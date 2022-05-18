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

namespace Yaxel.Tables.Lists
{
    public partial class ComponentList : Form
    {
        private int computerId;
        public ComponentList(int id)
        {
            InitializeComponent();

            computerId = id;
        }

        private void ComponentList_Load(object sender, EventArgs e)
        {
            DataGridViewImageCell detailImageCell = new DataGridViewImageCell();
            detailImageCell.Value = new Bitmap(25, 25);
            Graphics.FromImage((Image)detailImageCell.Value).DrawImage(Image.FromFile("../../Resources/Detail_Icon.png"), new Rectangle(0, 0, 25, 25));

            using (var context = new YaxelContext())
            {
                Computer computer = context.Computers.Include(c => c.Components.Select(x => x.Manufacturer)).ToList().Find(c => c.Id == computerId);
                List<Classes.Component> components = computer.Components.ToList();

                dataGridView1.Columns.Add("Id", "Id");
                dataGridView1.Columns.Add("Model", "Модель");
                dataGridView1.Columns.Add("ComponentType", "Тип компонента");
                dataGridView1.Columns.Add("Manufacturer", "Производитель");
                dataGridView1.Columns.Add(new DataGridViewImageColumn());

                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = 186;
                dataGridView1.Columns[2].Width = 186;
                dataGridView1.Columns[3].Width = 185;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.RowTemplate.Height = 28; // 800 43

                foreach (Classes.Component c in components)
                {
                    dataGridView1.Rows.Add(c.Id, c.Model, c.ComponentTypeTranslation, c.Manufacturer.Name, detailImageCell.Value);
                }
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.ColumnIndex == 4 && e.RowIndex > -1)
            {
                AttributeList form = new AttributeList((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                form.ShowDialog();
            }
        }
    }
}
