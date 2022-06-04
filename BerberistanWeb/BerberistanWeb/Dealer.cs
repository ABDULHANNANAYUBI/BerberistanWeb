using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BerberistanWeb
{
    public class Dealer
    {
        private int dealerID;
        private string dealerName;
        private string phoneNumber;
        private string city;
        private string district;
        private Byte[] photo;
        private int userUserID;
        private string mailAddress;

        public int DealerID { get => dealerID; set => dealerID = value; }
        public string DealerName { get => dealerName; set => dealerName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string City { get => city; set => city = value; }
        public string District { get => district; set => district = value; }
        public byte[] Photo { get => photo; set => photo = value; }
        public int UserUserID { get => userUserID; set => userUserID = value; }
        public string MailAddress { get => mailAddress; set => mailAddress = value; }

        public Dealer(int dealerID, string dealerName, string phoneNumber, string city, string district, Byte[] photo, int userUserID, string mailAddress)
        {
            this.dealerID = dealerID;
            this.dealerName = dealerName;
            this.phoneNumber = phoneNumber;
            this.city = city;
            this.district = district;
            this.photo = photo;
            this.userUserID = userUserID;
            this.mailAddress = mailAddress;
        }
    }
}