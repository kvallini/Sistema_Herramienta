<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EditarUsuario.aspx.vb" Inherits="Sistema.Administracion.EditarUsuario" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Editar Usuario</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server" class="container mt-4">

        <h3 class="mb-4">Editar Usuario</h3>

        <asp:HiddenField ID="hfUsuarioID" runat="server" />

        <div class="mb-3">
            <label>Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <label>Email</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <label>Departamento</label>
            <asp:TextBox ID="txtDepartamento" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <label>Rol</label>
            <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-select">
                <asp:ListItem Text="Administrador" Value="Admin" />
                <asp:ListItem Text="Bodega" Value="Bodega" />
                <asp:ListItem Text="Empleado" Value="Empleado" />
            </asp:DropDownList>
        </div>

        <div class="form-check mb-3">
            <asp:CheckBox ID="chkActivo" runat="server" CssClass="form-check-input" />
            <label class="form-check-label">Activo</label>
        </div>

        <asp:Button ID="btnGuardar" Text="Guardar Cambios" CssClass="btn btn-primary" runat="server" />

        <a href="~/Administracion/Usuarios.aspx" class="btn btn-secondary">Regresar</a>

    </form>

    <script src="../Scripts/swalHelper.js"></script>
</body>
</html>
