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
        List<Classes.Competition>? competitionList;
        List<Classes.Sportsman>? sportsmanList;
        List<Classes.SportKind>? sportKindList;
        List<Classes.Country>? countryList;

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

        public DeleteWindow(List<Classes.Sportsman> sportsmen)
        {
            InitializeComponent();

            sportsmanList = sportsmen;

            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("Id"), Width = 30 });
            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "Имя", Binding = new Binding("Name"), MinWidth = 200, Width = new DataGridLength(1, DataGridLengthUnitType.Star) });
            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "Рождение", Binding = new Binding("DateOfBirth"), Width = new DataGridLength(1, DataGridLengthUnitType.Star) });
            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "Рост", Binding = new Binding("Height"), Width = new DataGridLength(1, DataGridLengthUnitType.Star) });
            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "Вес", Binding = new Binding("Weight"), Width = new DataGridLength(1, DataGridLengthUnitType.Star) });
            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "Гендер", Binding = new Binding("Gender"), Width = new DataGridLength(1, DataGridLengthUnitType.Star) });
            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "Вид спорта", Binding = new Binding("SportKind"), Width = new DataGridLength(1, DataGridLengthUnitType.Star) });
            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "Страна", Binding = new Binding("Country"), Width = new DataGridLength(1, DataGridLengthUnitType.Star) });

            Delete_DataGrid.ItemsSource = sportsmen.ToList();
        }

        public DeleteWindow(List<Classes.SportKind> sportKinds)
        {
            InitializeComponent();

            sportKindList = sportKinds;

            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("Id"), Width = 30 });
            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "Имя", Binding = new Binding("Name"), MinWidth = 200, Width = new DataGridLength(1, DataGridLengthUnitType.Star) });

            Delete_DataGrid.ItemsSource = sportKinds.ToList();
        }

        public DeleteWindow(List<Classes.Country> countries)
        {
            InitializeComponent();

            countryList = countries;

            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("Id"), Width = 30 });
            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "Имя", Binding = new Binding("Name"), MinWidth = 200, Width = new DataGridLength(1, DataGridLengthUnitType.Star) });

            Delete_DataGrid.ItemsSource = countries.ToList();
        }

        private void Confirm_Button_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                    return;

                if (competitionList != null || sportsmanList != null || sportKindList != null || countryList != null)
                {
                    try
                    {
                        if (competitionList != null)
                            context.RemoveRange(competitionList);
                        if (sportsmanList != null)
                            context.RemoveRange(sportsmanList);
                        if (countryList != null)
                            context.RemoveRange(countryList);
                        if (sportKindList != null)
                            context.RemoveRange(sportKindList);

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
