using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steam
{
    /// <summary>
    /// This class will handle all the update statements.
    /// </summary>
    public class Update
    {
        readonly Connection _conn = new Connection();
        readonly Select _select  = new Select();

        public string Increase_Wallet(int money, int accId)
        {
            try
            {
                int balance = _select.Select_Wallet(accId);
                balance = balance + money;
            
                string query = "UPDATE USER_ACCOUNT SET steam_balance = '" + balance + "' WHERE acc_ID = '" + accId + "'";
                _conn.Execute(query);
                const string succes = "Saldo added";
                return succes;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Decrease_Wallet(int money, int accId)
        {
            try
            {
                int balance = _select.Select_Wallet(accId);
                balance = balance - money;

                string query = "UPDATE USER_ACCOUNT SET steam_balance = '" + balance + "' WHERE acc_ID = '" + accId + "'";
                _conn.Execute(query);
                const string succes = "Saldo added";
                return succes;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}