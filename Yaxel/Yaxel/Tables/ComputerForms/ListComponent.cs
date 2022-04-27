using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yaxel.Tables.ComputerForms
{
    public partial class ListComponent : Form
    {
        public ListComponent()
        {
            InitializeComponent();
        }

        private void ListComponent_Load(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                //dataGridView1.DataSource = context.Components.Where(c => c.Id == c);
            }
        }
    }
}
