Imports System.IO

Public Class Principal

    Dim actividades As New EntidadesActividades.Actividades
    Dim actividadesExternas As New EntidadesActividades.ActividadesExternas
    Dim actividadesResueltas As New EntidadesActividades.ActividadesResueltas
    Dim areas As New EntidadesActividades.Areas
    Dim usuarios As New EntidadesActividades.Usuarios
    Public datosEmpresaPrincipal As New LogicaActividades.DatosEmpresaPrincipal()
    Public datosEmpresa As New LogicaActividades.DatosEmpresa()
    Public datosUsuario As New LogicaActividades.DatosUsuario()
    Public datosArea As New LogicaActividades.DatosArea()
    Public tipoTexto As New FarPoint.Win.Spread.CellType.TextCellType()
    Public tipoEntero As New FarPoint.Win.Spread.CellType.NumberCellType()
    Public tipoDoble As New FarPoint.Win.Spread.CellType.NumberCellType()
    Public tipoPorcentaje As New FarPoint.Win.Spread.CellType.PercentCellType()
    Public tipoHora As New FarPoint.Win.Spread.CellType.DateTimeCellType()
    Public tipoFecha As New FarPoint.Win.Spread.CellType.DateTimeCellType()
    Public tipoBooleano As New FarPoint.Win.Spread.CellType.CheckBoxCellType()
    Public tieneImagen As Boolean = False
    Public rutaImagen As String = String.Empty
    Public opcionSeleccionada As Integer = 0
    Dim ejecutarProgramaPrincipal As New ProcessStartInfo()
    Public estaCerrando As Boolean = False
    Public estaMostrado As Boolean = False

    Public esPrueba As Boolean = False

#Region "Eventos"

    Private Sub Principal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Me.Cursor = Cursors.WaitCursor
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
        CargarEncabezados()
        CargarConsecutivoActividades() 
        CargarTiposDeDatos()
        CargarIndiceActividades()
        AlinearBotones(True)

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Salir()

    End Sub

    Private Sub Principal_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        PonerFocoEnControl(txtCapturaId) 
        FormatearSpread()
        CargarActividadesPendientesSpread()


    End Sub

    Private Sub btnCapturaGuardar_Click(sender As Object, e As EventArgs) Handles btnCapturaGuardar.Click

        If (Me.opcionSeleccionada = OpcionActividades.Capturar) Then
            GuardarEditarActividades()
        End If

    End Sub

    Private Sub txtId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCapturaId.KeyPress

        Dim valor As Boolean = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
        e.Handled = valor

    End Sub

    Private Sub btnCapturaIdAnterior_Click(sender As Object, e As EventArgs) Handles btnCapturaIdAnterior.Click

        If IsNumeric(txtCapturaId.Text) Then
            If CInt(txtCapturaId.Text) > 1 Then
                txtCapturaId.Text -= 1
                CargarActividades()
                PonerFocoEnControl(txtCapturaId)
            End If
        Else
            txtCapturaId.Clear()
        End If

    End Sub

    Private Sub btnCapturaIdSiguiente_Click(sender As Object, e As EventArgs) Handles btnCapturaIdSiguiente.Click

        If IsNumeric(txtCapturaId.Text) Then
            If CInt(txtCapturaId.Text) > 0 Then
                txtCapturaId.Text += 1
                CargarActividades()
                PonerFocoEnControl(txtCapturaId)
            End If
        Else
            txtCapturaId.Clear()
        End If

    End Sub

    Private Sub txtCapturaId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCapturaNombre.KeyDown, txtCapturaId.KeyDown, txtCapturaDescripcion.KeyDown, dtpCapturaFechaVencimiento.KeyDown, dtpCapturaFechaCreacion.KeyDown

        If e.KeyData = Keys.Enter Then
            e.SuppressKeyPress = True
            If sender.Equals(txtCapturaId) Then
                If IsNumeric(txtCapturaId.Text) Then
                    If CInt(txtCapturaId.Text) > 0 Then
                        CargarActividades()
                        txtCapturaNombre.Focus()
                    End If
                End If
            ElseIf sender.Equals(txtCapturaNombre) Then
                If Not String.IsNullOrEmpty(txtCapturaNombre.Text) Then
                    txtCapturaDescripcion.Focus()
                End If
            ElseIf sender.Equals(txtCapturaDescripcion) Then
                dtpCapturaFechaCreacion.Focus()
            ElseIf sender.Equals(dtpCapturaFechaCreacion) Then
                If IsDate(dtpCapturaFechaCreacion.Value) Then
                    dtpCapturaFechaVencimiento.Focus()
                End If
            ElseIf sender.Equals(dtpCapturaFechaVencimiento) Then
                If IsDate(dtpCapturaFechaVencimiento.Value) Then
                    btnCapturaGuardar.Focus()
                End If
            End If
            'ElseIf e.KeyData = Keys.Escape Then
            '    e.SuppressKeyPress = True
            '    SendKeys.Send("+({TAB})")
        End If

    End Sub

    Private Sub btnCapturaEliminar_Click(sender As Object, e As EventArgs) Handles btnCapturaEliminar.Click

        If (MessageBox.Show("Confirmas que deseas eliminar la actividad seleccionada?", "Confirmacion.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            If (Me.opcionSeleccionada = OpcionActividades.Capturar) Then
                EliminarActividades()
            End If
        End If

    End Sub

    Private Sub tbActividades_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbActividades.SelectedIndexChanged

        If tbActividades.SelectedIndex = 0 Then
            Me.opcionSeleccionada = OpcionActividades.Capturar
            PonerFocoEnControl(txtCapturaId)
        Else
            Me.opcionSeleccionada = OpcionActividades.Resolver
            PonerFocoEnControl(spResolverActividades) 
        End If

    End Sub

    Private Sub spResolverActividades_CellClick(sender As Object, e As FarPoint.Win.Spread.CellClickEventArgs) Handles spResolverActividades.CellClick

        Dim filas As Integer = spResolverActividades.ActiveSheet.Rows.Count
        If filas > 0 Then
            spResolverActividades.ActiveSheet.Rows(0, filas - 1).BackColor = Color.White
            spResolverActividades.ActiveSheet.Rows(e.Row).BackColor = Color.GreenYellow
            spResolverActividades.ActiveSheet.ActiveRowIndex = e.Row
            CargarActividadesPendientes()
            AcomodarSpreadIzquierda()
            If spResolverActividades.ActiveSheetIndex = 1 Then
                CargarValoresImagenes()
                Imagen.CargarValores()
                Imagen.Mostrar()
            End If
        End If 

    End Sub

    Private Sub spResolverActividades_CellDoubleClick(sender As Object, e As FarPoint.Win.Spread.CellClickEventArgs) Handles spResolverActividades.CellDoubleClick

        AcomodarSpreadCompleto()

    End Sub

    Private Sub btnResolucionGuardar_Click(sender As Object, e As EventArgs) Handles btnResolucionGuardar.Click

        If spResolverActividades.ActiveSheetIndex = 0 Then
            GuardarEditarActividadesResueltas()
        ElseIf spResolverActividades.ActiveSheetIndex = 1 Then
            GuardarEditarActividadesResueltasExternas()
        End If

    End Sub

    Private Sub txtResolucionId_KeyDown(sender As Object, e As KeyEventArgs) Handles txtResolucionId.KeyDown, txtResolucionMotivoRetraso.KeyDown, dtpResolucionFecha.KeyDown, btnAdministrarImagen.KeyDown

        If e.KeyData = Keys.Enter Then
            e.SuppressKeyPress = True
            If sender.Equals(txtResolucionDescripcion) Then
                If Not String.IsNullOrEmpty(txtResolucionDescripcion.Text) Then
                    txtResolucionMotivoRetraso.Focus()
                End If
            ElseIf sender.Equals(txtResolucionMotivoRetraso) Then
                dtpResolucionFecha.Focus()
            ElseIf sender.Equals(dtpResolucionFecha) Then
                If (IsDate(dtpResolucionFecha.Value)) Then
                    If (spResolverActividades.ActiveSheetIndex = 1) Then
                        If (Me.tieneImagen) Then
                            btnResolucionGuardar.Focus()
                        Else
                            btnAdministrarImagen.Focus() 
                        End If
                    Else
                        btnResolucionGuardar.Focus()
                    End If
                End If
            ElseIf sender.Equals(btnAdministrarImagen) Then
                If (spResolverActividades.ActiveSheetIndex = 1) Then
                    If (Me.tieneImagen) Then
                        btnResolucionGuardar.Focus()
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub btnCapturaGuardar_MouseHover(sender As Object, e As EventArgs) Handles btnCapturaGuardar.MouseHover

        AsignarTooltips("Guardar.")

    End Sub

    Private Sub btnCapturaEliminar_MouseHover(sender As Object, e As EventArgs) Handles btnCapturaEliminar.MouseHover

        AsignarTooltips("Eliminar.")

    End Sub

    Private Sub tpCapturarActividades_MouseHover(sender As Object, e As EventArgs) Handles tpCapturarActividades.MouseHover

        AsignarTooltips(String.Empty)

    End Sub

    Private Sub btnSalir_MouseHover(sender As Object, e As EventArgs) Handles btnSalir.MouseHover

        AsignarTooltips("Salir.")

    End Sub

    Private Sub btnResolucionGuardar_MouseHover(sender As Object, e As EventArgs) Handles btnResolucionGuardar.MouseHover

        AsignarTooltips("Guardar.")

    End Sub

    Private Sub tpResolverActividades_MouseHover(sender As Object, e As EventArgs) Handles tpResolverActividades.MouseHover

        AsignarTooltips(String.Empty)

    End Sub

    Private Sub btnCapturaFechaCreacionAnterior_Click(sender As Object, e As EventArgs) Handles btnCapturaFechaCreacionAnterior.Click

        dtpCapturaFechaCreacion.Value = dtpCapturaFechaCreacion.Value.AddDays(-1)

    End Sub

    Private Sub btnCapturaFechaCreacionSiguiente_Click(sender As Object, e As EventArgs) Handles btnCapturaFechaCreacionSiguiente.Click

        dtpCapturaFechaCreacion.Value = dtpCapturaFechaCreacion.Value.AddDays(1)

    End Sub

    Private Sub btnCapturaFechaVencimientoAnterior_Click(sender As Object, e As EventArgs) Handles btnCapturaFechaVencimientoAnterior.Click

        dtpCapturaFechaVencimiento.Value = dtpCapturaFechaVencimiento.Value.AddDays(-1)

    End Sub

    Private Sub btnCapturaFechaVencimientoSiguiente_Click(sender As Object, e As EventArgs) Handles btnCapturaFechaVencimientoSiguiente.Click

        dtpCapturaFechaVencimiento.Value = dtpCapturaFechaVencimiento.Value.AddDays(1)

    End Sub

    Private Sub btnResolucionFechaAnterior_Click(sender As Object, e As EventArgs) Handles btnResolucionFechaAnterior.Click

        dtpResolucionFecha.Value = dtpResolucionFecha.Value.AddDays(-1)

    End Sub

    Private Sub btnResolucionFechaSiguiente_Click(sender As Object, e As EventArgs) Handles btnResolucionFechaSiguiente.Click

        dtpResolucionFecha.Value = dtpResolucionFecha.Value.AddDays(1)

    End Sub

    Private Sub chkEsExterna_CheckedChanged(sender As Object, e As EventArgs) Handles chkCapturaEsExterna.CheckedChanged

        If chkCapturaEsExterna.Checked Then
            CargarComboAreas()
            CargarComboUsuarios()
            AlinearBotones(False)
            MostrarExternos(True)
        Else
            AlinearBotones(True) 
            MostrarExternos(False)
        End If

    End Sub
     
    Private Sub cbAreas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAreas.SelectedIndexChanged

        If cbAreas.Items.Count > 1 Then
            If cbAreas.SelectedIndex > 0 Then
                CargarComboUsuarios()
            End If
        End If

    End Sub

    Private Sub btnAdministrarImagen_Click(sender As Object, e As EventArgs) Handles btnAdministrarImagen.Click

        CargarValoresImagenes()
        If (Imagen.idActividad > 0) And (Imagen.idArea > 0) And (Imagen.idUsuario > 0) Then
            Imagen.Show()
        End If

    End Sub

    Private Sub pnlPie_MouseHover(sender As Object, e As EventArgs) Handles pnlPie.MouseHover, pnlEncabezado.MouseHover, pnlCuerpo.MouseHover

        AsignarTooltips(String.Empty)

    End Sub

    Private Sub btnAdministrarImagen_MouseHover(sender As Object, e As EventArgs) Handles btnAdministrarImagen.MouseHover

        AsignarTooltips("Administrar Imagenes de Evidencia.")

    End Sub

    Private Sub temporizador_Tick(sender As Object, e As EventArgs) Handles temporizador.Tick

        If (Me.estaCerrando) Then
            Desvanecer()
        End If

    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click

        MostrarAyuda()

    End Sub

    Private Sub btnAyuda_MouseHover(sender As Object, e As EventArgs) Handles btnAyuda.MouseHover

        AsignarTooltips("Ayuda.")

    End Sub

#End Region

#Region "Métodos"

#Region "Genericos"

    Private Sub Salir()

        Application.Exit()

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
        tp.SetToolTip(Me.btnCapturaGuardar, "Guardar.")
        tp.SetToolTip(Me.btnCapturaEliminar, "Eliminar.")
        tp.SetToolTip(Me.btnCapturaIdAnterior, "Id Anterior.")
        tp.SetToolTip(Me.btnCapturaIdSiguiente, "Id Siguiente.")
        tp.SetToolTip(Me.btnCapturaFechaCreacionAnterior, "Fecha Anterior.")
        tp.SetToolTip(Me.btnCapturaFechaCreacionSiguiente, "Fecha Siguiente.")
        tp.SetToolTip(Me.btnCapturaFechaVencimientoAnterior, "Fecha Anterior.")
        tp.SetToolTip(Me.btnCapturaFechaVencimientoSiguiente, "Fecha Siguiente.")
        tp.SetToolTip(Me.btnResolucionGuardar, "Guardar.")
        tp.SetToolTip(Me.btnResolucionFechaAnterior, "Fecha Anterior.")
        tp.SetToolTip(Me.btnResolucionFechaSiguiente, "Fecha Siguiente.")
        tp.SetToolTip(Me.spResolverActividades, "Click para Seleccionar una Actividad a Resolver.")
        tp.SetToolTip(Me.btnAdministrarImagen, "Administrar Imagenes de Evidencia.")
        tp.SetToolTip(Me.btnAyuda, "Ayuda.")

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

        If (Me.esPrueba) Then
            'baseDatos.CadenaConexionInformacion = "C:\\Berry-Agenda\\BD\\PODC\\Agenda.mdf" 
            Me.datosUsuario.EId = 201
            Me.datosUsuario.EIdArea = 2
            Me.datosEmpresa.EId = 1
            'LogicaActividades.DatosEmpresaPrincipal.instanciaSql = "ANDREW-MAC\SQLEXPRESS"
            LogicaActividades.DatosEmpresaPrincipal.instanciaSql = "BERRY1-DELL\SQLEXPRESS2008"
            LogicaActividades.DatosEmpresaPrincipal.usuarioSql = "AdminBerry"
            'LogicaActividades.DatosEmpresaPrincipal.contrasenaSql = "@berry"
            LogicaActividades.DatosEmpresaPrincipal.contrasenaSql = "@berry2017"
        Else
            'EntidadesActividades.BaseDatos.ECadenaConexionAgenda = datosEmpresa.EDirectorio & "\\Agenda.mdf"
            LogicaActividades.DatosEmpresaPrincipal.ObtenerParametrosInformacionEmpresa()
            Me.datosEmpresa.ObtenerParametrosInformacionEmpresa()
            Me.datosUsuario.ObtenerParametrosInformacionUsuario()
            Me.datosArea.ObtenerParametrosInformacionArea()
        End If
        EntidadesActividades.BaseDatos.ECadenaConexionInformacion = "Informacion"
        EntidadesActividades.BaseDatos.ECadenaConexionCatalogo = "Catalogos"
        EntidadesActividades.BaseDatos.ECadenaConexionAgenda = "Agenda"
        EntidadesActividades.BaseDatos.AbrirConexionInformacion()
        EntidadesActividades.BaseDatos.AbrirConexionCatalogo()
        EntidadesActividades.BaseDatos.AbrirConexionAgenda()

    End Sub

    Private Sub CargarEncabezados()

        lblEncabezadoPrograma.Text = "Programa: " + Me.Text
        lblEncabezadoEmpresa.Text = "Empresa: " + Me.datosEmpresa.ENombre
        lblEncabezadoUsuario.Text = "Usuario: " + Me.datosUsuario.ENombre
        lblEncabezadoArea.Text = "Area: " + datosArea.ENombre

    End Sub

    Private Sub PonerFocoEnControl(ByVal c As Control)

        c.Focus()

    End Sub

    Private Sub AbrirPrograma(nombre As String, salir As Boolean)

        If (Me.esPrueba) Then
            Exit Sub
        End If
        ejecutarProgramaPrincipal.UseShellExecute = True
        ejecutarProgramaPrincipal.FileName = nombre & Convert.ToString(".exe")
        ejecutarProgramaPrincipal.WorkingDirectory = Directory.GetCurrentDirectory()
        ejecutarProgramaPrincipal.Arguments = LogicaActividades.DatosEmpresaPrincipal.idEmpresa.ToString().Trim().Replace(" ", "|") & " " & LogicaActividades.DatosEmpresaPrincipal.activa.ToString().Trim().Replace(" ", "|") & " " & LogicaActividades.DatosEmpresaPrincipal.instanciaSql.ToString().Trim().Replace(" ", "|") & " " & LogicaActividades.DatosEmpresaPrincipal.rutaBd.ToString().Trim().Replace(" ", "|") & " " & LogicaActividades.DatosEmpresaPrincipal.usuarioSql.ToString().Trim().Replace(" ", "|") & " " & LogicaActividades.DatosEmpresaPrincipal.contrasenaSql.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de empresa principal, indice 7 ;)".Replace(" ", "|") & " " & datosEmpresa.EId.ToString().Trim().Replace(" ", "|") & " " & datosEmpresa.ENombre.Trim().Replace(" ", "|") & " " & datosEmpresa.EDescripcion.Trim().Replace(" ", "|") & " " & datosEmpresa.EDomicilio.Trim().Replace(" ", "|") & " " & datosEmpresa.ELocalidad.Trim().Replace(" ", "|") & " " & datosEmpresa.ERfc.Trim().Replace(" ", "|") & " " & datosEmpresa.EDirectorio.Trim().Replace(" ", "|") & " " & datosEmpresa.ELogo.Trim().Replace(" ", "|") & " " & datosEmpresa.EActiva.ToString().Trim().Replace(" ", "|") & " " & datosEmpresa.EEquipo.Trim().Replace(" ", "|") & " " & "Aquí terminan los de empresa, indice 18 ;)".Replace(" ", "|") & " " & datosUsuario.EId.ToString().Trim().Replace(" ", "|") & " " & datosUsuario.ENombre.Trim().Replace(" ", "|") & " " & datosUsuario.EContrasena.Trim().Replace(" ", "|") & " " & datosUsuario.ENivel.ToString().Trim().Replace(" ", "|") & " " & datosUsuario.EAccesoTotal.ToString().Trim().Replace(" ", "|") & " " & datosUsuario.EIdArea.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de usuario, indice 25 ;)".Replace(" ", "|") & " " & datosArea.EId.ToString().Trim().Replace(" ", "|") & " " & datosArea.ENombre.ToString().Trim().Replace(" ", "|") & " " & datosArea.EClave.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de area, indice 29 ;)".Replace(" ", "|")
        Try
            Process.Start(ejecutarProgramaPrincipal)
            If salir Then
                Application.Exit()
            End If
        Catch ex As Exception
            MessageBox.Show((Convert.ToString("No se puede abrir el programa principal en la ruta : " & ejecutarProgramaPrincipal.WorkingDirectory & "\") & nombre) & Environment.NewLine & Environment.NewLine & ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

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
            txtAyuda.Text = "Sección de Ayuda: " & vbNewLine & vbNewLine & "* Capturar Actividades: " & vbNewLine & "En esta pestaña se capturarán todas las actividades, ya sean para un mismo usuario, o para otro. " & vbNewLine & "Cuando la actividad es externa, significa que es para otro usuario, a lo cual se tiene que habilitar la opción llamada Es Externa y te pide especificar su area y a dicho usuario, ambos obligatoriamente. Existen los botones de guardar/editar y eliminar actividades dependiendo lo que se necesite hacer. " & vbNewLine & vbNewLine & "* Resolver Actividades: " & vbNewLine & "En este apartado aparecen todas las actividades separadas por internas y externas. " & vbNewLine & "Para resolver simplemente se selecciona una actividad, se rellenan los datos, además de una imagen obligatoria y se procede a guardar." : Application.DoEvents()
            pnlAyuda.Controls.Add(txtAyuda) : Application.DoEvents()
        Else
            pnlCuerpo.Visible = True : Application.DoEvents()
            pnlAyuda.Visible = False : Application.DoEvents()
        End If

    End Sub

#End Region

#Region "Captura de Actividades"

    Private Sub AlinearBotones(ByVal arriba As Boolean)

        If (arriba) Then
            btnCapturaGuardar.Top = 360 : btnCapturaEliminar.Top = 360 : Application.DoEvents()
        Else
            btnCapturaGuardar.Top = 434 : btnCapturaEliminar.Top = 434 : Application.DoEvents()
        End If

    End Sub

    Private Sub MostrarExternos(ByVal mostrar As Boolean)

        lblAreas.Visible = mostrar : lblUsuarios.Visible = mostrar : Application.DoEvents()
        cbAreas.Visible = mostrar : cbUsuarios.Visible = mostrar : Application.DoEvents()

    End Sub

    Private Sub CargarIndiceActividades()

        Me.opcionSeleccionada = OpcionActividades.Capturar

    End Sub

    Private Sub CargarConsecutivoActividades()

        actividades.EIdArea = Me.datosUsuario.EIdArea
        actividades.EIdUsuario = Me.datosUsuario.EId
        txtCapturaId.Text = actividades.ObtenerMaximo()

    End Sub

    Private Sub CargarActividades()

        Me.Cursor = Cursors.WaitCursor
        Dim lista As New List(Of EntidadesActividades.Actividades)
        actividades.EId = LogicaActividades.Funciones.ValidarNumero(txtCapturaId.Text)
        actividades.EIdArea = Me.datosUsuario.EIdArea
        actividades.EIdUsuario = Me.datosUsuario.EId
        lista = actividades.ObtenerListadoPorId()
        If lista.Count = 1 Then
            If (lista(0).EEstaResuelto Or lista(0).EEsRechazado) Then
                btnCapturaGuardar.Enabled = False
                btnCapturaEliminar.Enabled = False
            Else
                btnCapturaGuardar.Enabled = True
                btnCapturaEliminar.Enabled = True
            End If
            If (lista(0).EEsExterna) Then
                If (lista(0).EEsRechazado) Then
                    lblCalificacion.Text = "Rechazada"
                    lblCalificacion.ForeColor = Color.Maroon
                ElseIf (lista(0).EEsAutorizado) Then
                    lblCalificacion.Text = "Autorizada"
                    lblCalificacion.ForeColor = Color.Green
                Else
                    lblCalificacion.Text = "Pendiente"
                    lblCalificacion.ForeColor = Color.Black
                End If
            Else
                lblCalificacion.Text = "No Aplica"
                lblCalificacion.ForeColor = Color.Gray
            End If 
            If (lista(0).EEstaResuelto) Then
                lblEstatus.Text = "Resuelta"
                lblEstatus.ForeColor = Color.Maroon
            ElseIf (lista(0).EEstaResuelto = False) Then
                lblEstatus.Text = "Abierta"
                lblEstatus.ForeColor = Color.Green
            End If
            txtCapturaNombre.Text = lista(0).ENombre
            txtCapturaDescripcion.Text = lista(0).EDescripcion
            dtpCapturaFechaCreacion.Value = lista(0).EFechaCreacion
            dtpCapturaFechaVencimiento.Value = lista(0).EFechaVencimiento
            chkCapturaEsUrgente.Checked = lista(0).EEsUrgente
            chkCapturaEsExterna.Checked = lista(0).EEsExterna
            If lista(0).EEsExterna Then
                cbAreas.SelectedValue = lista(0).EIdAreaDestino
                cbUsuarios.SelectedValue = lista(0).EIdUsuarioDestino
            Else
                If cbAreas.Items.Count > 0 Then
                    cbAreas.SelectedIndex = 0
                End If
                If cbUsuarios.Items.Count > 0 Then
                    cbUsuarios.SelectedIndex = 0
                End If
            End If
        Else
            LimpiarPantallaActividades()
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub GuardarEditarActividades()

        Dim id As Integer = LogicaActividades.Funciones.ValidarNumero(txtCapturaId.Text)
        Dim idUsuario As Integer = Me.datosUsuario.EId
        Dim idArea As Integer = Me.datosUsuario.EIdArea
        Dim nombre As String = txtCapturaNombre.Text
        Dim descripcion As String = txtCapturaDescripcion.Text
        Dim fechaCreacion As Date = dtpCapturaFechaCreacion.Text
        Dim fechaVencimiento As Date = dtpCapturaFechaVencimiento.Text
        Dim esUrgente As Boolean = chkCapturaEsUrgente.Checked
        Dim esExterna As Boolean = chkCapturaEsExterna.Checked
        Dim idAreaDestino As Integer = cbAreas.SelectedValue
        Dim idUsuarioDestino As Integer = cbUsuarios.SelectedValue
        Dim esAutorizado As Boolean = False
        Dim esRechazado As Boolean = False
        Dim estaResuelto As Boolean = False
        If (esExterna And (idAreaDestino <= 0 Or idUsuarioDestino <= 0)) Then
            MsgBox("Falta definir area y/o usuario destino, no se puede guardar.", MsgBoxStyle.Exclamation, "No permitido.")
            Exit Sub
        End If
        If ((idAreaDestino = Me.datosUsuario.EIdArea) And (idUsuarioDestino = Me.datosUsuario.EId)) Then
            MsgBox("No está permitido guardar una actividad externa para ti mismo, tiene que ser para otro usuario.", MsgBoxStyle.Exclamation, "No permitido.")
            Exit Sub
        End If
        If ((id > 0) And (Not String.IsNullOrEmpty(nombre)) And (IsDate(fechaCreacion)) And IsDate(fechaVencimiento)) Then
            actividades.EId = id
            actividades.EIdArea = idArea
            actividades.EIdUsuario = idUsuario
            actividades.ENombre = nombre
            actividades.EDescripcion = descripcion
            actividades.EFechaCreacion = fechaCreacion
            actividades.EFechaVencimiento = fechaVencimiento
            actividades.EEsUrgente = esUrgente
            actividades.EEsExterna = esExterna
            actividades.EIdAreaDestino = idAreaDestino
            actividades.EIdUsuarioDestino = idUsuarioDestino
            actividades.EEsAutorizado = esAutorizado
            actividades.EEsRechazado = esRechazado
            actividades.EEstaResuelto = estaResuelto
            Dim estaResuelta As Boolean = actividades.ValidarResueltaPorId()
            If (estaResuelta) Then
                MsgBox("Actividad resuelta, no se puede guardar.", MsgBoxStyle.Exclamation, "No permitido.")
            Else ' Se valida que no haya sido resuelta anteriormente.
                If (DateDiff(DateInterval.Day, fechaVencimiento, fechaCreacion) > 0) Then
                    MsgBox("Fecha de creación mayor a fecha de vencimiento, no se puede guardar.", MsgBoxStyle.Exclamation, "No permitido.")
                Else
                    Dim tieneActividades As Boolean = actividades.ValidarPorId()
                    If (tieneActividades) Then
                        actividades.Editar()
                    Else
                        actividades.Guardar()
                    End If
                    MsgBox("Guardado finalizado.", MsgBoxStyle.ApplicationModal, "Finalizado.")
                    CargarConsecutivoActividades()
                    LimpiarPantallaActividades()
                    CargarActividadesPendientesSpread()
                End If
            End If
        End If

    End Sub

    Private Sub LimpiarPantallaActividades()

        txtCapturaNombre.Clear()
        txtCapturaDescripcion.Clear()
        dtpCapturaFechaCreacion.Value = Today
        dtpCapturaFechaVencimiento.Value = Today
        chkCapturaEsUrgente.Checked = False
        chkCapturaEsExterna.Checked = False
        If cbAreas.Items.Count > 0 Then
            cbAreas.SelectedIndex = 0
        End If
        If cbUsuarios.Items.Count > 0 Then
            cbUsuarios.SelectedIndex = 0
        End If
        PonerFocoEnControl(txtCapturaId)
        btnCapturaGuardar.Enabled = True
        btnCapturaEliminar.Enabled = True
        lblCalificacion.Text = String.Empty
        lblEstatus.Text = String.Empty
        Application.DoEvents()

    End Sub

    Private Sub EliminarActividades()

        Dim id As Integer = LogicaActividades.Funciones.ValidarNumero(txtCapturaId.Text)
        If (id > 0) Then
            actividades.EId = id
            actividades.EIdArea = Me.datosUsuario.EIdArea
            actividades.EIdUsuario = Me.datosUsuario.EId
            Dim estaResuelta As Boolean = actividades.ValidarResueltaPorId()
            If (estaResuelta) Then
                MsgBox("Actividad resuelta, no se puede modificar.", MsgBoxStyle.Exclamation, "No permitido.")
            Else ' Se valida que no haya sido resuelta anteriormente.
                actividades.Eliminar()
                MsgBox("Eliminado finalizado.", MsgBoxStyle.ApplicationModal, "Finalizado.")
                CargarActividades()
                CargarActividadesPendientesSpread()
            End If
        End If

    End Sub

    Private Sub CargarComboAreas()

        Dim lista As New List(Of EntidadesActividades.Areas)
        lista = areas.ObtenerListado()
        cbAreas.DataSource = lista
        cbAreas.ValueMember = "EId"
        cbAreas.DisplayMember = "ENombre"

    End Sub

    Private Sub CargarComboUsuarios()

        Try
            Dim idArea As Integer = cbAreas.SelectedValue()
            Dim lista As New List(Of EntidadesActividades.Usuarios)
            usuarios.EIdEmpresa = Me.datosEmpresa.EId
            usuarios.EIdArea = idArea
            usuarios.EId = Me.datosUsuario.EId
            lista = usuarios.ObtenerListadoPorEmpresa()
            cbUsuarios.DataSource = lista
            cbUsuarios.ValueMember = "EId"
            cbUsuarios.DisplayMember = "ENombre"
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region "Resolucion de Actividades"

    Private Sub CargarActividadesPendientes()

        Dim fila As Integer = spResolverActividades.ActiveSheet.ActiveRowIndex
        Try
            txtResolucionId.Text = spResolverActividades.ActiveSheet.Cells(fila, spResolverActividades.ActiveSheet.Columns("id").Index).Value
        Catch ex As Exception
        End Try

    End Sub

    Private Sub CargarActividadesPendientesSpread()

        If (Me.opcionSeleccionada = OpcionActividades.Resolver) Then
            Me.Cursor = Cursors.WaitCursor
        End If
        ' Actividades internas.
        spResolverActividades.ActiveSheetIndex = 0
        Dim lista As New List(Of EntidadesActividades.Actividades)
        actividades.EIdArea = Me.datosUsuario.EIdArea
        actividades.EIdUsuario = Me.datosUsuario.EId
        lista = actividades.ObtenerListadoPendientes()
        spResolverActividades.ActiveSheet.DataSource = lista
        FormatearSpreadActividadesPendientes(spResolverActividades.ActiveSheet.Columns.Count)
        If (Me.opcionSeleccionada = OpcionActividades.Resolver) Then
            Me.Cursor = Cursors.WaitCursor
        End If
        ' Actividades externas.
        spResolverActividades.ActiveSheetIndex = 1
        Dim listaExterna As New List(Of EntidadesActividades.ActividadesExternas)
        actividadesExternas.EIdArea = Me.datosUsuario.EIdArea
        actividadesExternas.EIdUsuario = Me.datosUsuario.EId
        listaExterna = actividadesExternas.ObtenerListadoPendientesExternas()
        spResolverActividades.ActiveSheet.DataSource = listaExterna
        FormatearSpreadActividadesPendientesExternas(spResolverActividades.ActiveSheet.Columns.Count)
        If (Me.opcionSeleccionada = OpcionActividades.Resolver) Then
            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub GuardarEditarActividadesResueltas()

        Dim fila As Integer = spResolverActividades.ActiveSheet.ActiveRowIndex
        Dim id As Integer = LogicaActividades.Funciones.ValidarNumero(spResolverActividades.ActiveSheet.Cells(fila, spResolverActividades.ActiveSheet.Columns("id").Index).Value)
        Dim idArea As Integer = Me.datosUsuario.EIdArea
        Dim idUsuario As Integer = Me.datosUsuario.EId
        Dim descripcion As String = txtResolucionDescripcion.Text
        Dim motivoRetraso As String = txtResolucionMotivoRetraso.Text
        Dim fechaResolucion As Date = dtpResolucionFecha.Text
        Dim esExterna As Boolean = spResolverActividades.ActiveSheet.Cells(fila, spResolverActividades.ActiveSheet.Columns("esExterna").Index).Value
        Dim idAreaOrigen As Integer = Me.datosUsuario.EIdArea ' Se toma el area que resuelve.
        Dim idUsuarioOrigen As Integer = Me.datosUsuario.EId ' Se toma el usuario que resuelve.  
        Dim estaResuelto As Boolean = True
        If (id > 0) And (Not String.IsNullOrEmpty(descripcion)) And IsDate(fechaResolucion) Then
            actividadesResueltas.EId = id
            actividadesResueltas.EIdArea = idArea
            actividadesResueltas.EIdUsuario = idUsuario
            actividadesResueltas.EDescripcionResolucion = descripcion
            actividadesResueltas.EMotivoRetraso = motivoRetraso
            actividadesResueltas.EFechaResolucion = fechaResolucion
            If (esExterna) Then
                actividadesResueltas.EIdAreaOrigen = idAreaOrigen
                actividadesResueltas.EIdUsuarioOrigen = idUsuarioOrigen
            End If
            actividadesResueltas.ERutaImagen = Me.rutaImagen
            actividadesResueltas.EEstaResuelto = estaResuelto
            Dim listaLocal As New List(Of EntidadesActividades.Actividades)
            Dim actividadesLocal As New EntidadesActividades.Actividades
            actividadesLocal.EId = id
            actividadesLocal.EIdArea = idArea
            actividadesLocal.EIdUsuario = idUsuario
            listaLocal = actividadesLocal.ObtenerListadoPorId()
            Dim fechaCreacion As Date = listaLocal(0).EFechaCreacion
            If (DateDiff(DateInterval.Day, fechaResolucion, fechaCreacion) > 0) Then
                MsgBox("Fecha de creación mayor a fecha de resolución, no se puede guardar.", MsgBoxStyle.Exclamation, "No permitido.")
            Else
                Dim tieneActividades As Boolean = actividadesResueltas.ValidarPorId()
                If (tieneActividades) Then
                    actividadesResueltas.Editar()
                Else
                    actividadesResueltas.Guardar()
                End If
                actividadesResueltas.GuardarEstatusResuelto()
                MsgBox("Guardado finalizado.", MsgBoxStyle.ApplicationModal, "Finalizado.")
                CargarActividadesPendientesSpread()
                LimpiarPantallaActividadesResueltas()
            End If
        End If

    End Sub

    Private Sub GuardarEditarActividadesResueltasExternas()

        Dim fila As Integer = spResolverActividades.ActiveSheet.ActiveRowIndex
        Dim id As Integer = LogicaActividades.Funciones.ValidarNumero(spResolverActividades.ActiveSheet.Cells(fila, spResolverActividades.ActiveSheet.Columns("id").Index).Value)
        Dim idArea As Integer = LogicaActividades.Funciones.ValidarNumero(spResolverActividades.ActiveSheet.Cells(fila, spResolverActividades.ActiveSheet.Columns("idArea").Index).Value) ' Se toma el area que la pidió, de la cual se va a resolver.
        Dim idUsuario As Integer = LogicaActividades.Funciones.ValidarNumero(spResolverActividades.ActiveSheet.Cells(fila, spResolverActividades.ActiveSheet.Columns("idUsuario").Index).Value) ' Se toma el usuario que la pidió, de la cual se va a resolver.
        Dim descripcion As String = txtResolucionDescripcion.Text
        Dim motivoRetraso As String = txtResolucionMotivoRetraso.Text
        Dim fechaResolucion As Date = dtpResolucionFecha.Text
        Dim idAreaOrigen As Integer = Me.datosUsuario.EIdArea ' Se toma el area que resuelve.
        Dim idUsuarioOrigen As Integer = Me.datosUsuario.EId ' Se toma el usuario que resuelve.
        Dim estaResuelto As Boolean = True
        If (id > 0) And (Not String.IsNullOrEmpty(descripcion)) And (IsDate(fechaResolucion)) And (Not String.IsNullOrEmpty(Me.rutaImagen)) Then
            actividadesResueltas.EId = id
            actividadesResueltas.EIdArea = idArea
            actividadesResueltas.EIdUsuario = idUsuario
            actividadesResueltas.EDescripcionResolucion = descripcion
            actividadesResueltas.EMotivoRetraso = motivoRetraso
            actividadesResueltas.EFechaResolucion = fechaResolucion
            actividadesResueltas.EIdAreaOrigen = idAreaOrigen
            actividadesResueltas.EIdUsuarioOrigen = idUsuarioOrigen
            actividadesResueltas.ERutaImagen = Me.rutaImagen
            actividadesResueltas.EEstaResuelto = estaResuelto
            Dim listaLocal As New List(Of EntidadesActividades.Actividades)
            Dim actividadesLocal As New EntidadesActividades.Actividades
            actividadesLocal.EId = id
            actividadesLocal.EIdArea = idArea
            actividadesLocal.EIdUsuario = idUsuario
            listaLocal = actividadesLocal.ObtenerListadoPorId()
            Dim fechaCreacion As Date = listaLocal(0).EFechaCreacion
            If (DateDiff(DateInterval.Day, fechaResolucion, fechaCreacion) > 0) Then
                MsgBox("Fecha de creación mayor a fecha de resolución, no se puede guardar.", MsgBoxStyle.Exclamation, "No permitido.")
            Else
                Dim tieneActividades As Boolean = actividadesResueltas.ValidarPorId()
                If (tieneActividades) Then
                    actividadesResueltas.Editar()
                Else
                    actividadesResueltas.Guardar()
                End If
                actividadesResueltas.GuardarEstatusResuelto()
                MsgBox("Guardado finalizado.", MsgBoxStyle.ApplicationModal, "Finalizado.")
                CargarActividadesPendientesSpread()
                LimpiarPantallaActividadesResueltas()
            End If
        End If

    End Sub

    Private Sub AcomodarSpreadCompleto()
         
        spResolverActividades.Top = 5 : Application.DoEvents()
        spResolverActividades.Left = 5 : Application.DoEvents()
        spResolverActividades.Width = tpResolverActividades.Width - 10 : Application.DoEvents()
        spResolverActividades.Height = tpResolverActividades.Height - 10 : Application.DoEvents()
        pnlResolucion.Visible = False : Application.DoEvents()

    End Sub

    Private Sub AcomodarSpreadIzquierda()
         
        spResolverActividades.Top = 5 : Application.DoEvents()
        spResolverActividades.Left = 5 : Application.DoEvents()
        spResolverActividades.Width = tpResolverActividades.Width - pnlResolucion.Width - 10 : Application.DoEvents()
        spResolverActividades.Height = tpResolverActividades.Height - 10 : Application.DoEvents()
        pnlResolucion.Top = 5 : Application.DoEvents()
        pnlResolucion.Left = spResolverActividades.Width + 5 : Application.DoEvents()
        pnlResolucion.Height = spResolverActividades.Height : Application.DoEvents()
        pnlResolucion.Visible = True : Application.DoEvents()

    End Sub

    Private Sub FormatearSpread()

        If (Me.opcionSeleccionada = OpcionActividades.Resolver) Then
            Me.Cursor = Cursors.WaitCursor
        End If
        spResolverActividades.Reset() : Application.DoEvents()
        spResolverActividades.Sheets.Count = 2 : Application.DoEvents()
        spResolverActividades.Sheets(0).SheetName = "Internas" : Application.DoEvents()
        spResolverActividades.Sheets(1).SheetName = "Externas" : Application.DoEvents()
        spResolverActividades.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell : Application.DoEvents()
        spResolverActividades.Visible = True : Application.DoEvents()
        spResolverActividades.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Regular) : Application.DoEvents()
        spResolverActividades.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded : Application.DoEvents()
        spResolverActividades.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded : Application.DoEvents()
        spResolverActividades.TabStrip.DefaultSheetTab.Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold) : Application.DoEvents()
        AcomodarSpreadCompleto()
        If (Me.opcionSeleccionada = OpcionActividades.Resolver) Then
            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub FormatearSpreadActividadesPendientes(ByVal cantidadColumnas As Integer)

        If (Me.opcionSeleccionada = OpcionActividades.Resolver) Then
            Me.Cursor = Cursors.WaitCursor
        End If
        spResolverActividades.ActiveSheetIndex = 0
        spResolverActividades.ActiveSheet.GrayAreaBackColor = Color.White : Application.DoEvents()
        spResolverActividades.ActiveSheet.Rows(-1).Height = 50 : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Rows(0).Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold) : Application.DoEvents()
        Dim numeracion As Integer = 0
        spResolverActividades.ActiveSheet.Columns.Count = cantidadColumnas
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "idArea" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "idUsuario" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "descripcion" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "fechaCreacion" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "fechaVencimiento" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "esUrgente" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "esExterna" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "idAreaDestino" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "idUsuarioDestino" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "esAutorizado" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "esRechazado" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "estaResuelto" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns("id").Width = 60 : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("nombre").Width = 300 : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("descripcion").Width = 500 : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("fechaCreacion").Width = 140 : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("fechaVencimiento").Width = 140 : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("esUrgente").Width = 110 : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("esUrgente").CellType = tipoBooleano : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("nombre").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Justify : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("descripcion").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Justify : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Cells(0, spResolverActividades.ActiveSheet.Columns("id").Index).Value = "No.".ToUpper : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Cells(0, spResolverActividades.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Cells(0, spResolverActividades.ActiveSheet.Columns("descripcion").Index).Value = "Descripción".ToUpper : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Cells(0, spResolverActividades.ActiveSheet.Columns("fechaCreacion").Index).Value = "Fecha de Creación".ToUpper : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Cells(0, spResolverActividades.ActiveSheet.Columns("fechaVencimiento").Index).Value = "Fecha de Vencimiento".ToUpper : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Cells(0, spResolverActividades.ActiveSheet.Columns("esUrgente").Index).Value = "Es Urgente?".ToUpper : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("idArea").Visible = False : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("idUsuario").Visible = False : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("esExterna").Visible = False : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("idAreaDestino").Visible = False : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("idUsuarioDestino").Visible = False : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("esAutorizado").Visible = False : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("esRechazado").Visible = False : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("estaResuelto").Visible = False : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Rows(0).Height = 45 : Application.DoEvents()
        spResolverActividades.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect 
        If (Me.opcionSeleccionada = OpcionActividades.Resolver) Then
            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub FormatearSpreadActividadesPendientesExternas(ByVal cantidadColumnas As Integer)

        If (Me.opcionSeleccionada = OpcionActividades.Resolver) Then
            Me.Cursor = Cursors.WaitCursor
        End If
        spResolverActividades.ActiveSheetIndex = 1
        spResolverActividades.ActiveSheet.GrayAreaBackColor = Color.White : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Rows(0).Height = 35 : Application.DoEvents()
        spResolverActividades.ActiveSheet.Rows(-1).Height = 50 : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.RowCount = 2 : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Rows(0, spResolverActividades.ActiveSheet.ColumnHeader.Rows.Count - 1).Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold) : Application.DoEvents()
        Dim numeracion As Integer = 0
        spResolverActividades.ActiveSheet.Columns.Count = cantidadColumnas
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "idArea" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "nombreArea" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "idUsuario" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "nombreUsuario" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "descripcion" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "fechaCreacion" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "fechaVencimiento" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "esUrgente" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "esExterna" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "idAreaDestino" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "idUsuarioDestino" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "esAutorizado" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "esRechazado" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns(numeracion).Tag = "estaResuelto" : numeracion += 1
        spResolverActividades.ActiveSheet.Columns("id").Width = 60 : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("idArea").Width = 40 : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("nombreArea").Width = 130 : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("idUsuario").Width = 40 : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("nombreUsuario").Width = 130 : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("nombre").Width = 300 : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("descripcion").Width = 500 : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("fechaCreacion").Width = 140 : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("fechaVencimiento").Width = 140 : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("esUrgente").Width = 110 : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("esUrgente").CellType = tipoBooleano : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("nombre").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Justify : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("descripcion").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Justify : Application.DoEvents() 
        spResolverActividades.ActiveSheet.AddColumnHeaderSpanCell(0, spResolverActividades.ActiveSheet.Columns("id").Index, 2, 1) : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Cells(0, spResolverActividades.ActiveSheet.Columns("id").Index).Value = "No.".ToUpper : Application.DoEvents() 
        spResolverActividades.ActiveSheet.AddColumnHeaderSpanCell(0, spResolverActividades.ActiveSheet.Columns("idArea").Index, 1, 2) : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Cells(0, spResolverActividades.ActiveSheet.Columns("idArea").Index).Value = "Area Origen".ToUpper : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Cells(1, spResolverActividades.ActiveSheet.Columns("idArea").Index).Value = "No.".ToUpper : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Cells(1, spResolverActividades.ActiveSheet.Columns("nombreArea").Index).Value = "Nombre".ToUpper : Application.DoEvents() 
        spResolverActividades.ActiveSheet.AddColumnHeaderSpanCell(0, spResolverActividades.ActiveSheet.Columns("idUsuario").Index, 1, 2) : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Cells(0, spResolverActividades.ActiveSheet.Columns("idUsuario").Index).Value = "Usuario Origen".ToUpper : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Cells(1, spResolverActividades.ActiveSheet.Columns("idUsuario").Index).Value = "No.".ToUpper : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Cells(1, spResolverActividades.ActiveSheet.Columns("nombreUsuario").Index).Value = "Nombre".ToUpper : Application.DoEvents() 
        spResolverActividades.ActiveSheet.AddColumnHeaderSpanCell(0, spResolverActividades.ActiveSheet.Columns("nombre").Index, 2, 1) : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Cells(0, spResolverActividades.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper : Application.DoEvents() 
        spResolverActividades.ActiveSheet.AddColumnHeaderSpanCell(0, spResolverActividades.ActiveSheet.Columns("descripcion").Index, 2, 1) : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Cells(0, spResolverActividades.ActiveSheet.Columns("descripcion").Index).Value = "Descripción".ToUpper : Application.DoEvents() 
        spResolverActividades.ActiveSheet.AddColumnHeaderSpanCell(0, spResolverActividades.ActiveSheet.Columns("fechaCreacion").Index, 2, 1) : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Cells(0, spResolverActividades.ActiveSheet.Columns("fechaCreacion").Index).Value = "Fecha de Creación".ToUpper : Application.DoEvents() 
        spResolverActividades.ActiveSheet.AddColumnHeaderSpanCell(0, spResolverActividades.ActiveSheet.Columns("fechaVencimiento").Index, 2, 1) : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Cells(0, spResolverActividades.ActiveSheet.Columns("fechaVencimiento").Index).Value = "Fecha de Vencimiento".ToUpper : Application.DoEvents() 
        spResolverActividades.ActiveSheet.AddColumnHeaderSpanCell(0, spResolverActividades.ActiveSheet.Columns("esUrgente").Index, 2, 1) : Application.DoEvents()
        spResolverActividades.ActiveSheet.ColumnHeader.Cells(0, spResolverActividades.ActiveSheet.Columns("esUrgente").Index).Value = "Es Urgente?".ToUpper : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("esExterna").Visible = False : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("idAreaDestino").Visible = False : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("idUsuarioDestino").Visible = False : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("esAutorizado").Visible = False : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("esRechazado").Visible = False : Application.DoEvents()
        spResolverActividades.ActiveSheet.Columns("estaResuelto").Visible = False : Application.DoEvents()
        spResolverActividades.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect : Application.DoEvents()
        If (Me.opcionSeleccionada = OpcionActividades.Resolver) Then
            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub ControlarSpreadActividadesPendientesEnter()

        Dim columnaActiva As Integer = spResolverActividades.ActiveSheet.ActiveColumnIndex
        ' Guardar o editar. 
        If (spResolverActividades.ActiveSheet.ActiveColumnIndex = spResolverActividades.ActiveSheet.Columns.Count - 1) Then
            spResolverActividades.ActiveSheet.AddRows(spResolverActividades.ActiveSheet.Rows.Count, 1)
            Dim filaActiva As Integer = spResolverActividades.ActiveSheet.ActiveRowIndex
            If (Me.opcionSeleccionada = OpcionActividades.Capturar) Then
                'GuardarEditarActividadesResueltas()
            ElseIf (Me.opcionSeleccionada = OpcionActividades.Resolver) Then
                'GuardarEditarEmpresas()
            End If
        End If

    End Sub

    Private Sub EliminarActividadesResueltas()

        Dim fila As Integer = spResolverActividades.ActiveSheet.ActiveRowIndex
        Dim id As String = spResolverActividades.ActiveSheet.Cells(fila, spResolverActividades.ActiveSheet.Columns("id").Index).Value
        If (Not String.IsNullOrEmpty(id)) Then
            actividades.EId = LogicaActividades.Funciones.ValidarNumero(id)
            actividades.EIdArea = Me.datosUsuario.EIdArea
            'actividades.Eliminar()
            'CargarActividades()
        End If

    End Sub

    Private Sub LimpiarPantallaActividadesResueltas()

        txtResolucionId.Clear()
        txtResolucionDescripcion.Clear()
        txtResolucionMotivoRetraso.Clear()
        dtpResolucionFecha.Value = Today
        pbImagen.Image = Nothing
        Me.tieneImagen = False
        Dim filas As Integer = spResolverActividades.ActiveSheet.Rows.Count
        If filas > 0 Then
            spResolverActividades.ActiveSheet.Rows(0, filas - 1).BackColor = Color.White
        End If
        Application.DoEvents()

    End Sub

    Private Sub CargarValoresImagenes()

        spResolverActividades.ActiveSheetIndex = 1
        Imagen.idActividad = LogicaActividades.Funciones.ValidarNumero(txtResolucionId.Text)
        Imagen.idUsuario = Me.datosUsuario.EId
        Imagen.idArea = Me.datosUsuario.EIdArea

    End Sub

#End Region

#End Region

#Region "Enumeraciones"

    Public Enum OpcionActividades

        Capturar = 1
        Resolver = 2

    End Enum

#End Region
       
End Class