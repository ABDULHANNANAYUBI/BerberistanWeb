using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BerberistanWeb
{
    public partial class Home : System.Web.UI.Page
    {
        protected List<Dealer> dealerSearchResults = new List<Dealer>();
        DbHelper dbHelper = new DbHelper();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (((User)(Session["User"])) == null)
            //    Response.Redirect("Login.aspx");

            dealerSearchResults = dbHelper.GetSearchResultDealer("");
        }

        protected void LinkButton_Search_Click(object sender, EventArgs e)
        {
            

            if (txt_SearchInput.Value.Length == 0)
            {
                dealerSearchResults = new List<Dealer>();
                return;
            }

            dealerSearchResults = dbHelper.GetSearchResultDealer(txt_SearchInput.Value);
        }
    }
}