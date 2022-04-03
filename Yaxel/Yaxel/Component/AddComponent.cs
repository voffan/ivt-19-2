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

namespace Yaxel
{
    public partial class AddComponent : Form
    {
        public AddComponent()
        {
            InitializeComponent();
        }

        private static AddComponent init;
        public static AddComponent GetForm
        {
            get
            {
                if (init == null || init.IsDisposed)
                    init = new AddComponent();
                return init;
            }
        }

        private void AddComponent_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = new BindingSource(EnumTranslator.DescriptionAttributes<AttrType>.RetrieveAttributes(), null);
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";
        }
    }
}
