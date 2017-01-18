Imports System.Data.SqlClient

Public Class ActividadesResueltas

    Inherits Actividades

    Private descripcionResolucion As String
    Private motivoRetraso As String
    Private fechaResolucion As Date

    Public Property EDescripcionResolucion() As String
        Get
            Return Me.descripcionResolucion
        End Get
        Set(value As String)
            Me.descripcionResolucion = value
        End Set
    End Property
    Public Property EMotivoRetraso() As String
        Get
            Return Me.motivoRetraso
        End Get
        Set(value As String)
            Me.motivoRetraso = value
        End Set
    End Property
    Public Property EFechaResolucion() As String
        Get
            Return Me.fechaResolucion
        End Get
        Set(value As String)
            Me.fechaResolucion = value
        End Set
    End Property

    'Public Overloads Function ObtenerListado() As List(Of ActividadesResueltas)

    '    Dim lista As New List(Of ActividadesResueltas)
    '    Try
    '        Dim comando As New SqlCommand()
    '        comando.Connection = BaseDatos.conexionAgenda
    '        comando.CommandText = "SELECT A.* FROM Actividades AS A LEFT JOIN ActividadesResueltas AS AR ON A.Id = AR.IdActividad WHERE AR.IdActividad IS NULL"
    '        BaseDatos.conexionAgenda.Open()
    '        Dim dataReader As SqlDataReader
    '        dataReader = comando.ExecuteReader()
    '        Dim actividades As New ActividadesResueltas
    '        While (dataReader.Read())
    '            actividades = New ActividadesResueltas()
    '            actividades.EId = Convert.ToInt32(dataReader("Id"))
    '            actividades.EIdUsuario = Convert.ToInt32(dataReader("IdUsuario"))
    '            actividades.ENombre = dataReader("Nombre").ToString()
    '            actividades.EDescripcion = dataReader("Descripcion").ToString()
    '            actividades.EFechaCreacion = dataReader("FechaCreacion").ToString()
    '            actividades.EFechaVencimiento = dataReader("FechaVencimiento").ToString()
    '            actividades.EEsUrgente = dataReader("EsUrgente").ToString()
    '            lista.Add(actividades)
    '        End While
    '        BaseDatos.conexionAgenda.Close()
    '        Return lista
    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

    ''Public Function ObtenerListadoPorId() As List(Of Actividades)

    ''    Dim lista As New List(Of Actividades)()
    ''    Try
    ''        Dim comando As New SqlCommand()
    ''        comando.Connection = BaseDatos.conexionAgenda
    ''        comando.CommandText = "SELECT * FROM Actividades WHERE Id=@id"
    ''        comando.Parameters.AddWithValue("@id", Me.EId)
    ''        BaseDatos.conexionAgenda.Open()
    ''        Dim dataReader As SqlDataReader = comando.ExecuteReader()
    ''        Dim Actividades As Actividades
    ''        While dataReader.Read()
    ''            Actividades = New Actividades()
    ''            Actividades.id = Convert.ToInt32(dataReader("Id"))
    ''            Actividades.motivoRetraso = dataReader("Nombre").ToString()
    ''            Actividades.descripcionResolucion = dataReader("Descripcion").ToString()
    ''            Actividades.fechaResolucion = dataReader("FechaCreacion").ToString()
    ''            Actividades.fechaVencimiento = dataReader("FechaVencimiento").ToString()
    ''            Actividades.esUrgente = dataReader("EsUrgente").ToString()
    ''            lista.Add(Actividades)
    ''        End While
    ''        BaseDatos.conexionAgenda.Close()
    ''        Return lista
    ''    Catch ex As Exception
    ''        Throw ex
    ''    Finally
    ''        BaseDatos.conexionAgenda.Close()
    ''    End Try

    ''End Function

    Public Overloads Sub Guardar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            comando.CommandText = "INSERT INTO ActividadesResueltas VALUES (@id, @descripcion, @motivoRetraso, @fechaResolucion)"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@descripcion", Me.EDescripcionResolucion)
            comando.Parameters.AddWithValue("@motivoRetraso", Me.EMotivoRetraso)
            comando.Parameters.AddWithValue("@fechaResolucion", Me.EFechaResolucion) 
            BaseDatos.conexionAgenda.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionAgenda.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionAgenda.Close()
        End Try

    End Sub

    Public Overloads Sub Editar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            comando.CommandText = "UPDATE ActividadesResueltas SET Descripcion=@descripcionResolucion, MotivoRetraso=@motivoRetraso, FechaResolucion=@fechaResolucion WHERE IdActividad=@id"
            comando.Parameters.AddWithValue("@id", Me.EId)
            comando.Parameters.AddWithValue("@descripcionResolucion", Me.EDescripcionResolucion)
            comando.Parameters.AddWithValue("@motivoRetraso", Me.EMotivoRetraso)
            comando.Parameters.AddWithValue("@fechaResolucion", Me.EFechaResolucion) 
            BaseDatos.conexionAgenda.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionAgenda.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionAgenda.Close()
        End Try

    End Sub

    Public Overloads Sub Eliminar()

        Try
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            comando.CommandText = "DELETE FROM ActividadesResueltas WHERE IdActividad=@id"
            comando.Parameters.AddWithValue("@id", Me.EId)
            BaseDatos.conexionAgenda.Open()
            comando.ExecuteNonQuery()
            BaseDatos.conexionAgenda.Close()
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionAgenda.Close()
        End Try

    End Sub

    Public Overloads Function ValidarPorNumero() As Boolean

        Try
            Dim resultado As Boolean = False
            Dim comando As New SqlCommand()
            comando.Connection = BaseDatos.conexionAgenda
            comando.CommandText = "SELECT * FROM ActividadesResueltas WHERE IdActividad=@id"
            comando.Parameters.AddWithValue("@id", Me.EId)
            BaseDatos.conexionAgenda.Open()
            Dim dataReader As SqlDataReader
            dataReader = comando.ExecuteReader()
            If (dataReader.HasRows) Then
                resultado = True
            Else
                resultado = False
            End If
            BaseDatos.conexionAgenda.Close()
            Return resultado
        Catch ex As Exception
            Throw ex
        Finally
            BaseDatos.conexionInformacion.Close()
        End Try

    End Function

    'Public Function ObtenerMaximo() As Integer

    '    Try
    '        Dim comando As New SqlCommand()
    '        comando.Connection = BaseDatos.conexionAgenda
    '        comando.CommandText = "SELECT MAX(Id) AS Id FROM Actividades"
    '        BaseDatos.conexionAgenda.Open()
    '        Dim dataReader As SqlDataReader
    '        dataReader = comando.ExecuteReader()
    '        If (Not dataReader.HasRows) Then
    '            Return 1
    '        End If
    '        While (dataReader.Read())
    '            If (String.IsNullOrEmpty(dataReader("Id").ToString())) Then
    '                Me.id = 1
    '            Else
    '                Me.id = Convert.ToInt32(dataReader("Id").ToString()) + 1
    '            End If
    '        End While
    '        BaseDatos.conexionAgenda.Close()
    '        Return Me.id
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        BaseDatos.conexionAgenda.Close()
    '    End Try
    'End Function

End Class
