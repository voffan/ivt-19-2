using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
using Yaxel.Classes;
using Yaxel.Tables.Computer;

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
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            listName = "Сотрудники";
            this.Text = oldText + " - " + listName;

            cTable = CurrentTable.Employee;
            fillDataGridView();
        }

        private void btnComputers_Click(object sender, EventArgs e)
        {
            listName = "Компьютеры";
            this.Text = oldText + " - " + listName;

            cTable = CurrentTable.Computer;
            fillDataGridView();
        }

        private void btnPeripherals_Click(object sender, EventArgs e)
        {
            listName = "Периферии";
            this.Text = oldText + " - " + listName;

            cTable = CurrentTable.Periphery;
            fillDataGridView();
        }

        private void btnComponents_Click(object sender, EventArgs e)
        {
            listName = "Компоненты";
            this.Text = oldText + " - " + listName;

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

                        List<Computer> computersList = context.Computers.Include(e => e.Employee).Include(m => m.Manufacturer).ToList();

                        dataGridView1.Columns.Add("Id", "Id");
                        dataGridView1.Columns.Add("Name", "Имя компьютера");
                        dataGridView1.Columns.Add("Status", "Статус");
                        dataGridView1.Columns.Add("Employee", "Сотрудник");
                        dataGridView1.Columns.Add("Manufacturer", "Производитель");

                        dataGridView1.Columns[0].Width = 25;

                        DataGridViewButtonColumn btnUpdate = new DataGridViewButtonColumn();
                        btnUpdate.Name = "Update";
                        btnUpdate.HeaderText = "Редактирование";
                        //dataGridView1.CellContentClick += DataGridView1_CellContentClick;
                        dataGridView1.Columns.Add(btnUpdate);

                        foreach (Computer c in computersList)
                        {
                            dataGridView1.Rows.Add(c.Id, c.Name, c.Status, c.Employee.Name, c.Manufacturer.Name);
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

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            switch (cTable)
            {
                case CurrentTable.Employee:

                    break;
                case CurrentTable.Computer:
                    AddComputers form = new AddComputers();
                    form.ShowDialog();
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


        private void btnDeleteEntry_Click(object sender, EventArgs e)
        {
            switch (cTable)
            {
                case CurrentTable.Employee:

                    break;
                case CurrentTable.Computer:
                    List<int> delItems = new List<int>();

                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                        delItems.Add((int)dataGridView1.SelectedRows[i].Cells[0].Value);

                    DeleteComputers form = new DeleteComputers(delItems);
                    form.ShowDialog();
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
