<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BerberistanWeb.Register" %>

<!DOCTYPE html>
<html>
<head>
    <link rel="icon" href="images/icons/berberistan.ico">

    <meta charset="utf-8">
    <title>Berberistan - Kaydol!</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

    <!-- LINEARICONS -->
    <link rel="stylesheet" href="fonts/linearicons/style.css">

    <!-- STYLE CSS -->
    <link rel="stylesheet" href="css/style.css">
</head>

<body>

    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>


    <div class="wrapper">
        <div class="inner">
            <img src="images/a.png" alt="" class="image-1">
            <form action="" runat="server">
                <h3>Yeni hesap?</h3>
                <div class="form-holder">
                    <span class="lnr lnr-user"></span>
                    <input id="txt_Username" runat="server" type="text" class="form-control" placeholder="Kullanıcı Adı">
                </div>
                <div class="form-holder">
                    <span class="lnr lnr-user"></span>
                    <input id="txt_Name" runat="server" type="text" class="form-control" placeholder="Ad">
                </div>
                <div class="form-holder">
                    <span class="lnr lnr-user"></span>
                    <input id="txt_Surname" runat="server" type="text" class="form-control" placeholder="Soyad">
                </div>
                <div class="form-holder">
                    <span class="lnr lnr-phone-handset"></span>
                    <input id="txt_PhoneNumber" runat="server" type="text" class="form-control" placeholder="Telefon Numarası">
                </div>
                <div class="form-holder">
                    <span class="lnr lnr-envelope"></span>
                    <input id="txt_MailAddress" runat="server" type="text" class="form-control" placeholder="Mail Adresi">
                </div>
                <div class="form-holder">
                    <span class="lnr lnr-lock"></span>
                    <input id="txt_Password" runat="server" type="password" class="form-control" placeholder="Şifre">
                </div>
                <div class="form-holder">
                    <span class="lnr lnr-lock"></span>
                    <input id="txt_AgainPassword" runat="server" type="password" class="form-control" placeholder="Yeniden Şifre">
                </div>
                <div class="form-holder">
                    <span class="lnr lnr-apartment"></span>
                    <input id="txt_City" runat="server" type="text" class="form-control" placeholder="İl">
                </div>
                <div class="form-holder">
                    <span class="lnr lnr-apartment"></span>
                    <input id="txt_District" runat="server" type="text" class="form-control" placeholder="İlçe">
                </div>


                <asp:Button ID="Button_Register" runat="server" CssClass="buttonII" Text="Kaydol" OnClick="Button_Register_Click" />

                <div id="div_Success" runat="server" class="alert alert-success mt-3" role="alert" Visible="false">
                    Kayıt başarıyla oluşturuldu! <a href="Login.aspx"> Giriş sayfasına dön!</a>
                </div>

            </form>
            <img src="images/image-2.png" alt="" class="image-2">
        </div>

    </div>

    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/main.js"></script>
</body>
<!-- This templates was made by Colorlib (https://colorlib.com) -->
</html>
