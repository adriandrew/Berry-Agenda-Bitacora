Imports System.Data.SqlClient

Public Class ActividadesFijas
     
    Private id As Integer
    Private idArea As Integer 
    Private idUsuario As Integer 
    Private nombre As String
    Private descripcion As String 
    Private idRangoFijoCreacion As Integer
    Private idRangoFijoVencimiento As Integer
    Private esUrgente As Boolean
    Private esExterna As Boolean
    Private idAreaDestino As Integer
    Private idUsuarioDestino As Integer
    Private solicitaAutorizacion As Boolean
    Private solicitaEvidencia As Boolean

    Public Property EId() As Integer
        Get
            Return Me.id
        End Get
        Set(value As Integer)
            Me.id = value
        End Set
    End Property
    Public Property EIdArea() As Integer
        Get
            Return Me.idArea
        End Get
        Set(value As Integer)
            Me.idArea = value
        End Set
    End Property
    Public Property EIdUsuario() As Integer
        Get
            Return Me.idUsuario
        End Get
        Set(value As Integer)
            Me.idUsuario = value
        End Set
    End Property
    Public Property ENombre() As String
        Get
            Return Me.nombre
        End Get
        Set(value As String)
            Me.nombre = value
        End Set
    End Property
    Public Property EDescripcion() As String
        Get
            Return Me.descripcion
        End Get
        Set(value As String)
            Me.descripcion = value
        End Set
    End Property
    Public Property EIdRangoFijoCreacion() As String
        Get
            Return Me.idRangoFijoCreacion
        End Get
        Set(value As String)
            Me.idRangoFijoCreacion = value
        End Set
    End Property
    Public Property EIdRangoFijoVencimiento() As String
        Get
            Return Me.idRangoFijoVencimiento
        End Get
        Set(value As String)
            Me.idRangoFijoVencimiento = value
        End Set
    End Property
    Public Property EEsUrgente() As Boolean
        Get
            Return Me.esUrgente
        End Get
        Set(value As Boolean)
            Me.esUrgente = value
        End Set
    End Property
    Public Property EEsExterna() As Boolean
        Get
            Return Me.esExterna
        End Get
        Set(value As Boolean)
            Me.esExterna = value
        End Set
    End Property
    Public Property EIdAreaDestino() As Integer
        Get
            Return Me.idAreaDestino
        End Get
        Set(value As Integer)
            Me.idAreaDestino = value
        End Set
    End Property
    Public Property EIdUsuarioDestino() As Integer
        Get
            Return Me.idUsuarioDestino
        End Get
        Set(value As Integer)
            Me.idUsuarioDestino = value
        End Set
    End Property
    Public Property ESolicitaAutorizacion() As Boolean
        Get
            Return Me.solicitaAutorizacion
        End Get
        Set(value As Boolean)
            Me.solicitaAutorizacion = value
        End Set
    End Property
    Public Property ESolicitaEvidencia() As Boolean
        Get
            Return Me.solicitaEvidencia
        End Get
        Set(value As Boolean)
            Me.solicitaEvidencia = value
        End Set
    End Property

    Public Function ObtenerListadoReporte() As DataTable

        Try
            Dim datos As New DataTable
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            comando.CommandText = "SELECT AF.Id, AF.Nombre, AF.Descripcion, AF.IdRangoFijoCreacion, RFC.Nombre, AF.IdRangoFijoVencimiento, RFV.Nombre, AF.EsUrgente, AF.EsExterna, AF.IdAreaDestino, Areas.Nombre, AF.IdUsuarioDestino, U.Nombre AS NombreUsuario, AF.SolicitaAutorizacion, AF.SolicitaEvidencia " & _
            " FROM (((ActividadesFijas AS AF LEFT JOIN [CATALOGOS].dbo.RangosFijos AS RFC ON AF.IdRangoFijoCreacion = RFC.Id) LEFT JOIN [CATALOGOS].dbo.RangosFijos AS RFV ON AF.IdRangoFijoVencimiento = RFV.Id) LEFT JOIN [Informacion].dbo.Usuarios AS U ON AF.IdUsuarioDestino = U.Id) LEFT JOIN [CATALOGOS].dbo.Areas ON AF.IdAreaDestino = Areas.Id " & _
            " WHERE AF.IdArea=@idArea AND AF.IdUsuario=@idUsuario"
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
            BaseDatos.conexionCatalogo.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            datos.Load(dataReader)
            BaseDatos.conexionCatalogo.Close()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionCatalogo.Close()
        End Try

    End Function

    Public Sub Guardar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            comando.CommandText = "INSERT INTO ActividadesFijas (Id, IdArea, IdUsuario, Nombre, Descripcion, idRangoFijoCreacion, IdRangoFijoVencimiento, EsUrgente, EsExterna, IdAreaDestino, IdUsuarioDestino, SolicitaAutorizacion, SolicitaEvidencia) VALUES (@id, @idArea, @idUsuario, @nombre, @descripcion, @idRangoFijoCreacion, @idRangoFijoVencimiento, @esUrgente, @esExterna, @idAreaDestino, @idUsuarioDestino, @solicitaAutorizacion, @solicitaEvidencia)"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
            comando.Parameters.AddWithValue("@nombre", Me.ENombre)
            comando.Parameters.AddWithValue("@descripcion", Me.EDescripcion)
            comando.Parameters.AddWithValue("@idRangoFijoCreacion", Me.EIdRangoFijoCreacion)
            comando.Parameters.AddWithValue("@idRangoFijoVencimiento", Me.EIdRangoFijoVencimiento)
            comando.Parameters.AddWithValue("@esUrgente", Me.EEsUrgente)
            comando.Parameters.AddWithValue("@esExterna", Me.EEsExterna)
            comando.Parameters.AddWithValue("@idAreaDestino", Me.EIdAreaDestino)
            comando.Parameters.AddWithValue("@idUsuarioDestino", Me.EIdUsuarioDestino)
            comando.Parameters.AddWithValue("@solicitaAutorizacion", Me.ESolicitaAutorizacion)
            comando.Parameters.AddWithValue("@solicitaEvidencia", Me.ESolicitaEvidencia)
            BaseDatos.conexionCatalogo.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionCatalogo.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionCatalogo.Close()
        End Try

    End Sub

    Public Sub Editar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            comando.CommandText = "UPDATE ActividadesFijas SET Nombre=@nombre, Descripcion=@descripcion, IdRango=@idRango, EsUrgente=@esUrgente, EsExterna=@esExterna, IdAreaDestino=@idAreaDestino, IdUsuarioDestino=@idUsuarioDestino, SolicitaAutorizacion=@solicitaAutorizacion, SolicitaEvidencia=@solicitaEvidencia WHERE Id=@id AND IdArea=@idArea AND IdUsuario=@idUsuario"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
            comando.Parameters.AddWithValue("@nombre", Me.ENombre)
            comando.Parameters.AddWithValue("@descripcion", Me.EDescripcion)
            comando.Parameters.AddWithValue("@idRango", Me.EIdRangoFijoCreacion)
            comando.Parameters.AddWithValue("@esUrgente", Me.EEsUrgente)
            comando.Parameters.AddWithValue("@esExterna", Me.EEsExterna)
            comando.Parameters.AddWithValue("@idAreaDestino", Me.EIdAreaDestino)
            comando.Parameters.AddWithValue("@idUsuarioDestino", Me.EIdUsuarioDestino)
            comando.Parameters.AddWithValue("@solicitaAutorizacion", Me.ESolicitaAutorizacion)
            comando.Parameters.AddWithValue("@solicitaEvidencia", Me.ESolicitaEvidencia)
            BaseDatos.conexionCatalogo.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionCatalogo.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionCatalogo.Close()
        End Try

    End Sub

    Public Sub Eliminar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            comando.CommandText = "DELETE FROM ActividadesFijas WHERE IdArea=@idArea AND IdUsuario=@idUsuario" 
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
            BaseDatos.conexionCatalogo.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionCatalogo.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionCatalogo.Close()
        End Try

    End Sub

    Public Function ValidarPorId() As Boolean

        Try
            Dim resultado As Boolean = False
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionCatalogo
            comando.CommandText = "SELECT Id FROM ActividadesFijas WHERE Id=@id AND IdArea=@idArea AND IdUsuario=@idUsuario"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
            BaseDatos.conexionCatalogo.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            If (dataReader.HasRows) Then
                resultado = True
            Else
                resultado = False
            End If
            BaseDatos.conexionCatalogo.Close()
            Return resultado
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionCatalogo.Close()
        End Try

    End Function

End Class
