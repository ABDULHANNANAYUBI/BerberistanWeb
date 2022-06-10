<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="BerberistanWeb.Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />

    <link href='https://fonts.googleapis.com/css?family=Roboto:400,100,300,700' rel='stylesheet' type='text/css' />

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />

    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="css/details.css" />
    <link rel="icon" href="images/icons/berberistan.ico" />
</head>
<body>
    <div runat="server" visible="false" id="popup" class="alert alert-success" role="alert">
        <h4 class="alert-heading">Randevunuz başarılı bir şekilde kaydedilmiştir. </h4>
        <h5> <% =selectedDate.ToString() %> tarhihinde <%= selectedTime.ToString() %> saatinde <%= dealer.DealerName.ToString() %> de oluşmuştur.</h5>
        <hr>
        <p class="mb-0"><%= dealer.District.ToString() %> adresinde gidebilirsiniz. </p>
        <a href="Home.aspx" style="font-size:x-large; font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif; color:green"> Ana sayfaya dönmek için tıklayınız.</a>
    </div>

    <form id="form1" runat="server">
        <div style="display: flex; flex-direction: column; width: 100%;">
            <button class="btn btn-secondary dropdown-toggle" type="button" id="Calender" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                Randevu Tarihi
            </button>
            <div>
                <asp:Calendar ID="Calendar1" runat="server" Width="100%" Font-Size="Medium" Font-Bold="true" BackColor="Transparent" BorderColor="Transparent" DayHeaderStyle-BackColor="Transparent" DayStyle-BackColor="Transparent" TitleStyle-ForeColor="White" TitleStyle-BackColor="#99CCFF" DayHeaderStyle-ForeColor="White" SelectedDayStyle-BackColor="#99CCFF" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
            </div>
            <div>
                <button class="btn btn-secondary dropdown-toggle" type="button" id="Times" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    Randevu Saati
                </button>
                <div id="collection" runat="server" class="row">
                </div>
                <div>
                    <button class="btn btn-secondary dropdown-toggle mb-3" type="button" id="Services" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        Hizmetler
                    </button>
                    <div id="services" class="col-4" runat="server">
                    </div>
                    <div style="align-content: center; text-align: center">
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" Style="color: black;" CssClass="chkChoice" Font-Bold="true" Font-Size="large" Width="100%" CellPadding="15"></asp:CheckBoxList>
                        <asp:LinkButton class="btn btn-secondary" Style="color: white" ID="checkout" runat="server" aria-haspopup="true" aria-expanded="false" OnClick="checkout_Click"> Randevu Al </asp:LinkButton>
                    </div>

                </div>
            </div>
        </div>
    </form>

</body>
</html>
