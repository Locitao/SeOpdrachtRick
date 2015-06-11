using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Steam
{
    public partial class Fighting : System.Web.UI.Page
    {
        readonly Administration admin = new Administration();
        readonly List<Game> fightGames  = new List<Game>();
        private Account acc;

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

            if (Session["Games"] == null && !IsPostBack)
            {
                Session_Games();
                Fill_Fighting();
                Fill_Listbox();
            }

            else if (!IsPostBack)
            {
                Fill_Fighting();
                Fill_Listbox();
            }

            else
            {
                Fill_Fighting();
            }

            if (Session["cart"] != null)
            {
                admin.shoppingCart = (List<Game>) Session["cart"];
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Signup.aspx");
        }

        protected void Session_Games()
        {
            admin.Fill_Games();
            Session["Games"] = null;
            Session["Games"] = admin.games;
        }

        protected void Fill_Fighting()
        {
            List<Game> allGames = (List<Game>)Session["Games"];

            foreach (var g in allGames.Where(g => g.CategoryId == 3))
            {
                fightGames.Add(g);
            }
        }

        protected void Fill_Listbox()
        {
            lbFighting.Items.Clear();
            foreach (var g in fightGames)
            {
                lbFighting.Items.Add(g.ToString());
            }
        }

        protected void mmo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Mmorpg.aspx");
        }

        protected void races_Click(object sender, EventArgs e)
        {
            Response.Redirect("Racing.aspx");
        }

        protected void fighting_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('You are already on this page!')", true);
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

            if (lbFighting.SelectedValue == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('If you want to purchase a game, select one in the list!')", true);
            }

            else
            {
                var gameText = lbFighting.SelectedValue;
                foreach (var s in fightGames.Where(s => s.ToString() == gameText))
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

        protected void Fill_Reviews(int productId)
        {
            string allReviews = admin.Find_Reviews(productId);
            lblReviews.Text = allReviews;
        }

        protected void reviews_Click(object sender, EventArgs e)
        {
            int productid = 0;

            string gameText = lbFighting.SelectedValue;

            foreach (var s in fightGames.Where(s => s.ToString() == gameText))
            {
                productid = s.GameId;
            }

            Fill_Reviews(productid);
        }
    }
}