using System;
using System.Windows.Forms;
using Yaxel.Classes;

namespace Yaxel.Tables.Component
{
    public partial class AddComponents : Form
    {
        public AddComponents()
        {
            InitializeComponent();
        }

        private void AddComponents_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = new BindingSource(EnumTranslator.DescriptionAttributes<AttrType>.RetrieveAttributes(), null);
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";
        }
    }
}
