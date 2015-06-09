using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Steam
{
    public partial class Mmorpg : System.Web.UI.Page
    {
        Administration admin = new Administration();
        List<Game> mmorpgs = new List<Game>();
        List<Game> shoppingCart = new List<Game>();
        private Account acc;
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
                Fill_Mmorpg();
                Fill_Listbox();
            }

            else
            {
                Fill_Mmorpg();
                Fill_Listbox();
            }

            if (Session["cart"] != null)
            {
                shoppingCart = (List<Game>)Session["cart"];
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Signup.aspx");
        }

        protected void Session_Games()
        {
            admin.Fill_Games();
            Session["Games"] = admin.games;
        }

        /// <summary>
        /// Find all MMORPGS and add em to the list.
        /// </summary>
        protected void Fill_Mmorpg()
        {
            List<Game> allGames = (List<Game>)Session["Games"];
            /* sadly enough, I couldn't get Linq to work
            mmorpgs =
                from Game in allGames
                where (Game.CategoryId == 1)
                select Game; */

            foreach (var g in allGames.Where(g => g.CategoryId == 1))
            {
                mmorpgs.Add(g);
            }
        }

        /// <summary>
        /// Fill the listbox with all MMORPGs.
        /// </summary>
        protected void Fill_Listbox()
        {
            foreach (var g in mmorpgs)
            {
                lbMmorpg.Items.Add(g.ToString());
            }
        }

        protected void mmo_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('You are already on this page!')", true);
        }

        protected void racing_Click(object sender, EventArgs e)
        {
            Response.Redirect("Racing.aspx");
        }

        protected void buy_Click(object sender, EventArgs e)
        {
            if (lbMmorpg.SelectedItem == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('If you want to purchase a game, select one in the list!')", true);
            }
            else
            {
                var gameText = lbMmorpg.SelectedItem.Text;
                foreach (var s in mmorpgs.Where(s => s.ToString() == gameText))
                {
                    shoppingCart.Add(s);
                    Session["cart"] = shoppingCart;
                }
            }
        }
    }
}