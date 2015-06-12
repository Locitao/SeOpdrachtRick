using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Steam
{
    public partial class Mmorpg : Page
    {
        private readonly Administration _admin = new Administration();
        private readonly List<Game> _mmorpgs = new List<Game>();
        private Account _acc;

        /// <summary>
        ///     During the loading of the page, a check takes place to see if the user is logged in. It also fills the listbox with
        ///     the appropriate
        ///     items.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserData"] != null)
            {
                _acc = (Account) Session["UserData"];
                btnLogin.Text = "Welcome " + _acc.Name + " €" + _acc.Balance + ".";
            }
            else if (Session["newAccount"] != null)
            {
                _acc = (Account) Session["newAccount"];
                btnLogin.Text = "Welcome " + _acc.Name + " €" + _acc.Balance + ".";
            }

            if (Session["Games"] == null && !IsPostBack)
            {
                Session_Games();
                Fill_Mmorpg();
                Fill_Listbox();
            }

            else if (!IsPostBack)
            {
                Fill_Mmorpg();
                Fill_Listbox();
            }

            else
            {
                Fill_Mmorpg();
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

        /// <summary>
        ///     Puts all available games in a Session, to be used at my discretion.
        /// </summary>
        protected void Session_Games()
        {
            _admin.Fill_Games();
            Session["Games"] = null;
            Session["Games"] = _admin.Games;
        }

        /// <summary>
        ///     Find all MMORPGS and add em to the list.
        /// </summary>
        protected void Fill_Mmorpg()
        {
            var allGames = (List<Game>) Session["Games"];
            /* sadly enough, I couldn't get Linq to work
            mmorpgs =
                from Game in allGames
                where (Game.CategoryId == 1)
                select Game; */

            foreach (var g in allGames.Where(g => g.CategoryId == 1))
            {
                _mmorpgs.Add(g);
            }
        }

        /// <summary>
        ///     Fill the listbox with all MMORPGs.
        /// </summary>
        protected void Fill_Listbox()
        {
            lbMmorpg.Items.Clear();
            foreach (var g in _mmorpgs)
            {
                lbMmorpg.Items.Add(g.ToString());
            }
        }

        protected void mmo_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage",
                "alert('You are already on this page!')", true);
        }

        protected void racing_Click(object sender, EventArgs e)
        {
            Response.Redirect("Racing.aspx");
        }

        protected void fighting_Click(object sender, EventArgs e)
        {
            Response.Redirect("Fighting.aspx");
        }

        /// <summary>
        ///     Event handler for purchasing the selected game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            if (lbMmorpg.SelectedValue == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage",
                    "alert('If you want to purchase a game, select one in the list!')", true);
            }
            else
            {
                //string gameText = lbMmorpg.SelectedItem.ToString(); //null
                //string gameText = String.Join(", ",
                //  lbMmorpg.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value)); //empty string
                var gameText = lbMmorpg.SelectedValue; //null

                foreach (var s in _mmorpgs.Where(s => s.ToString() == gameText))
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

        protected void lbMmorpg_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     Get's all the reviews belonging to a product, puts them in a listbox.
        /// </summary>
        /// <param name="productId"></param>
        protected void Fill_Reviews(int productId)
        {
            var allReviews = _admin.Find_Reviews(productId);
            lblReviews.Text = allReviews;
        }

        /// <summary>
        ///     Finds reviews and stuff.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void reviews_Click(object sender, EventArgs e)
        {
            var productid = 0;

            var gameText = lbMmorpg.SelectedValue;

            foreach (var s in _mmorpgs.Where(s => s.ToString() == gameText))
            {
                productid = s.GameId;
            }

            Fill_Reviews(productid);
        }
    }
}