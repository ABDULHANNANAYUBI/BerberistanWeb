<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BerberistanWeb.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <link href='https://fonts.googleapis.com/css?family=Roboto:400,100,300,700' rel='stylesheet' type='text/css'>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">

    <link rel="stylesheet" href="css/style.css">

    <link rel="icon" href="images/icons/berberistan.ico">
    <title></title>
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
                        <li class="nav-item"><a href="BarberManagement.aspx" class="nav-link"><strong>Bayiliğim</strong></a></li>


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
            <h6 class="my-3"><strong>Hangi bayiden randevu almak istersiniz?</strong></h6>

            <input class="mt-0 mb-0 mr-3" id="txt_SearchInput" runat="server" type="text" style="width: 50%; float: left; height: 40px;" placeholder="Hangi bayiden randevu almak istersiniz?" />
            <asp:LinkButton ID="LinkButton_Search" OnClick="LinkButton_Search_Click" CssClass="buttonII mt-0" Style="width: 15%; height: 40px; float: left;" runat="server"><i class="fa fa-search"></i></asp:LinkButton>

            <img src="images/image-1.png" width="170" height="170" style="margin: -120px 0 0 10px" />
        </div>

        <div class="container mt-4">
            <div class="row">
                <%
                    int resultCount = dealerSearchResults.Count == 0 ? 9 : dealerSearchResults.Count;
                    for (int i = 0; i < resultCount; i++)
                    {
                %>

                <div class="col-4">
                    <div class="card mx-2 my-2" style="width: 23rem;">
                        <img class="card-img-top" src="images/allef-vinicius-IvQeAVeJULw-unsplash.jpg" alt="Card image cap">
                        <div class="card-body">
                            <h5 class="card-title"><%= dealerSearchResults[i].DealerName %></h5>
                            <p class="card-text" style="margin: -20px 0 0 0"><%= (dealerSearchResults[i].District + " / " + dealerSearchResults[i].City) %></p>
                            <a href="Details.aspx?id=<%= dealerSearchResults[i].DealerID %>" class="buttonII btn-primary mt-1" >Bayiyi incele</a>
                        </div>
                    </div>
                </div>

                <%
                    }


                %>
            </div>
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
