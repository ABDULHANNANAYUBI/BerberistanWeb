<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="BerberistanWeb.Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />

    <link href='https://fonts.googleapis.com/css?family=Roboto:400,100,300,700' rel='stylesheet' type='text/css' />

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />

    <link rel="stylesheet" href="css/style.css" />

    <link rel="icon" href="images/icons/berberistan.ico" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="display: flex; flex-direction: column; width: 100%;">
            <button class="btn btn-secondary dropdown-toggle" type="button" id="Calender" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                Select Appointment Date
            </button>
            <div>
                <asp:Calendar ID="Calendar1" runat="server" Width="100%" Font-Size="Medium" Font-Bold="true" BackColor="Transparent" BorderColor="Transparent" DayHeaderStyle-BackColor="Transparent" DayStyle-BackColor="Transparent" TitleStyle-ForeColor="White" TitleStyle-BackColor="#99CCFF" DayHeaderStyle-ForeColor="White" SelectedDayStyle-BackColor="#99CCFF" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
            </div>
            <div>
                <button class="btn btn-secondary dropdown-toggle" type="button" id="Times" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    Select Appointment Time
                </button>
                <div id="collection" runat="server" class="row">
                </div>
                <div>
                    <button class="btn btn-secondary dropdown-toggle mb-3" type="button" id="Services" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        Services 
                    </button>
                    <div id="services" class="col-4" runat="server">

                    </div>
                    <div>

                        <asp:LinkButton class="btn btn-secondary" Width="100%" style="background-color: lightgreen; color: black" type="button" ID="checkout" runat="server" aria-haspopup="true" aria-expanded="false" OnClick="checkout_Click" >checkout </asp:LinkButton>
                        
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
