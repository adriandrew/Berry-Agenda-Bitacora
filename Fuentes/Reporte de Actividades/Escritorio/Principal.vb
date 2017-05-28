Imports System.IO
Imports FarPoint.Win.Spread
Imports System.Reflection

Public Class Principal

    Dim actividades As New EntidadesReporteActividades.Actividades
    Dim areas As New EntidadesReporteActividades.Areas
    Dim usuarios As New EntidadesReporteActividades.Usuarios
    Public datosEmpresa As New LogicaReporteActividades.DatosEmpresa()
    Public datosUsuario As New LogicaReporteActividades.DatosUsuario()
    Public datosArea As New LogicaReporteActividades.DatosArea()
    Public tipoTexto As New FarPoint.Win.Spread.CellType.TextCellType()
    Public tipoEntero As New FarPoint.Win.Spread.CellType.NumberCellType()
    Public tipoDoble As New FarPoint.Win.Spread.CellType.NumberCellType()
    Public tipoPorcentaje As New FarPoint.Win.Spread.CellType.PercentCellType()
    Public tipoHora As New FarPoint.Win.Spread.CellType.DateTimeCellType()
    Public tipoFecha As New FarPoint.Win.Spread.CellType.DateTimeCellType()
    Public tipoBooleano As New FarPoint.Win.Spread.CellType.CheckBoxCellType()
    Public opcionSeleccionada As Integer = 0
    Public estaMostrado As Boolean = False
    Dim ejecutarProgramaPrincipal As New ProcessStartInfo()
    Dim rutaTemporal As String = CurDir() & "\ArchivosTemporales"
    Public estaCerrando As Boolean = False

    Public esDesarrollo As Boolean = False

#Region "Eventos"

    Private Sub Principal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Me.Cursor = Cursors.WaitCursor
        EliminarArchivosTemporales()
        Dim nombrePrograma As String = "PrincipalBerry"
        AbrirPrograma(nombrePrograma, True)
        System.Threading.Thread.Sleep(5000)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Principal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Me.estaCerrando = True
        Desvanecer()

    End Sub

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Centrar()
        AsignarTooltips()
        ConfigurarConexiones()
        CargarTiposDeDatos()

    End Sub

    Private Sub Principal_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        Me.Cursor = Cursors.AppStarting
        Me.Enabled = False
        CargarEncabezados()
        CargarComboAreas()
        CargarComboUsuarios()
        CargarComboAreasDestino()
        CargarComboUsuariosDestino()
        FormatearSpread()
        Me.estaMostrado = True
        Me.Enabled = True
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Application.Exit()

    End Sub

    Private Sub btnGuardar_MouseHover(sender As Object, e As EventArgs)

        AsignarTooltips("Guardar.")

    End Sub

    Private Sub btnSalir_MouseHover(sender As Object, e As EventArgs) Handles btnSalir.MouseHover

        AsignarTooltips("Salir.")

    End Sub

    Private Sub cbAreas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAreas.SelectedIndexChanged

        If (Me.estaMostrado) Then
            If cbAreas.Items.Count > 1 Then
                CargarComboUsuarios()
            End If
        End If

    End Sub

    Private Sub cbAreasDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAreasDestino.SelectedIndexChanged

        If (Me.estaMostrado) Then
            If cbAreasDestino.Items.Count > 1 Then
                CargarComboUsuariosDestino()
            End If
        End If

    End Sub

    Private Sub pnlCuerpo_MouseHover(sender As Object, e As EventArgs) Handles pnlPie.MouseHover, pnlEncabezado.MouseHover, pnlCuerpo.MouseHover

        AsignarTooltips(String.Empty)

    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click

        GenerarReporte()

    End Sub

    Private Sub rbtnTipoInternas_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnTipoInternas.CheckedChanged

        cbAreasDestino.Enabled = False
        cbUsuariosDestino.Enabled = False

    End Sub

    Private Sub rbtnTipoExternas_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnTipoExternas.CheckedChanged

        cbAreasDestino.Enabled = True
        cbUsuariosDestino.Enabled = True

    End Sub

    Private Sub rbtnTipoTodas_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnTipoTodos.CheckedChanged

        cbAreasDestino.Enabled = True
        cbUsuariosDestino.Enabled = True

    End Sub

    Private Sub rbtnEstatusAbiertas_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnEstatusAbiertas.CheckedChanged, rbtnEstatusTodos.CheckedChanged

        dtpFechaResolucion.Enabled = False
        dtpFechaResolucionFinal.Enabled = False
        chkFechaResolucion.Enabled = False
        chkFechaResolucion.Checked = False

    End Sub

    Private Sub rbtnEstatusResueltas_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnEstatusResueltas.CheckedChanged

        dtpFechaResolucion.Enabled = True
        dtpFechaResolucionFinal.Enabled = True
        chkFechaResolucion.Enabled = True
        chkFechaResolucion.Checked = True

    End Sub

    Private Sub btnGenerar_MouseHover(sender As Object, e As EventArgs) Handles btnGenerar.MouseHover

        AsignarTooltips("Generar Reporte.")

    End Sub

    Private Sub pnlFiltros_MouseHover(sender As Object, e As EventArgs) Handles pnlFiltros.MouseHover, gbTipo.MouseHover, gbEstatus.MouseHover, gbCalificacion.MouseHover, gbFechas.MouseHover, gbOtros.MouseHover, chkFechaCreacion.MouseHover, chkFechaResolucion.MouseHover, chkFechaVencimiento.MouseHover, cbAreas.MouseHover, cbAreasDestino.MouseHover, cbUsuarios.MouseHover, cbUsuariosDestino.MouseHover

        AlinearFiltrosNormal()
        AsignarTooltips("Filtros para Generar el Reporte.")

    End Sub

    Private Sub spActividades_MouseHover(sender As Object, e As EventArgs) Handles spReporte.MouseHover

        AlinearFiltrosIzquierda()
        AsignarTooltips("Reporte Generado.")

    End Sub

    Private Sub temporizador_Tick(sender As Object, e As EventArgs) Handles temporizador.Tick

        If (Me.estaCerrando) Then
            Desvanecer()
        Else
            AlinearFiltrosIzquierda()
        End If

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        Imprimir(False)

    End Sub

    Private Sub btnExportarPdf_Click(sender As Object, e As EventArgs) Handles btnExportarPdf.Click

        Imprimir(True)

    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click

        ExportarExcel()

    End Sub

    Private Sub btnImprimir_MouseHover(sender As Object, e As EventArgs) Handles btnImprimir.MouseHover

        AsignarTooltips("Imprimir.")

    End Sub

    Private Sub btnExportarExcel_MouseHover(sender As Object, e As EventArgs) Handles btnExportarExcel.MouseHover

        AsignarTooltips("Exportar a Excel.")

    End Sub

    Private Sub btnExportarPdf_MouseHover(sender As Object, e As EventArgs) Handles btnExportarPdf.MouseHover

        AsignarTooltips("Exportar a Pdf.")

    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click

        MostrarAyuda()

    End Sub

    Private Sub btnAyuda_MouseHover(sender As Object, e As EventArgs) Handles btnAyuda.MouseHover

        AsignarTooltips("Ayuda.")

    End Sub

    Private Sub chkFechaCreacion_CheckedChanged(sender As Object, e As EventArgs) Handles chkFechaCreacion.CheckedChanged

        If (chkFechaCreacion.Checked) Then
            chkFechaCreacion.Text = "SI"
        Else
            chkFechaCreacion.Text = "NO"
        End If

    End Sub

    Private Sub chkFechaVencimiento_CheckedChanged(sender As Object, e As EventArgs) Handles chkFechaVencimiento.CheckedChanged

        If (chkFechaVencimiento.Checked) Then
            chkFechaVencimiento.Text = "SI"
        Else
            chkFechaVencimiento.Text = "NO"
        End If

    End Sub

    Private Sub chkFechaResolucion_CheckedChanged(sender As Object, e As EventArgs) Handles chkFechaResolucion.CheckedChanged

        If (chkFechaResolucion.Checked) Then
            chkFechaResolucion.Text = "SI"
        Else
            chkFechaResolucion.Text = "NO"
        End If

    End Sub

#End Region

#Region "Métodos"

#Region "Genericos"

    Private Sub MostrarAyuda()

        Dim pnlAyuda As New Panel()
        Dim txtAyuda As New TextBox()
        If (pnlContenido.Controls.Find("pnlAyuda", True).Count = 0) Then
            pnlAyuda.Name = "pnlAyuda" : Application.DoEvents()
            pnlAyuda.Visible = False : Application.DoEvents()
            pnlContenido.Controls.Add(pnlAyuda) : Application.DoEvents()
            txtAyuda.Name = "txtAyuda" : Application.DoEvents()
            pnlAyuda.Controls.Add(txtAyuda) : Application.DoEvents()
        Else
            pnlAyuda = pnlContenido.Controls.Find("pnlAyuda", False)(0) : Application.DoEvents()
            txtAyuda = pnlAyuda.Controls.Find("txtAyuda", False)(0) : Application.DoEvents()
        End If
        If (Not pnlAyuda.Visible) Then
            pnlCuerpo.Visible = False : Application.DoEvents()
            pnlAyuda.Visible = True : Application.DoEvents()
            pnlAyuda.Size = pnlCuerpo.Size : Application.DoEvents()
            pnlAyuda.Location = pnlCuerpo.Location : Application.DoEvents()
            pnlContenido.Controls.Add(pnlAyuda) : Application.DoEvents()
            txtAyuda.ScrollBars = ScrollBars.Both : Application.DoEvents()
            txtAyuda.Multiline = True : Application.DoEvents()
            txtAyuda.Width = pnlAyuda.Width - 10 : Application.DoEvents()
            txtAyuda.Height = pnlAyuda.Height - 10 : Application.DoEvents()
            txtAyuda.Location = New Point(5, 5) : Application.DoEvents()
            txtAyuda.Text = "Sección de Ayuda: " & vbNewLine & vbNewLine & "* Reporte: " & vbNewLine & "En esta pantalla se desplegará el reporte de acuerdo a los filtros que se hayan seleccionado. " & vbNewLine & "En la parte izquierda se puede agregar cualquiera de los filtros. Existen unos botones que se encuentran en las fechas que contienen la palabra si o no, si la palabra mostrada es si, el rango de fecha correspondiente se incluirá como filtro para el reporte, esto aplica para todas las opciones de fechas. Posteriormente se procede a generar el reporte con los criterios seleccionados. Cuando se termine de generar dicho reporte, se habilitarán las opciones de imprimir, exportar a excel o exportar a pdf, en estas dos últimas el usuario puede guardarlos directamente desde el archivo que se muestra en pantalla si así lo desea, mas no desde el sistema directamente. " : Application.DoEvents()
            pnlAyuda.Controls.Add(txtAyuda) : Application.DoEvents()
        Else
            pnlCuerpo.Visible = True : Application.DoEvents()
            pnlAyuda.Visible = False : Application.DoEvents()
        End If

    End Sub

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
        tp.SetToolTip(Me.btnImprimir, "Imprimir.")
        tp.SetToolTip(Me.btnExportarExcel, "Exportar a Excel.")
        tp.SetToolTip(Me.btnExportarPdf, "Exportar a Pdf.")
        tp.SetToolTip(Me.btnGenerar, "Generar Reporte.")
        tp.SetToolTip(Me.pnlFiltros, "Filtros para Generar el Reporte.")
        tp.SetToolTip(Me.spReporte, "Datos del Reporte.")

    End Sub

    Private Sub AsignarTooltips(ByVal texto As String)

        lblDescripcionTooltip.Text = texto

    End Sub

    Public Sub ControlarSpreadEnter(ByVal spread As FarPoint.Win.Spread.FpSpread)

        Dim valor1 As FarPoint.Win.Spread.InputMap
        Dim valor2 As FarPoint.Win.Spread.InputMap
        valor1 = spread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused)
        valor1.Put(New FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnWrap)
        valor1 = spread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused)
        valor1.Put(New FarPoint.Win.Spread.Keystroke(Keys.Enter, Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnWrap)
        valor2 = spread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused)
        valor2.Put(New FarPoint.Win.Spread.Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None)
        valor2 = spread.GetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused)
        valor2.Put(New FarPoint.Win.Spread.Keystroke(Keys.Escape, Keys.None), FarPoint.Win.Spread.SpreadActions.None)

    End Sub

    Private Sub CargarTiposDeDatos()

        tipoDoble.DecimalPlaces = 2
        tipoDoble.DecimalSeparator = "."
        tipoDoble.Separator = ","
        tipoDoble.ShowSeparator = True
        tipoEntero.DecimalPlaces = 0
        tipoEntero.Separator = ","
        tipoEntero.ShowSeparator = True

    End Sub

    Private Sub ConfigurarConexiones()

        If (Me.esDesarrollo) Then
            'baseDatos.CadenaConexionInformacion = "C:\\Berry-Agenda\\BD\\PODC\\Agenda.mdf"
            Me.datosUsuario.EId = 1
            Me.datosUsuario.EIdArea = 1
            Me.datosEmpresa.EId = 1
            Me.datosEmpresa.ENombre = "PODC"
            Me.datosEmpresa.EDescripcion = "Empresa Agricola"
            Me.datosEmpresa.EDomicilio = "Conocido"
            Me.datosEmpresa.ELocalidad = "San José Del Cabo"
            Me.datosEmpresa.ERfc = "RFCXSOMOSCHAVOS"
            'LogicaReporteActividades.DatosEmpresaPrincipal.instanciaSql = "ANDREW-MAC\SQLEXPRESS"
            LogicaReporteActividades.DatosEmpresaPrincipal.instanciaSql = "BERRY1-DELL\SQLEXPRESS2008"
            LogicaReporteActividades.DatosEmpresaPrincipal.usuarioSql = "AdminBerry"
            'LogicaReporteActividades.DatosEmpresaPrincipal.contrasenaSql = "@berry"
            LogicaReporteActividades.DatosEmpresaPrincipal.contrasenaSql = "@berry2017"
        Else
            'EntidadesActividades.BaseDatos.ECadenaConexionAgenda = datosEmpresa.EDirectorio & "\\Agenda.mdf"
            LogicaReporteActividades.DatosEmpresaPrincipal.ObtenerParametrosInformacionEmpresa()
            Me.datosEmpresa.ObtenerParametrosInformacionEmpresa()
            Me.datosUsuario.ObtenerParametrosInformacionUsuario()
            Me.datosArea.ObtenerParametrosInformacionArea()
        End If
        EntidadesReporteActividades.BaseDatos.ECadenaConexionAgenda = "Agenda"
        EntidadesReporteActividades.BaseDatos.ECadenaConexionCatalogo = "Catalogos"
        EntidadesReporteActividades.BaseDatos.ECadenaConexionInformacion = "Informacion"
        EntidadesReporteActividades.BaseDatos.AbrirConexionAgenda()
        EntidadesReporteActividades.BaseDatos.AbrirConexionCatalogo()
        EntidadesReporteActividades.BaseDatos.AbrirConexionInformacion()

    End Sub

    Private Sub CargarEncabezados()

        lblEncabezadoPrograma.Text = "Programa: " + Me.Text
        lblEncabezadoEmpresa.Text = "Empresa: " + datosEmpresa.ENombre
        lblEncabezadoUsuario.Text = "Usuario: " + datosUsuario.ENombre
        lblEncabezadoArea.Text = "Area: " + datosArea.ENombre

    End Sub

    Private Sub PonerFocoEnControl(ByVal c As Control)

        c.Focus()

    End Sub

    Private Sub AbrirPrograma(nombre As String, salir As Boolean)

        If (Me.esDesarrollo) Then
            Exit Sub
        End If
        ejecutarProgramaPrincipal.UseShellExecute = True
        ejecutarProgramaPrincipal.FileName = nombre & Convert.ToString(".exe")
        ejecutarProgramaPrincipal.WorkingDirectory = Directory.GetCurrentDirectory()
        ejecutarProgramaPrincipal.Arguments = LogicaReporteActividades.DatosEmpresaPrincipal.idEmpresa.ToString().Trim().Replace(" ", "|") & " " & LogicaReporteActividades.DatosEmpresaPrincipal.activa.ToString().Trim().Replace(" ", "|") & " " & LogicaReporteActividades.DatosEmpresaPrincipal.instanciaSql.ToString().Trim().Replace(" ", "|") & " " & LogicaReporteActividades.DatosEmpresaPrincipal.rutaBd.ToString().Trim().Replace(" ", "|") & " " & LogicaReporteActividades.DatosEmpresaPrincipal.usuarioSql.ToString().Trim().Replace(" ", "|") & " " & LogicaReporteActividades.DatosEmpresaPrincipal.contrasenaSql.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de empresa principal, indice 7 ;)".Replace(" ", "|") & " " & datosEmpresa.EId.ToString().Trim().Replace(" ", "|") & " " & datosEmpresa.ENombre.Trim().Replace(" ", "|") & " " & datosEmpresa.EDescripcion.Trim().Replace(" ", "|") & " " & datosEmpresa.EDomicilio.Trim().Replace(" ", "|") & " " & datosEmpresa.ELocalidad.Trim().Replace(" ", "|") & " " & datosEmpresa.ERfc.Trim().Replace(" ", "|") & " " & datosEmpresa.EDirectorio.Trim().Replace(" ", "|") & " " & datosEmpresa.ELogo.Trim().Replace(" ", "|") & " " & datosEmpresa.EActiva.ToString().Trim().Replace(" ", "|") & " " & datosEmpresa.EEquipo.Trim().Replace(" ", "|") & " " & "Aquí terminan los de empresa, indice 18 ;)".Replace(" ", "|") & " " & datosUsuario.EId.ToString().Trim().Replace(" ", "|") & " " & datosUsuario.ENombre.Trim().Replace(" ", "|") & " " & datosUsuario.EContrasena.Trim().Replace(" ", "|") & " " & datosUsuario.ENivel.ToString().Trim().Replace(" ", "|") & " " & datosUsuario.EAccesoTotal.ToString().Trim().Replace(" ", "|") & " " & datosUsuario.EIdArea.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de usuario, indice 25 ;)".Replace(" ", "|") & " " & datosArea.EId.ToString().Trim().Replace(" ", "|") & " " & datosArea.ENombre.ToString().Trim().Replace(" ", "|") & " " & datosArea.EClave.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de area, indice 29 ;)".Replace(" ", "|")
        Try
            Process.Start(ejecutarProgramaPrincipal)
            If salir Then
                Application.Exit()
            End If
        Catch ex As Exception
            MessageBox.Show((Convert.ToString("No se puede abrir el programa principal en la ruta : " & ejecutarProgramaPrincipal.WorkingDirectory & "\") & nombre) & Environment.NewLine & Environment.NewLine & ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Desvanecer()

        temporizador.Interval = 10
        temporizador.Enabled = True
        temporizador.Start()
        If (Me.Opacity > 0) Then
            Me.Opacity -= 0.25 : Application.DoEvents()
        Else
            temporizador.Enabled = False
            temporizador.Stop()
        End If

    End Sub

#End Region

#Region "Todos"

    Private Sub Imprimir(ByVal esPdf As Boolean)

        Me.Cursor = Cursors.WaitCursor
        Dim nombrePdf As String = "\Temporal.pdf"
        Dim fuente7 As Integer = 7 : Dim fuente8 As Integer = 8
        Dim encabezadoPuntoPago As String = String.Empty
        Dim informacionImpresion As New FarPoint.Win.Spread.PrintInfo
        impresor.AllowSelection = True
        impresor.AllowSomePages = True
        impresor.AllowCurrentPage = True
        informacionImpresion.Orientation = PrintOrientation.Landscape
        informacionImpresion.Margin.Top = 40
        informacionImpresion.Margin.Left = 20
        informacionImpresion.Margin.Right = 20
        informacionImpresion.Margin.Bottom = 20
        informacionImpresion.ShowBorder = False
        informacionImpresion.ShowGrid = False
        informacionImpresion.ZoomFactor = 0.5
        informacionImpresion.Printer = impresor.PrinterSettings.PrinterName
        informacionImpresion.Centering = FarPoint.Win.Spread.Centering.Horizontal
        informacionImpresion.ShowRowHeader = FarPoint.Win.Spread.PrintHeader.Hide
        informacionImpresion.ShowColumnHeader = FarPoint.Win.Spread.PrintHeader.Show
        Dim encabezado1 As String = String.Empty
        Dim encabezado2 As String = String.Empty
        Dim encabezado3 As String = String.Empty
        encabezado1 = "/l/fz""" & fuente7 & """" & "RFC: " & datosEmpresa.ERfc & "/c/fz""" & fuente7 & """" & datosEmpresa.ENombre
        encabezado1 &= "/r/fz""" & fuente7 & """" & "PÁGINA /p DE /pc"
        encabezado1 = encabezado1.ToUpper
        encabezado2 = "/l/fz""" & fuente7 & """" & datosEmpresa.EDomicilio.Replace("/N", ".N.") & "/c/fb1/fz""" & fuente8 & """" & datosEmpresa.EDescripcion & "/r/fz""" & fuente7 & """" & "FECHA: " & Today.ToShortDateString
        encabezado2 = encabezado2.ToUpper
        encabezado3 = "/l/fz""" & fuente7 & """" & datosEmpresa.ELocalidad & "/c/fb1/fz""" & fuente8 & """" & "Reporte de Actividades" & "/r/fz""" & fuente7 & """" & "HORA: " & Now.ToShortTimeString
        encabezado3 = encabezado3.ToUpper
        If esPdf Then
            Dim bandera As Boolean = True
            Dim obtenerRandom As System.Random = New System.Random()
            Try
                If (Not Directory.Exists(rutaTemporal)) Then
                    Directory.CreateDirectory(rutaTemporal)
                End If
            Catch ex As Exception
            End Try
            While bandera
                nombrePdf = "\" & obtenerRandom.Next(0, 99999).ToString.PadLeft(5, "0") & ".pdf"
                If Not File.Exists(rutaTemporal & nombrePdf) Then
                    bandera = False
                End If
            End While
            informacionImpresion.PdfWriteTo = PdfWriteTo.File
            informacionImpresion.PdfFileName = rutaTemporal & nombrePdf
            informacionImpresion.PrintToPdf = True
        End If
        informacionImpresion.Header = encabezado1 & "/n" & encabezado2 & "/n" & encabezado3
        informacionImpresion.Footer = "Creado por: Berry"
        For indice = 0 To spReporte.Sheets.Count - 1
            spReporte.Sheets(indice).PrintInfo = informacionImpresion
        Next
        If Not esPdf Then
            If impresor.ShowDialog = Windows.Forms.DialogResult.OK Then
                spReporte.PrintSheet(-1)
            End If
        Else
            spReporte.PrintSheet(-1)
            Try
                System.Diagnostics.Process.Start(nombrePdf)
                System.Diagnostics.Process.Start(rutaTemporal & nombrePdf)
            Catch
                System.Diagnostics.Process.Start(rutaTemporal & nombrePdf)
            End Try
        End If
        Me.Cursor = Cursors.Default
        Application.DoEvents()

    End Sub

    Private Sub ExportarExcel()

        Me.Cursor = Cursors.WaitCursor
        spParaClonar.Sheets.Clear()
        spParaClonar = ClonarSpread(spParaClonar)
        Dim bandera As Boolean = True
        Dim nombreExcel As String = "\Temporal.xls"
        Dim obtenerRandom As System.Random = New System.Random()
        FormatearExcel()
        Application.DoEvents()
        Try
            If (Not Directory.Exists(rutaTemporal)) Then
                Directory.CreateDirectory(rutaTemporal)
            End If
        Catch ex As Exception
        End Try
        While bandera
            nombreExcel = "\" & obtenerRandom.Next(0, 99999).ToString.PadLeft(5, "0") & ".xls"
            If Not File.Exists(rutaTemporal & nombreExcel) Then
                bandera = False
            End If
        End While
        spParaClonar.SaveExcel(rutaTemporal & nombreExcel, FarPoint.Win.Spread.Model.IncludeHeaders.ColumnHeadersCustomOnly)
        System.Diagnostics.Process.Start(rutaTemporal & nombreExcel)
        Me.Cursor = Cursors.Default

    End Sub

    Private Function ClonarSpread(baseObject As FpSpread) As FpSpread

        'Copying to a memory stream
        Dim ms As New System.IO.MemoryStream()
        FarPoint.Win.Spread.Model.SpreadSerializer.SaveXml(spReporte, ms, False)
        ms = New System.IO.MemoryStream(ms.ToArray())
        'Copying from memory stream to clone spread object
        Dim newSpread As New FarPoint.Win.Spread.FpSpread()
        FarPoint.Win.Spread.Model.SpreadSerializer.OpenXml(newSpread, ms)
        Dim fInfo As FieldInfo() = GetType(FarPoint.Win.Spread.FpSpread).GetFields(BindingFlags.Instance Or BindingFlags.[Public] Or BindingFlags.NonPublic Or BindingFlags.[Static])
        For Each field As FieldInfo In fInfo
            If field IsNot Nothing Then
                Dim del As [Delegate] = Nothing
                If field.FieldType.Name.Contains("EventHandler") Then
                    del = DirectCast(field.GetValue(baseObject), [Delegate])
                End If

                If del IsNot Nothing Then
                    Dim eInfo As EventInfo = GetType(FarPoint.Win.Spread.FpSpread).GetEvent(del.Method.Name.Substring(del.Method.Name.IndexOf("_"c) + 1))
                    If eInfo IsNot Nothing Then
                        eInfo.AddEventHandler(newSpread, del)
                    End If
                End If
            End If
        Next
        Return newSpread

    End Function

    Private Sub FormatearExcel()

        Dim fuente6 As Integer = 6
        Dim fuente7 As Integer = 7
        Dim fuente8 As Integer = 8
        Dim encabezado1I As String = String.Empty
        Dim encabezado1C As String = String.Empty
        Dim encabezado2I As String = String.Empty
        Dim encabezado2C As String = String.Empty
        Dim encabezado2D As String = String.Empty
        Dim encabezado3I As String = String.Empty
        Dim encabezado3C As String = String.Empty
        Dim encabezado3D As String = String.Empty
        encabezado1I = "RFC: " & datosEmpresa.ERfc : encabezado1I = encabezado1I.ToUpper
        encabezado1C = datosEmpresa.ENombre : encabezado1C = encabezado1C.ToUpper
        encabezado2I = datosEmpresa.EDomicilio : encabezado2I = encabezado2I.ToUpper
        encabezado2C = datosEmpresa.EDescripcion : encabezado2C = encabezado2C.ToUpper
        encabezado2D = "FECHA: " & Today.ToShortDateString : encabezado2D = encabezado2D.ToUpper
        encabezado3I = datosEmpresa.ELocalidad : encabezado3I = encabezado3I.ToUpper
        encabezado3C = "Reporte de Actividades" : encabezado3C = encabezado3C.ToUpper
        encabezado3D = "HORA: " & Now.ToShortTimeString : encabezado3D = encabezado3D.ToUpper
        For indice = 0 To spParaClonar.Sheets.Count - 1
            spParaClonar.Sheets(indice).Columns.Count = spReporte.Sheets(indice).Columns.Count + 10
            spParaClonar.Sheets(indice).Protect = False
            spParaClonar.Sheets(indice).ColumnHeader.Rows.Add(0, 6)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(0, 0, 1, 3) 'spParaClonar.Sheets(i).ColumnCount 
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(0, 3, 1, 5)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(0, 8, 1, 2)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(1, 0, 1, 3)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(1, 3, 1, 5)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(1, 8, 1, 2)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(2, 0, 1, 3)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(2, 3, 1, 5)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(2, 8, 1, 2)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(3, 0, 1, 3)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(3, 3, 1, 5)
            spParaClonar.Sheets(indice).AddColumnHeaderSpanCell(4, 0, 1, spParaClonar.Sheets(indice).ColumnCount)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(0, 0).Text = encabezado1I
            spParaClonar.Sheets(indice).ColumnHeader.Cells(0, 3).Text = encabezado1C
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 0).Text = encabezado2I
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 3).Text = encabezado2C
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 8).Text = encabezado2D
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 0).Text = encabezado3I
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 3).Text = encabezado3C
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 8).Text = encabezado3D
            spParaClonar.Sheets(indice).ColumnHeader.Cells(4, 0).Border = New FarPoint.Win.LineBorder(Color.Black, 1, False, True, False, False)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(0, 0).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(0, 3).Font = New Font("microsoft sans serif", fuente8, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(0, 8).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 0).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 3).Font = New Font("microsoft sans serif", fuente8, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 8).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 0).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 3).Font = New Font("microsoft sans serif", fuente8, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 8).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(3, 0).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(3, 3).Font = New Font("microsoft sans serif", fuente8, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(3, 8).Font = New Font("microsoft sans serif", fuente7, FontStyle.Bold)
            spParaClonar.Sheets(indice).ColumnHeader.Cells(0, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
            spParaClonar.Sheets(indice).ColumnHeader.Cells(1, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
            spParaClonar.Sheets(indice).ColumnHeader.Cells(2, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
            spParaClonar.Sheets(indice).ColumnHeader.Cells(3, 0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Left
            spParaClonar.Sheets(indice).ColumnHeader.Cells(3, 3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center
            spParaClonar.Sheets(indice).ColumnHeader.Cells(3, 8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right
        Next
        spParaClonar.ActiveSheet.Protect = False
        spParaClonar.ActiveSheet.Rows.Count += 20 ' Se aumenta la cantidad de filas debido a un bug del spread al exportar a excel.

    End Sub

    Private Sub EliminarArchivosTemporales()

        Try
            If Directory.Exists(rutaTemporal) Then
                Directory.Delete(rutaTemporal, True)
                Directory.CreateDirectory(rutaTemporal)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub AlinearFiltrosIzquierda()

        temporizador.Interval = 1
        temporizador.Enabled = True
        temporizador.Start()
        If (pnlFiltros.Location.X > -350) Then
            pnlFiltros.Location = New Point(pnlFiltros.Location.X - 20, pnlFiltros.Location.Y)
            spReporte.Location = New Point(spReporte.Location.X - 20, spReporte.Location.Y)
            Application.DoEvents()
        Else
            temporizador.Enabled = False
            temporizador.Stop()
            AlinearFiltrosIzquierda2()
        End If

    End Sub

    Private Sub AlinearFiltrosIzquierda2()
         
        pnlFiltros.BackColor = Color.Gray
        btnGenerar.Enabled = False
        spReporte.Width = pnlCuerpo.Width - 50
        Application.DoEvents()

    End Sub

    Private Sub AlinearFiltrosNormal()

        pnlFiltros.Left = 0
        pnlFiltros.BackColor = Color.FromArgb(64, 64, 64)
        btnGenerar.Enabled = True
        System.Threading.Thread.Sleep(250)
        spReporte.Width = pnlCuerpo.Width - 50
        spReporte.Location = New Point(pnlFiltros.Location.X + pnlFiltros.Width + 10)
        Application.DoEvents()

    End Sub


    Private Sub GenerarReporte()

        Me.Cursor = Cursors.WaitCursor
        Dim lista As New DataTable
        If (Me.estaMostrado) Then
            actividades.EIdArea = cbAreas.SelectedValue
            actividades.EIdUsuario = cbUsuarios.SelectedValue
            actividades.EIdAreaDestino = cbAreasDestino.SelectedValue
            actividades.EIdUsuarioDestino = cbUsuariosDestino.SelectedValue
        End If
        Dim tipo As Integer = 0
        If (rbtnTipoInternas.Checked) Then
            tipo = 1
        ElseIf (rbtnTipoExternas.Checked) Then
            tipo = 2
        Else
            tipo = 0
        End If
        Dim estatus As Integer = 0
        If (rbtnEstatusAbiertas.Checked) Then
            estatus = 1
        ElseIf (rbtnEstatusResueltas.Checked) Then
            estatus = 2
        Else
            estatus = 0
        End If
        Dim calificacion As Integer = 0
        If (rbtnCalificacionPendientes.Checked) Then
            calificacion = 1
        ElseIf (rbtnCalificacionRechazadas.Checked) Then
            calificacion = 2
        ElseIf (rbtnCalificacionAutorizadas.Checked) Then
            calificacion = 3
        Else
            calificacion = 0
        End If
        Dim fechaCreacion As Date = dtpFechaCreacion.Value.ToShortDateString : Dim fechaCreacion2 As Date = dtpFechaCreacionFinal.Value.ToShortDateString
        Dim fechaVencimiento As Date = dtpFechaVencimiento.Value.ToShortDateString : Dim fechaVencimiento2 As Date = dtpFechaVencimientoFinal.Value.ToShortDateString
        Dim fechaResolucion As Date = dtpFechaResolucion.Value.ToShortDateString : Dim fechaResolucion2 As Date = dtpFechaResolucionFinal.Value.ToShortDateString
        Dim aplicaFechaCreacion As Boolean = False
        If (chkFechaCreacion.Checked) Then
            aplicaFechaCreacion = True
            actividades.EFechaCreacion1 = fechaCreacion : actividades.EFechaCreacion2 = fechaCreacion2
        ElseIf (chkFechaCreacion.Checked) Then
            aplicaFechaCreacion = False
        End If
        Dim aplicaFechaVencimiento As Boolean = False
        If (chkFechaVencimiento.Checked) Then
            aplicaFechaVencimiento = True
            actividades.EFechaVencimiento1 = fechaVencimiento : actividades.EFechaVencimiento2 = fechaVencimiento2
        ElseIf (Not chkFechaVencimiento.Checked) Then
            aplicaFechaVencimiento = False
        End If
        Dim aplicaFechaResolucion As Boolean = False
        If (chkFechaResolucion.Checked) Then
            aplicaFechaResolucion = True
            actividades.EFechaResolucion1 = fechaResolucion : actividades.EFechaResolucion2 = fechaResolucion2
        ElseIf (Not chkFechaResolucion.Checked) Then
            aplicaFechaResolucion = False
        End If
        lista = actividades.ObtenerListadoActividades(tipo, estatus, calificacion, aplicaFechaCreacion, aplicaFechaVencimiento, aplicaFechaResolucion)
        spReporte.ActiveSheet.DataSource = lista
        FormatearSpreadReporteActividades(spReporte.ActiveSheet.Columns.Count)

        '' Intento de reporte grafico en la segunda hoja. (TODO. Queda pendiente.)
        'spReporte.Sheets.Count = 2
        'spReporte.ActiveSheetIndex = 0
        'Dim rango As New FarPoint.Win.Spread.Model.CellRange(3, 0, spReporte.ActiveSheet.Rows.Count - 1, 1)
        'spReporte.ActiveSheetIndex = 1
        'spReporte.ActiveSheet.AddChart(rango, GetType(FarPoint.Win.Chart.BarSeries), 400, 400, 0, 0)

        AlinearFiltrosIzquierda()
        btnImprimir.Enabled = True
        btnExportarExcel.Enabled = True
        btnExportarPdf.Enabled = True
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub FormatearSpread()

        spReporte.Reset()
        spReporte.Visible = False
        spReporte.ActiveSheet.SheetName = "Reporte"
        spReporte.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
        spReporte.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
        spReporte.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spReporte.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        Application.DoEvents()

    End Sub

    Private Sub FormatearSpreadReporteActividades(ByVal cantidadColumnas As Integer)

        spReporte.Visible = True
        spReporte.ActiveSheet.GrayAreaBackColor = Color.White
        spReporte.ActiveSheet.ColumnHeader.Rows(0).Height = 35
        spReporte.ActiveSheet.Rows(-1).Height = 30
        spReporte.ActiveSheet.ColumnHeader.RowCount = 2
        spReporte.ActiveSheet.ColumnHeader.Rows(0, spReporte.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold)
        Dim numeracion As Integer = 0
        spReporte.ActiveSheet.Columns.Count = cantidadColumnas
        spReporte.ActiveSheet.Columns(numeracion).Tag = "tipo" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "estatus" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "calificacion" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idArea" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreArea" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idUsuario" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreUsuario" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idAreaDestino" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreAreaDestino" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idUsuarioDestino" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreUsuarioDestino" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "descripcion" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "fechaCreacion" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "fechaVencimiento" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "esUrgente" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idAreaResolucion" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreAreaResolucion" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "idUsuarioResolucion" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "nombreUsuarioResolucion" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "descripcionResolucion" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "motivoRetraso" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "fechaResolucion" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "esAutorizado" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "esRechazado" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "esExterna" : numeracion += 1
        spReporte.ActiveSheet.Columns(numeracion).Tag = "estaResuelto" : numeracion += 1
        spReporte.ActiveSheet.Columns("tipo").Width = 100
        spReporte.ActiveSheet.Columns("estatus").Width = 100
        spReporte.ActiveSheet.Columns("calificacion").Width = 120
        spReporte.ActiveSheet.Columns("id").Width = 50
        spReporte.ActiveSheet.Columns("idArea").Width = 40
        spReporte.ActiveSheet.Columns("nombreArea").Width = 110
        spReporte.ActiveSheet.Columns("idUsuario").Width = 40
        spReporte.ActiveSheet.Columns("nombreUsuario").Width = 110
        spReporte.ActiveSheet.Columns("idAreaDestino").Width = 40
        spReporte.ActiveSheet.Columns("nombreAreaDestino").Width = 120
        spReporte.ActiveSheet.Columns("idUsuarioDestino").Width = 40
        spReporte.ActiveSheet.Columns("nombreUsuarioDestino").Width = 110
        spReporte.ActiveSheet.Columns("nombre").Width = 300
        spReporte.ActiveSheet.Columns("descripcion").Width = 500
        spReporte.ActiveSheet.Columns("fechaCreacion").Width = 120
        spReporte.ActiveSheet.Columns("fechaVencimiento").Width = 120
        spReporte.ActiveSheet.Columns("esUrgente").Width = 90
        spReporte.ActiveSheet.Columns("idAreaResolucion").Width = 40
        spReporte.ActiveSheet.Columns("nombreAreaResolucion").Width = 120
        spReporte.ActiveSheet.Columns("idUsuarioResolucion").Width = 40
        spReporte.ActiveSheet.Columns("nombreUsuarioResolucion").Width = 120
        spReporte.ActiveSheet.Columns("descripcionResolucion").Width = 400
        spReporte.ActiveSheet.Columns("motivoRetraso").Width = 150
        spReporte.ActiveSheet.Columns("fechaResolucion").Width = 120
        Application.DoEvents()
        spReporte.ActiveSheet.Columns("esUrgente").CellType = tipoBooleano
        spReporte.ActiveSheet.Columns("nombre").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Justify
        spReporte.ActiveSheet.Columns("descripcion").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Justify
        spReporte.ActiveSheet.Columns("descripcionResolucion").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Justify
        spReporte.ActiveSheet.Columns("motivoRetraso").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Justify
        spReporte.ActiveSheet.Columns("fechaResolucion").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Justify
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("tipo").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("tipo").Index).Value = "Tipo".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("estatus").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("estatus").Index).Value = "Estatus".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("calificacion").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("calificacion").Index).Value = "Calificación".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("id").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("id").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idArea").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idArea").Index).Value = "Area".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idArea").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreArea").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idUsuario").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idUsuario").Index).Value = "Usuario".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idUsuario").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreUsuario").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idAreaDestino").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idAreaDestino").Index).Value = "Area Destino".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idAreaDestino").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreAreaDestino").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idUsuarioDestino").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idUsuarioDestino").Index).Value = "Usuario Destino".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idUsuarioDestino").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreUsuarioDestino").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("nombre").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("descripcion").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("descripcion").Index).Value = "Descripción".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("fechaCreacion").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("fechaCreacion").Index).Value = "Fecha de Creación".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("fechaVencimiento").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("fechaVencimiento").Index).Value = "Fecha de Vencimiento".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("esUrgente").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("esUrgente").Index).Value = "Es Urgente?".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idAreaResolucion").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idAreaResolucion").Index).Value = "Area Resolución".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idAreaResolucion").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreAreaResolucion").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("idUsuarioResolucion").Index, 1, 2)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("idUsuarioResolucion").Index).Value = "Usuario Resolución".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("idUsuarioResolucion").Index).Value = "No.".ToUpper
        spReporte.ActiveSheet.ColumnHeader.Cells(1, spReporte.ActiveSheet.Columns("nombreUsuarioResolucion").Index).Value = "Nombre".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("descripcionResolucion").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("descripcionResolucion").Index).Value = "Descripción Resolución".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("motivoRetraso").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("motivoRetraso").Index).Value = "Motivo Retraso".ToUpper
        spReporte.ActiveSheet.AddColumnHeaderSpanCell(0, spReporte.ActiveSheet.Columns("fechaResolucion").Index, 2, 1)
        spReporte.ActiveSheet.ColumnHeader.Cells(0, spReporte.ActiveSheet.Columns("fechaResolucion").Index).Value = "Fecha de Resolución".ToUpper
        If (rbtnTipoInternas.Checked) Then
            spReporte.ActiveSheet.Columns(spReporte.ActiveSheet.Columns("idAreaDestino").Index, spReporte.ActiveSheet.Columns("nombreUsuarioDestino").Index).Visible = False
        ElseIf (rbtnTipoExternas.Checked Or rbtnTipoTodos.Checked) Then
            spReporte.ActiveSheet.Columns(spReporte.ActiveSheet.Columns("idAreaDestino").Index, spReporte.ActiveSheet.Columns("nombreUsuarioDestino").Index).Visible = True
        End If
        If (rbtnEstatusAbiertas.Checked) Then
            spReporte.ActiveSheet.Columns(spReporte.ActiveSheet.Columns("idAreaResolucion").Index, spReporte.ActiveSheet.Columns("fechaResolucion").Index).Visible = False
        ElseIf (rbtnEstatusResueltas.Checked Or rbtnEstatusTodos.Checked) Then
            spReporte.ActiveSheet.Columns(spReporte.ActiveSheet.Columns("idAreaResolucion").Index, spReporte.ActiveSheet.Columns("fechaResolucion").Index).Visible = True
        End If
        spReporte.ActiveSheet.Columns(spReporte.ActiveSheet.Columns("esAutorizado").Index, spReporte.ActiveSheet.Columns("estaResuelto").Index).Visible = False
        spReporte.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect
        Application.DoEvents()

    End Sub

    Private Sub CargarComboAreas()

        Dim lista As New List(Of EntidadesReporteActividades.Areas)
        lista = areas.ObtenerListado()
        cbAreas.DataSource = lista
        cbAreas.ValueMember = "EId"
        cbAreas.DisplayMember = "ENombre"

    End Sub

    Private Sub CargarComboUsuarios()

        Dim idArea As Integer = cbAreas.SelectedValue()
        Dim lista As New List(Of EntidadesReporteActividades.Usuarios)
        usuarios.EIdEmpresa = datosEmpresa.EId
        usuarios.EIdArea = idArea
        lista = usuarios.ObtenerListadoPorEmpresa()
        cbUsuarios.DataSource = lista
        cbUsuarios.ValueMember = "EId"
        cbUsuarios.DisplayMember = "ENombre"

    End Sub


    Private Sub CargarComboAreasDestino()

        Dim lista As New List(Of EntidadesReporteActividades.Areas)
        lista = areas.ObtenerListado()
        cbAreasDestino.DataSource = lista
        cbAreasDestino.ValueMember = "EId"
        cbAreasDestino.DisplayMember = "ENombre"

    End Sub

    Private Sub CargarComboUsuariosDestino()

        Dim idArea As Integer = cbAreasDestino.SelectedValue()
        Dim lista As New List(Of EntidadesReporteActividades.Usuarios)
        usuarios.EIdEmpresa = datosEmpresa.EId
        usuarios.EIdArea = idArea
        lista = usuarios.ObtenerListadoPorEmpresa()
        cbUsuariosDestino.DataSource = lista
        cbUsuariosDestino.ValueMember = "EId"
        cbUsuariosDestino.DisplayMember = "ENombre"

    End Sub

#End Region

#End Region

End Class