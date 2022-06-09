using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel.Syndication;
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
        public List<string> setDailyTimesWithSelectedDay { get; set; }
        public List<String> daysOfAppointment { get; set; }
        public List<DealerService> dealerServices { get; set; }

        public List<Appointment> allApointments { get; set; }
        public List<Boolean> selectedServices { get; set; }
        public int Count = 0;
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
                selectedServices = new List<bool>();
                FillDetails();
                if (IsPostBack)
                {
                   FillasButtons();
                   //FillTheServices();
                }
                if (!IsPostBack)
                {
                }
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
            //DateTime tomorrow = DateTime.Today.AddDays(1);
            //Calendar1.TodaysDate = tomorrow;
            DateTime selected = Calendar1.SelectedDate;
            List<Appointment> temp = new List<Appointment>();
            foreach (var item in allApointments)
            {
                var item1 = item.AppointmentStartTime.ToShortDateString();
                var item2 = selected.ToShortDateString();
                if (item.AppointmentStartTime.ToShortDateString() == selected.ToShortDateString())
                {
                    temp.Add(item);
                }
            }
            allApointments = temp;
            //setFreeTimes(item.AppointmentStartTime.Day.ToString());
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
        public void FillasButtons()
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
            if (lnk.BackColor == System.Drawing.Color.Red)
            {
                lnk.BackColor = System.Drawing.Color.FromArgb(unchecked((int)0x99ccff));
                lnk.CssClass = "buttonII";
                FillTheServices();
            }
            else
            {
                lnk.BackColor = System.Drawing.Color.Red;
                FillTheServices();
            }
        }

        
        public void FillTheServices()
        {
            this.services.Controls.Clear();
            for(int i = 0; i < dealerServices.Count; i++)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.ID = i.ToString() + Guid.NewGuid().ToString("N");
                checkBox.Text = dealerServices[i].ServiceName.ToString() + " Price : " + dealerServices[i].ServiceFee.ToString();
                checkBox.Style.Add("padding", "5px");
                checkBox.Style.Add("color", "black");
                checkBox.CssClass = "form - check";
                this.services.Controls.Add(checkBox);
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("checked");
        }

        public void GetServices()
        {
            foreach (Control ctl in form1.FindControl("services").Controls)
            {
                if (ctl is CheckBox)
                {
                    if (((CheckBox)ctl).Checked)
                    {
                        selectedServices.Add(true);
                    }
                }
            }
        }

        public void SetCheckoutButton()
        {

        }
        private void checkOut(object sender, EventArgs e)
        {
        }

        protected void checkout_Click(object sender, EventArgs e)
        {
            GetServices();

        }
    }
}
