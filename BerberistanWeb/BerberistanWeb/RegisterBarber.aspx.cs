using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BerberistanWeb
{
    public partial class RegisterBarber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((User)(Session["User"])) == null)
                Response.Redirect("Login.aspx");
          

        }
        protected void Button_Register_Click(object sender, EventArgs e)
        {
            DbHelper dbHelper = new DbHelper();

            Dealer dealer = new Dealer()
            {
                DealerName = txt_Username.Value,
                Photo = null,
                UserUserID = ((User)(Session["User"])).UserID,
                PhoneNumber = txt_PhoneNumber.Value,
                City = txt_City.Value,
                District = txt_District.Value,

            };


        }
    }
}