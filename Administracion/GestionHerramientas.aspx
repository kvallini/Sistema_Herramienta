<%@ Page Language="VB" AutoEventWireup="true" CodeBehind="GestionHerramientas.aspx.vb" Inherits="Admin_GestionHerramientas" MasterPageFile="~/Site.Master" %>
<asp ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
Herramientas
<asp ID="btnAgregar" runat="server" CssClass="btn btn-success mb-2" Text="Agregar" OnClick="btnAgregar_Click" />
<asp ID="gvHerramientas" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" DataKeyNames="HerramientaID" OnRowDeleting="gvHerramientas_RowDeleting" OnRowEditing="gvHerramientas_RowEditing" OnRowCancelingEdit="gvHerramientas_RowCancelingEdit" OnRowUpdating="gvHerramientas_RowUpdating">

<asp DataField="HerramientaID" HeaderText="ID" ReadOnly="True" />
<asp DataField="Nombre" HeaderText="Nombre" />
<asp DataField="Codigo" HeaderText="Código" />
<asp DataField="Estado" HeaderText="Estado" />
<asp DataField="Ubicacion" HeaderText="Ubicación" />
asp:TemplateField

<asp ID="lnkEdit" runat="server" CommandName="Edit" Text="Editar" CssClass="btn btn-sm btn-primary" />
<asp ID="lnkDelete" runat="server" CommandName="Delete" Text="Eliminar" CssClass="btn btn-sm btn-danger" />

</asp>

</asp>
</asp>