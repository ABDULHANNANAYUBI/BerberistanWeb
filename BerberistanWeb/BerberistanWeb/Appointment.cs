using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BerberistanWeb
{
    public class Appointment
    {
        private int appointmentID;
        private DateTime appointmentStartTime;
        private DateTime appointmentEndTime;
        private int dealerDealerID;
        private int userUserID;

        public int AppointmentID { get => appointmentID; set => appointmentID = value; }
        public DateTime AppointmentStartTime { get => appointmentStartTime; set => appointmentStartTime = value; }
        public DateTime AppointmentEndTime { get => appointmentEndTime; set => appointmentEndTime = value; }
        public int DealerDealerID { get => dealerDealerID; set => dealerDealerID = value; }
        public int UserUserID { get => userUserID; set => userUserID = value; }

        public Appointment(int appointmentID, DateTime appointmentStartTime, DateTime appointmentEndTime, int dealerDealerID, int userUserID)
        {
            this.appointmentID = appointmentID;
            this.appointmentStartTime = appointmentStartTime;
            this.appointmentEndTime = appointmentEndTime;
            this.dealerDealerID = dealerDealerID;
            this.userUserID = userUserID;
        }

        public Appointment()
        {
        }
    }
}