using System;
using System.Windows.Forms;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Yaxel.Tables.Computer
{
    public partial class DeleteComputers : Form
    {
        List<int> selectedRowsId;

        public DeleteComputers(List<int> delItems)
        {
            InitializeComponent();

            selectedRowsId = delItems;
        }

        private void DeleteComputers_Load(object sender, EventArgs e)
        {

        }

        private void yesButton_Click(object sender, EventArgs e)
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

        private void noButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
