<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EditarHerramienta.aspx.vb" Inherits="Sistema.Administracion.EditarHerramienta" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Editar Herramienta</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server" class="container mt-4">

        <h3 class="mb-4">Editar Herramienta</h3>

        <asp:HiddenField ID="hfID" runat="server" />

        <div class="mb-3">
            <label>Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <label>Código</label>
            <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <label>Ubicación</label>
            <asp:TextBox ID="txtUbicacion" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <label>Estado</label>
            <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select">
                <asp:ListItem Text="Disponible" Value="Disponible" />
                <asp:ListItem Text="Prestada" Value="Prestada" />
                <asp:ListItem Text="En reparación" Value="Reparacion" />
            </asp:DropDownList>
        </div>

        <div class="mb-3">
            <label>Descripción</label>
            <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" CssClass="form-control" />
        </div>

        <asp:Button ID="btnGuardar" Text="Guardar Cambios" CssClass="btn btn-primary" runat="server" />

        <a href="~/Administracion/GestionHerramientas.aspx" class="btn btn-secondary">Regresar</a>

    </form>

    <script src="../Scripts/swalHelper.js"></script>
</body>
</html>
