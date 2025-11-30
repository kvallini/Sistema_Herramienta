Imports App_Code

Namespace Administracion
    Public Class EditarUsuario
        Inherits System.Web.UI.Page

        Private usuarioDB As New UsuarioDB()

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not IsPostBack Then
                Dim id As Integer = Convert.ToInt32(Request.QueryString("id"))
                CargarUsuario(id)
            End If
        End Sub

        Private Sub CargarUsuario(id As Integer)
            Dim u = usuarioDB.GetById(id)

            If u Is Nothing Then
                Response.Redirect("~/Administracion/Usuarios.aspx")
            End If

            hfUsuarioID.Value = u.UsuarioID
            txtNombre.Text = u.Nombre
            txtEmail.Text = u.Email
            txtDepartamento.Text = u.Departamento
            ddlRol.SelectedValue = u.Rol
            chkActivo.Checked = u.Activo
        End Sub

        Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
            Dim u As New Usuario With {
                .UsuarioID = hfUsuarioID.Value,
                .Nombre = txtNombre.Text,
                .Email = txtEmail.Text,
                .Departamento = txtDepartamento.Text,
                .Rol = ddlRol.SelectedValue,
                .Activo = chkActivo.Checked
            }

            If usuarioDB.Update(u) Then
                SwalUtils.SwalSuccess(Me, "Usuario actualizado", "~/Administracion/Usuarios.aspx")
            Else
                SwalUtils.SwalError(Me, "Error al actualizar el usuario")
            End If
        End Sub

    End Class
End Namespace
