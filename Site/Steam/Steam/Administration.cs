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

        public void Login(string email, string password)
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
                id = Convert.ToInt32(row["acc_ID"]);
                name = Convert.ToString(row["name_user"]);
                pw = Convert.ToString(row["passw"]);
                mail = Convert.ToString(row["email_address"]);
                birthdate = Convert.ToString(row["birth_date"]);
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