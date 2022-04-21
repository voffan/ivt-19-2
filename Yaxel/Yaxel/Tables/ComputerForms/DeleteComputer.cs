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
    public partial class DeleteComputer : Form
    {
        List<int> selectedRowsId;

        public DeleteComputer(List<int> delItems)
        {
            InitializeComponent();

            selectedRowsId = delItems;
        }

        private void DeleteComputer_Load(object sender, EventArgs e)
        {

        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                List<Classes.Computer> computers = new List<Classes.Computer>();

                foreach (var item in selectedRowsId)
                {
                    computers.Add(context.Computers.Where(c => c.Id == item).ToList().ElementAt(0));
                }

                context.Computers.RemoveRange(computers);
                context.SaveChanges();
            }

            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
