using System;
using System.Collections.Generic;
using System.Linq;

namespace Steam
{
    /// <summary>
    ///     This class is the backbone of the application, doing all the heavy lifting.
    /// </summary>
    public class Administration
    {
        /// <summary>
        ///     Fields/properties.
        /// </summary>
        public Account Account;

        public List<Category> Categories = new List<Category>();
        public List<Game> Games = new List<Game>();
        public Insert Insert = new Insert();
        public Select Select = new Select();
        public List<Game> ShoppingCart = new List<Game>();
        public Update Update = new Update();

        /// <summary>
        ///     Used to login as a user. Returns an instance of Account when the account is found in the database.
        /// </summary>
        /// <param name="email">Email of the user who wants to log in.</param>
        /// <param name="password">Password of the user who wants to log in.</param>
        /// <returns></returns>
        public Account Login(string email, string password)
        {
                var id = 0;
                var name = "tempname";
                var pw = "temppw";
                var mail = "tempmail";
                var birthdate = "tempDate";
                var balance = 0;

                var data = Select.Select_Account(email, password);

                foreach (var row in data)
                {
                    id = Convert.ToInt32(row["ACC_ID"]);
                    name = Convert.ToString(row["NAME_USER"]);
                    pw = Convert.ToString(row["PASSW"]);
                    mail = Convert.ToString(row["EMAIL_ADDRESS"]);
                    birthdate = Convert.ToString(row["BIRTH_DATE"]);
                    balance = Convert.ToInt32(row["STEAM_BALANCE"]);
                }

                Account = new Account(id, name, pw, mail, birthdate, balance);
                return Account;
            
            
        }

        /// <summary>
        ///     Returns information of the account that is currently selected.
        /// </summary>
        /// <returns>Account data</returns>
        public string Get_Account_Data()
        {
            try
            {
                var data = Account.ToString();
                return data;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        ///     Inserts an account into the database with the insert class.
        /// </summary>
        /// <param name="name">Name for the account holder.</param>
        /// <param name="email">Email of the account holder.</param>
        /// <param name="password">Password of the account holder.</param>
        /// <param name="birthdate">And his birthdate</param>
        /// <returns>Returns true or false, depending on if it succeeded or not.</returns>
        public bool Insert_Account(string name, string email, string password, string birthdate)
        {
            try
            {
                Insert.Insert_Account(name, password, email, birthdate);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        ///     Fills the list of games with all games from the database.
        /// </summary>
        /// <returns></returns>
        public bool Fill_Games()
        {
            try
            {
                var data = Select.Select_All_Games();

                foreach (var row in data)
                {
                    var gameId = Convert.ToInt32(row["PRODUCT_ID"]);
                    var categoryId = Convert.ToInt32(row["CATEGORY_ID"]);
                    var name = Convert.ToString(row["PR_NAME"]);
                    var price = Convert.ToInt32(row["PRICE"]);
                    var description = Convert.ToString(row["PR_DESCRIPTION"]);
                    var game = new Game(gameId, categoryId, description, name, price);
                    Games.Add(game);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        ///     Add a game to an account, and inserts it into the database.
        /// </summary>
        /// <param name="accId"></param>
        /// <param name="gameId"></param>
        /// <returns></returns>
        public bool Add_Game(int accId, int gameId)
        {
            try
            {
                Insert.Insert_Library(accId, gameId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        ///     Add funds to the wallet of the selected account.
        /// </summary>
        /// <param name="acc"></param>
        /// <returns></returns>
        public bool Increase_wallet(Account acc)
        {
            try
            {
                Update.Increase_Wallet(acc.Balance, acc.Id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        ///     Removes funds from the wallet of the account.
        /// </summary>
        /// <param name="acc"></param>
        /// <returns></returns>
        public bool Decrease_Wallet(Account acc)
        {
            try
            {
                Update.Decrease_Wallet(acc.Balance, acc.Id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        ///     Finds the reviews belonging to the selected product.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public string Find_Reviews(int productId)
        {
            try
            {
                var data = Select.Select_Reviews(productId);
                var returndata = "";
                foreach (var row in data)
                {
                    var description = Convert.ToString(row["REV_DESCRIPTION"]);
                    var rating = Convert.ToString(row["RATING"]);
                    var name = Select.Select_Account_Name(Convert.ToString(row["ACC_ID"]));
                    returndata = returndata + name + ": " + rating + ", " + description + "<br />";
                }
                return returndata;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        ///     Finds the games belonging to the given user.
        /// </summary>
        /// <param name="accId"></param>
        /// <returns></returns>
        public List<Game> Find_Games(int accId)
        {
            var data = Select.Select_Games_User(accId);

            return (from s in data let gameid = Convert.ToInt32(s["PRODUCT_ID"]) let categoryid = Convert.ToInt32(s["CATEGORY_ID"]) let description = Convert.ToString(s["PR_DESCRIPTION"]) let name = Convert.ToString(s["PR_NAME"]) let price = Convert.ToInt32(s["PRICE"]) select new Game(gameid, categoryid, description, name, price)).ToList();
        }
    }
}