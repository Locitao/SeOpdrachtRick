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
        public int Select_Wallet(int accId)
        {
            string sql = "SELECT steam_balance FROM USER_ACCOUNT WHERE acc_ID = '" + accId + "'";
            int balance = 0;
            var data = Connection.ExecuteQuery(sql);

            foreach (Dictionary<string, object> row in data)
            {
                balance = Convert.ToInt32(row["STEAM_BALANCE"]);
            }
            return balance;
        }
    }
}