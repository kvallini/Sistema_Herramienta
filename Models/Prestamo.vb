Public Class Prestamo
    Public Property PrestamoID As Integer
    Public Property HerramientaID As Integer
    Public Property UsuarioID As Integer
    Public Property FechaPrestamo As DateTime
    Public Property FechaDevolucionPrevista As DateTime
    Public Property FechaDevolucionReal As DateTime?
    Public Property Estado As String
    Public Property Observaciones As String

    Public Sub New()
        FechaPrestamo = DateTime.Now
        Estado = "Activo"
    End Sub
End Class