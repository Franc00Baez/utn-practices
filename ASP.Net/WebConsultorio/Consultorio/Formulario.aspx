<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="Consultorio.Formulario" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre del medico</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido del medico</label>
                <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtFechaNacimiento" class="form-label">Fecha de nacimiento</label>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <asp:TextBox runat="server" ID="txtFechaNacimiento" CssClass="form-control" />
                            <asp:CalendarExtender TargetControlID="txtFechaNacimiento" runat="server" Format="yyyy/MM/dd" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>  
            <div class="mb-3">
                <label class="form-label">Seleccione especialidad</label>
                <asp:DropDownList runat="server" ID="ddlEspecialidades" CssClass="btn btn-sm btn-dark dropdown-toggle"></asp:DropDownList>
                <asp:DropDownList runat="server" ID="ddlSexo" CssClass="btn btn-sm btn-dark dropdown-toggle">
                    <asp:ListItem Text="Masculino" CssClass="dropdown-item" />
                    <asp:ListItem Text="Femenino"  />
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label class="form-label" for="txtFechaAlta">Fecha de alta</label>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:TextBox runat="server" ID="txtFechaAlta" CssClass="form-control" />
                        <asp:CalendarExtender TargetControlID="txtFechaAlta" runat="server" Format="yyyy/MM/dd" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="mb-3">
                <asp:Button Text="Aceptar" runat="server" CssClass="btn btn-primary" ID="btnAceptar" OnClick="btnAceptar_Click" />
                <a class="link-body-emphasis" href="Default.aspx">Cancelar</a>
            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <label class="form-label" for="txtCosto">Costo de Consulta </label>
                <asp:TextBox runat="server" ID="txtCosto" CssClass="form-control" />
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagen" class="form-label">Ingrese URL de imagen</label>
                        <asp:TextBox runat="server" ID="txtImagen" CssClass="form-control" OnTextChanged="txtImagen_TextChanged" AutoPostBack="true" />
                        <asp:Image ID="Imagen" runat="server" ImageUrl="https://t3.ftcdn.net/jpg/02/48/42/64/360_F_248426448_NVKLywWqArG2ADUxDq6QprtIzsF82dMF.jpg" alt="Imagen" Width="30%" Class="mx-auto" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        </div>
</asp:Content>
