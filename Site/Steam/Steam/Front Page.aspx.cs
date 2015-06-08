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
    }
}