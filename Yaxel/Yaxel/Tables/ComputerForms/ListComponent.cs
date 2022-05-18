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

namespace Yaxel.Tables.ComputerForms
{
    public partial class ListComponent : Form
    {
        int id;
        public ListComponent(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void ListComponent_Load(object sender, EventArgs e)
        {
            DataGridViewImageCell detailImageCell = new DataGridViewImageCell();
            detailImageCell.Value = new Bitmap(25, 25);
            Graphics.FromImage((Image)detailImageCell.Value).DrawImage(Image.FromFile("../../Resources/Detail_Icon.png"), new Rectangle(0, 0, 25, 25));

            using (var context = new YaxelContext())
            {
                Computer computer = context.Computers.Include(c => c.Components.Select(x => x.Manufacturer)).ToList().Find(c => c.Id == id);
                List<Classes.Component> components = computer.Components.ToList();

                dataGridView1.Columns.Add("Id", "Id");
                dataGridView1.Columns.Add("Model", "Модель");
                dataGridView1.Columns.Add("ComponentType", "Тип компонента");
                dataGridView1.Columns.Add("Manufacturer", "Производитель");
                dataGridView1.Columns.Add(new DataGridViewImageColumn());
                dataGridView1.Columns.Add(new DataGridViewImageColumn());

                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 206;
                dataGridView1.Columns[2].Width = 206;
                dataGridView1.Columns[3].Width = 205;
                dataGridView1.Columns[4].Width = 50;
                dataGridView1.Columns[5].Width = 50; //810 43
                dataGridView1.RowTemplate.Height = 28;

                foreach (Classes.Component c in components)
                {
                    dataGridView1.Rows.Add(c.Id, c.Model, c.ComponentTypeTranslation, c.Manufacturer.Name, detailImageCell.Value, detailImageCell.Value);
                }
            }
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.ColumnIndex == 4 && e.RowIndex > -1)
                {
                    ListComputer form = new ListComputer((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value, 1);
                    form.ShowDialog();
                }

                if (e.ColumnIndex == 5 && e.RowIndex > -1)
                {
                    ListAttribute form = new ListAttribute((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    form.ShowDialog();
                }
            }
        }
    }
}
