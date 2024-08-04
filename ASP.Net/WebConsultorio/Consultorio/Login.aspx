<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Consultorio.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <label class="col-form-label">Usuario: </label>
                <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="col-form-label">Contraseña: </label>
                <asp:TextBox runat="server" ID="txtContraseña"  CssClass="form-control" type="password"/>
            </div>
            <div class="mb-3">
                <asp:Button Text="Ingresar" ID="btnIngresar" CssClass="btn btn-dark" runat="server" OnClick="btnIngresar_Click" />
                <a class="btn btn-link" href="Default.aspx">Salir</a>
            </div>
        </div>
    </div>
     
</asp:Content>
