using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Steam
{
    public partial class Checkout : System.Web.UI.Page
    {
        Administration admin = new Administration();
        private Account acc;
        private List<Game> buying; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserData"] != null)
            {
                Account acc = (Account)Session["UserData"];
                btnLogin.Text = "Welcome " + acc.Name + ".";
            }
            else if (Session["newAccount"] != null)
            {
                Account acc = (Account) Session["newAccount"];
                btnLogin.Text = "Welcome " + acc.Name + ".";
            }

            else
            {
                Page home = HttpContext.Current.Handler as Page;
                if (home != null)
                {
                    ScriptManager.RegisterStartupScript(home, home.GetType(), "err_msg",
                    "alert('You need to log in first!');window.location='Signup.aspx';", true);
                }
                
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Signup.aspx");
        }

        protected void Fill_List()
        {
            buying = (List<Game>)Session["cart"];

            foreach (var s in buying)
            {
                lbCheckout.Items.Add(s.ToString());
            }
        }

        protected void buy_Click(object sender, EventArgs e)
        {
            admin.Fill_Games();
            foreach (var x in buying)
            {
                foreach (var y in admin.games)
                {
                    if (x.GameId == y.GameId)
                    {
                        admin.Add_Game(acc.Id, x.GameId);
                    }
                }
            }
            Session["cart"] = null;
            Page home = HttpContext.Current.Handler as Page;
            if (home != null)
            {
                ScriptManager.RegisterStartupScript(home, home.GetType(), "err_msg",
                "alert('Your purchased games can now be found in your library.');window.location='Front Page.aspx';", true);
            }
        }
    }
}