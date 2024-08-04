<%@ Page Title="" Language="C#" MasterPageFile="~/Wallet.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WEB.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background-color: #d0e7f9; /* Fondo azul claro */
        }

        .card-wrapper {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }
    </style>
    <script>
        document.addEventListener("DOMContentLoaded", function () {
            var username = document.getElementById('<%= txtbUsername.ClientID %>');
            var password = document.getElementById('<%= txtbPassword.ClientID %>');
            var btnLogin = document.getElementById('<%= btnLogin.ClientID %>');

            function validateInputs() {
                if (username.value.trim() === "" || password.value.trim() === "") {
                    btnLogin.disabled = true;
                } else {
                    btnLogin.disabled = false;
                }
            }

            username.addEventListener("input", validateInputs);
            password.addEventListener("input", validateInputs);

            // Initial validation
            validateInputs();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card-wrapper">
        <div class="card" style="width: 18rem;">
            <div class="card-body">
                <h5 class="card-title text-center">Login</h5>
                <div class="form-group">
                    <label for="txtbUsername">Username o Email</label>
                    <asp:TextBox ID="txtbUsername" runat="server" CssClass="form-control" />
                    <asp:Label Text="" runat="server" ID="lbErrorUsername" Visible="false" />
                </div>
                <div class="form-group">
                    <label for="txtbPassword">Password</label>
                    <asp:TextBox ID="txtbPassword" runat="server" TextMode="Password" CssClass="form-control" />
                    <asp:Label Text="" runat="server" ID="lbErrorPassword" Visible="false" />
                </div>
                <div class="text-center">
                    <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary" Text="Login" OnClick="btnLogin_Click" />
                    <a href="Registro.aspx" class="btn btn-primary">Registrate!</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
