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

        /// <summary>
        /// This method inserts a new account into the database.
        /// </summary>
        /// <param name="name">Name of the user.</param>
        /// <param name="password">Users password</param>
        /// <param name="email">Users email</param>
        /// <param name="birthdate">Users birthdate.</param>
        /// <returns>Returns an error message or a message that the account has been created.</returns>
        public string Insert_Account(string name, string password, string email, string birthdate)
        {
            try
            {
                string query =
                    "INSERT INTO USER_ACCOUNT (acc_ID, name_user, passw, email_address, birth_date) VALUES " +
                    "(auto_inc_acc.nextval, '" + name + "', '" + password + "', '" + email + "', '" + birthdate + "')";
                conn.Execute(query);
                const string succes = "Account created!";
                return succes;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// This method inserts a review into the database.
        /// </summary>
        /// <param name="description">The description/text of the review</param>
        /// <param name="number">The rating of the review</param>
        /// <param name="accId">The account which posts the review.</param>
        /// <param name="productId">The product to which the review belongs.</param>
        /// <returns>Returns an error message or a message that the review was created.</returns>
        public string Insert_Review(string description, int number, int accId, int productId)
        {
            try
            {
                string query = "INSERT INTO REVIEW (review_ID, rev_description, rating, acc_ID, product_ID) VALUES " +
                           "(auto_inc_rev.nextval, '" + description + "', '" + number + "', '" + accId + "', '" +
                           productId + "')";
                conn.Execute(query);
                const string succes = "Review created.";
                return succes;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        /// <summary>
        /// This method inserts a message (to another user) in the database.
        /// </summary>
        /// <param name="accId">The senders' acc_id.</param>
        /// <param name="accIdTwo">The receivers' acc_id</param>
        /// <param name="text">Text of the message.</param>
        /// <param name="date">When the message was sent.</param>
        /// <returns>Returns an error message or a message that the message has been sent.</returns>
        public string Insert_Message(int accId, int accIdTwo, string text, string date)
        {
            try
            {
                string query = "INSERT INTO POST (post_ID, acc_ID, acc_ID_two, post_text, post_date) VALUES " +
                                           "(auto_inc_pst.nextval, '" + accId + "', '" + accIdTwo + "', '" + text + "', '" + date +
                                           "')";
                conn.Execute(query);
                const string succes = "Message send.";
                return succes;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        public string Insert_Game(int accId, int gameId)
        {
            try
            {
                string query = "INSERT INTO AC_LIBRARY (library_ID, acc_ID, product_ID) VALUES " +
                               "(auto_inc_lib.nextval, '" + accId + "', '" + gameId + "')";
                conn.Execute(query);
                const string succes = "Game purchased and has been added to your library!";
                return succes;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}