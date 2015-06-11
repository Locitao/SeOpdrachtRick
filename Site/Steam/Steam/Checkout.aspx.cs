using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Steam
{
    public partial class Checkout : System.Web.UI.Page
    {
        Administration admin = new Administration();
        private Account acc;
        private List<Game> buying; 
        protected void Page_Load(object sender, EventArgs e)
        {
            //Checks if the user is logged in; otherwise you're redirected to the log in page.
            if (Session["UserData"] != null)
            {
                acc = (Account)Session["UserData"];
                btnLogin.Text = "Welcome " + acc.Name + " €" + acc.Balance;

                if (IsPostBack) return;
                Fill_List();
                dropDownWallet.Items.Add("5");
                dropDownWallet.Items.Add("10");
                dropDownWallet.Items.Add("15");
                dropDownWallet.Items.Add("20");
                dropDownWallet.Items.Add("60");
                dropDownWallet.Items.Add("100");
            }
            else if (Session["newAccount"] != null)
            {
                acc = (Account) Session["newAccount"];
                btnLogin.Text = "Welcome " + acc.Name + ".";
            }

            else
            {
                Page home = HttpContext.Current.Handler as Page;
                if (home != null)
                {
                    ScriptManager.RegisterStartupScript(home, home.GetType(), "err_msg",
                    "alert('You need to log in first!');window.location='Signup.aspx';", true);
                }
                
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Signup.aspx");
        }

        /// <summary>
        /// Puts a list of the games you've got in your shopping cart, into the listbox.
        /// </summary>
        protected void Fill_List()
        {
            buying = (List<Game>)Session["cart"];

            if (buying == null) return;
            foreach (var s in buying)
            {
                lbCheckout.Items.Add(s.ToString());
            }
        }

        /// <summary>
        /// Buys the games currently in the listbox. Checks which payment method is used and adjusts accordingly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void buy_Click(object sender, EventArgs e)
        {
            admin.Fill_Games();
            Fill_List();
            int check = 0;
            if (rdIdeal.Checked) { check = 1;}
            if (rdPayPal.Checked) { check = 2;}
            if (rdWallet.Checked) { check = 3;}

            switch (check)
            {
                case 0:
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('You need to select a payment option.')", true);
                    break;
                case 1:
                    Session["cart"] = null;
                    Buy_Games();
                    Page home = HttpContext.Current.Handler as Page;
                    if (home != null)
                    {
                        ScriptManager.RegisterStartupScript(home, home.GetType(), "err_msg",
                        "alert('Your purchased games can now be found in your library.');window.location='Front Page.aspx';", true);
                    }
                    break;
                case 2:
                    Session["cart"] = null;
                    Buy_Games();
                    Page home2 = HttpContext.Current.Handler as Page;
                    if (home2 != null)
                    {
                        ScriptManager.RegisterStartupScript(home2, home2.GetType(), "err_msg",
                        "alert('Your purchased games can now be found in your library.');window.location='Front Page.aspx';", true);
                    }
                    break;
                case 3:
                    int x = buying.Aggregate(0, (current, y) => current + y.Price);
                    if (x > acc.Balance)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Please add funds to your wallet or pick a different payment method.')", true);
                    }
                    else
                    {
                        Buy_Games();
                        acc.Balance = acc.Balance - x;
                        admin.Decrease_Wallet(acc);
                        Session["UserData"] = acc;
                        Page home3 = HttpContext.Current.Handler as Page;
                        if (home3 != null)
                        {
                            ScriptManager.RegisterStartupScript(home3, home3.GetType(), "err_msg",
                            "alert('Your purchased games can now be found in your library.');window.location='Front Page.aspx';", true);
                        }
                    }
                    break;
            }

            
            
        }

        /// <summary>
        /// Adds the games to the users' account.
        /// </summary>
        protected void Buy_Games()
        {
            foreach (var x in buying)
            {
                foreach (var y in admin.games)
                {
                    if (x.GameId == y.GameId)
                    {
                        admin.Add_Game(acc.Id, x.GameId);
                    }
                }
            }
        }

        protected void toFrontPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Front Page.aspx");
        }

        /// <summary>
        /// Adds funds to the users' account (wallet).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddFunds_Click(object sender, EventArgs e)
        {
            if (dropDownWallet.SelectedItem == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Why would you want to add nothing to your wallet?')", true);
            }

            else
            {
                int funds = Convert.ToInt32(dropDownWallet.SelectedItem.Text);
                acc.Balance = acc.Balance + funds;
                Session["UserData"] = acc;
                admin.Increase_wallet(acc);
            }
        }
    }
}