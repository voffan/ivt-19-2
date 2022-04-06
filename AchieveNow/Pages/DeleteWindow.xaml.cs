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
using AchieveNow.ProgramClasses;

namespace AchieveNow.Pages
{
    /// <summary>
    /// Interaction logic for DeleteWindow.xaml
    /// </summary>
    public partial class DeleteWindow : Window
    {
        List<Classes.Competition> competitionList;

        public DeleteWindow(List<Classes.Competition> competitions)
        {
            InitializeComponent();

            competitionList = competitions;

            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("Id"), Width = 30 });
            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "Название", Binding = new Binding("Name"), MinWidth = 200, Width = new DataGridLength(1, DataGridLengthUnitType.Star) });
            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "Уровень", Binding = new Binding("Level"), Width = new DataGridLength(1, DataGridLengthUnitType.Star)});
            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "Локация", Binding = new Binding("Location"), Width = new DataGridLength(1, DataGridLengthUnitType.Star) });
            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "Вид спорта", Binding = new Binding("SportKind"), Width = new DataGridLength(1, DataGridLengthUnitType.Star) });
            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "Дата проведения", Binding = new Binding("DateOfExecution"), Width = new DataGridLength(1, DataGridLengthUnitType.Star) });

            Delete_DataGrid.ItemsSource = competitions.ToList();
        }

        private void Confirm_Button_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                {
                    return;
                }

                if (competitionList != null)
                {
                    try
                    {
                        context.RemoveRange(competitionList);
                        context.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("Произошла ошибка при удалении. Возможно, выбранные элементы были уже удалены");
                    }
                }
                else
                {
                    MessageBox.Show("Отсутствуют объекты для удаления");
                }

                Close();
            }
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
