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
using Yaxel.Tables.ComputerForms;

namespace Yaxel.Tables.ComponentForms
{
    public partial class ListComputer : Form
    {
        int id;
        private int num;
        public ListComputer(int id, int num)
        {
            InitializeComponent();
            this.id = id;
            this.num = num;
        }

        private void ListComputer_Load(object sender, EventArgs e)
        {
            DataGridViewImageCell detailImageCell = new DataGridViewImageCell();
            detailImageCell.Value = new Bitmap(25, 25);
            Graphics.FromImage((Image)detailImageCell.Value).DrawImage(Image.FromFile("../../Resources/Detail_Icon.png"), new Rectangle(0, 0, 25, 25));

            using (var context = new YaxelContext())
            {
                List<Computer> computers = context.Computers.ToList();
                if (num == 1)
                {
                    Classes.Component component = context.Components.Include(c => c.Computers.Select(x => x.Employee)).Where(item => item.Id == id).FirstOrDefault();
                    computers = component.Computers.ToList();
                }
                else if (num == 2)
                {
                    Periphery periphery = context.Peripheries.Include(c => c.Computers.Select(x => x.Employee)).Where(item => item.Id == id).FirstOrDefault();
                    computers = periphery.Computers.ToList();
                }
                //Classes.Component component = context.Components.Include(c => c.Computers.Select(x => x.Employee)).Where(item => item.Id == id).FirstOrDefault();
                //List<Computer> computers = component.Computers.ToList();

                dataGridView1.Columns.Add("Id", "Id");
                dataGridView1.Columns.Add("Name", "Имя компьютера");
                dataGridView1.Columns.Add("Status", "Статус");
                dataGridView1.Columns.Add("Employee", "Сотрудник");
                dataGridView1.Columns.Add(new DataGridViewImageColumn());

                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 200;
                dataGridView1.Columns[2].Width = 200;
                dataGridView1.Columns[3].Width = 200;
                dataGridView1.Columns[4].Width = 50; //743 43
                dataGridView1.RowTemplate.Height = 28;

                foreach (Computer c in computers)
                {
                    dataGridView1.Rows.Add(c.Id, c.Name, c.CompStatus, c.Employee.Name, detailImageCell.Value);
                }
            }
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.ColumnIndex == 4 && e.RowIndex > -1)
                {
                    ListComponent form = new ListComponent((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    form.ShowDialog();
                }
            }
        }
    }
}
