using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace BerberistanWeb
{
    public partial class Details : System.Web.UI.Page
    {
        public int ID { get; set; }
        public Dealer dealer { get; set; }
        public DbHelper dbHelper { get; set; }
        public List<string> getDailyTimes { get; set; }
        public List<String> setDailyTimesWithSelectedDay { get; set; }
        public List<String> daysOfAppointment { get; set; }
        public List<DealerService> dealerServices { get; set; }

        public List<Appointment> allApointments { get; set; }
        public List<Boolean> selectedServices { get; set; }
        public int Count = 0;
        public static Boolean isTrue = false;

        public static DateTime selectedDate;
        public static String selectedTime = "";
        public User user { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Request.QueryString["id"] != null)
                {
                    ID = Int32.Parse(Request.QueryString["id"]);
                }

                else
                {
                    ID = 1;
                }
                dealer = new Dealer();
                dbHelper = new DbHelper();
                getDailyTimes = new List<string>();
                daysOfAppointment = new List<string>();
                setDailyTimesWithSelectedDay = new List<string>();
                allApointments = new List<Appointment>();
                dealerServices = new List<DealerService>();
                FillDetails();
                if (IsPostBack)
                {
                   FillAsButtons();
                    //FillTheServices();
                   //FillTheServices();
                }
                if (!IsPostBack)
                {
                    FillCheckboxList();
                    user = new User();
                    selectedServices = new List<bool>();
                    selectedDate = new DateTime();
                    user = new User() { UserID = 1 };
                }
                //this.popup.Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void FillDetails()
        {
            dealer = dbHelper.GetDealer(ID);
            allApointments = dbHelper.GetAppointments(ID);
            setDealerServices();
            calculateTimes();
        }
        public void setDealerServices()
        {
            dealerServices = dbHelper.GetDealerAllServices(ID);
        }
        public void calculateTimes()
        {
            FillTheTimes();
        }

        public void FillTheTimes()
        {
            int IntervalParameter = 30;
            getDailyTimes = Enumerable
              .Range(0, (int)(new TimeSpan(24, 0, 0).TotalMinutes / IntervalParameter))
              .Select(i => DateTime.Today
                 .AddMinutes(i * (double)IntervalParameter)
                 .ToString("HH:mm"))
              .ToList();

            List<String> Temp = getDailyTimes.Where((value, index) => index >= 17 && index <= 46)
                                .ToList();
            getDailyTimes = Temp;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            selectedDate = Calendar1.SelectedDate;
            List<Appointment> temp = new List<Appointment>();
            foreach (var item in allApointments)
            {
                var item1 = item.AppointmentStartTime.ToShortDateString();
                var item2 = selectedDate.ToShortDateString();
                if (item.AppointmentStartTime.ToShortDateString() == selectedDate.ToShortDateString())
                {
                    temp.Add(item);
                }
            }
            allApointments = temp;
            setFreeTimes();
        }
        public void setFreeTimes()
        {
            setDailyTimesWithSelectedDay = new List<string>(getDailyTimes);
            List<String> tempAppointmentTimes = new List<string>();
            foreach (var appointment in allApointments)
            {
                tempAppointmentTimes.Add(appointment.AppointmentStartTime.ToShortTimeString().Replace("AM", "").Replace("PM", "").Replace(" ", ""));
            }
            foreach (var item in getDailyTimes)
            {
                foreach (var item2 in tempAppointmentTimes)
                {
                    if (String.Equals(item, item2))
                    {
                        setDailyTimesWithSelectedDay.Remove(item);
                        Count++;
                    }
                    else
                    {
                    }
                }
            }
        }
        public void FillAsButtons()
        {
            this.collection.Controls.Clear();
            setFreeTimes();
            for (int i = 0; i < setDailyTimesWithSelectedDay.Count; i++)
            {
                //createDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                System.Web.UI.HtmlControls.HtmlGenericControl createDiv =
                 new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                createDiv.Attributes["class"] = "col-2";
                createDiv.ID = "createDiv" + i;
                LinkButton lnk = new LinkButton();
                lnk.ID = i.ToString();
                lnk.CssClass = "buttonII";
                lnk.CausesValidation = false;
                lnk.Text = setDailyTimesWithSelectedDay[i].ToString();
                lnk.Click += new EventHandler(this.Lnk_Click);
                createDiv.Controls.Add(lnk);
                this.collection.Controls.Add(createDiv);
            }
        }

        private void Lnk_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            if (!isTrue)
            {
                if (lnk.BackColor == System.Drawing.Color.Red)
                {
                    isTrue = false;
                    lnk.BackColor = System.Drawing.Color.FromArgb(unchecked((int)0x99ccff));
                    lnk.CssClass = "buttonII";
                }
                else
                {
                    lnk.BackColor = System.Drawing.Color.Red;
                    isTrue = true;
                    selectedTime = lnk.Text.ToString();
                }
            }
            else
            {
                if(lnk.BackColor == System.Drawing.Color.Red)
                {
                    lnk.BackColor = System.Drawing.Color.FromArgb(unchecked((int)0x99ccff));
                    lnk.CssClass = "buttonII";
                    isTrue = false;
                    selectedTime = lnk.Text.ToString();
                }
                else
                {
                    lnk.BackColor = System.Drawing.Color.Red;
                    isTrue = true;
                    selectedTime = lnk.Text.ToString();
                }
                
            }
            
        }


        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("checked");
        }

        protected void FillCheckboxList()
        {
            List<String> temp = new List<string>(); 
            foreach(var item in dealerServices)
            {
                temp.Add(item.ServiceName.ToString());
            }
            CheckBoxList1.DataSource = temp;
            CheckBoxList1.DataBind();
        }

        //public void GetServices()
        //{
        //    foreach (Control ctl in form1.FindControl("services").Controls)
        //    {
        //        if (ctl is CheckBox)
        //        {
        //            if (((CheckBox)ctl).Checked)
        //            {
        //                selectedServices.Add(true);
        //            }
        //        }
        //    }
        //}

        public void SetCheckoutButton()
        {

        }
        private void checkOut(object sender, EventArgs e)
        {
        }

        protected void checkout_Click(object sender, EventArgs e)
        {
            try
            {
                //user = (User)Session["User"];

                //if (user == null)
                //{
                //    user = new User();
                //    user.UserID = 1;
                //}
                //for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                //{
                //    if (CheckBoxList1.Items[i].Selected == true)// getting selected value from CheckBox List  
                //    {
                //        dbHelper.InsertServices(dealerServices[i], user.UserID);
                //    }
                //}
                //String tempTime = selectedDate.ToString() + selectedTime.ToString();
                //var StartDate = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, Convert.ToDateTime(selectedTime).Hour, Convert.ToDateTime(selectedTime).Minute, selectedDate.Second);
                //var EndMin = Convert.ToDateTime(selectedTime).Minute + 30;
                //var EndDate = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, Convert.ToDateTime(selectedTime).Hour, EndMin, selectedDate.Second);
                //DbHelper temp = new DbHelper();
                //temp.InsertAppointment(new Appointment(1, StartDate, EndDate, ID, user.UserID));
                this.form1.Visible = false;
                //this.popup.Visible = true;
                Thread.Sleep(2000);
                //Response.Redirect("Home.aspx");
            }
            catch (Exception ex)
            {

            }
           
        }
    }

}
