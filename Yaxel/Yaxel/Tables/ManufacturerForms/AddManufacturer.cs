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
    public partial class AddManufacturer : Form
    {
        public AddManufacturer()
        {
            InitializeComponent();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                Manufacturer manufacturer = new Manufacturer();
                manufacturer.Name = textBoxName.Text;
                context.Manufacturers.Add(manufacturer);
                context.SaveChanges();
                Close();
            }
        }
    }
}
