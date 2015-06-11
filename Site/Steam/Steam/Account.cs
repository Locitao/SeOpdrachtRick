using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steam
{
    /// <summary>
    /// This class will be used to save an instance of an account, to use in the application.
    /// </summary>
    [Serializable]
    public class Account
    {
        /// <summary>
        /// Fields.
        /// </summary>
        private int id;
        private string name;
        private string password;
        private string email;
        private string birthdate;
        private int balance;

        /// <summary>
        /// Properties.
        /// </summary>
        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Birthdate { get { return birthdate; } set { birthdate = value; } }
        public int Balance { get { return balance; } set { balance = value; } }

        /// <summary>
        /// Constructor, based on the ACCOUNT table from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="birthdate"></param>
        /// <param name="balance"></param>
        public Account(int id, string name, string password, string email, string birthdate, int balance)
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            Birthdate = birthdate;
            Balance = balance;
        }

        public Account(string name, string password, string email, string birthdate)
        {
            Name = name;
            Password = password;
            Email = email;
            Birthdate = birthdate;
        }
        /// <summary>
        /// ToString method returns information about the account.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string data = Convert.ToString(Id) + ", " + Name + ", " + Email + ", " + Convert.ToString(Birthdate) + ".";
            return data;
        }
    }
}