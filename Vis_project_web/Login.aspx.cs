using Shift.Data;
using Shift.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vis_project_web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String name = TextBox1.Text;
            String password = TextBox2.Text;
            AddToShift Application = new AddToShift();
            Login LoginForm = new Login();
            Dictionary<String, object> param = new Dictionary<string, object>();
            param.Add("Employee_login", name);
            DatabaseTable<Employees> empl = EmployeeData.getEmployees(param);

            if (!empl.Any())
            {
                //MessageBox.Show("Login or password is empty");
            }
            else
            {
                var login = empl[0].Employee_login;
                var pass = empl[0].Employee_password;
                var isAdmin = empl[0].isAdmin;
                if (name == login && password == pass)
                {
                    Session["employee"] = empl[0];
                    Response.Redirect("/AddToShift.aspx");
                }
                else
                {
                    
                }
            }
        }
    }
}