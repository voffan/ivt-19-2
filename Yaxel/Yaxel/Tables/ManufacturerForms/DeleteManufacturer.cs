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

namespace Yaxel.Tables.ManufacturerForms
{
    public partial class DeleteManufacturer : Form
    {
        List<int> selectedRowsId;

        public DeleteManufacturer(List<int> delItems)
        {
            InitializeComponent();

            selectedRowsId = delItems;
        }

        private void DeleteManufacturer_Load(object sender, EventArgs e)
        {

        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                List<Manufacturer> manufacturers = new List<Manufacturer>();

                foreach (var item in selectedRowsId)
                {
                    manufacturers.Add(context.Manufacturers.Where(m => m.Id == item).ToList().FirstOrDefault());
                }

                context.Manufacturers.RemoveRange(manufacturers);
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
