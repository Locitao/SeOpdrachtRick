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
        readonly Administration admin = new Administration();
        readonly List<Game> mmorpgs = new List<Game>();
        private Account acc;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserData"] != null)
            {
                acc = (Account)Session["UserData"];
                btnLogin.Text = "Welcome " + acc.Name + " €" + acc.Balance + ".";
            }
            else if (Session["newAccount"] != null)
            {
                acc = (Account)Session["newAccount"];
                btnLogin.Text = "Welcome " + acc.Name + " €" + acc.Balance + ".";
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
                admin.shoppingCart = (List<Game>)Session["cart"];
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
            lbMmorpg.Items.Clear();
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

        protected void fighting_Click(object sender, EventArgs e)
        {
            Response.Redirect("Fighting.aspx");
        }

        protected void buy_Click(object sender, EventArgs e)
        {
            if (acc == null)
            {
                Page home = HttpContext.Current.Handler as Page;
                if (home != null)
                {
                    ScriptManager.RegisterStartupScript(home, home.GetType(), "err_msg", "alert('You need to log in first.');window.location='Signup.aspx';", true);
                }
            }

            if (lbMmorpg.SelectedValue == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('If you want to purchase a game, select one in the list!')", true);
            }
            else
            {
                //string gameText = lbMmorpg.SelectedItem.ToString(); //null
                //string gameText = String.Join(", ",
                  //  lbMmorpg.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value)); //empty string
                string gameText = lbMmorpg.SelectedValue; //null

                foreach (var s in mmorpgs.Where(s => s.ToString() == gameText))
                {
                    admin.shoppingCart.Add(s);
                    Session["cart"] = admin.shoppingCart;
                }
            }
        }

        protected void toFrontPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Front Page.aspx");
        }

        protected void toCheckOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Checkout.aspx");
        }
    }
}