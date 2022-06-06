using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BerberistanWeb
{
    public partial class BarberManagement : System.Web.UI.Page
    {
        protected Dealer dealer = null;
        protected List<DealerService> dealerServices = new List<DealerService>();
        private DbHelper dbHelper = new DbHelper();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (((Dealer)(Session["Dealer"])) == null)
            {
                Response.Redirect("RegisterBarber.aspx");
                if (((User)(Session["User"])) == null)
                    Response.Redirect("Login.aspx");
            }

            dealer = (Dealer)(Session["Dealer"]);
            dealerServices = dbHelper.GetDealerAllServices(((Dealer)(Session["Dealer"])).DealerID);
        }

        protected void LinkButton_AddNewService_Click(object sender, EventArgs e)
        {

            dbHelper.AddNewDealerService(new DealerService()
            {
                ServiceName = txt_ServiceName.Value,
                ServiceFee = Convert.ToDouble(txt_ServiceFee.Value),
                ServiceTimeMinutes = Convert.ToInt32(txt_ServiceTimeMinutes.Value)
            }, (Dealer)(Session["Dealer"]));

            dealerServices = dbHelper.GetDealerAllServices(((Dealer)(Session["Dealer"])).DealerID);
        }
    }
}