using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yaxel.Classes;

namespace Yaxel
{
    public partial class MultiList : Form
    {
        private String oldText = "";
        private String listName = "";

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
                        dataGridView1.DataSource = context.Employees.ToList();
                        break;
                    case CurrentTable.Computer:
                        dataGridView1.DataSource = context.Computers.ToList();
                        break;
                    case CurrentTable.Periphery:
                        dataGridView1.DataSource = context.Peripheries.ToList();
                        break;
                    case CurrentTable.Component:
                        dataGridView1.DataSource = context.Components.ToList();
                        break;
                    case CurrentTable.none:
                        break;
                }
            }
        }

        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            switch (cTable)
            {
                case CurrentTable.Employee:

                    break;
                case CurrentTable.Computer:
                    AddComputers.GetForm.ShowDialog();
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
    }
}
