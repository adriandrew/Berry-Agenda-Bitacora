Public Class Principal

    Dim areas As New EntidadesCatalogos.Areas
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
        FormatearSpread()
        CargarAreas()
        FormatearSpreadAreas()

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Application.Exit()

    End Sub

#End Region

#Region "Metodos"

    Private Sub Centrar()

        Me.CenterToScreen()
        'Me.Opacity = 0.97 'Está bien perro esto.  
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

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

        Dim esPrueba As Boolean = True
        If (esPrueba) Then
            'baseDatos.CadenaConexionInformacion = "C:\\Berry-Agenda\\BD\\PODC\\Catalogos.mdf"
            EntidadesCatalogos.BaseDatos.ECadenaConexionCatalogo = "Catalogos"
        Else
            Me.datosEmpresa.ObtenerParametrosInformacionEmpresa()
            EntidadesCatalogos.BaseDatos.ECadenaConexionCatalogo = "Catalogos" 'datosEmpresa.EDirectorio & "\\Catalogos.mdf" 
        End If
        EntidadesCatalogos.BaseDatos.AbrirConexionCatalogo()

    End Sub

    Private Sub CargarEncabezados()

        lblEncabezadoPrograma.Text = "Programa: " + Me.Text
        lblEncabezadoEmpresa.Text = "Empresa: " + datosEmpresa.ENombre

    End Sub

    Private Sub CargarAreas()

        Dim lista As New List(Of EntidadesCatalogos.Areas)
        lista = areas.ObtenerListado()
        spCatalogos.ActiveSheet.DataSource = lista 

    End Sub

    Private Sub FormatearSpread()

        spCatalogos.Visible = True : Application.DoEvents()
        spCatalogos.ActiveSheet.GrayAreaBackColor = Color.White : Application.DoEvents()
        spCatalogos.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold) : Application.DoEvents()
        spCatalogos.ActiveSheet.Rows(-1).Height = 25 : Application.DoEvents()
        spCatalogos.ActiveSheetIndex = 0 : Application.DoEvents()

    End Sub

    Private Sub FormatearSpreadAreas()

        Dim numeracion As Integer = 0
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "clave" : numeracion += 1
        spCatalogos.ActiveSheet.Columns("id").Width = 100 : Application.DoEvents()
        spCatalogos.ActiveSheet.Columns("nombre").Width = 200 : Application.DoEvents()
        spCatalogos.ActiveSheet.Columns("clave").Width = 150 : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("id").Index).Value = "Id".ToUpper : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("clave").Index).Value = "Clave".ToUpper : Application.DoEvents()


    End Sub

#End Region
      
    Private Sub miArea_Click(sender As Object, e As EventArgs) Handles miArea.Click

        miArea.BackColor = Color.LightSeaGreen
        miOpcion2.BackColor = msMenu.BackColor

    End Sub

    Private Sub miOpcion2_Click(sender As Object, e As EventArgs) Handles miOpcion2.Click

        miOpcion2.BackColor = Color.LightSeaGreen
        miArea.BackColor = msMenu.BackColor

    End Sub
     
End Class