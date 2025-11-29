Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class ConexionBD
    Public Shared Function ObtenerConexion() As SqlConnection
        Return New SqlConnection(ConfigurationManager.ConnectionStrings("HerramientasConnectionString").ConnectionString)
    End Function

    Public Shared Function EjecutarConsulta(query As String) As DataTable
        Dim tabla As New DataTable()
        Using conexion As SqlConnection = ObtenerConexion()
            Using comando As New SqlCommand(query, conexion)
                conexion.Open()
                Using adapter As New SqlDataAdapter(comando)
                    adapter.Fill(tabla)
                End Using
            End Using
        End Using
        Return tabla
    End Function

    Public Shared Function EjecutarComando(query As String, parametros As List(Of SqlParameter)) As Integer
        Using conexion As SqlConnection = ObtenerConexion()
            Using comando As New SqlCommand(query, conexion)
                If parametros IsNot Nothing Then
                    comando.Parameters.AddRange(parametros.ToArray())
                End If
                conexion.Open()
                Return comando.ExecuteNonQuery()
            End Using
        End Using
    End Function

    Public Shared Function EjecutarComandoSimple(query As String) As Integer
        Using conexion As SqlConnection = ObtenerConexion()
            Using comando As New SqlCommand(query, conexion)
                conexion.Open()
                Return comando.ExecuteNonQuery()
            End Using
        End Using
    End Function

    ' Método para ejecutar consultas con parámetros
    Public Shared Function EjecutarConsultaEscalar(query As String, parametros As List(Of SqlParameter)) As Object
        Using conexion As SqlConnection = ObtenerConexion()
            Using comando As New SqlCommand(query, conexion)
                If parametros IsNot Nothing Then
                    comando.Parameters.AddRange(parametros.ToArray())
                End If
                conexion.Open()
                Return comando.ExecuteScalar()
            End Using
        End Using
    End Function

    ' Método para ejecutar consultas que devuelven un DataTable con parámetros
    Public Shared Function EjecutarConsultaConParametros(query As String, parametros As List(Of SqlParameter)) As DataTable
        Dim tabla As New DataTable()
        Using conexion As SqlConnection = ObtenerConexion()
            Using comando As New SqlCommand(query, conexion)
                If parametros IsNot Nothing Then
                    comando.Parameters.AddRange(parametros.ToArray())
                End If
                conexion.Open()
                Using adapter As New SqlDataAdapter(comando)
                    adapter.Fill(tabla)
                End Using
            End Using
        End Using
        Return tabla
    End Function
End Class