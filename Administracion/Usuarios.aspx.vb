Imports System
Imports System.Reflection
Imports Sistema_Herramienta.Models

Partial Class Admin_Usuarios
    Inherits System.Web.UI.Page

    'clase que maneja la conexión y operaciones de BD
    Private db As New UsuarioDB()

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' Validar que el usuario tenga rol de administrador
        If Session("Rol") Is Nothing OrElse Session("Rol").ToString() <> "Admin" Then
            Response.Redirect("~/Account/Login.aspx")
            Return
        End If

        ' Solo cargar datos cuando no es un postback
        If Not IsPostBack Then
            BindGrid()
        End If
    End Sub

    'BindGrid: Carga los datos de usuarios desde la BD al GridView.
    Private Sub BindGrid()
        gvUsuarios.DataSource = db.GetAll()
        gvUsuarios.DataBind()
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/Admin/EditUsuario.aspx")
    End Sub

    'Editar
    Protected Sub gvUsuarios_RowEditing(sender As Object, e As GridViewEditEventArgs)
        gvUsuarios.EditIndex = e.NewEditIndex
        BindGrid()
    End Sub

    Protected Sub gvUsuarios_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        gvUsuarios.EditIndex = -1
        BindGrid()
    End Sub

    'Actualizar un registro desde el GridView
    Protected Sub gvUsuarios_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)

        ' Obtener ID del usuario a modificar
        Dim id = Convert.ToInt32(gvUsuarios.DataKeys(e.RowIndex).Value)
        Dim nombre = e.NewValues("Nombre")
        Dim email = e.NewValues("Email")
        Dim departamento = e.NewValues("Departamento")
        Dim rol = e.NewValues("Rol")

        ' Crear un "objeto" usuario
        Dim u As New Usuario With {
            .UsuarioID = id,
            .Nombre = If(nombre IsNot Nothing, nombre.ToString(), ""),
            .Email = If(email IsNot Nothing, email.ToString(), ""),
            .Departamento = If(departamento IsNot Nothing, departamento.ToString(), ""),
            .Rol = If(rol IsNot Nothing, rol.ToString(), ""),
            .Contrasena = ""
        }

        'actualizar usuario en la base de datos
        Dim msg = db.Update(u)
        gvUsuarios.EditIndex = -1
        BindGrid()
    End Sub

    'Eliminar un usuario desde el GridView
    Protected Sub gvUsuarios_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)

        Dim id = Convert.ToInt32(gvUsuarios.DataKeys(e.RowIndex).Value)
        Dim msg = db.Delete(id)
        e.Cancel = True

        ' Actualizar la tabla
        BindGrid()
    End Sub

End Class
