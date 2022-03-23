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
    public partial class ListComponent : Form
    {
        private static ListComponent init;
        public static ListComponent GetForm
        {
            get
            {
                if (init == null || init.IsDisposed)
                    init = new ListComponent();
                return init;
            }
        }

        public ListComponent()
        {
            InitializeComponent();
        }

        private void ListComponent_Load(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                grid.DataSource = context.Computers.ToList();
            }
        }
    }
}
