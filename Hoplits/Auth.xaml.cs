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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hoplits.Components;

namespace Hoplits
{
    /// <summary>
    /// Interaction logic for Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var empl = EmployeeLogic.Login(login.Text, password.Text);
                if (empl == null)
                {
                    MessageBox.Show("Failed to log in!");
                    return;
                }
                //go to main menu 
                MessageBox.Show("Logged in!");
                this.Hide();
                MainWindow mainWindow = new MainWindow(); 
                mainWindow.ShowDialog();
                this.Close();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
