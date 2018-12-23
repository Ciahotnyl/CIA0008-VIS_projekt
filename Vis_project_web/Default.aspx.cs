using Shift.Data;
using Shift.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vis_project_library;
using Vis_project_library.Domain;

namespace Vis_project_web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<String, object> param = new Dictionary<string, object>();
            param.Add("Employees.ID_shift", null);
            DatabaseTable<Employees> empl = EmployeeData.getEmployees(param);
            GridView1.DataSource = empl;
            GridView1.DataBind();
        }
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink hh = new HyperLink();
                hh.Text = DataBinder.Eval(e.Row.DataItem, "Last_name").ToString();
                hh.NavigateUrl = "~/AddToShift.aspx?id="+ DataBinder.Eval(e.Row.DataItem, "ID_employee").ToString(); ;
                e.Row.Cells[3].Controls.Add(hh);
            }
        }

        protected void Export_to_json_Click(object sender, EventArgs e)
        {
            foreach (Type t in DataProviderFactory.tables)
            {
                Type dt = typeof(DatabaseTable<>).MakeGenericType(t);

                Type jp = typeof(JsonDataMapper<>).MakeGenericType(t);
                Type sp = typeof(SqlDataMapper<>).MakeGenericType(t);

                object oo = Activator.CreateInstance(dt);

                dynamic ins = oo;
              
                dynamic jprov = Activator.CreateInstance(jp);
                dynamic sprov = Activator.CreateInstance(sp);

                sprov.Fill(ins);
                DataProviderFactory.settings["path"] = this.MapPath("~/App_Data/JSON/");
                jprov.Export(ins);
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = RadioButtonList1.SelectedValue;
            switch (selectedValue)
            {
                case "SQL":

                    Dictionary<String, object> param = new Dictionary<string, object>();
                    param.Add("Employees.ID_shift", null);
                    DataProviderFactory.SetDefaultDataProvider("SQL");
                    DatabaseTable<Employees> empl = EmployeeData.getEmployees(param);
                    GridView1.DataSource = empl;
                    GridView1.DataBind();
                    break;

                case "JSON":
                    Dictionary<String, object> J_param = new Dictionary<string, object>();
                    J_param.Add("Employees.ID_shift", null);
                    DataProviderFactory.SetDefaultDataProvider("JSON");
                    DataProviderFactory.settings["path"] = this.MapPath("~/App_Data/JSON/");
                    DatabaseTable<Employees> J_empl = EmployeeData.getEmployees(J_param);
                    GridView1.DataSource = J_empl;
                    GridView1.DataBind();
                    break;
            }
        }
    }
}