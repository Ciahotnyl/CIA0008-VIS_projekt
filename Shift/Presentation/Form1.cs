﻿using Shift.Data;
using Shift.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shift
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            if(employeeGrid.DataSource == null)
            {
                DatabaseTable<Employees> empl = EmployeeData.getEmployees(null);
                employeeGrid.DataSource = empl;
                //employeeNavigator.BindingSource = empl;
            }
        }

        private void employeeGrid_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            int i = 10;

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            ShiftCombo.SelectedIndex = 0;
        }

        private void ShiftCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<String, object> param = new Dictionary<string, object>();
            if(ShiftCombo.SelectedItem != "All")
            {
                param.Add("Name_of_shift", ShiftCombo.SelectedItem);
            }
            DatabaseTable<Employees> empl = EmployeeData.getEmployees(param);
            employeeGrid.DataSource = empl;
        }
    }
}
