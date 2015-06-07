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
        private Account account;
        private Insert insert;
        private Select select;
        private Update update;

        private void Login(string email, string password)
        {
            int id = 0;
            string name = "tempname";
            string pw = "temppw";
            string mail = "tempmail";
            DateTime birthdate = new DateTime(1990, 10, 10);
            int balance = 0;

            var data = select.Select_Account(email, password);

            foreach (Dictionary<string, object> row in data)
            {
                id = Convert.ToInt32(row["acc_ID"]);
                name = Convert.ToString(row["name_user"]);
                pw = Convert.ToString(row["passw"]);
                mail = Convert.ToString(row["email_address"]);
                birthdate = Convert.ToDateTime(row["birth_date"]);
                balance = Convert.ToInt32(row["steam_balance"]);
            }

            account = new Account(id, name, pw, mail, birthdate, balance);
            /*
            HttpCookie userCookie = new HttpCookie("UserData");
            userCookie["Name"] = "testname";
            userCookie["Password"] = password;
            userCookie.Expires = DateTime.Now.AddDays(30); */
            
            

        }

        public string Get_Account_Data()
        {
            string data = account.ToString();
            return data;
        }
    }
}