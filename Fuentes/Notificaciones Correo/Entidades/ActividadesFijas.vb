Imports System.Data.SqlClient

Public Class ActividadesFijas
     
    Public Function ObtenerListado() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo 
            comando.CommandText = "SELECT IdArea, IdUsuario, Id, Nombre, Descripcion, IdRango, IdDiaMes, FechaInicio, CantidadDiasEspera, CantidadDiasRecordatorio, EsUrgente, EsExterna, IdAreaDestino, IdUsuarioDestino, SolicitaAutorizacion, SolicitaEvidencia " & _
            " FROM ActividadesFijas" & _
            " ORDER BY IdArea, IdUsuario, Id ASC"
            BaseDatos.conexionCatalogo.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            datos.Load(dataReader)
            BaseDatos.conexionCatalogo.Close()
            Return datos
        Catch ex As Exception
            Throw ex
        End Try

    End Function

End Class
