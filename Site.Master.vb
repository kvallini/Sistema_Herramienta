Imports System

Partial Class SiteMaster
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ConfigureMenuByRole()
        End If
    End Sub

    Private Sub ConfigureMenuByRole()
        Dim role = TryCast(Session("Rol"), String)
        Dim menuHtml As New System.Text.StringBuilder()

        If role Is Nothing Then
            menuHtml.Append("<li class='nav-item'><a class='nav-link' href='~/Account/Login.aspx'>Login</a></li>")
        Else
            ' Empleado
            If role = "Empleado" Then
                menuHtml.Append("<li class='nav-item'><a class='nav-link' href='~/Empleado/HerramientasDisponibles.aspx'>Herramientas</a></li>")
                menuHtml.Append("<li class='nav-item'><a class='nav-link' href='~/Empleado/MisPrestamos.aspx'>Mis préstamos</a></li>")
            End If

            ' Bodega
            If role = "Bodega" Then
                menuHtml.Append("<li class='nav-item'><a class='nav-link' href='~/Bodega/Solicitudes.aspx'>Solicitudes</a></li>")
                menuHtml.Append("<li class='nav-item'><a class='nav-link' href='~/Bodega/PrestamosActivos.aspx'>Préstamos</a></li>")
            End If

            ' Admin
            If role = "Admin" Then
                menuHtml.Append("<li class='nav-item'><a class='nav-link' href='~/Admin/Usuarios.aspx'>Usuarios</a></li>")
                menuHtml.Append("<li class='nav-item'><a class='nav-link' href='~/Admin/GestionHerramientas.aspx'>Herramientas</a></li>")
            End If

            menuHtml.Append("<li class='nav-item'><a class='nav-link' href='javascript:__doPostBack(&#39;lnkLogout&#39;,&#39;&#39;)'>Cerrar sesión</a></li>")
        End If

        MenuItems.Controls.Clear()
        MenuItems.Controls.Add(New LiteralControl(menuHtml.ToString()))

        Dim nombre = TryCast(Session("Nombre"), String)
        If nombre IsNot Nothing Then
            lblUser.Text = "Hola, " & nombre
        End If
    End Sub

    Protected Sub lnkLogout_Click(sender As Object, e As EventArgs)
        Session.Clear()
        Response.Redirect("~/Account/Login.aspx")
    End Sub


End Class