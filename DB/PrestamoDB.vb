Imports System.Data
Imports System.Data.SqlClient
Imports System.Reflection

Public Class PrestamoDB
    Public Function GetAll() As DataTable
        Dim q = "SELECT P.*, H.Nombre AS HerramientaNombre, U.Nombre AS UsuarioNombre FROM Prestamos P LEFT JOIN Herramientas H ON P.HerramientaID=H.HerramientaID LEFT JOIN Usuarios U ON P.UsuarioID=U.UsuarioID"
        Return DatabaseHelper.ExecuteQuery(q, Nothing)
    End Function

    Public Function GetPending() As DataTable
        Dim q = "SELECT P.*, H.Nombre AS HerramientaNombre, U.Nombre AS UsuarioNombre FROM Prestamos P LEFT JOIN Herramientas H ON P.HerramientaID=H.HerramientaID LEFT JOIN Usuarios U ON P.UsuarioID=U.UsuarioID WHERE P.Estado='Pendiente'"
        Return DatabaseHelper.ExecuteQuery(q, Nothing)
    End Function

    Public Function Insert(Prestamo) As String
        Dim q = "INSERT INTO Prestamos (HerramientaID,UsuarioID,FechaPrestamo,Estado,Observaciones) VALUES(@HerramientaID,@UsuarioID,@FechaPrestamo,@Estado,@Observaciones)"
        Dim ps = New List(Of SqlParameter) From {
            New SqlParameter("@HerramientaID", HerramientaID),
            New SqlParameter("@UsuarioID", UsuarioID),
            New SqlParameter("@FechaPrestamo", FechaPrestamo),
            New SqlParameter("@Estado", Estado),
            New SqlParameter("@Observaciones", Observaciones)
        }
        Try
            DatabaseHelper.ExecuteNonQuery(q, ps)
            Return "Solicitud creada"
        Catch ex As Exception
            Return "Error: " & ex.Message
        End Try
    End Function

    Public Function UpdateState(id As Integer, estado As String, obs As String, fechaPrevista As DateTime?) As String
        Dim q = "UPDATE Prestamos SET Estado=@Estado, Observaciones=@Obs"
        If fechaPrevista IsNot Nothing Then q &= ", FechaDevolucionPrevista=@FechaPrevista"
        q &= " WHERE PrestamoID=@PrestamoID"

        Dim ps = New List(Of SqlParameter) From {
            New SqlParameter("@Estado", estado),
            New SqlParameter("@Obs", obs),
            New SqlParameter("@PrestamoID", id)
        }
        If fechaPrevista IsNot Nothing Then ps.Add(New SqlParameter("@FechaPrevista", fechaPrevista))
        Try
            DatabaseHelper.ExecuteNonQuery(q, ps)
            Return "Estado actualizado"
        Catch ex As Exception
            Return "Error: " & ex.Message
        End Try
    End Function

End Class