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
                MsgBox("Add your login and password, please", this.Page, this);
            }
            else
            {
                var login = empl[0].Employee_login;
                var pass = empl[0].Employee_password;
                var isAdmin = empl[0].isAdmin;
                if (name == login && password == pass)
                {
                    if (isAdmin)
                    {
                        Session["employee"] = empl[0];
                        Response.Redirect("/AddToShift.aspx");
                    }
                    else
                    {
                        MsgBox("Your are not Mistr!", this.Page, this);
                    }

                }
                else
                {

                    MsgBox("Incorrect loing or password", this.Page, this);
                }
            }
        }
        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }
    }
}