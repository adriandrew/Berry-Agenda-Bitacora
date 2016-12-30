Public Class Principal

    Public baseDatos As New EntidadesCatalogos.BaseDatos()
    Public datosEmpresa As New LogicaCatalogos.DatosEmpresa()

#Region "Eventos"

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Centrar()
        AsignarTooltips()
        'ControlarSpread(spTarima);
        'FormatearSpread();
        'FormatearSpreadTarimas(); 
        ConfigurarConexiones()
        'CargarTitulosEmpresa()
        CargarEncabezados()

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Application.Exit()

    End Sub

#End Region

#Region "Metodos"

    Private Sub Centrar()

        Me.CenterToScreen()

    End Sub

    Private Sub AsignarTooltips()

        Dim tp As New ToolTip()
        tp.AutoPopDelay = 5000
        tp.InitialDelay = 0
        tp.ReshowDelay = 100
        tp.ShowAlways = True
        tp.SetToolTip(Me.btnSalir, "Salir.")

    End Sub

    Private Sub ConfigurarConexiones()

        Dim esPrueba As Boolean = False
        If (esPrueba) Then
            'baseDatos.CadenaConexionInformacion = "C:\\Berry-Agenda\\BD\\PODC\\Catalogos.mdf";
            baseDatos.ECadenaConexionInformacion = "Catalogos"
        Else
            Me.datosEmpresa.ObtenerParametrosInformacionEmpresa()
            baseDatos.ECadenaConexionCatalogo = datosEmpresa.EDirectorio & "\\Catalogos.mdf" '"Catalogos" 
        End If
        baseDatos.AbrirConexionCatalogo()

    End Sub

    Private Sub CargarEncabezados()

        lblEncabezadoPrograma.Text = "Programa: " + Me.Text
        lblEncabezadoEmpresa.Text = "Empresa: " + datosEmpresa.ENombre

    End Sub

#End Region

End Class