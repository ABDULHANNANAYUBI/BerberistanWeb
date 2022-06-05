using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace BerberistanWeb
{
    public class DbHelper
    {
        Configuration config;
        string connStr;
        SqlConnection connection;

        public DbHelper()
        {
            config = WebConfigurationManager.OpenWebConfiguration("~");
            connStr = config.ConnectionStrings.ConnectionStrings["DataConnect"].ConnectionString;
            connection = new SqlConnection(connStr);
        }

        public bool AddNewUser(User user)
        {
            int result;
            using (connection)
            {

                using (SqlCommand insertCommand = connection.CreateCommand())

                {
                    insertCommand.CommandText = "INSERT INTO [User](UserName, Password, PhoneNumber, City, District, MailAddress, Name, Surname) VALUES (@UserName, @Password, @PhoneNumber, @City, @District, @MailAddress, @Name, @Surname)";
                    insertCommand.Parameters.Add("@UserName", user.UserName);
                    insertCommand.Parameters.Add("@Password", user.Password);
                    insertCommand.Parameters.Add("@PhoneNumber", user.PhoneNumber);
                    insertCommand.Parameters.Add("@City", user.City);
                    insertCommand.Parameters.Add("@District", user.District);
                    insertCommand.Parameters.Add("@MailAddress", user.MailAddress);
                    insertCommand.Parameters.Add("@Name", user.Name);
                    insertCommand.Parameters.Add("@Surname", user.Surname);

                    insertCommand.Connection.Open();
                    result = insertCommand.ExecuteNonQuery();
                    insertCommand.Connection.Close();

                }
            }

            if (result > 0)
                return true;
            else
                return false;

        }

        public bool AddNewDealer(Dealer dealer)
        {
            int result;
            using (connection)
            {

                using (SqlCommand insertCommand = connection.CreateCommand())

                {
                    insertCommand.CommandText = "INSERT INTO [Dealer](DealerName, PhoneNumber, City, District, UserUserID) VALUES (@DealerName, @PhoneNumber, @City, @District, @UserUserID)";
                    insertCommand.Parameters.Add("@DealerName", dealer.DealerName);
                    insertCommand.Parameters.Add("@PhoneNumber", dealer.PhoneNumber);
                    insertCommand.Parameters.Add("@City", dealer.City);
                    insertCommand.Parameters.Add("@District", dealer.District);
                   // insertCommand.Parameters.Add("@Photo", dealer.Photo);
                    insertCommand.Parameters.Add("@UserUserID", dealer.UserUserID);

                    insertCommand.Connection.Open();
                    result = insertCommand.ExecuteNonQuery();
                    insertCommand.Connection.Close();

                }
            }

            if (result > 0)
                return true;
            else
                return false;

        }

        public User GetUser(string userName, string password)
        {
            User user = null;

            connection.Open();

            SqlCommand command = new SqlCommand("SELECT UserID, UserName, Password, PhoneNumber, MailAddress, Name, Surname, City, District FROM [User] WHERE UserName = @UserName AND Password = @Password", connection);
            command.Parameters.AddWithValue("@UserName", userName);
            command.Parameters.AddWithValue("@Password", password);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    user = new User()
                    {
                        UserID = Convert.ToInt32(reader["UserID"].ToString()),
                        UserName = reader["UserName"].ToString(),
                        Password = reader["Password"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        MailAddress = reader["MailAddress"].ToString(),
                        Name = reader["Name"].ToString(),
                        Surname = reader["Surname"].ToString(),
                        City = reader["City"].ToString(),
                        District = reader["District"].ToString()
                    };
                }
            }

            connection.Close();

            return user;
        }
    }
}