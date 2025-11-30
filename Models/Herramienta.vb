Public Class Herramienta
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

    Public Sub New(herramientaID As Integer, nombre As String, codigo As String, estado As String, ubicacion As String, descripcion As String, fechaCreacion As Date)
        Me.HerramientaID = herramientaID
        Me.Nombre = nombre
        Me.Codigo = codigo
        Me.Estado = estado
        Me.Ubicacion = ubicacion
        Me.Descripcion = descripcion
        Me.FechaCreacion = fechaCreacion
    End Sub
End Class
