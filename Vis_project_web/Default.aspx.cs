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
            //Response.Redirect("/Login.aspx");
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
                //e.Row.DataItem,
                e.Row.Cells[3].Controls.Add(hh);
            }
        }

        protected void Export_to_json_Click(object sender, EventArgs e)
        {

            //DatabaseTable<Employees> empl = EmployeeData.getEmployees(null);
            //DatabaseTable<Workplaces> work = EmployeeData.getEmployees(null);

           

            

            foreach (Type t in DataProviderFactory.tables)
            {
                Type dt = typeof(DatabaseTable<>).MakeGenericType(t);

                Type jp = typeof(JsonDataProvider<>).MakeGenericType(t);
                Type sp = typeof(SqlDataProvider<>).MakeGenericType(t);

                object oo = Activator.CreateInstance(dt);

                dynamic ins = oo;
                //DatabaseTable<Record> ins = (dt)oo as DatabaseTable<Record>;                
                dynamic jprov = Activator.CreateInstance(jp);
                dynamic sprov = Activator.CreateInstance(sp);

                sprov.Fill(ins);
                DataProviderFactory.settings["path"] = this.MapPath("~/App_Data/JSON/");
                jprov.Export(ins);
                


                //DatabaseTable <ins> a = new DatabaseTable<t>();
            }
            //DatabaseTable<Employees> employee = new DatabaseTable<Employees>();

            //employee.Fill(param);

        }
    }
}