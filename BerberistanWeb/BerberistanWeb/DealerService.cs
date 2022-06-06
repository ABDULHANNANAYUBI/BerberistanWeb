using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BerberistanWeb
{
    public class DealerService
    {
        private int serviceID;
        private string serviceName;
        private int serviceTimeMinutes;
        private double serviceFee;
        private int dealerDealerID;

        public int ServiceID { get => serviceID; set => serviceID = value; }
        public string ServiceName { get => serviceName; set => serviceName = value; }
        public int ServiceTimeMinutes { get => serviceTimeMinutes; set => serviceTimeMinutes = value; }
        public double ServiceFee { get => serviceFee; set => serviceFee = value; }
        public int DealerDealerID { get => dealerDealerID; set => dealerDealerID = value; }

        public DealerService() { }

        public DealerService(int serviceID, string serviceName, int serviceTimeMinutes, double serviceFee, int dealerDealerID)
        {
            this.serviceID = serviceID;
            this.serviceName = serviceName;
            this.serviceTimeMinutes = serviceTimeMinutes;
            this.serviceFee = serviceFee;
            this.dealerDealerID = dealerDealerID;
        }
    }
}