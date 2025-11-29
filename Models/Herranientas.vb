Public Class Herranientas
    Public Property HerramientaID As Integer
    Public Property Nombre As String
    Public Property Codigo As String
    Public Property Estado As String
    Public Property Ubicacion As String
    Public Property Descripcion As String
    Public Property FechaCreacion As DateTime

    Public Sub New()

        Estado = "Disponible"
        FechaCreacion = DateTime.Now

    End Sub

End Class
