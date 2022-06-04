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
    }
}