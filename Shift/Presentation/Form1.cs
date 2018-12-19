using Shift.Data;
using Shift.Domain;
using Shift.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vis_project_library.Domain;

namespace Shift
{
    public partial class Form1 : Form
    {
        string login = "";
        bool isAdmin = false;
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
            while(login == "")
            {
                Login lf = new Login();
                switch(lf.ShowDialog())
                {
                    case DialogResult.OK:
                        if(lf.emp != null)
                        {
                            login = lf.emp.Employee_login;
                            isAdmin = lf.emp.isAdmin;
                        }
                        break;
                    case DialogResult.Cancel:
                        Close();
                        return;
                }
            }           
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

        private void button1_Click(object sender, EventArgs e)
        {
            //var row = employeeGrid.SelectedRows.ToString();
            if (employeeGrid.SelectedRows.Count == 1)
            {
                int selectedrowindex = employeeGrid.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = employeeGrid.Rows[selectedrowindex];

                string ID_employee = Convert.ToString(selectedRow.Cells["ID_employee"].Value);
                string ID_position = Convert.ToString(selectedRow.Cells["ID_position"].Value);

                CreateTeam formTeam = new CreateTeam(ID_employee, ID_position);
                Form1 f = new Form1();
                formTeam.Show();
                f.Close();
            }
        }
    }
}
