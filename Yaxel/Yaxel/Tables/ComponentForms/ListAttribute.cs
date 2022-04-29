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

namespace Yaxel.Tables.ComponentForms
{
    public partial class ListAttribute : Form
    {
        int id;
        public ListAttribute(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void ListAttribute_Load(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                dataGridView1.DataSource = context.Attributes.Include(a => a.Component).Where(c => c.ComponentId == id).ToList();
            }
        }
    }
}
