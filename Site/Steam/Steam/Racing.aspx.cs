using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Steam
{
    public partial class Racing : System.Web.UI.Page
    {
        Administration admin = new Administration();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserData"] != null)
            {
                Account acc = (Account)Session["UserData"];
                btnLogin.Text = "Welcome " + acc.Name + ".";
            }
            else if (Session["newAccount"] != null)
            {
                Account acc = (Account)Session["newAccount"];
                btnLogin.Text = "Welcome " + acc.Name + ".";
            }

            if (Session["Games"] == null)
            {
                
            }

            else
            {
                
            }
        }
    }
}