Public Class Usuario
    Public Property UsuarioID As Integer
    Public Property Nombre As String
    Public Property Email As String
    Public Property Departamento As String
    Public Property FechaRegistro As DateTime
    Public Property Activo As Boolean
    Public Property Contraseña As String
    Public Property Rol As String
    Public Sub New()
        FechaRegistro = DateTime.Now
        Activo = True
    End Sub
End Class
