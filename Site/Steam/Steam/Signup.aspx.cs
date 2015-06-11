using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Steam
{
    public partial class Signup : System.Web.UI.Page
    {
        
        
        Administration admin = new Administration();
        protected void Page_Load(object sender, EventArgs e)
        {
           /*
           HttpCookie userCookie = new HttpCookie("UserData");
           userCookie["Name"] = "testname";
           userCookie["Password"] = "test";
           userCookie.Expires = DateTime.Now.AddDays(30);
           Response.Cookies.Add(userCookie);
           Response.Write(Request.Cookies["UserData"].Value);
            */
            
        }
        /// <summary>
        /// Button is used to create an account.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            /*
            Page home = HttpContext.Current.Handler as Page;
            if (home != null)
            {
              ScriptManager.RegisterStartupScript(home, home.GetType(), "err_msg", "alert('Thank you for signing up. You can now login.');window.location='Front Page.aspx';", true);  
            }
             */
            //Some simple validation of user data.
            if (tbBirthdate.Text.Length < 4)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Birthdate is too short.')", true);
            }
            else if (tbSignupEmail.Text.Length < 5)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Email is too short.')", true);
            }
            else if (tbSignupName.Text.Length < 3)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Name is too short.')", true);

            }
            else if (tbSignupPassword.Text.Length < 4 || tbSignupPassword.Text == "penis") //small easter egg 
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Password is too short.')", true);

            }
            else
            {
                Session["UserData"] = null;
                var name = tbSignupName.Text;
                var email = tbSignupEmail.Text;
                var password = tbSignupPassword.Text;
                var birthdate = tbBirthdate.Text;
                if (admin.Insert_Account(name, email, password, birthdate))
                {
                    Account registeredAccount = new Account(name, password, email, birthdate);
                    Session["newAccount"] = registeredAccount;
                    Page home = HttpContext.Current.Handler as Page;
                    if (home != null)
                    {
                        ScriptManager.RegisterStartupScript(home, home.GetType(), "err_msg", "alert('Thank you for signing up. You can now login.');window.location='Front Page.aspx';", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Failed to create account. Get in touch with the developer.')", true);
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //This was a test, to see if I could cast a session back to an account object. 
            //Response.Write(Session["UserData"]);
            try
            {
                if (tbLoginEmail.Text == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Your email is incorrect.')", true);
                }
                else if (tbLoginPassword == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Password is empty.')", true);
                }
                else
                {
                    var email = tbLoginEmail.Text;
                    var password = tbLoginPassword.Text;
                    Account acc;
                    acc = admin.Login(email, password);
                    Session["UserData"] = null;
                    Session["UserData"] = acc;

                    if (password == acc.Password && email == acc.Email)
                    {
                        Page home = HttpContext.Current.Handler as Page;
                        if (home != null)
                        {
                            ScriptManager.RegisterStartupScript(home, home.GetType(), "err_msg", "alert('You logged in.');window.location='Front Page.aspx';", true);
                        } 
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Password or email is incorrect.')", true);
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
    }
}