<%@ Page Language="VB" AutoEventWireup="true" CodeBehind="Herramientas.aspx.vb" Inherits="Empleado_HerramientasDisponibles" MasterPageFile="~/Site.Master" %>
<asp ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
Herramientas Disponibles
<asp ID="gvDisponibles" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" DataKeyNames="HerramientaID" OnRowCommand="gvDisponibles_RowCommand">

<asp DataField="HerramientaID" HeaderText="ID" />
<asp DataField="Nombre" HeaderText="Nombre" />
<asp DataField="Codigo" HeaderText="Código" />
<asp DataField="Ubicacion" HeaderText="Ubicación" />
asp:TemplateField

<asp ID="btnSolicitar" runat="server" Text="Solicitar" CssClass="btn btn-sm btn-primary" CommandName="Solicitar" CommandArgument='<%# Eval("HerramientaID") %>' />

</asp>

</asp>
</asp>