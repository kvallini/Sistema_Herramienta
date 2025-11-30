Imports System

Partial Class Bodega_Solicitudes
    Inherits System.Web.UI.Page

    Private db As New PrestamoDB()

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("Rol") Is Nothing OrElse Session("Rol").ToString() <> "Bodega" Then
            Response.Redirect("~/Account/Login.aspx")
            Return
        End If

        If Not IsPostBack Then
            BindGrid()
        End If
    End Sub

    Private Sub BindGrid()
        gvSolicitudes.DataSource = db.GetPending()
        gvSolicitudes.DataBind()
    End Sub

    Protected Sub gvSolicitudes_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "Aprobar" Then
            Dim id = Convert.ToInt32(e.CommandArgument)
            ' Ejemplo: establecer fecha prevista 7 días después
            Dim fechaPrev = DateTime.Now.AddDays(7)
            Dim msg = db.UpdateState(id, "Aprobado", "", fechaPrev)
            SwalUtils.ShowSwal(Me, "Resultado", msg, If(msg.StartsWith("Error"), "error", "success"))
            BindGrid()
        ElseIf e.CommandName = "Denegar" Then
            Dim id = Convert.ToInt32(e.CommandArgument)
            Dim msg = db.UpdateState(id, "Denegado", "Rechazado por bodega", Nothing)
            SwalUtils.ShowSwal(Me, "Resultado", msg, If(msg.StartsWith("Error"), "error", "success"))
            BindGrid()
        End If
    End Sub

End Class