using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BerberistanWeb
{
    public class User
    {
        private int userID;
        private string userName;
        private string password;
        private string mailAddress;
        private string name;
        private string surname;
        private string city;
        private string district;

        public int UserID { get => userID; set => userID = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string MailAddress { get => mailAddress; set => mailAddress = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string City { get => city; set => city = value; }
        public string District { get => district; set => district = value; }

        public User(int userID, string userName, string password, string mailAddress, string name, string surname, string city, string district)
        {
            this.userID = userID;
            this.userName = userName;
            this.password = password;
            this.mailAddress = mailAddress;
            this.name = name;
            this.surname = surname;
            this.city = city;
            this.district = district;
        }

    }
}