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
            using (var context = new YaxelContext())
            {
                //dataGridView1.DataSource = context.Components.;
                Computer c = context.Computers.Include("Components").Where(item=>item.Id == id).FirstOrDefault();
                dataGridView1.DataSource = c.Components.ToList();
            }
        }
    }
}
