using System;

namespace Steam
{
    /// <summary>
    ///     This class will handle all the update statements.
    /// </summary>
    public class Update
    {
        private readonly Connection _conn = new Connection();

        /// <summary>
        ///     Updates a users wallet (adds money).
        /// </summary>
        /// <param name="money"></param>
        /// <param name="accId"></param>
        /// <returns></returns>
        public string Increase_Wallet(int money, int accId)
        {
            try
            {
                var query = "UPDATE USER_ACCOUNT SET steam_balance = '" + money + "' WHERE acc_ID = '" + accId + "'";
                _conn.Execute(query);
                const string succes = "Saldo added";
                return succes;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        ///     Decreases a users' wallet.
        /// </summary>
        /// <param name="money"></param>
        /// <param name="accId"></param>
        /// <returns></returns>
        public string Decrease_Wallet(int money, int accId)
        {
            try
            {
                var query = "UPDATE USER_ACCOUNT SET steam_balance = '" + money + "' WHERE acc_ID = '" + accId + "'";
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