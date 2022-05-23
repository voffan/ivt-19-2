using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using Yaxel.Classes;

namespace Yaxel.Tables.ManufacturerForms
{
    public partial class UpdateManufacturer : Form
    {
        int manufId;
        public UpdateManufacturer(int id)
        {
            InitializeComponent();

            manufId = id;
        }

        private void UpdateManufacturer_Load(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                Manufacturer manufacturer = context.Manufacturers.ToList().Find(c => c.Id == manufId);

                textBoxName.Text = manufacturer.Name;
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                Manufacturer manufacturer = context.Manufacturers.ToList().Find(c => c.Id == manufId);

                manufacturer.Name = textBoxName.Text;

                context.SaveChanges();
            }

            Close();
        }
    }
}
