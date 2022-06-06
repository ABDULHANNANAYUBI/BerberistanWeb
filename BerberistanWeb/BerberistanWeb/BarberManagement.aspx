<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BarberManagement.aspx.cs" Inherits="BerberistanWeb.BarberManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <link href='https://fonts.googleapis.com/css?family=Roboto:400,100,300,700' rel='stylesheet' type='text/css'>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">

    <link rel="stylesheet" href="css/style.css">

    <link rel="icon" href="images/icons/berberistan.ico">
    <title><%= dealer.DealerName %> - Bayilik Yönetim Paneli</title>
</head>
<body>
    <section class="ftco-section">


        <nav class="navbar navbar-expand-lg navbar-light " id="ftco-navbar" style="background-color: #99ccff">
            <div class="container-fluid">

                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#ftco-nav" aria-controls="ftco-nav" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="fa fa-bars"></span>Menu
	     
                </button>
                <div class="col-md-4 d-flex">
                    <div class="social-media">
                        <p class="mb-0 d-flex">
                            <a href="#" class="d-flex align-items-center justify-content-center"><span class="fa fa-facebook"><i class="sr-only">Facebook</i></span></a>
                            <a href="#" class="d-flex align-items-center justify-content-center"><span class="fa fa-twitter"><i class="sr-only">Twitter</i></span></a>
                            <a href="#" class="d-flex align-items-center justify-content-center"><span class="fa fa-instagram"><i class="sr-only">Instagram</i></span></a>
                        </p>
                    </div>
                </div>

                <div class="collapse navbar-collapse" id="ftco-nav">
                    <ul class="navbar-nav">
                        <li class="nav-item active"><a href="#" class="nav-link"><strong>Ana Sayfa</strong></a></li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" id="dropdown04" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><strong>Page</strong></a>
                            <div class="dropdown-menu" aria-labelledby="dropdown04">
                                <a class="dropdown-item" href="#">Page 1</a>
                                <a class="dropdown-item" href="#">Page 2</a>
                                <a class="dropdown-item" href="#">Page 3</a>
                                <a class="dropdown-item" href="#">Page 4</a>
                            </div>
                        </li>
                        <li class="nav-item"><a href="#" class="nav-link"><strong>Berberistan Hakkında</strong></a></li>
                        <li class="nav-item"><a href="#" class="nav-link"><strong>Profilim</strong></a></li>
                        <li class="nav-item"><a href="RegisterBarber.aspx" class="nav-link"><strong>Yeni Bayilik</strong></a></li>
                        <li class="nav-item"><a href="#" class="nav-link"><strong>Bayiliğim</strong></a></li>

                    </ul>
                    <div class="social-media ml-auto">
                        <p class="mb-0 d-flex">
                            <a href="Login.aspx" class="d-flex align-items-center justify-content-center ml-auto">
                                <img style="width: 21px; height: 21px;" src="images/icons/arrow-right-from-bracket-solid.svg"><i class="sr-only">Exit</i></img></a>
                        </p>
                    </div>
                </div>
            </div>
        </nav>
        <!-- END nav -->

    </section>

    <script src="js/jquery.min.js"></script>
    <script src="js/popper.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/main.js"></script>

    <form id="form1" runat="server">

        <div style="margin: 0 auto 0 200px">
            <h6 style="font-size: 40px; color: black" class="my-3"><strong><%= (dealer.DealerName) + " Bayisi Yönetim Paneli" %></strong></h6>
            <h6 class="mt-0 mb-3"><strong><%= (dealer.District + "/" + dealer.City + " - " + dealer.PhoneNumber + " - (" + dealer.MailAddress+")") %></strong></h6>
            <h6 style="font-size: 20px;" class="my-3"><strong>Eklemek istediğiniz hizmeti giriniz:</strong></h6>

            <input class="mt-0 mb-0 mr-3" id="txt_ServiceName" runat="server" type="text" style="width: 20%; float: left; height: 40px;" placeholder="Hizmet adı" />
            <input class="mt-0 mb-0 mr-3 mt-2" id="txt_ServiceFee" runat="server" type="text" style="width: 20%; clear: both; float: left; height: 40px;" placeholder="Hizmet ücreti" />

            <input class="mt-0 mb-0 mr-3 mt-2" id="txt_ServiceTimeMinutes" runat="server" type="text" style="width: 20%; clear: both; float: left; height: 40px;" placeholder="Tahmini hizmet süresi" />
            <asp:LinkButton ID="LinkButton_AddNewService" OnClick="LinkButton_AddNewService_Click" CssClass="buttonII mt-2" Style="width: 5%; height: 40px; float: left;" runat="server"><i class="fa fa-plus"></i></asp:LinkButton>


            <ul class="list-group">
                <%
                    if (dealerServices.Count != 0)
                    {
                        for (int i = 0; i < dealerServices.Count; i++)
                        {
                %><li class="list-group-item ml-5" style="width: 40rem;"><%= (dealerServices[i].ServiceName + " - Ortalama Hizmet Süresi: "+dealerServices[i].ServiceTimeMinutes + " ("+dealerServices[i].ServiceFee+"₺) - " + dealer.DealerName +" Bayisi" ) %></li>
                <%
                        }
                    }



                %>
            </ul>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>

    <!-- FOOTER -->
    <footer class="w-100 py-4 flex-shrink-0">
        <div class="container py-4">
            <div class="row gy-4 gx-5">
                <div class="col-lg-4 col-md-6">
                    <h5 class="h1 text-white">Berberistan</h5>
                    <p class="small text-muted">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt.</p>
                    <p class="small text-muted mb-0">&copy; Copyrights. All rights reserved. <a class="text-primary" href="#">Bootstrapious.com</a></p>
                </div>
                <div class="col-lg-2 col-md-6">
                    <h5 class="text-white mb-3">Quick links</h5>
                    <ul class="list-unstyled text-muted">
                        <li><a href="#">Home</a></li>
                        <li><a href="#">About</a></li>
                        <li><a href="#">Get started</a></li>
                        <li><a href="#">FAQ</a></li>
                    </ul>
                </div>
                <div class="col-lg-2 col-md-6">
                    <h5 class="text-white mb-3">Quick links</h5>
                    <ul class="list-unstyled text-muted">
                        <li><a href="#">Home</a></li>
                        <li><a href="#">About</a></li>
                        <li><a href="#">Get started</a></li>
                        <li><a href="#">FAQ</a></li>
                    </ul>
                </div>
                <div class="col-lg-4 col-md-6">
                    <h5 class="text-white mb-3">Newsletter</h5>
                    <p class="small text-muted">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt.</p>

                </div>
            </div>
        </div>
    </footer>
</body>
</html>
