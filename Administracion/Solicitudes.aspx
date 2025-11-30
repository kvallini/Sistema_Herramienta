<%@ Page Language="VB" AutoEventWireup="true" CodeBehind="Solicitudes.aspx.vb" Inherits="Bodega_Solicitudes" MasterPageFile="~/Site.Master" %>
<asp ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
Solicitudes Pendientes
<asp ID="gvSolicitudes" runat="server" CssClass="table table-hover" AutoGenerateColumns="False" DataKeyNames="PrestamoID" OnRowCommand="gvSolicitudes_RowCommand">

<asp DataField="PrestamoID" HeaderText="ID" />
<asp DataField="HerramientaNombre" HeaderText="Herramienta" />
<asp DataField="UsuarioNombre" HeaderText="Solicitante" />
<asp DataField="FechaPrestamo" HeaderText="Fecha Solicitada" DataFormatString="{0/MM/yyyy}" />
<asp DataField="Observaciones" HeaderText="Observaciones" />
asp:TemplateField

<asp ID="btnAprobar" runat="server" Text="Aprobar" CssClass="btn btn-sm btn-success" CommandName="Aprobar" CommandArgument='<%# Eval("PrestamoID") %>' />
<asp ID="btnDenegar" runat="server" Text="Denegar" CssClass="btn btn-sm btn-danger" CommandName="Denegar" CommandArgument='<%# Eval("PrestamoID") %>' />

</asp>

</asp>
</asp>