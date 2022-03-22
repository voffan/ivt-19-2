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

namespace Yaxel
{
    public partial class ListComputers : Form
    {
        private static ListComputers init;
        public static ListComputers GetForm
        {
            get
            {
                if (init == null || init.IsDisposed)
                    init = new ListComputers();
                return init;
            }
        }

        public ListComputers()
        {
            InitializeComponent();
        }

        private void ListComputers_Load(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                dataGridView1.DataSource = context.Computers.ToList();
            }

            //dataGridView1.Columns.AddRange(new DataGridViewColumn[] { new DataGridViewButtonColumn() });
        }
    }
}
