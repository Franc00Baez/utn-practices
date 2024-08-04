<%@ Page Title="Error" Language="C#" MasterPageFile="~/Wallet.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WEB.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 20px;
        }

        .error-content {
            background-color: #fff;
            padding: 20px;
            border: 1px solid #ddd;
            border-radius: 4px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        pre {
            white-space: pre-wrap;
            word-wrap: break-word;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="error-content">
        <h2>Ocurrió un error</h2>
        <p>Lo sentimos, pero ocurrió un error. Aquí está el registro del error:</p>
        <asp:Literal ID="ltlErrorMessage" runat="server" />
    </div>
</asp:Content>
