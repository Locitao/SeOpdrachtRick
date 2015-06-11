using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Steam
{
    /// <summary>
    /// This page is the users' library, from here they have an overview of which games they own, and they can install these.
    /// </summary>
    public partial class Library : System.Web.UI.Page
    {
        readonly Administration admin = new Administration();
        List<Game> libGames  = new List<Game>();
        private Account acc;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserData"] != null)
            {
                acc = (Account) Session["UserData"];
                btnLogin.Text = "Welcome " + acc.Name + " €" + acc.Balance + ".";

                if (!IsPostBack)
                {
                    Fill_List();
                }
            }
            else if (Session["newAccount"] != null)
            {
                acc = (Account) Session["newAccount"];
                btnLogin.Text = "Welcome " + acc.Name + " €" + acc.Balance + ".";

                if (!IsPostBack)
                {
                    Fill_List();
                }
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

        protected void toFrontPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Front Page.aspx");
        }

        protected void toCheckOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Checkout.aspx");
        }

        protected void Fill_List()
        {
            try
            {
                libGames = admin.Find_Games(acc.Id);

                foreach (var g in libGames)
                {
                    lbGames.Items.Add(g.ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        protected void Install_Game()
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Game succesfully installed.')", true);
        }

        protected void btnInstall_Click(object sender, EventArgs e)
        {
            Install_Game();
        }
    }
}