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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {

            Page home = HttpContext.Current.Handler as Page;
            if (home != null)
            {
              ScriptManager.RegisterStartupScript(home, home.GetType(), "err_msg", "alert('Thank you for signing up. You can now login.');window.location='Front Page.aspx';", true);  
            }
        }
    }
}