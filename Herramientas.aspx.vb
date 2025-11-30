Imports System
Imports System.Reflection

Partial Class Empleado_HerramientasDisponibles
    Inherits System.Web.UI.Page

    Private hdb As New HerramientaDB()
    Private pdb As New PrestamoDB()

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("Rol") Is Nothing OrElse Session("Rol").ToString() <> "Empleado" Then
            Response.Redirect("~/Account/Login.aspx")
            Return
        End If

        If Not IsPostBack Then
            BindGrid()
        End If
    End Sub

    Private Sub BindGrid()
        gvDisponibles.DataSource = hdb.GetAvailable()
        gvDisponibles.DataBind()
    End Sub

    Protected Sub gvDisponibles_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "Solicitar" Then
            Dim id = Convert.ToInt32(e.CommandArgument)
            Dim pres As New Models.Prestamo With {
                .HerramientaID = id,
                .UsuarioID = Convert.ToInt32(Session("UsuarioID")),
                .FechaPrestamo = DateTime.Now,
                .Estado = "Pendiente",
                .Observaciones = ""
            }
            Dim msg = pdb.Insert(pres)
            SwalUtils.ShowSwal(Me, "Resultado", msg, If(msg.StartsWith("Error"), "error", "success"))
            BindGrid()
        End If
    End Sub

End Class