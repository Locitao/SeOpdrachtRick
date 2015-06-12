using System;

namespace Steam
{
    /// <summary>
    ///     This class will be used to save an instance of an account, to use in the application.
    /// </summary>
    [Serializable]
    public class Account
    {
        /// <summary>
        ///     Fields.
        /// </summary>
        private int _balance;
        private string _birthdate;
        private string _email;
        private int _id;
        private string _name;
        private string _password;

        /// <summary>
        ///     Constructor, based on the ACCOUNT table from the database.
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
        ///     Properties.
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Birthdate
        {
            get { return _birthdate; }
            set { _birthdate = value; }
        }

        public int Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        /// <summary>
        ///     ToString method returns information about the account.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var data = Convert.ToString(Id) + ", " + Name + ", " + Email + ", " + Convert.ToString(Birthdate) + ".";
            return data;
        }
    }
}