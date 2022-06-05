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

            if (user != null)
                Response.Redirect("Home.aspx");

        }
        protected void Button_Login_Click(object sender, EventArgs e)
        {
            DbHelper dbHelper = new DbHelper();

            User user = dbHelper.GetUser(txt_Username.Value, txt_Password.Value);
            SaveUserToSession(user);

            if(user != null)
            {
                Response.Redirect("Home.aspx");
            }
        }

        private void SaveUserToSession(User user)
        {
            Session["User"] = user;
        }
    }
}