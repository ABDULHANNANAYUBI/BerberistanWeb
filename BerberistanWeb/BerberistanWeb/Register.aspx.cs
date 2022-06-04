using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BerberistanWeb
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button_Register_Click(object sender, EventArgs e)
        {
            DbHelper dbHelper = new DbHelper();

            User user = new User()
            {
                UserName = txt_Username.Value,
                Name = txt_Name.Value,
                Surname = txt_Surname.Value,
                PhoneNumber = txt_PhoneNumber.Value,
                MailAddress = txt_MailAddress.Value,
                Password = txt_Password.Value,
                City = txt_City.Value,
                District = txt_District.Value
            };

            SaveUserToSession(user);

            if (dbHelper.AddNewUser(user))
                div_Success.Visible = true;

        }

        private void SaveUserToSession(User user)
        {
            Session["User"] = user;
        }
    }
}