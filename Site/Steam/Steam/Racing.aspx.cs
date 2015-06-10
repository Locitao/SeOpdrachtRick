using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Steam
{
    public partial class Racing : System.Web.UI.Page
    {
        Administration admin = new Administration();
        List<Game> racegames = new List<Game>();
        List<Game> shoppingCart = new List<Game>(); 
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
                Session_Games();
                Fill_Racing();
                Fill_Listbox();
            }

            else
            {
                Fill_Racing();
                Fill_Listbox();
            }

            if (Session["cart"] != null)
            {
                shoppingCart = (List<Game>) Session["cart"];
            }

            
        }

        protected void Session_Games()
        {
            admin.Fill_Games();
            Session["Games"] = null;
            Session["Games"] = admin.games;
        }

        protected void Fill_Racing()
        {
            List<Game> allGames = (List<Game>)Session["Games"];

            foreach (var g in allGames.Where(g => g.CategoryId == 2))
            {
                racegames.Add(g);
            }
        }

        protected void Fill_Listbox()
        {
            lbRacing.Items.Clear();
            foreach (var g in racegames)
            {
                lbRacing.Items.Add(g.ToString());
            }
        }

        protected void mmo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Mmorpg.aspx");
        }

        protected void races_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('You are already on this page!')", true);
        }

        protected void fighting_Click(object sender, EventArgs e)
        {
            Response.Redirect("Fighting.aspx");
        }
    }
}