<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="logUsuario.aspx.cs" Inherits="Consultorio.logUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center">Si entraste aca es porque te logeaste</h1>
    <asp:Button Text="Pagina Usuarios" runat="server" ID="btnUsuarios" cssclass="btn-dark btn-sm" OnClick="btnUsuarios_Click"/>
    <%if (Session["Usuario"] != null && ((Dominio.Usuario)Session["Usuario"]).TipoUsuario == Dominio.UserType.ADMIN) { %>
         <asp:Button Text="Pagina Admin" cssclass="btn-dark btn-sm" ID="btnAdmin" runat="server" OnClick="btnAdmin_Click" />
            
        <%} %>
    
</asp:Content>
