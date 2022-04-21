﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yaxel.Classes;

namespace Yaxel.Tables.ComputerForms
{
    public partial class UpdateComputer : Form
    {
        private int compId;

        public UpdateComputer(int compId)
        {
            InitializeComponent();

            this.compId = compId;
        }


        private void UpdateComputer_Load(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                Computer computer = context.Computers.Where(c => c.Id == compId).ToList().First();
                textBoxName.Text = computer.Name;

                comboBoxStatus.DataSource = new BindingSource(EnumTranslator.DescriptionAttributes<Status>.RetrieveAttributes(), null);
                comboBoxStatus.DisplayMember = "Key";
                comboBoxStatus.ValueMember = "Value";

                comboBoxStatus.SelectedItem = computer.Status;

                comboBoxEmployee.DataSource = context.Employees.ToList();
                comboBoxEmployee.DisplayMember = "Name";
                comboBoxEmployee.ValueMember = "Id";

                comboBoxEmployee.SelectedItem = computer.EmployeeId;

                comboBoxManufacturer.DataSource = context.Manufacturers.ToList();
                comboBoxManufacturer.DisplayMember = "Name";
                comboBoxManufacturer.ValueMember = "Id";

                //comboBoxManufacturer.SelectedItem = computer.ManufacturerId;
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                Computer computer = context.Computers.Where(c => c.Id == compId).ToList().First();

                computer.Name = textBoxName.Text;
                computer.Status = (Status)Enum.Parse(typeof(Status), (string)comboBoxStatus.SelectedValue);
                computer.EmployeeId = (int)comboBoxEmployee.SelectedValue;
                //computer.ManufacturerId = (int)comboBoxManufacturer.SelectedValue;

                context.SaveChanges();
            }

            Close();
        }
    }
}
