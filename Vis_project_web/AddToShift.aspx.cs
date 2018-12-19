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
        public DatabaseTable<Employees> empl;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                Dictionary<string, object> param = new Dictionary<string, object>();
                if (Request.Params["id"] == null)
                {
                    Response.Redirect("/");
                }
                int id = Int32.Parse(Request.Params["id"]);
                param.Add("Employees.ID_employee", id);
                HiddenField1.Value = id.ToString();
                /*DatabaseTable<Employees>*/ empl = EmployeeData.getEmployees(param);
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
            Dictionary<String, object> param = new Dictionary<string, object>();
            if(RadioButtonList1.SelectedValue == "")
            {
                return;
            }
            else
            {
                int i = Int32.Parse(HiddenField1.Value);
                param.Add("ID_employee", i);
                int shift = Int32.Parse(RadioButtonList1.SelectedValue);
                //empl = EmployeeData.getEmployees(param);
                
                param.Add("ID_shift", shift);
                //param.Add("ID_employee", i);
                IDataProvider<Employees> provider = DataProviderFactory.GetDefaultDataProvider<Employees>();
                provider.Save(param);
                Response.Redirect("/");
                //empl = EmployeeData.setEmployees(param);
            }
        }
    }
}