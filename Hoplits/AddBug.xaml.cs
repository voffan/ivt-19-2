using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Hoplits.Classes;

namespace Hoplits
{
    /// <summary>
    /// Логика взаимодействия для AddBug.xaml
    /// </summary>
    public partial class AddBug : Window
    {
        public AddBug(int _id)
        {
            InitializeComponent();
            errortype_list.ItemsSource = Enum.GetValues(typeof(ErrorType));
            MessageBox.Show(_id.ToString());
        }
    }
}
