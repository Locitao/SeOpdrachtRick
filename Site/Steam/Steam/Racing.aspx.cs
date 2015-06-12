using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Steam
{
    public partial class Racing : Page
    {
        private readonly Administration _admin = new Administration();
        private readonly List<Game> _racegames = new List<Game>();
        private readonly Account _acc;

        public Racing(Account acc)
        {
            _acc = acc;
        }

        //Same as Mmorpg, see comments there for details.
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

            if (Session["Games"] == null && !IsPostBack)
            {
                Session_Games();
                Fill_Racing();
                Fill_Listbox();
            }

            else if (!IsPostBack)
            {
                Fill_Racing();
                Fill_Listbox();
            }

            else
            {
                Fill_Racing();
            }

            if (Session["cart"] != null)
            {
                _admin.ShoppingCart = (List<Game>) Session["cart"];
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Signup.aspx");
        }

        protected void Session_Games()
        {
            _admin.Fill_Games();
            Session["Games"] = null;
            Session["Games"] = _admin.Games;
        }

        protected void Fill_Racing()
        {
            var allGames = (List<Game>) Session["Games"];

            foreach (var g in allGames.Where(g => g.CategoryId == 2))
            {
                _racegames.Add(g);
            }
        }

        protected void Fill_Listbox()
        {
            lbRacing.Items.Clear();
            foreach (var g in _racegames)
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
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage",
                "alert('You are already on this page!')", true);
        }

        protected void fighting_Click(object sender, EventArgs e)
        {
            Response.Redirect("Fighting.aspx");
        }

        protected void buy_Click(object sender, EventArgs e)
        {
            if (_acc == null)
            {
                var home = HttpContext.Current.Handler as Page;
                if (home != null)
                {
                    ScriptManager.RegisterStartupScript(home, home.GetType(), "err_msg",
                        "alert('You need to log in first.');window.location='Signup.aspx';", true);
                }
            }

            if (lbRacing.SelectedValue == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage",
                    "alert('If you want to purchase a game, select one in the list!')", true);
            }

            else
            {
                var gameText = lbRacing.SelectedValue;
                foreach (var s in _racegames.Where(s => s.ToString() == gameText))
                {
                    _admin.ShoppingCart.Add(s);
                    Session["cart"] = _admin.ShoppingCart;
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
            var allReviews = _admin.Find_Reviews(productId);
            lblReviews.Text = allReviews;
        }

        protected void reviews_Click(object sender, EventArgs e)
        {
            var productid = 0;

            var gameText = lbRacing.SelectedValue;

            foreach (var s in _racegames.Where(s => s.ToString() == gameText))
            {
                productid = s.GameId;
            }

            Fill_Reviews(productid);
        }
    }
}