using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Vis_project_web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        internal protected void Application_BeginRequest(object sender, EventArgs e)
        {
            /*
            if (Session["username"] == null)
            {
                Session["abc"] = "asdasd";
            }
            */
        }
        protected void Session_Start(Object sender, EventArgs e)
        {
            //HttpContext.Current.Session["Abc"] = "123";
        }

        protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            if(HttpContext.Current.Session != null)
            {
                if(Session["employee"] == null)
                {
                    if(Request.FilePath != "/Login.aspx"){
                        Response.Redirect("/Login.aspx");
                    }
                }
                //HttpContext.Current.Session["Abc"] = "123";
            }
        }
    }
}