using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yaxel
{
    public partial class MainMenu : Form
    {
        private static MainMenu init;
        public static MainMenu GetForm
        {
            get
            {
                if (init == null || init.IsDisposed)
                    init = new MainMenu();
                return init;
            }
        }

        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void listEmployeesButton_Click(object sender, EventArgs e)
        {
            MainMenu.GetForm.Hide();
            ListEmployee.GetForm.ShowDialog();
            MainMenu.GetForm.Show();
        }

        private void listСomputersButton_Click(object sender, EventArgs e)
        {
            ListComputers.GetForm.Show();
            MainMenu.GetForm.Hide();
        }

        private void listPeripheralsButton_Click(object sender, EventArgs e)
        {

        }

        private void listComponentsButton_Click(object sender, EventArgs e)
        {
            MainMenu.GetForm.Hide();
            ListComponent.GetForm.ShowDialog();
            MainMenu.GetForm.Show();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Authorization.GetForm.Show();
            MainMenu.GetForm.Hide();
        }
    }
}
