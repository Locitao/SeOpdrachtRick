using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Steam
{
    
    public partial class Front_Page : System.Web.UI.Page
    {
        readonly Connection conn = new Connection();
        Administration admin = new Administration();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserData"] != null)
            {
                Account acc = (Account)Session["UserData"];
                btnLogin.Text = "Welcome " + acc.Name + " €" + acc.Balance + ".";
            }
            else if (Session["newAccount"] != null)
            {
                Account acc = (Account)Session["newAccount"];
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
        /// Just a way to test the database connection.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnTestConnection_Click(object sender, EventArgs e)
        {
            
            if (conn.NewConnection())
            {
                lblTest.Text = "Jaja, hier komt shit want DB werkt";
                conn.CloseConnection();
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
        /// Method used to put a list of all games in a session (if possible).
        /// </summary>
        protected void Session_Games()
        {
            admin.Fill_Games();
            Session["Games"] = admin.games;
            
        }

        protected void mmorpg_Click(object sender, EventArgs e)
        {
            Response.Redirect("Mmorpg.aspx");
        }

        protected void checkout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Checkout.aspx");
        }
    }
}