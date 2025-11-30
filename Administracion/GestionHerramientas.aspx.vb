Imports System
Imports System.Reflection

Partial Class Admin_GestionHerramientas
    Inherits System.Web.UI.Page

    Private db As New HerramientaDB()

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("Rol") Is Nothing OrElse (Session("Rol").ToString() <> "Admin" AndAlso Session("Rol").ToString() <> "Bodega") Then
            Response.Redirect("~/Account/Login.aspx")
            Return
        End If

        If Not IsPostBack Then
            BindGrid()
        End If
    End Sub

    Private Sub BindGrid()
        gvHerramientas.DataSource = db.GetAll()
        gvHerramientas.DataBind()
    End Sub

    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/Admin/EditHerramienta.aspx") ' crear formulario de creación/edición
    End Sub

    Protected Sub gvHerramientas_RowEditing(sender As Object, e As GridViewEditEventArgs)
        gvHerramientas.EditIndex = e.NewEditIndex
        BindGrid()
    End Sub

    Protected Sub gvHerramientas_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        gvHerramientas.EditIndex = -1
        BindGrid()
    End Sub

    Protected Sub gvHerramientas_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Dim id = Convert.ToInt32(gvHerramientas.DataKeys(e.RowIndex).Value)
        Dim h As New Models.Herramienta With {
            .HerramientaID = id,
            .Nombre = If(e.NewValues("Nombre") IsNot Nothing, e.NewValues("Nombre").ToString(), ""),
            .Codigo = If(e.NewValues("Codigo") IsNot Nothing, e.NewValues("Codigo").ToString(), ""),
            .Estado = If(e.NewValues("Estado") IsNot Nothing, e.NewValues("Estado").ToString(), ""),
            .Ubicacion = If(e.NewValues("Ubicacion") IsNot Nothing, e.NewValues("Ubicacion").ToString(), "")
        }
        Dim msg = db.Update(h)
        SwalUtils.ShowSwal(Me, "Resultado", msg, If(msg.StartsWith("Error"), "error", "success"))
        gvHerramientas.EditIndex = -1
        BindGrid()
    End Sub

    Protected Sub gvHerramientas_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim id = Convert.ToInt32(gvHerramientas.DataKeys(e.RowIndex).Value)
        Dim msg = db.Delete(id)
        SwalUtils.ShowSwal(Me, "Resultado", msg, If(msg.StartsWith("Error"), "error", "success"))
        e.Cancel = True
        BindGrid()
    End Sub

End Class