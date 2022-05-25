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

namespace Yaxel.Tables.ComputerForms
{
    public partial class SearchComputer : Form
    {
        internal List<Computer> resultComputer { get; set; }
        
        public SearchComputer()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            resultComputer = new List<Computer>();

            using (var context = new YaxelContext())
            {
                var q = context.Computers.Include(c => c.Employee)
                    .Where(x => x.Name == PCNameTextBox.Text)
                    .ToList();

                resultComputer.AddRange(q);

                MessageBox.Show("Найдено " + q.Count + " строк");
            }
            Hide();
        }

        private void SearchComputer_Load(object sender, EventArgs e)
        {

        }
    }
}
