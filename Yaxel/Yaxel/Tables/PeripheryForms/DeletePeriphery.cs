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

namespace Yaxel.Tables.PeripheryForms
{
    public partial class DeletePeriphery : Form
    {
        List<int> selectedRowsId;

        public DeletePeriphery(List<int> delItems)
        {
            InitializeComponent();

            selectedRowsId = delItems;
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                List<Periphery> periphery = new List<Periphery>();

                foreach (var item in selectedRowsId)
                {
                    periphery.Add(context.Peripheries.Where(c => c.Id == item).ToList().ElementAt(0));
                }

                context.Peripheries.RemoveRange(periphery);
                context.SaveChanges();
            }

            Close();
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DeletePeriphery_Load(object sender, EventArgs e)
        {

        }
    }
}
