using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yaxel
{
    public partial class ListEmployee : Form
    {
        private static ListEmployee init;
        public static ListEmployee GetForm
        {
            get
            {
                if (init == null || init.IsDisposed)
                    init = new ListEmployee();
                return init;
            }
        }
        public ListEmployee()
        {
            InitializeComponent();
        }

        private void ListEmployee_Load(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                dataGridView1.DataSource = context.Employees.ToList();
            }
        }
    }
}
