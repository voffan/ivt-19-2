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
    public partial class ComputerList : Form
    {
        private int parentId;
        private int whatIsParent;

        public ComputerList(int id, int whatIsParent)
        {
            InitializeComponent();

            parentId = id;
            this.whatIsParent = whatIsParent;
        }

        private void ComputerList_Load(object sender, EventArgs e)
        {
            DataGridViewImageCell componentImageCell = new DataGridViewImageCell();
            DataGridViewImageCell PeripheryImageCell = new DataGridViewImageCell();

            componentImageCell.Value = new Bitmap(25, 25);
            PeripheryImageCell.Value = new Bitmap(25, 25);

            Graphics.FromImage((Image)componentImageCell.Value).DrawImage(Image.FromFile("../../Resources/Component.png"), new Rectangle(0, 0, 25, 25));
            Graphics.FromImage((Image)PeripheryImageCell.Value).DrawImage(Image.FromFile("../../Resources/Periphery.png"), new Rectangle(0, 0, 25, 25));

            using (var context = new YaxelContext())
            {
                List<Computer> computers = new List<Computer>();

                if (whatIsParent == 1)
                {
                    Classes.Component component = context.Components.Include(c => c.Computers.Select(x => x.Employee)).ToList().Find(c => c.Id == parentId);
                    computers = component.Computers.ToList();
                } 
                else if (whatIsParent == 2)
                {
                    Periphery periphery = context.Peripheries.Include(p => p.Computers.Select(x => x.Employee)).ToList().Find(p => p.Id == parentId);
                    computers = periphery.Computers.ToList();
                }

                dataGridView1.Columns.Add("Id", "Id");
                dataGridView1.Columns.Add("Name", "Имя компьютера");
                dataGridView1.Columns.Add("Status", "Статус");
                dataGridView1.Columns.Add("Employee", "Сотрудник");
                dataGridView1.Columns.Add(new DataGridViewImageColumn()); // 800 43 185 100*2

                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = 186;
                dataGridView1.Columns[2].Width = 186;
                dataGridView1.Columns[3].Width = 185;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.RowTemplate.Height = 28;

                foreach (Computer c in computers)
                {
                    dataGridView1.Rows.Add(c.Id, c.Name, c.CompStatus, c.Employee.Name,
                        whatIsParent == 1 ? PeripheryImageCell.Value : componentImageCell.Value);
                }
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.ColumnIndex == 4 && e.RowIndex > -1)
            {
                if (whatIsParent == 2)
                {
                    ComponentList form = new ComponentList((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    form.ShowDialog();
                } if (whatIsParent == 1)
                {
                    PeripheryList form = new PeripheryList((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    form.ShowDialog();
                }
            }
        }
    }
}
