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
        private bool loggedIn = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (loggedIn)
            {
                
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
    }
}