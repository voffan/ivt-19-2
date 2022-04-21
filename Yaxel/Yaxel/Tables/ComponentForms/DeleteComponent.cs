using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yaxel.Tables.ComponentForms
{
    public partial class DeleteComponent : Form
    {
        List<int> selectedRowsId;

        public DeleteComponent(List<int> delItems)
        {
            InitializeComponent();

            selectedRowsId = delItems;
        }

        private void DeleteComponent_Load(object sender, EventArgs e)
        {

        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                List<Classes.Component> component = new List<Classes.Component>();

                foreach (var item in selectedRowsId)
                {
                    component.Add(context.Components.Where(c => c.Id == item).ToList().ElementAt(0));
                }

                context.Components.RemoveRange(component);
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
