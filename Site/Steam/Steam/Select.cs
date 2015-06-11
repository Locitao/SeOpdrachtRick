using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steam
{
    /// <summary>
    /// This class will be used to get information out of the database, using SELECT statements.
    /// </summary>
    public class Select
    {
        /// <summary>
        /// Get's the users current balance.
        /// </summary>
        /// <param name="accId">acc_id of which the balance is looked up.</param>
        /// <returns>Int with the users balance.</returns>
        public int Select_Wallet(int accId)
        {
            
            var sql = "SELECT steam_balance FROM USER_ACCOUNT WHERE acc_ID = '" + accId + "'";
            var balance = 0;
            var data = Connection.ExecuteQuery(sql);

            foreach (Dictionary<string, object> row in data)
            {
                balance = Convert.ToInt32(row["STEAM_BALANCE"]);
            }
            return balance;
        }

        /// <summary>
        /// This method gets all the games which that acc_id has purchased.
        /// </summary>
        /// <param name="accId">Acc_id of whom we're going to get the library</param>
        /// <returns>A list<dictionary> object with all the rows of ac_library which has acc_id in it.</dictionary></returns>
        public List<Dictionary<string, object>> Select_Games(int accId)
        {
            var sql = "SELECT product_ID FROM AC_LIBRARY WHERE acc_ID = '" + accId + "'";
            var data = Connection.ExecuteQuery(sql);
            return data;
        }
        /// <summary>
        /// Finds all the information about the given name.
        /// </summary>
        /// <param name="gameId">ID of the game.</param>
        /// <returns>Dictionary with the information.</returns>
        public List<Dictionary<string, object>> Select_Game_Info(int gameId)
        {
            var sql =
                "SELECT product_ID, category_ID, pr_name, pr_description, price FROM PRODUCT WHERE product_ID = '" +
                gameId + "'";
            var data = Connection.ExecuteQuery(sql);
            return data;
        }
        /// <summary>
        /// Finds all the account information.
        /// </summary>
        /// <param name="email">Email that is given to identify the account.</param>
        /// <param name="password">Password for the account.</param>
        /// <returns>All the information for the account.</returns>
        public List<Dictionary<string, object>> Select_Account(string email, string password)
        {
            var sql =
                "SELECT acc_ID, name_user, steam_balance, email_address, birth_date, passw FROM USER_ACCOUNT WHERE email_address = '" +
                email + "' AND passw = '" + password + "'";
            var data = Connection.ExecuteQuery(sql);
            return data;
        }
        /// <summary>
        /// Returns a list of games belonging to the given category.
        /// </summary>
        /// <param name="catId">ID of the category whose games we want to get.</param>
        /// <returns>List of dictionary objects with the games.</returns>
        public List<Dictionary<string, object>> Select_Category_Games(int catId)
        {
            var sql = "SELECT product_ID, pr_name, pr_description, price FROM PRODUCT WHERE category_ID = '" + catId +
                      "'";
            var data = Connection.ExecuteQuery(sql);
            return data;
        }
        /// <summary>
        /// Returns the category_ID and description of the selected category.
        /// </summary>
        /// <param name="description">Description of the category</param>
        /// <returns>category_ID and category description.</returns>
        public List<Dictionary<string, object>> Select_Category(string description)
        {
            var sql = "SELECT category_ID, cat_description FROM PROD_CATEGORY WHERE cat_description = '" + description +
                      "'";
            var data = Connection.ExecuteQuery(sql);
            return data;
        }
        /// <summary>
        /// Selects all the games. I realize that, if the database were a lot bigger, this would not be a good idea. However, here I
        /// just wanted to see if I could do it, since I had a plan to try and use Linq.
        /// </summary>
        /// <returns>List of dictionary objects of all the games.</returns>
        public List<Dictionary<string, object>> Select_All_Games()
        {
            const string sql = "SELECT * FROM PRODUCT";
            var data = Connection.ExecuteQuery(sql);
            return data;
        }

        public List<Dictionary<string, object>> Select_Reviews(int productId)
        {
            string sql = "SELECT * FROM REVIEW WHERE product_ID = '" + productId + "'";
            var data = Connection.ExecuteQuery(sql);
            return data;
        }

        public string Select_Account_Name(string accId)
        {
            try
            {
                string sql = "SELECT NAME_USER FROM USER_ACCOUNT WHERE ACC_ID = '" + accId + "'";
                var data = Connection.ExecuteQuery(sql);

                string returndata = "";
                foreach (Dictionary<string, object> x in data)
                {
                    returndata = Convert.ToString(x["NAME_USER"]);
                }

                return returndata;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        public List<Dictionary<string, object>> Select_Games_User(int accId)
        {
            try
            {
                string sql =
                    "SELECT * FROM PRODUCT WHERE PRODUCT_ID IN (SELECT PRODUCT_ID FROM AC_LIBRARY WHERE ACC_ID = '" +
                    accId + "')";
                var data = Connection.ExecuteQuery(sql);
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}