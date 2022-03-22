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
    }
}
