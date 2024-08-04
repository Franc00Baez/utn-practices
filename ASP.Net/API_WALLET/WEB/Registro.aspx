<%@ Page Title="" Language="C#" MasterPageFile="~/Wallet.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="WEB.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background-color: #d0e7f9; /* Fondo azul claro */
        }

        .card-wrapper {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100%;
        }

        .card {
            background-color: rgba(255, 255, 255, 0.9); /* Fondo blanco con transparencia */
            border-radius: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript">
         document.addEventListener("DOMContentLoaded", function () {
             var txtUserName = document.getElementById('<%= txtbUserName.ClientID %>');
             var txtEmail = document.getElementById('<%= txtbEmail.ClientID %>');
             var txtPassword = document.getElementById('<%= txtbPassword.ClientID %>');
             var btnRegister = document.getElementById('<%= btnRegister.ClientID %>');

             function validateForm() {
                 var isFormValid = txtUserName.value.trim() !== '' &&
                     txtEmail.value.trim() !== '' &&
                     txtPassword.value.trim() !== '' &&
                     txtPassword.value.length >= 8;
                 btnRegister.disabled = !isFormValid;
             }

             txtUserName.addEventListener('input', validateForm);
             txtEmail.addEventListener('input', validateForm);
             txtPassword.addEventListener('input', validateForm);

             txtPassword.addEventListener('keyup', function () {
                 var message = document.getElementById('passwordMessage');
                 if (txtPassword.value.length < 8) {
                     message.style.color = 'red';
                     message.innerText = 'Password must be at least 8 characters long';
                 } else {
                     message.innerText = '';
                 }
             });

             validateForm(); // Initial check
         });
     </script>
    <div class="card-wrapper">
        <div class="card" style="width: 18rem;">
            <div class="card-body">
                <h5 class="card-title text-center">Register</h5>
                <asp:Label Text="" runat="server" ForeColor="Red" CssClass="text-warning text-center" Visible="false"  ID="lblErrorGeneral"/>
                    <div class="form-group">
                        <label for="txtbUserName">Username</label>
                        <asp:TextBox ID="txtbUserName" runat="server" CssClass="form-control" />
                        <asp:Label Text="" runat="server" visible="false" ForeColor="Red" ID="lblErrorUsername" />
                    </div>
                    <div class="form-group">
                        <label for="txtbEmail">Email</label>
                        <asp:TextBox ID="txtbEmail" runat="server" CssClass="form-control" TextMode="Email"  />
                        <asp:Label Text="" runat="server" visible="false" ForeColor="Red" ID="lblErrorEmail" />
                    </div>
                    <div class="form-group">
                        <label for="txtbPassword">Password</label>
                        <asp:TextBox ID="txtbPassword" runat="server" CssClass="form-control" TextMode="Password" />
                        <span id="passwordMessage"></span>
                    </div>
                    <div class="text-center">
                        <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-primary" Text="Register" Onclick="btnRegister_Click" Enabled="false"/>
                        <a href ="Login.aspx" class="btn btn-primary">Cancelar</a>
                    </div>
            </div>
        </div>
    </div>
</asp:Content>
