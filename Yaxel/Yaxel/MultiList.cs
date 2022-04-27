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

namespace Yaxel
{
    public partial class MultiList : Form
    {
        private static MultiList inst;
        public static MultiList GetForm
        {
            get
            {
                if (inst == null || inst.IsDisposed)
                    inst = new MultiList();
                return inst;
            }
        }

        private String oldText = "";
        private String listName = "";

        private String oldTextDelete = "";

        private CurrentTable cTable;
        private enum CurrentTable
        {
            Employee,
            Computer,
            Periphery,
            Component,
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

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            listName = "Сотрудники";
            this.Text = oldText + " - " + listName;
            Invalidate();

            cTable = CurrentTable.Employee;
            fillDataGridView();
        }

        private void btnComputers_Click(object sender, EventArgs e)
        {
            listName = "Компьютеры";
            this.Text = oldText + " - " + listName;
            Invalidate();

            cTable = CurrentTable.Computer;
            fillDataGridView();
        }

        private void btnPeripherals_Click(object sender, EventArgs e)
        {
            listName = "Периферии";
            this.Text = oldText + " - " + listName;
            Invalidate();

            cTable = CurrentTable.Periphery;
            fillDataGridView();
        }

        private void btnComponents_Click(object sender, EventArgs e)
        {
            listName = "Компоненты";
            this.Text = oldText + " - " + listName;
            Invalidate();

            cTable = CurrentTable.Component;
            fillDataGridView();
        }

        private void fillDataGridView()
        {
            using (var context = new YaxelContext())
            {
                switch (cTable)
                {
                    case CurrentTable.Employee:
                        dataGridView1.Columns.Clear();
                        dataGridView1.DataSource = context.Employees.ToList();
                        break;
                    case CurrentTable.Computer:
                        dataGridView1.DataSource = null;
                        dataGridView1.Columns.Clear();

                        List<Computer> computersList = context.Computers.Include(e => e.Employee).ToList();

                        DataGridViewImageCell update_Icon = new DataGridViewImageCell();
                        DataGridViewImageCell detail_Icon = new DataGridViewImageCell();

                        Image srcImage = Image.FromFile("../../Resources/Update_Icon.png");

                        Bitmap newImage = new Bitmap(25, 25);
                        using (Graphics gr = Graphics.FromImage(newImage))
                        {
                            gr.SmoothingMode = SmoothingMode.HighQuality;
                            gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            gr.DrawImage(srcImage, new Rectangle(0, 0, 25, 25));
                        }

                        update_Icon.Value = newImage;

                        srcImage = Image.FromFile("../../Resources/Detail_Icon.png");

                        newImage = new Bitmap(25, 25);
                        using (Graphics gr = Graphics.FromImage(newImage))
                        {
                            gr.SmoothingMode = SmoothingMode.HighQuality;
                            gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            gr.DrawImage(srcImage, new Rectangle(0, 0, 25, 25));
                        }

                        detail_Icon.Value = newImage;

                        dataGridView1.Columns.Add("Id", "Id");
                        dataGridView1.Columns.Add("Name", "Имя компьютера");
                        dataGridView1.Columns.Add("Status", "Статус");
                        dataGridView1.Columns.Add("Employee", "Сотрудник");
                        //dataGridView1.Columns.Add("Manufacturer", "Производитель");
                        dataGridView1.Columns.Add(new DataGridViewImageColumn());
                        dataGridView1.Columns.Add(new DataGridViewImageColumn());

                        dataGridView1.Columns[0].Width = 25;
                        dataGridView1.Columns[4].Width = 28;
                        dataGridView1.Columns[5].Width = 28;
                        dataGridView1.RowTemplate.Height = 28;

                        foreach (Computer c in computersList)
                        {
                            dataGridView1.Rows.Add(c.Id, c.Name, c.CompStatus, c.Employee.Name, detail_Icon.Value, update_Icon.Value);
                        }
                        break;
                    case CurrentTable.Periphery:
                        dataGridView1.Columns.Clear();
                        dataGridView1.DataSource = context.Peripheries.ToList();
                        break;
                    case CurrentTable.Component:
                        dataGridView1.Columns.Clear();
                        dataGridView1.DataSource = context.Components.ToList();
                        break;
                    case CurrentTable.none:
                        break;
                }
            }
        }

        private void DataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                switch (cTable)
                {
                    case CurrentTable.Employee:

                        break;
                    case CurrentTable.Computer:
                        if (e.ColumnIndex == 5 && e.RowIndex > -1)
                        {
                            UpdateComputer form = new UpdateComputer((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                            form.ShowDialog();
                            fillDataGridView();
                        }

                        if (e.ColumnIndex == 4 && e.RowIndex > -1)
                        {

                        }
                        break;
                    case CurrentTable.Periphery:

                        break;
                    case CurrentTable.Component:

                        break;
                    case CurrentTable.none:

                        break;
                }
        }

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
                    break;
                case CurrentTable.Component:
                    AddComponent componentForm = new AddComponent();
                    componentForm.ShowDialog();
                    fillDataGridView();
                    break;
                case CurrentTable.none:

                    break;
            }
        }


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
                    List<int> delItems = new List<int>();

                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                        delItems.Add((int)dataGridView1.SelectedRows[i].Cells[0].Value);

                    DeleteComputer computerForm = new DeleteComputer(delItems);
                    computerForm.ShowDialog();
                    fillDataGridView();
                    break;
                case CurrentTable.Periphery:

                    break;
                case CurrentTable.Component:
                    List<int> delComponents = new List<int>();

                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                        delComponents.Add((int)dataGridView1.SelectedRows[i].Cells[0].Value);

                    DeleteComponent componentForm = new DeleteComponent(delComponents);
                    componentForm.ShowDialog();
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

                    break;
                case CurrentTable.Computer:
                    SearchComputer computerForm = new SearchComputer();
                    computerForm.ShowDialog();
                    fillDataGridView();
                    break;
                case CurrentTable.Periphery:

                    break;
                case CurrentTable.Component:

                    break;
                case CurrentTable.none:

                    break;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int count = dataGridView1.SelectedRows.Count;
            btnDeleteEntry.Text = oldTextDelete + " (" + (count != 0 ? count : 0) + ")";
            btnDeleteEntry.Invalidate();
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
