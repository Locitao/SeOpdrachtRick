using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steam
{
    /// <summary>
    /// This class will handle all insert statements.
    /// </summary>
    public class Insert
    {
        Connection conn = new Connection();

        public string Insert_Account(string name, string password, string email, string birthdate)
        {
            try
            {
                string query =
                    "INSERT INTO USER_ACCOUNT (acc_ID, name_user, passw, email_address, birth_date) VALUES " +
                    "(auto_inc_acc.nextval, '" + name + "', '" + password + "', '" + email + "', '" + birthdate + "');";
                conn.Execute(query);
                const string succes = "Account created!";
                return succes;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Insert_Review(string description, int number, int accId, int productId)
        {
            try
            {
                string query = "INSERT INTO REVIEW (review_ID, rev_description, rating, acc_ID, product_ID) VALUES " +
                           "(auto_inc_rev.nextval, '" + description + "', '" + number + "', '" + accId + "', '" +
                           productId + "');";
                conn.Execute(query);
                const string succes = "Review created.";
                return succes;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        public string Insert_Message(int accId, int accIdTwo, string text, string date)
        {
            try
            {
                string query = "INSERT INTO POST (post_ID, acc_ID, acc_ID_two, post_text, post_date) VALUES " +
                                           "(auto_inc_pst.nextval, '" + accId + "', '" + accIdTwo + "', '" + text + "', '" + date +
                                           "');";
                conn.Execute(query);
                const string succes = "Message send.";
                return succes;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }
    }
}