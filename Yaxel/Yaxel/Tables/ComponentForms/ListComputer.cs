using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows.Forms;
using Yaxel.Classes;

namespace Yaxel.Tables.ComponentForms
{
    public partial class ListComputer : Form
    {
        int id;
        public ListComputer(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void ListComputer_Load(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                Classes.Component c = context.Components.Include(item => item.Computers).Where(item => item.Id == id).FirstOrDefault();
                dataGridView1.DataSource = c.Computers.ToList();
            }
        }
    }
}
