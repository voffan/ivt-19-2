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
using Hoplits.Cs;
using Hoplits.Classes;

namespace Hoplits
{
    /// <summary>
    /// Логика взаимодействия для ShowSolutions.xaml
    /// </summary>
    public partial class ShowSolutions : Window
    {
        public ShowSolutions(int _id)
        {
            InitializeComponent();
            ApplicationContext context = new ApplicationContext();
            var items = context.Solutions.Where(c => c.ErrorId == _id).ToList();
            richTextBox.Document.Blocks.Clear();
            int i = 1;
            foreach (var item in items)
            {
                richTextBox.Document.Blocks.Add(new Paragraph(new Run(i + ".\n" + item.SolutionOfError + "\n author: " + item.EmployeeId)));
                i++;
            }
            
            
        }
        
    }
}
