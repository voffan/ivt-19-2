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

namespace Yaxel.Tables.ComponentForms
{
    public partial class UpdateComponent : Form
    {
        //private int compId;

        public UpdateComponent(int compId)
        {
            InitializeComponent();

            //this.compId = compId;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            //using (var context = new YaxelContext())
            //{
            //    Component component = context.Components.Where(c => c.Id == compId).ToList().First();

            //    component.Name = textBoxName.Text;


            //    context.SaveChanges();
            //}

            Close();
        }

        private void UpdateComponent_Load(object sender, EventArgs e)
        {

        }

        private void selectComputersButton_Click(object sender, EventArgs e)
        {

        }

        private void applyButton_Click_1(object sender, EventArgs e)
        {

        }
    }
}
