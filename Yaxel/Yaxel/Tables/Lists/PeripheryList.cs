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
    public partial class PeripheryList : Form
    {
        private int computerId;

        public PeripheryList(int id)
        {
            InitializeComponent();

            computerId = id;
        }

        private void PeripheryList_Load(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                Computer computer = context.Computers.Include(c => c.Peripheries.Select(x => x.Manufacturer)).ToList().Find(c => c.Id == computerId);
                List<Periphery> peripheries = computer.Peripheries.ToList();

                dataGridView1.Columns.Add("Id", "Id");
                dataGridView1.Columns.Add("Model", "Модель");
                dataGridView1.Columns.Add("PeripheryType", "Тип");
                dataGridView1.Columns.Add("Status", "Статус");
                dataGridView1.Columns.Add("Manufacturer", "Производитель"); // 800 43

                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = 165;
                dataGridView1.Columns[2].Width = 164;
                dataGridView1.Columns[3].Width = 164;
                dataGridView1.Columns[4].Width = 164;
                dataGridView1.RowTemplate.Height = 28;

                foreach (Periphery p in peripheries)
                {
                    dataGridView1.Rows.Add(p.Id, p.Model, p.TranslationType, p.PeripheryStatus, p.Manufacturer.Name);
                }
            }
        }
    }
}
