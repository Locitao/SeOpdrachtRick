using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steam
{
    [Serializable]
    public class Account
    {
        private int id;
        private string name;
        private string password;
        private string email;
        private string birthdate;
        private int balance;


        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Birthdate { get { return birthdate; } set { birthdate = value; } }
        public int Balance { get { return balance; } set { balance = value; } }

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
        public override string ToString()
        {
            string data = Convert.ToString(Id) + ", " + Name + ", " + Email + ", " + Convert.ToString(Birthdate) + ".";
            return data;
        }
    }
}