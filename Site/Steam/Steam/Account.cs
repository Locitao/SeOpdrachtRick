using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steam
{
    public class Account
    {
        public int Id { get { return Id; } set { Id = value; } }
        public string Name { get { return Name; } set { Name = value; } }
        public string Password { get { return Password; } set { Password = value; } }
        public string Email { get { return Email; } set { Email = value; } }
        public DateTime Birthdate { get { return Birthdate; } set { Birthdate = value; } }
        public int Balance { get { return Balance; } set { Balance = value; } }

        public Account(int id, string name, string password, string email, DateTime birthdate, int balance)
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            Birthdate = birthdate;
            Balance = balance;
        }

        public override string ToString()
        {
            string data = Convert.ToString(Id) + ", " + Name + ", " + Email + ", " + Convert.ToString(Birthdate) + ".";
            return data;
        }
    }
}