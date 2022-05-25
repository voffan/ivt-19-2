using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Drawing2D;
using Yaxel.Classes;
using Yaxel.Tables.ComputerForms;
using Yaxel.Tables.ComponentForms;
using Yaxel.Tables.EmployeeForms;
using Yaxel.Tables.PeripheryForms;
using Yaxel.Tables.ManufacturerForms;
using Yaxel.Tables.Lists;

namespace Yaxel
{
    public partial class MultiList : Form
    {
        //private static MultiList inst;
        //public static MultiList GetForm
        //{ 
        //    get
        //    {
        //        if (inst == null || inst.IsDisposed)
        //            inst = new MultiList();
        //        return inst;
        //    }
        //}

        private String oldText = "";
        private String listName = "";

        private String oldTextDelete = "";

        private CurrentTable cTable;

        private bool isSearch;
        private List<Computer> resultComputer = new List<Computer>();
        private List<Employee> resultEmployee = new List<Employee>();
        private List<Component> resultComponent = new List<Component>();
        private List<Periphery> resultPeriphery = new List<Periphery>();
        private List<Manufacturer> resultManufacturer = new List<Manufacturer>();

        private enum CurrentTable
        {
            Employee,
            Computer,
            Periphery,
            Component,
            Manufacturer,
            none
        }
        public MultiList()
        {
            InitializeComponent();
        }

        private void MultiList_Load(object sender, EventArgs e)
        {
            oldText = this.Text;
            oldTextDelete = btnDeleteEntry.Text;

            SetDoubleBuffered(dataGridView1);

            cTable = CurrentTable.none;

            dataGridView1.CellMouseUp += DataGridView1_CellMouseUp;
        }

        #region Кнопки выбора таблицы

        // сотрудник
        private void btnEmployees_Click(object sender, EventArgs e)
        {
            listName = "Сотрудники";
            this.Text = oldText + " - " + listName;
            Invalidate();

            cTable = CurrentTable.Employee;
            fillDataGridView();
        }

        // компьютер
        private void btnComputers_Click(object sender, EventArgs e)
        {
            listName = "Компьютеры";
            this.Text = oldText + " - " + listName;
            Invalidate();

            cTable = CurrentTable.Computer;
            fillDataGridView();
        }

        // периферия
        private void btnPeripherals_Click(object sender, EventArgs e)
        {
            listName = "Периферии";
            this.Text = oldText + " - " + listName;
            Invalidate();

            cTable = CurrentTable.Periphery;
            fillDataGridView();
        }

        // компонент
        private void btnComponents_Click(object sender, EventArgs e)
        {
            listName = "Компоненты";
            this.Text = oldText + " - " + listName;
            Invalidate();

            cTable = CurrentTable.Component;
            fillDataGridView();
        }

        // производители
        private void btnManufacturers_Click(object sender, EventArgs e)
        {
            listName = "Производители";
            this.Text = oldText + " - " + listName;
            Invalidate();

            cTable = CurrentTable.Manufacturer;
            fillDataGridView();
        }
        #endregion

        // заполнение данных в datagridview
        private void fillDataGridView()
        {
            using (var context = new YaxelContext())
            {//Repair.png
                DataGridViewImageCell updateImageCell = new DataGridViewImageCell();
                DataGridViewImageCell detailImageCell = new DataGridViewImageCell();
                DataGridViewImageCell componentImageCell = new DataGridViewImageCell();
                DataGridViewImageCell PCImageCell = new DataGridViewImageCell();
                DataGridViewImageCell PeripheryImageCell = new DataGridViewImageCell();
                DataGridViewImageCell repairImageCell = new DataGridViewImageCell();

                updateImageCell.Value = new Bitmap(25, 25);
                detailImageCell.Value = new Bitmap(25, 25);
                componentImageCell.Value = new Bitmap(25, 25);
                PCImageCell.Value = new Bitmap(25, 25);
                PeripheryImageCell.Value = new Bitmap(25, 25);
                repairImageCell.Value = new Bitmap(25, 25);

                Graphics.FromImage((Image)updateImageCell.Value).DrawImage(Image.FromFile("../../Resources/Update_Icon.png"), new Rectangle(0, 0, 25, 25));
                Graphics.FromImage((Image)detailImageCell.Value).DrawImage(Image.FromFile("../../Resources/Detail_Icon.png"), new Rectangle(0, 0, 25, 25));
                Graphics.FromImage((Image)componentImageCell.Value).DrawImage(Image.FromFile("../../Resources/Component.png"), new Rectangle(0, 0, 25, 25));
                Graphics.FromImage((Image)PCImageCell.Value).DrawImage(Image.FromFile("../../Resources/PC.png"), new Rectangle(0, 0, 25, 25));
                Graphics.FromImage((Image)PeripheryImageCell.Value).DrawImage(Image.FromFile("../../Resources/Periphery.png"), new Rectangle(0, 0, 25, 25));
                Graphics.FromImage((Image)repairImageCell.Value).DrawImage(Image.FromFile("../../Resources/Repair.png"), new Rectangle(0, 0, 25, 25));

                switch (cTable)
                {
                    // сотрудник
                    case CurrentTable.Employee:
                        dataGridView1.DataSource = null;
                        dataGridView1.Columns.Clear();

                        List<Employee> employeesList = new List<Employee>();
                        if (!isSearch)
                        {
                            employeesList = context.Employees.ToList();
                        }
                        else
                        {
                            employeesList.AddRange(resultEmployee);
                            isSearch = false;
                            resultEmployee.Clear();
                        }

                        dataGridView1.Columns.Add("Id", "Id");
                        dataGridView1.Columns.Add("Name", "Имя");
                        dataGridView1.Columns.Add("Login", "Логин");
                        dataGridView1.Columns.Add("Password", "Пароль");
                        dataGridView1.Columns.Add("Position", "Должность");
                        dataGridView1.Columns.Add(new DataGridViewImageColumn());

                        dataGridView1.Columns[0].Width = 25;
                        dataGridView1.Columns[5].Width = 28;
                        dataGridView1.RowTemplate.Height = 28;

                        foreach (Employee e in employeesList)
                        {
                            dataGridView1.Rows.Add(e.Id, e.Name, e.Login, e.Password, e.EmployeePosition, updateImageCell.Value);
                        }
                        break;

                    // компьютер
                    case CurrentTable.Computer:
                        dataGridView1.DataSource = null;
                        dataGridView1.Columns.Clear();

                        List<Computer> computersList = new List<Computer>();
                        if (!isSearch)
                        {
                            computersList = context.Computers.Include(e => e.Employee).ToList();
                        }
                        else
                        {
                            computersList.AddRange(resultComputer);
                            isSearch = false;
                            resultComputer.Clear();
                        }

                        

                        dataGridView1.Columns.Add("Id", "Id");
                        dataGridView1.Columns.Add("Name", "Имя компьютера");
                        dataGridView1.Columns.Add("Status", "Статус");
                        dataGridView1.Columns.Add("Reason", "Причина");
                        dataGridView1.Columns.Add("Date", "Дата");
                        dataGridView1.Columns.Add("Employee", "Сотрудник");
                        dataGridView1.Columns.Add(new DataGridViewImageColumn());
                        dataGridView1.Columns.Add(new DataGridViewImageColumn());
                        dataGridView1.Columns.Add(new DataGridViewImageColumn());
                        dataGridView1.Columns.Add(new DataGridViewImageColumn());

                        dataGridView1.Columns[0].Width = 25;
                        dataGridView1.Columns[6].Width = 28;
                        dataGridView1.Columns[7].Width = 28;
                        dataGridView1.Columns[8].Width = 28;
                        dataGridView1.Columns[9].Width = 28;
                        dataGridView1.RowTemplate.Height = 28;

                        foreach (Computer c in computersList)
                        {
                            dataGridView1.Rows.Add(c.Id, c.Name, c.CompStatus, c.ReasonRepair, c.RepairTime, c.Employee.Name, componentImageCell.Value, PeripheryImageCell.Value, updateImageCell.Value, repairImageCell.Value);
                        }
                        break;

                    // периферия
                    case CurrentTable.Periphery:
                        dataGridView1.DataSource = null;
                        dataGridView1.Columns.Clear();

                        List<Periphery> peripheriesList = new List<Periphery>();
                        if (!isSearch)
                        {
                            peripheriesList = context.Peripheries.Include(p => p.Manufacturer).ToList();
                        }
                        else
                        {
                            peripheriesList.AddRange(resultPeriphery);
                            isSearch = false;
                            resultPeriphery.Clear();
                        }

                        dataGridView1.Columns.Add("Id", "Id");
                        dataGridView1.Columns.Add("Model", "Модель");
                        dataGridView1.Columns.Add("PeripheryType", "Тип");
                        dataGridView1.Columns.Add("Status", "Статус");
                        dataGridView1.Columns.Add("Manufacturer", "Производитель");
                        dataGridView1.Columns.Add(new DataGridViewImageColumn());
                        dataGridView1.Columns.Add(new DataGridViewImageColumn());

                        dataGridView1.Columns[0].Width = 25;
                        dataGridView1.Columns[5].Width = 28;
                        dataGridView1.Columns[6].Width = 28;
                        dataGridView1.RowTemplate.Height = 28;

                        foreach (Periphery p in peripheriesList)
                        {
                            dataGridView1.Rows.Add(p.Id, p.Model, p.TranslationType, p.PeripheryStatus, p.Manufacturer.Name, PCImageCell.Value, updateImageCell.Value);
                        }
                        break;

                    // компонент
                    case CurrentTable.Component:
                        dataGridView1.DataSource = null;
                        dataGridView1.Columns.Clear();

                        List<Component> componentsList = new List<Component>();
                        if (!isSearch)
                        { 
                            componentsList = context.Components.Include(m => m.Manufacturer).ToList();
                        }
                        else
                        {
                            componentsList.AddRange(resultComponent);
                            isSearch = false;
                            resultComponent.Clear();
                        }

                        dataGridView1.Columns.Add("Id", "Id");
                        dataGridView1.Columns.Add("Model", "Модель");
                        dataGridView1.Columns.Add("ComponentType", "Тип компонента");
                        dataGridView1.Columns.Add("Manufacturer", "Производитель");
                        dataGridView1.Columns.Add(new DataGridViewImageColumn());
                        dataGridView1.Columns.Add(new DataGridViewImageColumn());
                        dataGridView1.Columns.Add(new DataGridViewImageColumn());

                        dataGridView1.Columns[0].Width = 25;
                        dataGridView1.Columns[4].Width = 28;
                        dataGridView1.Columns[5].Width = 28;
                        dataGridView1.Columns[6].Width = 28;
                        dataGridView1.RowTemplate.Height = 28;

                        foreach (Component c in componentsList)
                        {
                            dataGridView1.Rows.Add(c.Id, c.Model, c.ComponentType, c.Manufacturer.Name, PCImageCell.Value, detailImageCell.Value, updateImageCell.Value);
                        }
                        break;

                    case CurrentTable.Manufacturer:
                        dataGridView1.DataSource = null;
                        dataGridView1.Columns.Clear();

                        List<Manufacturer> manufacturers = new List<Manufacturer>();
                        if (!isSearch)
                        {
                            manufacturers = context.Manufacturers.ToList();
                        }
                        else
                        {
                            manufacturers.AddRange(resultManufacturer);
                            isSearch = false;
                            resultManufacturer.Clear();
                        }

                        dataGridView1.Columns.Add("Id", "Id");
                        dataGridView1.Columns.Add("Name", "Название");
                        dataGridView1.Columns.Add(new DataGridViewImageColumn());

                        dataGridView1.Columns[2].Width = 50;
                        dataGridView1.RowTemplate.Height = 28;

                        foreach (Manufacturer m in manufacturers)
                        {
                            dataGridView1.Rows.Add(m.Id, m.Name, updateImageCell.Value);
                        }

                        break;
                    case CurrentTable.none:
                        break;
                }
            }
        }

        // клик по ячейке
        private void DataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                switch (cTable)
                {
                    case CurrentTable.Employee:
                        if (e.ColumnIndex == 5 && e.RowIndex > -1) // Update
                        {
                            UpdateEmployee form = new UpdateEmployee((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                            form.ShowDialog();
                            fillDataGridView();
                        }
                        break;
                    case CurrentTable.Computer:
                        if (e.ColumnIndex == 6 && e.RowIndex > -1) // Component
                        {
                            ComponentList form = new ComponentList((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                            form.ShowDialog();
                        }

                        if (e.ColumnIndex == 7 && e.RowIndex > -1) // Periphery
                        {
                            PeripheryList form = new PeripheryList((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                            form.ShowDialog();
                        }

                        if (e.ColumnIndex == 8 && e.RowIndex > -1) // Update
                        {
                            UpdateComputer form = new UpdateComputer((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                            form.ShowDialog();
                            fillDataGridView();
                        }
                        if (e.ColumnIndex == 9 && e.RowIndex > -1) // ChangeStates
                        {
                            ChangeStateComputer form = new ChangeStateComputer((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                            form.ShowDialog();
                            fillDataGridView();
                        }
                        break;
                    case CurrentTable.Periphery:
                        if (e.ColumnIndex == 5 && e.RowIndex > -1) // Computer
                        {
                            ComputerList form = new ComputerList((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value, 2);
                            form.ShowDialog();
                        }
                        if (e.ColumnIndex == 6 && e.RowIndex > -1) // Update
                        {
                            UpdatePeriphery form = new UpdatePeriphery((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                            form.ShowDialog();
                            fillDataGridView();
                            //MessageBox.Show("Update");
                        }
                        break;
                    case CurrentTable.Component:
                        if (e.ColumnIndex == 4 && e.RowIndex > -1) // Computer
                        {
                            ComputerList form = new ComputerList((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value, 1);
                            form.ShowDialog();
                        }

                        if (e.ColumnIndex == 5 && e.RowIndex > -1) // Attribute
                        {
                            AttributeList form = new AttributeList((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                            form.ShowDialog();
                        }
                        if (e.ColumnIndex == 6 && e.RowIndex > -1) // Update
                        {
                            UpdateComponent form = new UpdateComponent((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                            form.ShowDialog();
                            fillDataGridView();
                            //MessageBox.Show("Update");
                        }
                        break;
                    case CurrentTable.Manufacturer:
                        if (e.ColumnIndex == 2 && e.RowIndex > -1) // Update
                        {
                            UpdateManufacturer form = new UpdateManufacturer((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                            form.ShowDialog();
                            fillDataGridView();
                        }
                        break;
                    case CurrentTable.none:

                        break;
                }
        }

        // счётчик сколько элементов выделено
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int count = dataGridView1.SelectedRows.Count;
            btnDeleteEntry.Text = oldTextDelete + " (" + (count != 0 ? count : 0) + ")";
            btnDeleteEntry.Invalidate();
        }

        #region Кнопки "добавить", "удалить", "поиск"

        // добавить
        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            switch (cTable)
            {
                
                case CurrentTable.Employee:
                    AddEmployee formEmployee = new AddEmployee();
                    formEmployee.ShowDialog();
                    fillDataGridView();
                    break;

                case CurrentTable.Computer:
                    AddComputer computerForm = new AddComputer();
                    computerForm.ShowDialog();
                    fillDataGridView();
                    break;

                case CurrentTable.Periphery:
                    AddPeriphery peripheryForm = new AddPeriphery();
                    peripheryForm.ShowDialog();
                    fillDataGridView();
                    break;

                case CurrentTable.Component:
                    AddComponent componentForm = new AddComponent();
                    componentForm.ShowDialog();
                    fillDataGridView();
                    break;

                case CurrentTable.Manufacturer:
                    AddManufacturer manufacturerForm = new AddManufacturer();
                    manufacturerForm.ShowDialog();
                    fillDataGridView();
                    break;

                case CurrentTable.none:

                    break;
            }
        }

        // удалить
        private void btnDeleteEntry_Click(object sender, EventArgs e)
        {
            switch (cTable)
            {
                case CurrentTable.Employee:
                    List<int> delIEmployees = new List<int>();

                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                        delIEmployees.Add((int)dataGridView1.SelectedRows[i].Cells[0].Value);
                    DeleteEmployee formDeleteEmployees = new DeleteEmployee(delIEmployees);
                    formDeleteEmployees.ShowDialog();
                    fillDataGridView();

                    break;
                case CurrentTable.Computer:
                    List<int> delComputers = new List<int>();

                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                        delComputers.Add((int)dataGridView1.SelectedRows[i].Cells[0].Value);

                    DeleteComputer computerForm = new DeleteComputer(delComputers);
                    computerForm.ShowDialog();
                    fillDataGridView();
                    break;
                case CurrentTable.Periphery:
                    List<int> delPeriphery = new List<int>();

                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                        delPeriphery.Add((int)dataGridView1.SelectedRows[i].Cells[0].Value);

                    DeletePeriphery peripheryForm = new DeletePeriphery(delPeriphery);
                    peripheryForm.ShowDialog();
                    fillDataGridView();
                    break;
                case CurrentTable.Component:
                    List<int> delComponents = new List<int>();

                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                        delComponents.Add((int)dataGridView1.SelectedRows[i].Cells[0].Value);

                    DeleteComponent componentForm = new DeleteComponent(delComponents);
                    componentForm.ShowDialog();
                    fillDataGridView();
                    break;
                case CurrentTable.Manufacturer:
                    List<int> delManufacturers = new List<int>();

                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                        delManufacturers.Add((int)dataGridView1.SelectedRows[i].Cells[0].Value);

                    DeleteManufacturer manufacturerForm = new DeleteManufacturer(delManufacturers);
                    manufacturerForm.ShowDialog();
                    fillDataGridView();
                    break;
                case CurrentTable.none:

                    break;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            switch (cTable)
            {
                case CurrentTable.Employee:
                    using (var context = new YaxelContext())
                    {
                        var q = context.Employees.Where(x => x.Name == SearchTextBox.Text).ToList();

                        resultEmployee.AddRange(q);
                        MessageBox.Show("Найдено " + q.Count + " строк");
                    }
                    isSearch = true;
                    SearchTextBox.Text = "";
                    fillDataGridView();
                    break;
                case CurrentTable.Computer:
                    using (var context = new YaxelContext())
                    {
                        var q = context.Computers.Include(c => c.Employee)
                            .Where(x => x.Name == SearchTextBox.Text)
                            .ToList();

                        resultComputer.AddRange(q);
                        MessageBox.Show("Найдено " + q.Count + " строк");
                    }
                    isSearch = true;
                    SearchTextBox.Text = "";
                    fillDataGridView();
                    break;
                case CurrentTable.Periphery:
                    using (var context = new YaxelContext())
                    {
                        var q = context.Peripheries.Include(p => p.Manufacturer).Where(x => x.Model == SearchTextBox.Text).ToList();

                        resultPeriphery.AddRange(q);
                        MessageBox.Show("Найдено " + q.Count + " строк");
                    }
                    isSearch = true;
                    SearchTextBox.Text = "";
                    fillDataGridView();
                    break;
                case CurrentTable.Component:
                    using (var context = new YaxelContext())
                    {
                        var q = context.Components.Include(p => p.Manufacturer).Where(x => x.Model == SearchTextBox.Text).ToList();

                        resultComponent.AddRange(q);
                        MessageBox.Show("Найдено " + q.Count + " строк");
                    }
                    isSearch = true;
                    SearchTextBox.Text = "";
                    fillDataGridView();
                    break;
                case CurrentTable.Manufacturer:
                    using (var context = new YaxelContext())
                    {
                        var q = context.Manufacturers.Where(x => x.Name == SearchTextBox.Text).ToList();

                        resultManufacturer.AddRange(q);
                        MessageBox.Show("Найдено " + q.Count + " строк");
                    }
                    isSearch = true;
                    SearchTextBox.Text = "";
                    fillDataGridView();
                    break;
                case CurrentTable.none:

                    break;
            }

        }
        #endregion

        // Report
        private void yaxelButton1_Click(object sender, EventArgs e)
        {
            ReportComputer form = new ReportComputer();
            form.ShowDialog();
        }

        private static void SetDoubleBuffered(Control c)
        {
            if (SystemInformation.TerminalServerSession)
                return;

            System.Reflection.PropertyInfo pDoubleBuffered =
                  typeof(Control).GetProperty(
                        "DoubleBuffered",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);

            pDoubleBuffered.SetValue(c, true, null);
        }
    }
}
