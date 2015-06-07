using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Steam
{
    public partial class Signup : System.Web.UI.Page
    {
        Administration admin = new Administration();
        Account acc = new Account(2, "test", "test", "email", new DateTime(1900, 10, 10), 0);
        protected void Page_Load(object sender, EventArgs e)
        {
           /*
           HttpCookie userCookie = new HttpCookie("UserData");
           userCookie["Name"] = "testname";
           userCookie["Password"] = "test";
           userCookie.Expires = DateTime.Now.AddDays(30);
           Response.Cookies.Add(userCookie);
           Response.Write(Request.Cookies["UserData"].Value);
            */
            Session["UserData"] = acc;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {

            Page home = HttpContext.Current.Handler as Page;
            if (home != null)
            {
              ScriptManager.RegisterStartupScript(home, home.GetType(), "err_msg", "alert('Thank you for signing up. You can now login.');window.location='Front Page.aspx';", true);  
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Write(Session["UserData"]);
        }
    }
}