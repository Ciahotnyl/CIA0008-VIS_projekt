using Shift.Data;
using Shift.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vis_project_web
{
    public partial class Default : System.Web.UI.Page
    {
        //Dictionary<String, object> param = new Dictionary<string, object>();

        //DatabaseTable<Employees> empl = EmployeeData.getEmployees(null);
        protected void Page_Load(object sender, EventArgs e)
        {          
            Dictionary<String, object> param = new Dictionary<string, object>();
            param.Add("Employees.ID_shift", null);
            DatabaseTable<Employees> empl = EmployeeData.getEmployees(param);
            //Response.Redirect("~/");
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
    }
}