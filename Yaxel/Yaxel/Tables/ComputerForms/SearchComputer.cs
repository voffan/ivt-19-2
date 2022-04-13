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
    public partial class SearchComputer : Form
    {
        public SearchComputer()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            { 
                var q = context.Computers
                    .Where(x => x.Name == PCNameTextBox.Text)
                    .ToList();
            }


        }
    }
}
