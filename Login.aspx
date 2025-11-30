<%@ Page Language="VB" AutoEventWireup="true" CodeBehind="Login.aspx.vb" Inherits="Account_Login" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4" style="max-width:400px;">
        <h3 class="text-center mb-4">Login</h3>

        <!-- Mensaje -->
        <asp:Label ID="lblMsg" runat="server" CssClass="text-danger"></asp:Label>

        <!-- Email -->
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control mb-3" Placeholder="Email"></asp:TextBox>

        <!-- Contraseña -->
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control mb-3" Placeholder="Contraseña"></asp:TextBox>

        <!-- Botón -->
        <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary w-100" Text="Ingresar" OnClick="btnLogin_Click" />

    </div>

</asp:Content>
