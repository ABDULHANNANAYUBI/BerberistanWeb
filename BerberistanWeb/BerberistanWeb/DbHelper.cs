using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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

        public void InsertAppointment(Appointment app)
        {
            int result;
            using (connection)
            {
                using (SqlCommand insertCommand = connection.CreateCommand())
                {
                    insertCommand.CommandText = "INSERT INTO [Appointment](AppointmentStartTime, AppointmentFinishTime, DealerDealerID, UserUserID) VALUES (@AppointmentStartTime, @AppointmentFinishTime, @DealerDealerID, @UserUserID)";
                    insertCommand.Parameters.Add("@AppointmentStartTime", app.AppointmentStartTime);
                    insertCommand.Parameters.Add("@AppointmentFinishTime", app.AppointmentEndTime);
                    insertCommand.Parameters.Add("@DealerDealerID", app.DealerDealerID);
                    insertCommand.Parameters.Add("@UserUserID", app.UserUserID);

                    insertCommand.Connection.Open();
                    result = insertCommand.ExecuteNonQuery();
                    insertCommand.Connection.Close();
                }
            }
        }

        public void InsertServices(DealerService dealerService, int userID)
        {
            int result;
            using (connection)
            {
                using (SqlCommand insertCommand = connection.CreateCommand())
                {
                    insertCommand.CommandText = "INSERT INTO [CustomerService](DealerID,UserID , ServiceName, ServiceFee) VALUES (@DealerID, @UserID, @ServiceName, @ServiceFee)";
                    insertCommand.Parameters.Add("@DealerID", dealerService.DealerDealerID);
                    insertCommand.Parameters.Add("@UserID", userID);
                    insertCommand.Parameters.Add("@ServiceName", dealerService.ServiceName);
                    insertCommand.Parameters.Add("@ServiceFee", dealerService.ServiceFee);

                    insertCommand.Connection.Open();
                    result = insertCommand.ExecuteNonQuery();
                    insertCommand.Connection.Close();
                }
            }
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

        public bool AddNewDealerService(DealerService dealerService, Dealer dealer)
        {
            int result;
            using (connection)
            {

                using (SqlCommand insertCommand = connection.CreateCommand())

                {
                    insertCommand.CommandText = "INSERT INTO [DealerService](ServiceName, ServiceTimeMinutes, ServiceFee, DealerDealerID) VALUES (@ServiceName, @ServiceTimeMinutes, @ServiceFee, @DealerDealerID)";
                    insertCommand.Parameters.Add("@ServiceName", dealerService.ServiceName);
                    insertCommand.Parameters.Add("@ServiceTimeMinutes", dealerService.ServiceTimeMinutes);
                    insertCommand.Parameters.Add("@ServiceFee", dealerService.ServiceFee);
                    insertCommand.Parameters.Add("@DealerDealerID", dealer.DealerID);

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

        public List<DealerService> GetDealerAllServices(int dealerDealerID)
        {
            List<DealerService> dealerAllServices = new List<DealerService>();
            DealerService dealerService = null;

            connection.ConnectionString = connStr;
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT ServiceID, ServiceName, ServiceTimeMinutes, ServiceFee, DealerDealerID FROM [DealerService] WHERE DealerDealerID = @DealerDealerID", connection);
            command.Parameters.AddWithValue("@DealerDealerID", dealerDealerID);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    dealerService = new DealerService()
                    {
                        ServiceID = Convert.ToInt32(reader["ServiceID"].ToString()),
                        ServiceName = reader["ServiceName"].ToString(),
                        ServiceTimeMinutes = Convert.ToInt32(reader["ServiceTimeMinutes"].ToString()),
                        ServiceFee = Convert.ToDouble(reader["ServiceFee"].ToString()),
                        DealerDealerID = Convert.ToInt32(reader["DealerDealerID"].ToString())
                    };
                    dealerAllServices.Add(dealerService);
                }
            }

            connection.Close();

            return dealerAllServices;
        }

        public bool AddNewDealerServiceDealer(DealerService_Dealer dealerService_Dealer)
        {
            int result;

            using (connection)
            {

                using (SqlCommand insertCommand = connection.CreateCommand())

                {
                    insertCommand.CommandText = "INSERT INTO [DealerService_Dealer](DealerServiceServiceID, DealerDealerID) VALUES (@DealerServiceServiceID, @DealerDealerID)";
                    insertCommand.Parameters.Add("@DealerServiceServiceID", dealerService_Dealer.DealerServiceServiceID);
                    insertCommand.Parameters.Add("@DealerDealerID", dealerService_Dealer.DealerDealerID);

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



        public List<Dealer> GetSearchResultDealer(string inputText)
        {
            List<Dealer> searchResults = new List<Dealer>();
            Dealer dealer = null;
            //if (inputText == "") return null;
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT DealerID, DealerName, PhoneNumber, City, District, Photo, UserUserID FROM [Dealer] WHERE DealerName LIKE '%" + inputText + "%'", connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    dealer = new Dealer()
                    {
                        DealerID = Convert.ToInt32(reader["DealerID"].ToString()),
                        DealerName = reader["DealerName"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        City = reader["City"].ToString(),
                        District = reader["District"].ToString(),
                        Photo = Encoding.ASCII.GetBytes(reader["Photo"].ToString()),
                        UserUserID = Convert.ToInt32(reader["UserUserID"].ToString()),
                    };
                    searchResults.Add(dealer);
                }
            }

            connection.Close();

            return searchResults;
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


        public List<Appointment> GetAppointments(int dealerId)
        {
            List<Appointment> appointments = new List<Appointment>();
            Appointment appointment = null;

            connection.ConnectionString = connStr;
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT AppointmentID, AppointmentStartTime, AppointmentFinishTime, DealerDealerID, UserUserID FROM [Appointment] WHERE DealerDealerID = @DealerDealerID", connection);
            command.Parameters.AddWithValue("@DealerDealerID", dealerId);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    appointment = new Appointment()
                    {
                        AppointmentID = Convert.ToInt32(reader["AppointmentID"]),
                        AppointmentStartTime = (DateTime)reader["AppointmentStartTime"],
                        AppointmentEndTime = (DateTime)(reader["AppointmentFinishTime"]),
                        DealerDealerID = Convert.ToInt32(reader["DealerDealerID"].ToString()),
                        UserUserID = Convert.ToInt32(reader["UserUserID"].ToString())
                    };
                    appointments.Add(appointment);
                }
            }

            connection.Close();
            return appointments;
        }
        public Dealer GetDealer(int userUserID)
        {
            Dealer dealer = null;
            if (userUserID == 0) return null;
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT DealerID, DealerName, PhoneNumber, City, District, Photo, UserUserID FROM [Dealer] WHERE UserUserID = @UserUserID", connection);
            command.Parameters.AddWithValue("@UserUserID", userUserID);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    dealer = new Dealer()
                    {
                        DealerID = Convert.ToInt32(reader["DealerID"].ToString()),
                        DealerName = reader["DealerName"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        City = reader["City"].ToString(),
                        District = reader["District"].ToString(),
                        Photo = Encoding.ASCII.GetBytes(reader["Photo"].ToString()),
                        UserUserID = Convert.ToInt32(reader["UserUserID"].ToString()),
                    };
                }
            }

            connection.Close();

            return dealer;
        }
    }
}