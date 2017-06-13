Imports System.Data.SqlClient

Public Class Actividades

    Private id As Integer
    Private idArea As Integer
    Private idUsuario As Integer
    Private idAreaDestino As Integer
    Private idUsuarioDestino As Integer
    Private fechaCreacion1 As Date
    Private fechaCreacion2 As Date
    Private fechaVencimiento1 As Date
    Private fechaVencimiento2 As Date
    Private fechaResolucion1 As Date
    Private fechaResolucion2 As Date

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
    Public Property EFechaCreacion1() As String
        Get
            Return Me.fechaCreacion1
        End Get
        Set(value As String)
            Me.fechaCreacion1 = value
        End Set
    End Property
    Public Property EFechaCreacion2() As String
        Get
            Return Me.fechaCreacion2
        End Get
        Set(value As String)
            Me.fechaCreacion2 = value
        End Set
    End Property
    Public Property EFechaVencimiento1() As String
        Get
            Return Me.fechaVencimiento1
        End Get
        Set(value As String)
            Me.fechaVencimiento1 = value
        End Set
    End Property
    Public Property EFechaVencimiento2() As String
        Get
            Return Me.fechaVencimiento2
        End Get
        Set(value As String)
            Me.fechaVencimiento2 = value
        End Set
    End Property
    Public Property EFechaResolucion1() As String
        Get
            Return Me.fechaResolucion1
        End Get
        Set(value As String)
            Me.fechaResolucion1 = value
        End Set
    End Property
    Public Property EFechaResolucion2() As String
        Get
            Return Me.fechaResolucion2
        End Get
        Set(value As String)
            Me.fechaResolucion2 = value
        End Set
    End Property

    Public Function ObtenerListadoReporte(ByVal tipo As Integer, ByVal estatus As Integer, ByVal calificacion As Integer, ByVal aplicaFechaCreacion As Boolean, ByVal aplicaFechaVencimiento As Boolean, ByVal aplicaFechaResolucion As Boolean) As DataTable

        Dim datos As New DataTable
        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            Dim consultaWhere As String = String.Empty
            If tipo = 1 Then
                consultaWhere &= " AND (A.EsExterna = 'FALSE' OR A.EsExterna IS NULL) "
            ElseIf tipo = 2 Then
                consultaWhere &= " AND A.EsExterna = 'TRUE' "
            End If
            If estatus = 1 Then
                consultaWhere &= " AND (A.EstaResuelto = 'FALSE' OR A.EstaResuelto IS NULL) "
            ElseIf estatus = 2 Then
                consultaWhere &= " AND A.EstaResuelto = 'TRUE' "
            End If
            If calificacion = 1 Then
                consultaWhere &= " AND (A.EsRechazado = 'FALSE' OR A.EsRechazado IS NULL) AND (A.EsAutorizado = 'FALSE' OR A.EsAutorizado IS NULL) "
            ElseIf calificacion = 2 Then
                consultaWhere &= " AND A.EsRechazado = 'TRUE' "
            ElseIf calificacion = 3 Then
                consultaWhere &= " AND A.EsAutorizado = 'TRUE' "
            End If
            If Me.EIdArea > 0 Then
                consultaWhere &= " AND A.IdArea=@idArea "
            End If
            If Me.EIdUsuario > 0 Then
                consultaWhere &= " AND A.IdUsuario=@idUsuario "
            End If
            If Me.EIdAreaDestino > 0 Then
                consultaWhere &= " AND A.IdAreaDestino=@idAreaDestino "
            End If
            If Me.EIdUsuarioDestino > 0 Then
                consultaWhere &= " AND A.IdUsuarioDestino=@idUsuarioDestino "
            End If
            If (aplicaFechaCreacion) Then
                consultaWhere &= " AND A.FechaCreacion BETWEEN @fechaCreacion AND @fechaCreacion2 "
            End If
            If (aplicaFechaVencimiento) Then
                consultaWhere &= " AND A.FechaVencimiento BETWEEN @fechaVencimiento AND @fechaVencimiento2 "
            End If
            If (aplicaFechaResolucion) Then
                consultaWhere &= " AND AR.FechaResolucion BETWEEN @fechaResolucion AND @fechaResolucion2 "
            End If
            comando.CommandText = "SELECT " & _
            "CASE " & _
                "WHEN (R.EsExterna='FALSE' OR R.EsExterna IS NULL) THEN 'Interno' " & _
                "WHEN (R.EsExterna ='TRUE') THEN 'Externo' " & _
            "END AS Tipo, " & _
            "CASE " & _
                "WHEN (R.EstaResuelto ='TRUE') THEN 'Resuelto' " & _
                "WHEN (R.EstaResuelto='FALSE' OR R.EstaResuelto IS NULL) THEN 'Abierto' " & _
            "END AS Estatus, " & _
            "CASE " & _
                "WHEN (R.EsExterna='FALSE') THEN 'No Aplica' " & _
                "WHEN ((R.EsAutorizado='TRUE') AND (R.EsExterna = 'TRUE')) THEN 'Autorizado' " & _
                "WHEN ((R.EsRechazado='TRUE') AND (R.EsExterna = 'TRUE')) THEN 'Rechazado' " & _
                "WHEN ((R.EsAutorizado='FALSE' OR R.EsAutorizado IS NULL AND R.EsRechazado='FALSE' OR R.EsRechazado IS NULL) AND (R.EsExterna = 'TRUE')) THEN 'Pendiente' " & _
            "END AS Calificacion, R.*" & _
            " FROM " & _
            "(" & _
                "SELECT A.Id, A.IdArea, Areas.Nombre AS NombreArea, A.IdUsuario, U.Nombre AS NombreUsuario, A.IdAreaDestino, AreasD.Nombre AS NombreAreaDestino, A.IdUsuarioDestino, UD.Nombre AS NombreUsuarioDestino, A.Nombre, A.Descripcion, A.FechaCreacion, A.FechaVencimiento, A.EsUrgente, AR.IdAreaOrigen, AreasR.Nombre AS NombreAreaResuelto, AR.IdUsuarioOrigen, UR.Nombre AS NombreUsuarioResuelto, AR.Descripcion AS DescripcionResolucion, AR.MotivoRetraso, AR.FechaResolucion, A.SolicitaAutorizacion, A.SolicitaEvidencia, AR.RutaImagen, A.EsAutorizado, A.EsRechazado, A.EsExterna, A.EstaResuelto " & _
                " FROM ((((((Actividades AS A LEFT JOIN ActividadesResueltas AS AR ON A.Id = AR.IdActividad AND A.IdArea = AR.IdArea AND A.IdUsuario = AR.IdUsuario) " & _
                " LEFT JOIN [INFORMACION].dbo.Usuarios AS U ON A.IdUsuario = U.Id) " & _
                " LEFT JOIN [INFORMACION].dbo.Usuarios AS UD ON A.IdUsuarioDestino = UD.Id) " & _
                " LEFT JOIN [INFORMACION].dbo.Usuarios AS UR ON AR.IdUsuarioOrigen = UR.Id) " & _
                " LEFT JOIN [CATALOGOS].dbo.Areas ON A.IdArea = Areas.Id) " & _
                " LEFT JOIN [CATALOGOS].dbo.Areas AS AreasD ON A.IdAreaDestino = AreasD.Id) " & _
                " LEFT JOIN [CATALOGOS].dbo.Areas AS AreasR ON AR.IdAreaOrigen = AreasR.Id " & _
                " WHERE 1=1 " & consultaWhere & _
            ") AS R" & _
            " ORDER BY R.IdArea, R.IdUsuario, R.Id ASC"
            comando.Parameters.AddWithValue("@idArea", Me.EIdArea)
            comando.Parameters.AddWithValue("@idUsuario", Me.EIdUsuario)
            comando.Parameters.AddWithValue("@idAreaDestino", Me.EIdAreaDestino)
            comando.Parameters.AddWithValue("@idUsuarioDestino", Me.EIdUsuarioDestino)
            comando.Parameters.AddWithValue("@fechaCreacion", Me.EFechaCreacion1)
            comando.Parameters.AddWithValue("@fechaCreacion2", Me.EFechaCreacion2)
            comando.Parameters.AddWithValue("@fechaVencimiento", Me.EFechaVencimiento1)
            comando.Parameters.AddWithValue("@fechaVencimiento2", Me.EFechaVencimiento2)
            comando.Parameters.AddWithValue("@fechaResolucion", Me.EFechaResolucion1)
            comando.Parameters.AddWithValue("@fechaResolucion2", Me.EFechaResolucion2)
            BaseDatos.conexionAgenda.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            datos.Load(dataReader)
            BaseDatos.conexionAgenda.Close()
            Return datos
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionAgenda.Close()
        End Try

    End Function

End Class
