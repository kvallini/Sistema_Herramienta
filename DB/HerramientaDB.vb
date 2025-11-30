Imports System.Data
Imports System.Data.SqlClient
Imports System.Reflection

Public Class HerramientaDB

    Private ReadOnly db As New DatabaseHelper()

    Public Function GetAll() As DataTable
        Dim q = "SELECT * FROM Herramientas"
        Return db.ExecuteQuery(q)
    End Function

    Public Function GetAvailable() As DataTable
        Dim q = "SELECT * FROM Herramientas WHERE Estado='Disponible'"
        Return db.ExecuteQuery(q)
    End Function

    Public Function GetById(id As Integer) As DataTable
        Dim q = "SELECT * FROM Herramientas WHERE HerramientaID=@id"
        Dim p = New List(Of SqlParameter) From {New SqlParameter("@id", id)}
        Return db.ExecuteQuery(q, p)
    End Function

    Public Function Insert(Herramienta) As String
        Dim q = "INSERT INTO Herramientas 
                (Nombre,Codigo,Estado,Ubicacion,Descripcion,FechaCreacion) 
                 VALUES(@Nombre,@Codigo,@Estado,@Ubicacion,@Descripcion,@FechaCreacion)"

        Dim p = New List(Of SqlParameter) From {
            New SqlParameter("@Nombre", Nombre),
            New SqlParameter("@Codigo", Codigo),
            New SqlParameter("@Estado", Estado),
            New SqlParameter("@Ubicacion", Ubicacion),
            New SqlParameter("@Descripcion", Descripcion),
            New SqlParameter("@FechaCreacion", FechaCreacion)
        }

        Try
            db.ExecuteNonQuery(q, p)
            Return "Herramienta agregada"
        Catch ex As Exception
            Return "Error: " & ex.Message
        End Try
    End Function

    Public Function Update(Herramienta) As String
        Dim q = "UPDATE Herramientas 
                 SET Nombre=@Nombre, Codigo=@Codigo, Estado=@Estado, 
                     Ubicacion=@Ubicacion, Descripcion=@Descripcion, 
                     FechaCreacion=@FechaCreacion
                 WHERE HerramientaID=@HerramientaID"

        Dim p = New List(Of SqlParameter) From {
            New SqlParameter("@Nombre", Nombre),
            New SqlParameter("@Codigo", Codigo),
            New SqlParameter("@Estado", Estado),
            New SqlParameter("@Ubicacion", Ubicacion),
            New SqlParameter("@Descripcion", Descripcion),
            New SqlParameter("@FechaCreacion", FechaCreacion),
            New SqlParameter("@HerramientaID", HerramientaID)
        }

        Try
            db.ExecuteNonQuery(q, p)
            Return "Herramienta actualizada"
        Catch ex As Exception
            Return "Error: " & ex.Message
        End Try
    End Function

    Public Function Delete(id As Integer) As String
        Dim q = "DELETE FROM Herramientas WHERE HerramientaID=@id"
        Dim p = New List(Of SqlParameter) From {New SqlParameter("@id", id)}

        Try
            db.ExecuteNonQuery(q, p)
            Return "Herramienta eliminada"
        Catch ex As Exception
            Return "Error: " & ex.Message
        End Try
    End Function

End Class
