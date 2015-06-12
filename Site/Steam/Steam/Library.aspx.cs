using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

namespace Steam
{
    /// <summary>
    ///     This page is the users' library, from here they have an overview of which games they own, and they can install
    ///     these.
    /// </summary>
    public partial class Library : Page
    {
        private readonly Administration _admin = new Administration();
        private Account _acc;
        private List<Game> _libGames = new List<Game>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserData"] != null)
            {
                _acc = (Account) Session["UserData"];
                btnLogin.Text = "Welcome " + _acc.Name + " €" + _acc.Balance + ".";

                if (!IsPostBack)
                {
                    Fill_List();
                }
            }
            else if (Session["newAccount"] != null)
            {
                _acc = (Account) Session["newAccount"];
                btnLogin.Text = "Welcome " + _acc.Name + " €" + _acc.Balance + ".";

                if (!IsPostBack)
                {
                    Fill_List();
                }
            }


            else
            {
                var home = HttpContext.Current.Handler as Page;
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
            _libGames = _admin.Find_Games(_acc.Id);

            foreach (var g in _libGames)
            {
                lbGames.Items.Add(g.ToString());
            }
        }

        protected void Install_Game()
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage",
                "alert('Game succesfully installed.')", true);
        }

        protected void btnInstall_Click(object sender, EventArgs e)
        {
            Install_Game();
        }
    }
}