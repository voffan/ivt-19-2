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
using AchieveNow.ProgramClasses;

namespace AchieveNow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /*using (ApplicationContext db = new ApplicationContext())
            {
                SportKind sportKind = new SportKind(Name = "Полетино");
            }*/

            using (ApplicationContext db = new ApplicationContext())
            {
                var sportKinds = db.SportKinds.ToList();
                Console.WriteLine("Список видов спорта:");
                foreach ( var sportKind in sportKinds )
                {
                    Console.WriteLine($"{sportKind.Id}.{sportKind.Name}");
                }
            }
        }
    }
}
