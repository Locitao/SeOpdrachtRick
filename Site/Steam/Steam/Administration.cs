using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;


namespace Steam
{
    /// <summary>
    /// This class is the backbone of the application, doing all the heavy lifting.
    /// </summary>
    public class Administration
    {
        /// <summary>
        /// Fields/properties.
        /// </summary>
        public Account account;
        public Insert insert = new Insert();
        public Select select = new Select();
        public Update update = new Update();
        public List<Game> games = new List<Game>();
        public List<Category> categories = new List<Category>();
        public List<Game> shoppingCart = new List<Game>(); 

        /// <summary>
        /// Used to login as a user. Returns an instance of Account when the account is found in the database.
        /// </summary>
        /// <param name="email">Email of the user who wants to log in.</param>
        /// <param name="password">Password of the user who wants to log in.</param>
        /// <returns></returns>
        public Account Login(string email, string password)
        {
            try
            {
                int id = 0;
                string name = "tempname";
                string pw = "temppw";
                string mail = "tempmail";
                string birthdate = "tempDate";
                int balance = 0;

                var data = select.Select_Account(email, password);

                foreach (Dictionary<string, object> row in data)
                {
                    id = Convert.ToInt32(row["ACC_ID"]);
                    name = Convert.ToString(row["NAME_USER"]);
                    pw = Convert.ToString(row["PASSW"]);
                    mail = Convert.ToString(row["EMAIL_ADDRESS"]);
                    birthdate = Convert.ToString(row["BIRTH_DATE"]);
                    balance = Convert.ToInt32(row["STEAM_BALANCE"]);
                }

                account = new Account(id, name, pw, mail, birthdate, balance);
                return account;
            }
            catch (Exception)
            {
                
                throw;
            }
            
            
            
            

        }
        /// <summary>
        /// Returns information of the account that is currently selected.
        /// </summary>
        /// <returns>Account data</returns>
        public string Get_Account_Data()
        {
            try
            {
                string data = account.ToString();
                return data;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        /// <summary>
        /// Inserts an account into the database with the insert class.
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
                insert.Insert_Account(name, password, email, birthdate);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Fill_Games()
        {
            try
            {
                var data = select.Select_All_Games();

                foreach (Dictionary<string, object> row in data)
                {
                    var gameId = Convert.ToInt32(row["PRODUCT_ID"]);
                    var categoryId = Convert.ToInt32(row["CATEGORY_ID"]);
                    var name = Convert.ToString(row["PR_NAME"]);
                    var price = Convert.ToInt32(row["PRICE"]);
                    var description = Convert.ToString(row["PR_DESCRIPTION"]);
                    Game game = new Game(gameId, categoryId, description, name, price);
                    games.Add(game);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public bool Add_Game(int accId, int gameId)
        {
            try
            {
                var x = insert.Insert_Library(accId, gameId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Increase_wallet(Account acc)
        {
            try
            {
                update.Increase_Wallet(acc.Balance, acc.Id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Decrease_Wallet(Account acc)
        {
            try
            {
                update.Decrease_Wallet(acc.Balance, acc.Id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string Find_Reviews(int productId)
        {
            try
            {
                var data = select.Select_Reviews(productId);
                string returndata = "";
                foreach (Dictionary<string, object> row in data)
                {
                    string description = Convert.ToString(row["REV_DESCRIPTION"]);
                    string rating = Convert.ToString(row["RATING"]);
                    string name = select.Select_Account_Name(Convert.ToString(row["ACC_ID"]));
                    returndata = returndata + name + ": " + rating + ", " + description + "<br />";
                    
                }
                return returndata;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Game> Find_Games(int accId)
        {
            List<Game> games = new List<Game>();

            var data = select.Select_Games_User(accId);

            foreach (var s in data)
            {
                int gameid = Convert.ToInt32(s["PRODUCT_ID"]);
                int categoryid = Convert.ToInt32(s["CATEGORY_ID"]);
                string description = Convert.ToString(s["PR_DESCRIPTION"]);
                string name = Convert.ToString(s["PR_NAME"]);
                int price = Convert.ToInt32(s["PRICE"]);

                Game g = new Game(gameid, categoryid, description, name, price);
                games.Add(g);
            }

            return games;
        }
    }
}