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
            const string testMessage = "ik neuk jullie allemaal de moeder";
            Response.Write(@"<script language='javascript'>alert('" + testMessage + " .');</script>");
        }
    }
}