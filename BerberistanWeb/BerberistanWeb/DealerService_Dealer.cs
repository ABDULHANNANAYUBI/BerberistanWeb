using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BerberistanWeb
{
    public class DealerService_Dealer
    {
        private int dealerServiceServiceID;
        private int dealerDealerID;

        public int DealerServiceServiceID { get => dealerServiceServiceID; set => dealerServiceServiceID = value; }
        public int DealerDealerID { get => dealerDealerID; set => dealerDealerID = value; }

        public DealerService_Dealer() { }

        public DealerService_Dealer(int dealerServiceServiceID, int dealerDealerID)
        {
            this.dealerServiceServiceID = dealerServiceServiceID;
            this.dealerDealerID = dealerDealerID;
        }
    }
}