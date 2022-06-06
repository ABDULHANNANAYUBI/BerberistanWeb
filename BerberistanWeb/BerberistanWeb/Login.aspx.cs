using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BerberistanWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["User"];
            Dealer dealer = (Dealer)Session["Dealer"];

            if (user != null)
                Response.Redirect("Home.aspx");

        }
        protected void Button_Login_Click(object sender, EventArgs e)
        {
            DbHelper dbHelper = new DbHelper();

            User user = dbHelper.GetUser(txt_Username.Value, txt_Password.Value);
            Dealer dealer = dbHelper.GetDealer(user.UserID);

            SaveUserToSession(user);
            SaveDealerToSession(dealer);

            if(user != null)
            {
                Response.Redirect("Home.aspx");
            }
        }

        private void SaveUserToSession(User user)
        {
            Session["User"] = user;
        }

        private void SaveDealerToSession(Dealer dealer)
        {
            Session["Dealer"] = dealer;
        }
    }
}