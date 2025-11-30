Public Class Prestamo
    Public Property PrestamoID As Integer
    Public Property HerramientaID As Integer
    Public Property UsuarioID As Integer
    Public Property FechaPrestamo As DateTime
    Public Property FechaDevolucionPrevista As DateTime?
    Public Property FechaDevolucionReal As DateTime?
    Public Property Estado As String
    Public Property Observaciones As String

    Public Sub New()
        FechaPrestamo = DateTime.Now
        Estado = "Activo"
    End Sub

    Public Sub New(prestamoID As Integer, herramientaID As Integer, usuarioID As Integer, fechaPrestamo As Date, fechaDevolucionPrevista As Date?, fechaDevolucionReal As Date?, estado As String, observaciones As String)
        Me.PrestamoID = prestamoID
        Me.HerramientaID = herramientaID
        Me.UsuarioID = usuarioID
        Me.FechaPrestamo = fechaPrestamo
        Me.FechaDevolucionPrevista = fechaDevolucionPrevista
        Me.FechaDevolucionReal = fechaDevolucionReal
        Me.Estado = estado
        Me.Observaciones = observaciones
    End Sub
End Class