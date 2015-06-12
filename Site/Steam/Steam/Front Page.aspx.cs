using System;
using System.Web.UI;

namespace Steam
{
    public partial class FrontPage : Page
    {
        private readonly Administration _admin = new Administration();
        private readonly Connection _conn = new Connection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserData"] != null)
            {
                var acc = (Account) Session["UserData"];
                btnLogin.Text = "Welcome " + acc.Name + " €" + acc.Balance + ".";
            }
            else if (Session["newAccount"] != null)
            {
                var acc = (Account) Session["newAccount"];
                btnLogin.Text = "Welcome " + acc.Name + " €" + acc.Balance + ".";
            }

            if (Session["Games"] == null)
            {
                Session_Games();
            }
        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     Just a way to test the database connection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnTestConnection_Click(object sender, EventArgs e)
        {
            if (_conn.NewConnection())
            {
                lblTest.Text = "Jaja, hier komt shit want DB werkt";
                _conn.CloseConnection();
            }
            else
            {
                lblTest.Text = "fuck oracle";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Signup.aspx");
        }

        /// <summary>
        ///     Method used to put a list of all games in a session (if possible).
        /// </summary>
        protected void Session_Games()
        {
            _admin.Fill_Games();
            Session["Games"] = _admin.Games;
        }

        protected void mmorpg_Click(object sender, EventArgs e)
        {
            Response.Redirect("Mmorpg.aspx");
        }

        protected void checkout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Checkout.aspx");
        }

        protected void btnLibrary_Click(object sender, EventArgs e)
        {
            Response.Redirect("Library.aspx");
        }

        protected void racing_Click(object sender, EventArgs e)
        {
            Response.Redirect("Racing.aspx");
        }

        protected void fighting_Click(object sender, EventArgs e)
        {
            Response.Redirect("Fighting.aspx");
        }
    }
}