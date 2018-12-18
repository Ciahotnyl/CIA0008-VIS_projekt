using Shift.Data;
using Shift.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vis_project_library.Domain;

namespace Vis_project_web
{
    public partial class AddToShift : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("Employees.ID_employee", Request.Params["id"]);
                DatabaseTable<Employees> empl = EmployeeData.getEmployees(param);
                Label1.Text = empl[0].First_name + " " + empl[0].Last_name;
                DatabaseTable<Shifts> shif = ShiftData.getShifts(null);
                RadioButtonList1.DataValueField = "ID_shift";
                RadioButtonList1.DataTextField = "Name_of_shift";
                RadioButtonList1.DataSource = shif;
                RadioButtonList1.DataBind();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // ošetřit když nebude nic vybrané
            int shift = Int32.Parse(RadioButtonList1.SelectedValue);
        }
    }
}