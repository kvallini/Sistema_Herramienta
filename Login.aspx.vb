Imports System
Imports System.Web.UI
Imports Models

Partial Class Account_Login
    Inherits System.Web.UI.Page

    Private db As New UsuarioDB()
    Public Property SwalUtils As Object

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' si ya está autenticado redirigir
            If Session("UsuarioID") IsNot Nothing Then
                Response.Redirect("~/Default.aspx")
            End If
        End If
    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)
        Try
            Dim email = txtEmail.Text.Trim()
            Dim pass = txtPassword.Text.Trim()
            Dim dt = db.ValidateCredentials(email, pass)
            If dt.Rows.Count = 0 Then
                lblMsg.Text = "Credenciales inválidas"
                SwalUtils.ShowSwal(Me, "Error", "Credenciales inválidas", "error")
                Return
            End If

            Dim row = dt.Rows(0)
            If Not Convert.ToBoolean(row("Activo")) Then
                lblMsg.Text = "Usuario inactivo"
                SwalUtils.ShowSwal(Me, "Error", "Usuario inactivo", "error")
                Return
            End If

            Session("UsuarioID") = row("UsuarioID")
            Session("Nombre") = row("Nombre")
            Session("Rol") = row("Rol")
            Response.Redirect("~/Default.aspx")
        Catch ex As Exception
            lblMsg.Text = ex.Message
            SwalUtils.ShowSwal(Me, "Error", ex.Message, "error")
        End Try
    End Sub

End Class