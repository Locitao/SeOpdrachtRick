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

        public List<Dictionary<string, object>> Select_Game_Info(int gameId)
        {
            var sql =
                "SELECT product_ID, category_ID, pr_name, pr_description, price FROM PRODUCT WHERE product_ID = '" +
                gameId + "'";
            var data = Connection.ExecuteQuery(sql);
            return data;
        }

        public List<Dictionary<string, object>> Select_Account(string email, string password)
        {
            var sql =
                "SELECT acc_ID, name_user, steam_balance, email_address, birth_date FROM USER_ACCOUNT WHERE email_address = '" +
                email + "' AND passw = '" + password + "'";
            var data = Connection.ExecuteQuery(sql);
            return data;
        }


    }
}