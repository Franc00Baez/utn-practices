<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Consultorio.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="row row-cols-1 row-cols-md-2 g-4">
            <asp:Repeater runat="server" ID="Repeater" OnItemDataBound="Repeater_ItemDataBound">
                <ItemTemplate>
                    <div class="col">
                        <div class="card">
                            <img src='<%# Eval("Imagenes") != null && ((List<string>)Eval("Imagenes")).Count > 0 ? Eval("Imagenes[0]") : "https://t3.ftcdn.net/jpg/02/48/42/64/360_F_248426448_NVKLywWqArG2ADUxDq6QprtIzsF82dMF.jpg" %>' class="card-img-top img-fluid w-50" alt="Imagen" />
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Datos_Personales.Nombre") %> <%#Eval("Datos_Personales.Apellido") %></h5>
                                <p class="card-text">Especialidad: <%#Eval("Especialidad.tipo") %></p>
                                <p class="card-text">Fecha de ingreso:  <%# ((DateTime)Eval("Fecha_ingreso")).ToString("dd/MM/yyyy") %></p>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
