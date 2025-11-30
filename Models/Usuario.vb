Namespace Models

    Public Class Usuario
        Public Property UsuarioID As Integer
        Public Property Nombre As String
        Public Property Email As String
        Public Property Departamento As String
        Public Property FechaRegistro As DateTime
        Public Property Activo As Boolean = True
        Public Property Contrasena As String
        Public Property Rol As String
        Public Sub New()
            FechaRegistro = DateTime.Now
            Activo = True
        End Sub

        Public Sub New(usuarioID As Integer, nombre As String, email As String, departamento As String, fechaRegistro As Date, activo As Boolean, contrasena As String, rol As String)
            Me.UsuarioID = usuarioID
            Me.Nombre = nombre
            Me.Email = email
            Me.Departamento = departamento
            Me.FechaRegistro = fechaRegistro
            Me.Activo = activo
            Me.Contrasena = contrasena
            Me.Rol = rol
        End Sub
    End Class
End Namespace
