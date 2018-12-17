using Shift.Data;
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

namespace Shift.Presentation
{
    public partial class Login : Form
    {
        public Employees emp;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            string password = txtpassword.Text;
            Form1 Application = new Form1();
            Login LoginForm = new Login();
            Dictionary<String, object> param = new Dictionary<string, object>();
            param.Add("Employee_login", username);
            DatabaseTable<Employees> empl = EmployeeData.getEmployees(param);

            if(!empl.Any())
            {
                MessageBox.Show("Login or password is empty");
            }
            else
            {
                var login = empl[0].Employee_login;
                var pass = empl[0].Employee_password;
                var isAdmin = empl[0].isAdmin;
                if (username == login && password == pass)
                {
                    emp = empl[0];
                    Close();
                }
                else
                {
                    MessageBox.Show("Login or password is incorrect");
                }
            }





        }

    }
}
