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
        List<Classes.Location>? locationList;
        List<Classes.Achievement> achievementList;
        List<Classes.User> userList;

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

        public DeleteWindow(List<Classes.Location> locations)
        {
            InitializeComponent();

            locationList = locations;

            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("Id"), Width = 30 });
            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "Имя", Binding = new Binding("Name"), MinWidth = 200, Width = new DataGridLength(1, DataGridLengthUnitType.Star) });
            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "Страна", Binding = new Binding("Country"), Width = new DataGridLength(1, DataGridLengthUnitType.Star) });

            Delete_DataGrid.ItemsSource = locations.ToList();
        }

        public DeleteWindow(List<Classes.Achievement> achievements)
        {
            InitializeComponent();

            achievementList = achievements;

            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding ("Id"), Width = 30 });
            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "Название", Binding = new Binding("Name"), MinWidth = 200, Width = new DataGridLength(1, DataGridLengthUnitType.Star) });
            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "Результат", Binding = new Binding("Result"), MinWidth = 200, Width = new DataGridLength(1, DataGridLengthUnitType.Star) });
            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "Соревнование", Binding = new Binding("Competition"), MinWidth = 200, Width = new DataGridLength(1, DataGridLengthUnitType.Star) });
            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "Дата выдачи", Binding = new Binding("DateOfIssue"), MinWidth = 200, Width = new DataGridLength(1, DataGridLengthUnitType.Star) });

            Delete_DataGrid.ItemsSource = achievements.ToList();
        }

        public DeleteWindow(List<Classes.User> users)
        {
            InitializeComponent();

            userList = users;

            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("Id"), Width = 30 });
            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "Логин", Binding = new Binding("Login"), MinWidth = 200, Width = new DataGridLength(1, DataGridLengthUnitType.Star) });
            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "Пароль", Binding = new Binding("Password"), MinWidth = 200, Width = new DataGridLength(1, DataGridLengthUnitType.Star) });
            Delete_DataGrid.Columns.Add(new DataGridTextColumn { Header = "Должность", Binding = new Binding("Position"), Width = new DataGridLength(1, DataGridLengthUnitType.Star) });

            Delete_DataGrid.ItemsSource = users.ToList();
        }

        private void Confirm_Button_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                    return;

                if (competitionList != null || sportsmanList != null || sportKindList != null || countryList != null || locationList != null || achievementList != null || userList != null)
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
                        if (achievementList != null)
                            context.RemoveRange(achievementList);
                        if (locationList != null)
                            context.RemoveRange(locationList);
                        if (userList != null)
                            context.RemoveRange(userList);

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
