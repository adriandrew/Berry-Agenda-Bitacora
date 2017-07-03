Imports System.IO
Imports System.ComponentModel

Public Class Principal

    Dim usuarios As New EntidadesCatalogosGenerales.Usuarios 
    Dim areas As New EntidadesCatalogosGenerales.Areas
    Dim actividadesFijas As New EntidadesCatalogosGenerales.ActividadesFijas
    Dim rangosFijos As New EntidadesCatalogosGenerales.RangosFijos
    Public datosEmpresa As New LogicaCatalogosGenerales.DatosEmpresa()
    Public datosUsuario As New LogicaCatalogosGenerales.DatosUsuario()
    Public datosArea As New LogicaCatalogosGenerales.DatosArea()
    Public tipoTexto As New FarPoint.Win.Spread.CellType.TextCellType()
    Public tipoTextoContrasena As New FarPoint.Win.Spread.CellType.TextCellType()
    Public tipoEntero As New FarPoint.Win.Spread.CellType.NumberCellType()
    Public tipoDoble As New FarPoint.Win.Spread.CellType.NumberCellType()
    Public tipoPorcentaje As New FarPoint.Win.Spread.CellType.PercentCellType()
    Public tipoHora As New FarPoint.Win.Spread.CellType.DateTimeCellType()
    Public tipoFecha As New FarPoint.Win.Spread.CellType.DateTimeCellType()
    Public tipoBooleano As New FarPoint.Win.Spread.CellType.CheckBoxCellType()
    Public opcionSeleccionada As Integer = 0
    Dim ejecutarProgramaPrincipal As New ProcessStartInfo()
    Public estaCerrando As Boolean = False
    Public estaMostrado As Boolean = False

    Public esDesarrollo As Boolean = False

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
        CargarTiposDeDatos()

    End Sub

    Private Sub Principal_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Me.Cursor = Cursors.AppStarting
        Me.Enabled = False 
        CargarEncabezados()
        FormatearSpread()
        SeleccionoActividadesFijas()
        Me.Enabled = True
        spCatalogos.Focus()
        Me.estaMostrado = True
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Salir()

    End Sub

    Private Sub spCatalogos_DialogKey(sender As Object, e As FarPoint.Win.Spread.DialogKeyEventArgs) Handles spCatalogos.DialogKey

        If (e.KeyData = Keys.Enter) Then
            ControlarSpreadEnter()
        End If

    End Sub

    Private Sub spCatalogos_KeyDown(sender As Object, e As KeyEventArgs) Handles spCatalogos.KeyDown

        If e.KeyData = Keys.F5 Then ' Abrir catalogos.
            If (Me.opcionSeleccionada = Opciones.Fijas) Then 
                If (spCatalogos.ActiveSheet.ActiveColumnIndex = spCatalogos.ActiveSheet.Columns("idRangoFijoCreacion").Index) Or (spCatalogos.ActiveSheet.ActiveColumnIndex = spCatalogos.ActiveSheet.Columns("nombreRangoFijoCreacion").Index Or spCatalogos.ActiveSheet.ActiveColumnIndex = spCatalogos.ActiveSheet.Columns("idRangoFijoVencimiento").Index) Or (spCatalogos.ActiveSheet.ActiveColumnIndex = spCatalogos.ActiveSheet.Columns("nombreRangoFijoVencimiento").Index) Then
                    spCatalogos.Enabled = False
                    pnlMenu.Enabled = False
                    CargarCatalogoRangosFijos()
                    spCatalogos2.Focus()
                ElseIf (spCatalogos.ActiveSheet.Cells(spCatalogos.ActiveSheet.ActiveRowIndex, spCatalogos.ActiveSheet.Columns("esExterna").Index).Value) Then
                    If (spCatalogos.ActiveSheet.ActiveColumnIndex = spCatalogos.ActiveSheet.Columns("idUsuarioDestino").Index) Or (spCatalogos.ActiveSheet.ActiveColumnIndex = spCatalogos.ActiveSheet.Columns("nombreUsuarioDestino").Index) Then
                        spCatalogos.Enabled = False
                        pnlMenu.Enabled = False
                        CargarCatalogoUsuarios()
                        spCatalogos2.Focus()
                    ElseIf (spCatalogos.ActiveSheet.ActiveColumnIndex = spCatalogos.ActiveSheet.Columns("idAreaDestino").Index) Or (spCatalogos.ActiveSheet.ActiveColumnIndex = spCatalogos.ActiveSheet.Columns("nombreAreaDestino").Index) Then
                        spCatalogos.Enabled = False
                        pnlMenu.Enabled = False
                        CargarCatalogoAreas()
                        spCatalogos.Focus()
                    End If
                End If
            End If
        ElseIf e.KeyData = Keys.F6 Then ' Eliminar un registro.
            If (MessageBox.Show("Confirmas que deseas eliminar el registro seleccionado?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                Dim fila As Integer = spCatalogos.ActiveSheet.ActiveRowIndex
                If (Me.opcionSeleccionada = Opciones.Fijas) Then
                    spCatalogos.ActiveSheet.Rows.Remove(fila, 1)
                End If
            End If
        ElseIf (e.KeyData = Keys.Enter) Then ' Validar registros.
            ControlarSpreadEnter()
        End If

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If (Me.opcionSeleccionada = Opciones.Fijas) Then
            GuardarEditarActividadesFijas()
        End If

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        If (Me.opcionSeleccionada = Opciones.Fijas) Then
            EliminarActividadesFijas()
        End If

    End Sub

    Private Sub btnGuardar_MouseHover(sender As Object, e As EventArgs) Handles btnGuardar.MouseHover

        AsignarTooltips("Guardar.")

    End Sub

    Private Sub btnEliminar_MouseHover(sender As Object, e As EventArgs) Handles btnEliminar.MouseHover

        AsignarTooltips("Eliminar.")

    End Sub

    Private Sub btnSalir_MouseHover(sender As Object, e As EventArgs) Handles btnSalir.MouseHover

        AsignarTooltips("Salir.")

    End Sub

    Private Sub pnlEncabezado_MouseHover(sender As Object, e As EventArgs) Handles pnlPie.MouseHover, pnlEncabezado.MouseHover, pnlCuerpo.MouseHover

        AsignarTooltips(String.Empty)

    End Sub

    Private Sub spCatalogos2_CellClick(sender As Object, e As FarPoint.Win.Spread.CellClickEventArgs) Handles spCatalogos2.CellClick

        Dim fila As Integer = e.Row
        If (Me.opcionSeleccionada = Opciones.Fijas) Then
            If (spCatalogos.ActiveSheet.ActiveColumnIndex = spCatalogos.ActiveSheet.Columns("idRangoFijoCreacion").Index Or spCatalogos.ActiveSheet.ActiveColumnIndex = spCatalogos.ActiveSheet.Columns("nombreRangoFijoCreacion").Index) Then
                spCatalogos.ActiveSheet.Cells(spCatalogos.ActiveSheet.ActiveRowIndex, spCatalogos.ActiveSheet.Columns("idRangoFijoCreacion").Index).Text = spCatalogos2.ActiveSheet.Cells(fila, spCatalogos2.ActiveSheet.Columns("id").Index).Text
                spCatalogos.ActiveSheet.Cells(spCatalogos.ActiveSheet.ActiveRowIndex, spCatalogos.ActiveSheet.Columns("nombreRangoFijoCreacion").Index).Text = spCatalogos2.ActiveSheet.Cells(fila, spCatalogos2.ActiveSheet.Columns("nombre").Index).Text
            ElseIf (spCatalogos.ActiveSheet.ActiveColumnIndex = spCatalogos.ActiveSheet.Columns("idRangoFijoVencimiento").Index Or spCatalogos.ActiveSheet.ActiveColumnIndex = spCatalogos.ActiveSheet.Columns("nombreRangoFijoVencimiento").Index) Then
                spCatalogos.ActiveSheet.Cells(spCatalogos.ActiveSheet.ActiveRowIndex, spCatalogos.ActiveSheet.Columns("idRangoFijoVencimiento").Index).Text = spCatalogos2.ActiveSheet.Cells(fila, spCatalogos2.ActiveSheet.Columns("id").Index).Text
                spCatalogos.ActiveSheet.Cells(spCatalogos.ActiveSheet.ActiveRowIndex, spCatalogos.ActiveSheet.Columns("nombreRangoFijoVencimiento").Index).Text = spCatalogos2.ActiveSheet.Cells(fila, spCatalogos2.ActiveSheet.Columns("nombre").Index).Text
            ElseIf (spCatalogos.ActiveSheet.ActiveColumnIndex = spCatalogos.ActiveSheet.Columns("idAreaDestino").Index Or spCatalogos.ActiveSheet.ActiveColumnIndex = spCatalogos.ActiveSheet.Columns("nombreAreaDestino").Index) Then
                spCatalogos.ActiveSheet.Cells(spCatalogos.ActiveSheet.ActiveRowIndex, spCatalogos.ActiveSheet.Columns("idAreaDestino").Index).Text = spCatalogos2.ActiveSheet.Cells(fila, spCatalogos2.ActiveSheet.Columns("id").Index).Text
                spCatalogos.ActiveSheet.Cells(spCatalogos.ActiveSheet.ActiveRowIndex, spCatalogos.ActiveSheet.Columns("nombreAreaDestino").Index).Text = spCatalogos2.ActiveSheet.Cells(fila, spCatalogos2.ActiveSheet.Columns("nombre").Index).Text
            ElseIf (spCatalogos.ActiveSheet.ActiveColumnIndex = spCatalogos.ActiveSheet.Columns("idUsuarioDestino").Index Or spCatalogos.ActiveSheet.ActiveColumnIndex = spCatalogos.ActiveSheet.Columns("nombreUsuarioDestino").Index) Then
                spCatalogos.ActiveSheet.Cells(spCatalogos.ActiveSheet.ActiveRowIndex, spCatalogos.ActiveSheet.Columns("idUsuarioDestino").Index).Text = spCatalogos2.ActiveSheet.Cells(fila, spCatalogos2.ActiveSheet.Columns("id").Index).Text
                spCatalogos.ActiveSheet.Cells(spCatalogos.ActiveSheet.ActiveRowIndex, spCatalogos.ActiveSheet.Columns("nombreUsuarioDestino").Index).Text = spCatalogos2.ActiveSheet.Cells(fila, spCatalogos2.ActiveSheet.Columns("nombre").Index).Text
            End If
        End If

    End Sub

    Private Sub spCatalogos2_CellDoubleClick(sender As Object, e As FarPoint.Win.Spread.CellClickEventArgs) Handles spCatalogos2.CellDoubleClick

        VolverFocoCatalogos()

    End Sub

    Private Sub spCatalogos2_KeyDown(sender As Object, e As KeyEventArgs) Handles spCatalogos2.KeyDown

        If e.KeyCode = Keys.Escape Then
            VolverFocoCatalogos()
        End If

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

    Private Sub rbtnActividadesFijas_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnActividadesFijas.CheckedChanged

        If (Me.estaMostrado) Then
            If (rbtnActividadesFijas.Checked) Then
                SeleccionoActividadesFijas()
            End If
        End If

    End Sub

#End Region

#Region "Metodos"

#Region "Genericos"

    Private Sub Salir()

        Application.Exit()

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
            txtAyuda.Text = "Sección de Ayuda: " & vbNewLine & vbNewLine & "* Teclas básicas: " & vbNewLine & "F5 sirve para mostrar catálogos. " & vbNewLine & "F6 sirve para eliminar un registro únicamente. " & vbNewLine & "Escape sirve para ocultar catálogos que se encuentren desplegados. " & vbNewLine & vbNewLine & "* Catálogos desplegados: " & vbNewLine & "Cuando se muestra algún catálogo, al seleccionar alguna opción de este, se va mostrando en tiempo real en la captura de donde se originó. Cuando se le da doble clic en alguna opción o a la tecla escape se oculta dicho catálogo. " & vbNewLine & vbNewLine & "* Areas: " & vbNewLine & "En esta pestaña se capturarán todas las areas necesarias. " & vbNewLine & "Existen los botones de guardar/editar y eliminar todo dependiendo lo que se necesite hacer. " & vbNewLine & vbNewLine & "* Usuarios: " & vbNewLine & "En esta parte se capturarán todos los usuarios. " & vbNewLine & "Descripción de los datos que pide: " & vbNewLine & "- Contraseña: esta permite letras y/o números sin ningun problema, no existen restricciones de ningún tipo." & vbNewLine & "- Nivel: 0 es para acceso a todos los programas, excepto los de gerencia. 1 es para los módulos, en este caso como es uno solo, no aplica. 2 es para los programas, si se le da doble clic aparecerán los programas para seleccionar cuales se permitirán y cuales no. 3 es para subprogramas, no aplica en este caso. Si se configura un usuario a nivel 2, hay que darle doble clic sobre el para poder ver los programas y poder seleccionarlos para bloquearle el acceso." & vbNewLine & "- Acceso Total: es solamente para usuarios de gerencia. " & vbNewLine & "Existen los botones de guardar/editar y eliminar todo dependiendo lo que se necesite hacer. " & vbNewLine & vbNewLine & "* Correos: " & vbNewLine & "En este apartado se capturarán todos los usuarios con sus respectivos correos para enviarles sus notificaciones de actividades pendientes que se encuentran retrasadas en tiempos. " & vbNewLine & "Existen los botones de guardar/editar y eliminar todo dependiendo lo que se necesite hacer. " : Application.DoEvents()
            pnlAyuda.Controls.Add(txtAyuda) : Application.DoEvents()
        Else
            pnlCuerpo.Visible = True : Application.DoEvents()
            pnlAyuda.Visible = False : Application.DoEvents()
        End If

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

    End Sub

    Private Sub AsignarTooltips(ByVal texto As String)

        lblDescripcionTooltip.Text = texto

    End Sub

    Private Sub ConfigurarConexiones()

        If (Me.esDesarrollo) Then  
            LogicaCatalogosGenerales.DatosEmpresaPrincipal.instanciaSql = "BERRY1-DELL\SQLEXPRESS2008"
            LogicaCatalogosGenerales.DatosEmpresaPrincipal.usuarioSql = "AdminBerry" 
            LogicaCatalogosGenerales.DatosEmpresaPrincipal.contrasenaSql = "@berry2017" 
            datosEmpresa.EId = 1
            datosUsuario.EIdArea = 1
            datosUsuario.EId = 1
        Else 
            LogicaCatalogosGenerales.DatosEmpresaPrincipal.ObtenerParametrosInformacionEmpresa()
            Me.datosEmpresa.ObtenerParametrosInformacionEmpresa()
            Me.datosUsuario.ObtenerParametrosInformacionUsuario()
            Me.datosArea.ObtenerParametrosInformacionArea()
        End If
        EntidadesCatalogosGenerales.BaseDatos.ECadenaConexionCatalogo = "Catalogos"
        EntidadesCatalogosGenerales.BaseDatos.ECadenaConexionInformacion = "Informacion"
        EntidadesCatalogosGenerales.BaseDatos.ECadenaConexionAgenda = "Agenda"
        EntidadesCatalogosGenerales.BaseDatos.AbrirConexionCatalogo()
        EntidadesCatalogosGenerales.BaseDatos.AbrirConexionInformacion()
        EntidadesCatalogosGenerales.BaseDatos.AbrirConexionAgenda()

    End Sub

    Private Sub CargarEncabezados()

        lblEncabezadoPrograma.Text = "Programa: " + Me.Text
        lblEncabezadoEmpresa.Text = "Empresa: " + datosEmpresa.ENombre
        lblEncabezadoUsuario.Text = "Usuario: " + datosUsuario.ENombre
        lblEncabezadoArea.Text = "Area: " + datosArea.ENombre

    End Sub

    Private Sub AbrirPrograma(nombre As String, salir As Boolean)

        If (Me.esDesarrollo) Then
            Exit Sub
        End If
        ejecutarProgramaPrincipal.UseShellExecute = True
        ejecutarProgramaPrincipal.FileName = nombre & Convert.ToString(".exe")
        ejecutarProgramaPrincipal.WorkingDirectory = Application.StartupPath
        ejecutarProgramaPrincipal.Arguments = LogicaCatalogosGenerales.DatosEmpresaPrincipal.idEmpresa.ToString().Trim().Replace(" ", "|") & " " & LogicaCatalogosGenerales.DatosEmpresaPrincipal.activa.ToString().Trim().Replace(" ", "|") & " " & LogicaCatalogosGenerales.DatosEmpresaPrincipal.instanciaSql.ToString().Trim().Replace(" ", "|") & " " & LogicaCatalogosGenerales.DatosEmpresaPrincipal.rutaBd.ToString().Trim().Replace(" ", "|") & " " & LogicaCatalogosGenerales.DatosEmpresaPrincipal.usuarioSql.ToString().Trim().Replace(" ", "|") & " " & LogicaCatalogosGenerales.DatosEmpresaPrincipal.contrasenaSql.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de empresa principal, indice 7 ;)".Replace(" ", "|") & " " & datosEmpresa.EId.ToString().Trim().Replace(" ", "|") & " " & datosEmpresa.ENombre.Trim().Replace(" ", "|") & " " & datosEmpresa.EDescripcion.Trim().Replace(" ", "|") & " " & datosEmpresa.EDomicilio.Trim().Replace(" ", "|") & " " & datosEmpresa.ELocalidad.Trim().Replace(" ", "|") & " " & datosEmpresa.ERfc.Trim().Replace(" ", "|") & " " & datosEmpresa.EDirectorio.Trim().Replace(" ", "|") & " " & datosEmpresa.ELogo.Trim().Replace(" ", "|") & " " & datosEmpresa.EActiva.ToString().Trim().Replace(" ", "|") & " " & datosEmpresa.EEquipo.Trim().Replace(" ", "|") & " " & "Aquí terminan los de empresa, indice 18 ;)".Replace(" ", "|") & " " & datosUsuario.EId.ToString().Trim().Replace(" ", "|") & " " & datosUsuario.ENombre.Trim().Replace(" ", "|") & " " & datosUsuario.EContrasena.Trim().Replace(" ", "|") & " " & datosUsuario.ENivel.ToString().Trim().Replace(" ", "|") & " " & datosUsuario.EAccesoTotal.ToString().Trim().Replace(" ", "|") & " " & datosUsuario.EIdArea.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de usuario, indice 25 ;)".Replace(" ", "|") & " " & datosArea.EId.ToString().Trim().Replace(" ", "|") & " " & datosArea.ENombre.ToString().Trim().Replace(" ", "|") & " " & datosArea.EClave.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de area, indice 29 ;)".Replace(" ", "|")
        Try
            Process.Start(ejecutarProgramaPrincipal)
            If salir Then
                Application.Exit()
            End If
        Catch ex As Exception
            MessageBox.Show((Convert.ToString("No se puede abrir el programa principal en la ruta : " & ejecutarProgramaPrincipal.WorkingDirectory & "\") & nombre) & Environment.NewLine & Environment.NewLine & ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

#Region "Todos"

    Private Sub LimpiarSpread()

        spCatalogos.ActiveSheet.ClearRange(0, 0, spCatalogos.ActiveSheet.Rows.Count, spCatalogos.ActiveSheet.Columns.Count, False)

    End Sub

    Private Sub FormatearSpread()

        ' Se cargan tipos de datos de spread.
        tipoEntero.DecimalPlaces = 0
        tipoTextoContrasena.PasswordChar = "*"
        ' Se cargan las opciones generales de cada spread.
        spCatalogos.Reset()
        spCatalogos2.Reset()
        ControlarSpreadEnter(spCatalogos)
        spCatalogos.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
        spCatalogos2.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Midnight 
        spCatalogos.Visible = False
        spCatalogos2.Visible = False 
        spCatalogos.ActiveSheet.GrayAreaBackColor = Color.White 
        spCatalogos.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Regular)
        spCatalogos2.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Regular) 
        spCatalogos.ActiveSheet.ColumnHeader.Rows(0).Height = 45
        spCatalogos2.ActiveSheet.ColumnHeader.Rows(0).Height = 45 
        spCatalogos.ActiveSheet.Rows(-1).Height = 25
        spCatalogos2.ActiveSheet.Rows(-1).Height = 25 
        spCatalogos.ActiveSheetIndex = 0
        spCatalogos2.ActiveSheetIndex = 0
        spCatalogos.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spCatalogos.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        Application.DoEvents()

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
        tipoHora.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.TimeOnly

    End Sub

    Private Sub SeleccionoActividadesFijas()

        Me.Cursor = Cursors.WaitCursor
        Me.opcionSeleccionada = Opciones.Fijas
        CargarActividadesFijas()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub CargarActividadesFijas()

        'LimpiarSpread()
        Dim datos As New DataTable 
        actividadesFijas.EIdArea = datosUsuario.EIdArea
        actividadesFijas.EIdUsuario = datosUsuario.EId
        datos = actividadesFijas.ObtenerListadoReporte()
        spCatalogos.ActiveSheet.DataSource = datos
        spCatalogos.ActiveSheet.Rows.Count += 1
        'RestaurarAlturaSpread()
        spCatalogos.Visible = True
        FormatearSpreadActividadesFijas()

    End Sub

    Private Sub GuardarEditarActividadesFijas()

        Me.Cursor = Cursors.WaitCursor
        actividadesFijas.EIdArea = Me.datosUsuario.EIdArea
        actividadesFijas.EIdUsuario = Me.datosUsuario.EId
        actividadesFijas.Eliminar()
        For filaActiva = 0 To spCatalogos.ActiveSheet.Rows.Count - 1 
            Dim id As Integer = LogicaCatalogosGenerales.Funciones.ValidarNumero(spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("id").Index).Value)
            Dim idUsuario As Integer = Me.datosUsuario.EId
            Dim idArea As Integer = Me.datosUsuario.EIdArea
            Dim nombre As String = spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("nombre").Index).Text
            Dim descripcion As String = spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("descripcion").Index).Text
            Dim idRangoFijoCreacion As Integer = LogicaCatalogosGenerales.Funciones.ValidarNumero(spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("idRangoFijoCreacion").Index).Value)
            Dim idRangoFijoVencimiento As Integer = LogicaCatalogosGenerales.Funciones.ValidarNumero(spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("idRangoFijoVencimiento").Index).Value)
            Dim esUrgente As Boolean = spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("esUrgente").Index).Value
            Dim esExterna As Boolean = spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("esExterna").Index).Value
            Dim idAreaDestino As Integer = LogicaCatalogosGenerales.Funciones.ValidarNumero(spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("idAreaDestino").Index).Value)
            Dim idUsuarioDestino As Integer = LogicaCatalogosGenerales.Funciones.ValidarNumero(spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("idUsuarioDestino").Index).Value)
            Dim solicitaAutorizacion As Boolean = spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("solicitaAutorizacion").Index).Value
            If (Not esExterna) Then ' Si es interna estos valores se guardarán por defecto así.
                idAreaDestino = 0 : idUsuarioDestino = 0 : solicitaAutorizacion = False
            End If
            Dim solicitaEvidencia As Boolean = spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("solicitaEvidencia").Index).Value
            If (esExterna And (idAreaDestino <= 0 Or idUsuarioDestino <= 0)) Then
                MsgBox("Falta definir area y/o usuario destino, no se guardará el no. " & id, MsgBoxStyle.Exclamation, "No permitido.")
                GoTo salta
            End If
            If ((id > 0) And (idRangoFijoCreacion <= 0 Or idRangoFijoVencimiento <= 0)) Then
                MsgBox("Falta definir rangos de creación y/o vencimientos, no se guardará el no. " & id, MsgBoxStyle.Exclamation, "No permitido.")
                GoTo salta
            End If
            If ((id > 0) And (String.IsNullOrEmpty(nombre))) Then
                MsgBox("Falta definir nombre de actividad, no se guardará el no. " & id, MsgBoxStyle.Exclamation, "No permitido.")
                GoTo salta
            End If
            If ((idAreaDestino = Me.datosUsuario.EIdArea) And (idUsuarioDestino = Me.datosUsuario.EId)) Then
                MsgBox("No está permitido guardar una actividad externa para ti mismo, tiene que ser para otro usuario.", MsgBoxStyle.Exclamation, "No permitido.")
                Exit Sub
            End If
            If ((id > 0) And (Not String.IsNullOrEmpty(nombre)) And (idRangoFijoCreacion > 0) And (idRangoFijoVencimiento > 0)) Then
                actividadesFijas.EId = id
                actividadesFijas.EIdArea = idArea
                actividadesFijas.EIdUsuario = idUsuario
                actividadesFijas.ENombre = nombre
                actividadesFijas.EDescripcion = descripcion
                actividadesFijas.EIdRangoFijoCreacion = idRangoFijoCreacion
                actividadesFijas.EIdRangoFijoVencimiento = idRangoFijoVencimiento
                actividadesFijas.EEsUrgente = esUrgente
                actividadesFijas.EEsExterna = esExterna
                actividadesFijas.EIdAreaDestino = idAreaDestino
                actividadesFijas.EIdUsuarioDestino = idUsuarioDestino
                actividadesFijas.ESolicitaAutorizacion = solicitaAutorizacion
                actividadesFijas.ESolicitaEvidencia = solicitaEvidencia
                actividadesFijas.Guardar()
            End If
salta:
        Next
        MsgBox("Guardado finalizado.", MsgBoxStyle.ApplicationModal, "Finalizado.")
        CargarActividadesFijas()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub EliminarActividadesFijas()

        If (MessageBox.Show("Confirmas que deseas eliminar todo?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            Me.Cursor = Cursors.WaitCursor 
            actividadesFijas.EIdArea = Me.datosUsuario.EIdArea
            actividadesFijas.EIdUsuario = Me.datosUsuario.EId
            actividadesFijas.Eliminar()
            CargarActividadesFijas()
            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub FormatearSpreadActividadesFijas()
         
        spCatalogos.ActiveSheet.Rows(-1).Height = 50
        spCatalogos.ActiveSheet.ColumnHeader.RowCount = 2
        spCatalogos.ActiveSheet.ColumnHeader.Rows(0, 1).Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        Dim numeracion As Integer = 0 
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "descripcion" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "idRangoFijoCreacion" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "nombreRangoFijoCreacion" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "idRangoFijoVencimiento" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "nombreRangoFijoVencimiento" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "esUrgente" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "esExterna" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "idAreaDestino" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "nombreAreaDestino" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "idUsuarioDestino" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "nombreUsuarioDestino" : numeracion += 1 
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "solicitaAutorizacion" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "solicitaEvidencia" : numeracion += 1
        spCatalogos.ActiveSheet.Columns("id").Width = 60
        spCatalogos.ActiveSheet.Columns("nombre").Width = 300
        spCatalogos.ActiveSheet.Columns("descripcion").Width = 500
        spCatalogos.ActiveSheet.Columns("idRangoFijoCreacion").Width = 50
        spCatalogos.ActiveSheet.Columns("nombreRangoFijoCreacion").Width = 120
        spCatalogos.ActiveSheet.Columns("idRangoFijoVencimiento").Width = 50
        spCatalogos.ActiveSheet.Columns("nombreRangoFijoVencimiento").Width = 120
        spCatalogos.ActiveSheet.Columns("esUrgente").Width = 110
        spCatalogos.ActiveSheet.Columns("esExterna").Width = 110
        spCatalogos.ActiveSheet.Columns("idAreaDestino").Width = 50
        spCatalogos.ActiveSheet.Columns("nombreAreaDestino").Width = 160
        spCatalogos.ActiveSheet.Columns("idUsuarioDestino").Width = 50
        spCatalogos.ActiveSheet.Columns("nombreUsuarioDestino").Width = 160
        spCatalogos.ActiveSheet.Columns("solicitaAutorizacion").Width = 155
        spCatalogos.ActiveSheet.Columns("solicitaEvidencia").Width = 155
        spCatalogos.ActiveSheet.Columns("esUrgente").CellType = tipoBooleano
        spCatalogos.ActiveSheet.Columns("solicitaAutorizacion").CellType = tipoBooleano
        spCatalogos.ActiveSheet.Columns("solicitaEvidencia").CellType = tipoBooleano
        spCatalogos.ActiveSheet.Columns("nombre").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Justify
        spCatalogos.ActiveSheet.Columns("descripcion").HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Justify
        spCatalogos.ActiveSheet.AddColumnHeaderSpanCell(0, spCatalogos.ActiveSheet.Columns("id").Index, 2, 1)
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("id").Index).Value = "No. *".ToUpper
        spCatalogos.ActiveSheet.AddColumnHeaderSpanCell(0, spCatalogos.ActiveSheet.Columns("nombre").Index, 2, 1)
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("nombre").Index).Value = "Nombre *".ToUpper
        spCatalogos.ActiveSheet.AddColumnHeaderSpanCell(0, spCatalogos.ActiveSheet.Columns("descripcion").Index, 2, 1)
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("descripcion").Index).Value = "Descripción".ToUpper
        spCatalogos.ActiveSheet.AddColumnHeaderSpanCell(0, spCatalogos.ActiveSheet.Columns("idRangoFijoCreacion").Index, 1, 2)
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("idRangoFijoCreacion").Index).Value = "Rango de Creación *".ToUpper
        spCatalogos.ActiveSheet.ColumnHeader.Cells(1, spCatalogos.ActiveSheet.Columns("idRangoFijoCreacion").Index).Value = "No.".ToUpper
        spCatalogos.ActiveSheet.ColumnHeader.Cells(1, spCatalogos.ActiveSheet.Columns("nombreRangoFijoCreacion").Index).Value = "Nombre".ToUpper
        spCatalogos.ActiveSheet.AddColumnHeaderSpanCell(0, spCatalogos.ActiveSheet.Columns("idRangoFijoVencimiento").Index, 1, 2)
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("idRangoFijoVencimiento").Index).Value = "Rango de Vencimiento *".ToUpper
        spCatalogos.ActiveSheet.ColumnHeader.Cells(1, spCatalogos.ActiveSheet.Columns("idRangoFijoVencimiento").Index).Value = "No.".ToUpper
        spCatalogos.ActiveSheet.ColumnHeader.Cells(1, spCatalogos.ActiveSheet.Columns("nombreRangoFijoVencimiento").Index).Value = "Nombre".ToUpper
        spCatalogos.ActiveSheet.AddColumnHeaderSpanCell(0, spCatalogos.ActiveSheet.Columns("esUrgente").Index, 2, 1)
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("esUrgente").Index).Value = "Es Urgente?".ToUpper
        spCatalogos.ActiveSheet.AddColumnHeaderSpanCell(0, spCatalogos.ActiveSheet.Columns("esExterna").Index, 2, 1)
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("esExterna").Index).Value = "Es Externa?".ToUpper
        spCatalogos.ActiveSheet.AddColumnHeaderSpanCell(0, spCatalogos.ActiveSheet.Columns("idAreaDestino").Index, 1, 2)
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("idAreaDestino").Index).Value = "Area Destino".ToUpper
        spCatalogos.ActiveSheet.ColumnHeader.Cells(1, spCatalogos.ActiveSheet.Columns("idAreaDestino").Index).Value = "No.".ToUpper
        spCatalogos.ActiveSheet.ColumnHeader.Cells(1, spCatalogos.ActiveSheet.Columns("nombreAreaDestino").Index).Value = "Nombre".ToUpper
        spCatalogos.ActiveSheet.AddColumnHeaderSpanCell(0, spCatalogos.ActiveSheet.Columns("idUsuarioDestino").Index, 1, 2)
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("idUsuarioDestino").Index).Value = "Usuario Destino".ToUpper
        spCatalogos.ActiveSheet.ColumnHeader.Cells(1, spCatalogos.ActiveSheet.Columns("idUsuarioDestino").Index).Value = "No.".ToUpper
        spCatalogos.ActiveSheet.ColumnHeader.Cells(1, spCatalogos.ActiveSheet.Columns("nombreUsuarioDestino").Index).Value = "Nombre".ToUpper 
        spCatalogos.ActiveSheet.AddColumnHeaderSpanCell(0, spCatalogos.ActiveSheet.Columns("solicitaAutorizacion").Index, 2, 1)
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("solicitaAutorizacion").Index).Value = "Solicita Autorización?".ToUpper
        spCatalogos.ActiveSheet.AddColumnHeaderSpanCell(0, spCatalogos.ActiveSheet.Columns("solicitaEvidencia").Index, 2, 1)
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("solicitaEvidencia").Index).Value = "Solicita Evidencia?".ToUpper       
        spCatalogos.ActiveSheet.ColumnHeader.Rows(0).Height = 45
        Application.DoEvents()

    End Sub

    Private Sub ControlarSpreadEnter()

        Dim columnaActiva As Integer = spCatalogos.ActiveSheet.ActiveColumnIndex
        If (columnaActiva = spCatalogos.ActiveSheet.Columns.Count - 1) Then
            spCatalogos.ActiveSheet.Rows.Count += 1
        End If
        Dim fila As Integer = spCatalogos.ActiveSheet.ActiveRowIndex
        If (Me.opcionSeleccionada = Opciones.Fijas) Then
            If (spCatalogos.ActiveSheet.ActiveColumnIndex = spCatalogos.ActiveSheet.Columns("idRangoFijoCreacion").Index) Then
                Dim idRangoCreacion As Integer = LogicaCatalogosGenerales.Funciones.ValidarNumero(spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("idRangoFijoCreacion").Index).Text.ToString())
                If (idRangoCreacion > 0) Then
                    rangosFijos.EId = idRangoCreacion
                    Dim lista As New List(Of EntidadesCatalogosGenerales.RangosFijos)
                    lista = rangosFijos.ObtenerListadoPorId()
                    If (lista.Count > 0) Then
                        spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("nombreRangoFijoCreacion").Index).Value = lista(0).ENombre
                    Else
                        spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("idRangoFijoCreacion").Index).Value = String.Empty
                        spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("nombreRangoFijoCreacion").Index).Value = String.Empty
                        spCatalogos.ActiveSheet.SetActiveCell(fila, spCatalogos.ActiveSheet.Columns("idRangoFijoCreacion").Index - 1)
                    End If
                End If
            ElseIf (spCatalogos.ActiveSheet.ActiveColumnIndex = spCatalogos.ActiveSheet.Columns("idRangoFijoVencimiento").Index) Then
                Dim idRangoVencimiento As Integer = LogicaCatalogosGenerales.Funciones.ValidarNumero(spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("idRangoFijoVencimiento").Index).Text.ToString())
                If (idRangoVencimiento > 0) Then
                    rangosFijos.EId = idRangoVencimiento
                    Dim lista As New List(Of EntidadesCatalogosGenerales.RangosFijos)
                    lista = rangosFijos.ObtenerListadoPorId()
                    If (lista.Count > 0) Then
                        spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("nombreRangoFijoVencimiento").Index).Value = lista(0).ENombre
                    Else
                        spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("idRangoFijoVencimiento").Index).Value = String.Empty
                        spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("nombreRangoFijoVencimiento").Index).Value = String.Empty
                        spCatalogos.ActiveSheet.SetActiveCell(fila, spCatalogos.ActiveSheet.Columns("idRangoFijoVencimiento").Index - 1)
                    End If
                End If
            ElseIf (spCatalogos.ActiveSheet.Cells(spCatalogos.ActiveSheet.ActiveRowIndex, spCatalogos.ActiveSheet.Columns("esExterna").Index).Value) Then 
                If (spCatalogos.ActiveSheet.ActiveColumnIndex = spCatalogos.ActiveSheet.Columns("idAreaDestino").Index) Then
                    Dim idAreaDestino As Integer = LogicaCatalogosGenerales.Funciones.ValidarNumero(spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("idAreaDestino").Index).Text.ToString())
                    If (idAreaDestino > 0) Then
                        areas.EId = idAreaDestino
                        Dim lista As New List(Of EntidadesCatalogosGenerales.Areas)
                        lista = areas.ObtenerListadoPorId()
                        If (lista.Count > 0) Then
                            spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("nombreAreaDestino").Index).Value = lista(0).ENombre
                        Else
                            spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("idAreaDestino").Index).Value = String.Empty
                            spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("nombreAreaDestino").Index).Value = String.Empty
                            spCatalogos.ActiveSheet.SetActiveCell(fila, spCatalogos.ActiveSheet.Columns("idAreaDestino").Index - 1)
                        End If
                    End If
                ElseIf (columnaActiva = spCatalogos.ActiveSheet.Columns("idUsuarioDestino").Index) Then
                    usuarios.EIdEmpresa = datosEmpresa.EId
                    Dim idArea As Integer = LogicaCatalogosGenerales.Funciones.ValidarNumero(spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("idAreaDestino").Index).Text.ToString())
                    usuarios.EIdArea = idArea
                    Dim idUsuario As Integer = LogicaCatalogosGenerales.Funciones.ValidarNumero(spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("idUsuarioDestino").Index).Text)
                    usuarios.EId = idUsuario
                    If (idUsuario > 0 And idUsuario <> Me.datosUsuario.EId) Then
                        Dim lista As New List(Of EntidadesCatalogosGenerales.Usuarios)
                        lista = usuarios.ObtenerListadoPorId()
                        If (lista.Count > 0) Then
                            spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("nombreUsuarioDestino").Index).Value = lista(0).ENombre
                        Else
                            spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("idUsuarioDestino").Index).Value = String.Empty
                            spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("nombreUsuarioDestino").Index).Value = String.Empty
                            spCatalogos.ActiveSheet.SetActiveCell(fila, spCatalogos.ActiveSheet.Columns("idUsuarioDestino").Index - 1)
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub FormatearSpreadCatalogoUsuarios()

        spCatalogos2.ActiveSheet.ColumnHeader.Rows(0).Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        spCatalogos2.Width = 300
        If (Me.opcionSeleccionada = Opciones.Fijas) Then
            spCatalogos2.Location = New Point(spCatalogos.Location.X, spCatalogos.Location.Y)
            'Else
            '    spCatalogos2.Location = New Point(spCatalogos.Width - spCatalogos2.Width, spCatalogos.Location.Y)
        End If
        spCatalogos2.Visible = True
        spCatalogos2.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        spCatalogos2.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spCatalogos2.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect
        spCatalogos2.Height = spCatalogos.Height
        Dim numeracion As Integer = 0
        spCatalogos2.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spCatalogos2.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spCatalogos2.ActiveSheet.Columns("id").Width = 50
        spCatalogos2.ActiveSheet.Columns("nombre").Width = 210
        spCatalogos2.ActiveSheet.ColumnHeader.Cells(0, spCatalogos2.ActiveSheet.Columns("id").Index).Value = "No.".ToUpper
        spCatalogos2.ActiveSheet.ColumnHeader.Cells(0, spCatalogos2.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper
        spCatalogos2.ActiveSheet.ColumnHeader.Rows(0).Height = 35
        Application.DoEvents()

    End Sub

    Private Sub CargarCatalogoUsuarios()

        usuarios.EIdEmpresa = Me.datosEmpresa.EId
        usuarios.EIdArea = LogicaCatalogosGenerales.Funciones.ValidarNumero(spCatalogos.ActiveSheet.Cells(spCatalogos.ActiveSheet.ActiveRowIndex, spCatalogos.ActiveSheet.Columns("idAreaDestino").Index).Value)
        usuarios.EId = Me.datosUsuario.EId
        spCatalogos2.ActiveSheet.DataSource = usuarios.ObtenerListadoReporte()
        spCatalogos2.Focus()
        FormatearSpreadCatalogoUsuarios()

    End Sub

    Private Sub FormatearSpreadCatalogoAreas()

        spCatalogos2.Height = spCatalogos.Height
        spCatalogos2.Width = 310
        spCatalogos2.ActiveSheet.ColumnHeader.Rows(0).Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        If (Me.opcionSeleccionada = Opciones.Fijas) Then
            spCatalogos2.Location = New Point(spCatalogos.Location.X, spCatalogos.Location.Y)
            'ElseIf (Me.opcionSeleccionada = Opciones.Horarios) Then
            '    spCatalogos2.Location = New Point(spCatalogos.Width - spCatalogos2.Width, spCatalogos.Location.Y)
        End If
        spCatalogos2.Visible = True
        spCatalogos2.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        spCatalogos2.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spCatalogos2.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect
        Dim numeracion As Integer = 0
        spCatalogos2.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spCatalogos2.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spCatalogos2.ActiveSheet.Columns(numeracion).Tag = "clave" : numeracion += 1
        spCatalogos2.ActiveSheet.Columns("id").Width = 50
        spCatalogos2.ActiveSheet.Columns("nombre").Width = 220
        spCatalogos2.ActiveSheet.Columns("id").CellType = tipoEntero
        spCatalogos2.ActiveSheet.Columns("nombre").CellType = tipoTexto
        spCatalogos2.ActiveSheet.ColumnHeader.Cells(0, spCatalogos2.ActiveSheet.Columns("id").Index).Value = "No.".ToUpper()
        spCatalogos2.ActiveSheet.ColumnHeader.Cells(0, spCatalogos2.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper()
        spCatalogos2.ActiveSheet.ColumnHeader.Rows(0).Height = 35
        spCatalogos2.ActiveSheet.Columns("clave").Visible = False
        Application.DoEvents()

    End Sub

    Private Sub CargarCatalogoAreas()

        spCatalogos2.DataSource = areas.ObtenerListado()
        FormatearSpreadCatalogoAreas()

    End Sub
     
    Private Sub FormatearSpreadCatalogoRangosFijos()

        spCatalogos2.ActiveSheet.ColumnHeader.Rows(0).Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        spCatalogos2.Width = 300
        If (Me.opcionSeleccionada = Opciones.Fijas) Then
            spCatalogos2.Location = New Point(spCatalogos.Location.X, spCatalogos.Location.Y)
            'Else
            '    spCatalogos2.Location = New Point(spCatalogos.Width - spCatalogos2.Width, spCatalogos.Location.Y)
        End If
        spCatalogos2.Visible = True
        spCatalogos2.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never
        spCatalogos2.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded
        spCatalogos2.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect
        spCatalogos2.Height = spCatalogos.Height
        Dim numeracion As Integer = 0
        spCatalogos2.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spCatalogos2.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spCatalogos2.ActiveSheet.Columns("id").Width = 50
        spCatalogos2.ActiveSheet.Columns("nombre").Width = 210
        spCatalogos2.ActiveSheet.ColumnHeader.Cells(0, spCatalogos2.ActiveSheet.Columns("id").Index).Value = "No.".ToUpper
        spCatalogos2.ActiveSheet.ColumnHeader.Cells(0, spCatalogos2.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper
        spCatalogos2.ActiveSheet.ColumnHeader.Rows(0).Height = 35
        Application.DoEvents()

    End Sub

    Private Sub CargarCatalogoRangosFijos()
          
        spCatalogos2.ActiveSheet.DataSource = rangosFijos.ObtenerListadoReporte()
        spCatalogos2.Focus()
        FormatearSpreadCatalogoRangosFijos()

    End Sub

    Private Sub VolverFocoCatalogos()

        pnlMenu.Enabled = True
        spCatalogos.Enabled = True
        spCatalogos.Focus()
        If (Me.opcionSeleccionada = Opciones.Fijas) Then
            spCatalogos.ActiveSheet.SetActiveCell(spCatalogos.ActiveSheet.ActiveRowIndex, spCatalogos.ActiveSheet.ActiveColumnIndex)
        End If
        spCatalogos2.Visible = False

    End Sub

    Private Sub RestaurarAlturaSpread()
         
        spCatalogos.Height = pnlCuerpo.Height - pnlMenu.Height : Application.DoEvents()

    End Sub

#End Region

#End Region

#Region "Enumeraciones"

    Public Enum Opciones

        Fijas = 1

    End Enum

#End Region

    Private Sub spCatalogos_CellClick(sender As Object, e As FarPoint.Win.Spread.CellClickEventArgs) Handles spCatalogos.CellClick

        'Dim columnaActiva As Integer = spCatalogos.ActiveSheet.ActiveColumnIndex
        'Dim filaActiva As Integer = e.Row
        'If (Me.opcionSeleccionada = Opciones.Fijas) Then
        '    If (columnaActiva = spCatalogos.ActiveSheet.Columns("esExterna").Index) Then
        '        Dim esExterna As Boolean = spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("esExterna").Index).Value
        '        If (esExterna) Then
        '            spCatalogos.ActiveSheet.Columns(spCatalogos.ActiveSheet.Columns("idAreaDestino").Index, spCatalogos.ActiveSheet.Columns("nombreUsuarioDestino").Index).Visible = True
        '        Else
        '            spCatalogos.ActiveSheet.Columns(spCatalogos.ActiveSheet.Columns("idAreaDestino").Index, spCatalogos.ActiveSheet.Columns("nombreUsuarioDestino").Index).Visible = False
        '        End If
        '    End If
        'End If

    End Sub

End Class