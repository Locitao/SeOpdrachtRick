using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;


namespace Steam
{
    public class Administration
    {
        public Account account;
        public Insert insert = new Insert();
        public Select select = new Select();
        public Update update = new Update();

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
    }
}