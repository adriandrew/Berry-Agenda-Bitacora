Imports System.IO
Imports System.ComponentModel

Public Class Principal

    Dim usuarios As New EntidadesCatalogos.Usuarios
    Dim areas As New EntidadesCatalogos.Areas
    Dim correos As New EntidadesCatalogos.Correos
    Dim correosUsuarios As New EntidadesCatalogos.CorreosUsuarios 
    Dim usuariosAreas As New EntidadesCatalogos.UsuariosAreas()
    Dim programas As New EntidadesCatalogos.Programas()
    Dim bloqueoUsuarios As New EntidadesCatalogos.BloqueoUsuarios()
    Public datosEmpresa As New LogicaCatalogos.DatosEmpresa()
    Public datosUsuario As New LogicaCatalogos.DatosUsuario()
    Public datosArea As New LogicaCatalogos.DatosArea()
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
    Public idEmpresa As Integer = 1 ' Fijo a PODC por ahora.

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
        FormatearSpread()
        SeleccionoAreas()
        CargarTiposDeDatos()

    End Sub

    Private Sub Principal_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        If (Not ValidarAccesoTotal()) Then
            Salir()
        End If

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Salir()

    End Sub

    Private Sub miAreas_Click(sender As Object, e As EventArgs) Handles miAreas.Click

        SeleccionoAreas()

    End Sub

    Private Sub miUsuarios_Click(sender As Object, e As EventArgs) Handles miUsuarios.Click

        SeleccionoUsuarios()

    End Sub

    Private Sub miCorreos_Click(sender As Object, e As EventArgs) Handles miCorreos.Click

        SeleccionoCorreos()

    End Sub

    Private Sub spCatalogos_DialogKey(sender As Object, e As FarPoint.Win.Spread.DialogKeyEventArgs) Handles spCatalogos.DialogKey

        If (e.KeyData = Keys.Enter) Then
            ControlarSpreadEnter()
        End If

    End Sub

    Private Sub spCatalogos_KeyDown(sender As Object, e As KeyEventArgs) Handles spCatalogos.KeyDown

        If e.KeyData = Keys.F5 Then ' Abrir catalogos.
            If (Me.opcionSeleccionada = Opciones.Correos) Then
                If (spCatalogos.ActiveSheet.ActiveColumnIndex = spCatalogos.ActiveSheet.Columns("idUsuario").Index) Or (spCatalogos.ActiveSheet.ActiveColumnIndex = spCatalogos.ActiveSheet.Columns("nombreUsuario").Index) Then
                    spCatalogos.Enabled = False
                    CargarCatalogoUsuarios()
                    FormatearSpreadCatalogoUsuarios(False)
                    spCatalogos2.Focus()
                End If
            ElseIf (Me.opcionSeleccionada = Opciones.Usuarios) Then
                If (spCatalogos.ActiveSheet.ActiveColumnIndex = spCatalogos.ActiveSheet.Columns("idArea").Index) Or (spCatalogos.ActiveSheet.ActiveColumnIndex = spCatalogos.ActiveSheet.Columns("nombreArea").Index) Then
                    spCatalogos.Enabled = False
                    CargarCatalogoAreas()
                    FormatearSpreadCatalogoAreas()
                    spCatalogos.Focus()
                End If
            End If
        ElseIf e.KeyData = Keys.F6 Then ' Eliminar un registro.
            If (MessageBox.Show("Confirmas que deseas eliminar el registro seleccionado?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                Dim fila As Integer = spCatalogos.ActiveSheet.ActiveRowIndex
                Dim id As Integer = 0
                If (Me.opcionSeleccionada = Opciones.Areas) Then
                    id = spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("id").Index).Text
                    areas.EId = id
                    Dim tieneDatos As Boolean = areas.ValidarActividadPorId()
                    If (tieneDatos) Then
                        MsgBox("No se puede eliminar este registro, ya que contiene actividades capturadas.", MsgBoxStyle.Exclamation, "No permitido.")
                    Else
                        spCatalogos.ActiveSheet.Rows.Remove(fila, 1)
                    End If
                ElseIf (Me.opcionSeleccionada = Opciones.Usuarios) Then
                    Dim idUsuario As Integer = LogicaCatalogos.Funciones.ValidarNumero(spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("id").Index).Text)
                    usuarios.EId = idUsuario
                    Dim tieneDatos As Boolean = usuarios.ValidarActividadPorId()
                    If (tieneDatos) Then
                        MessageBox.Show("No se puede eliminar este registro, ya que contiene actividades capturadas.", "No permitido.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        spCatalogos.ActiveSheet.Rows.Remove(fila, 1)
                    End If
                ElseIf (Me.opcionSeleccionada = Opciones.Correos) Then
                    spCatalogos.ActiveSheet.Rows.Remove(fila, 1)
                End If
            End If
        ElseIf (e.KeyData = Keys.Enter) Then ' Validar registros.
            ControlarSpreadEnter()
        End If

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If (Me.opcionSeleccionada = Opciones.Areas) Then
            GuardarEditarAreas()
        ElseIf (Me.opcionSeleccionada = Opciones.Usuarios) Then
            GuardarEditarUsuarios()
        ElseIf (Me.opcionSeleccionada = Opciones.Correos) Then
            GuardarEditarCorreos()
        End If

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        If (Me.opcionSeleccionada = Opciones.Areas) Then
            EliminarAreas()
        ElseIf (Me.opcionSeleccionada = Opciones.Usuarios) Then
            EliminarUsuarios()
        ElseIf (Me.opcionSeleccionada = Opciones.Correos) Then
            EliminarCorreos()
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
        If (Me.opcionSeleccionada = Opciones.Correos) Then
            spCatalogos.ActiveSheet.Cells(spCatalogos.ActiveSheet.ActiveRowIndex, spCatalogos.ActiveSheet.Columns("idUsuario").Index).Text = spCatalogos2.ActiveSheet.Cells(fila, spCatalogos2.ActiveSheet.Columns("id").Index).Text
            spCatalogos.ActiveSheet.Cells(spCatalogos.ActiveSheet.ActiveRowIndex, spCatalogos.ActiveSheet.Columns("nombreUsuario").Index).Text = spCatalogos2.ActiveSheet.Cells(fila, spCatalogos2.ActiveSheet.Columns("nombre").Index).Text
        ElseIf (Me.opcionSeleccionada = Opciones.Usuarios) Then
            spCatalogos.ActiveSheet.Cells(spCatalogos.ActiveSheet.ActiveRowIndex, spCatalogos.ActiveSheet.Columns("idArea").Index).Text = spCatalogos2.ActiveSheet.Cells(fila, spCatalogos2.ActiveSheet.Columns("id").Index).Text
            spCatalogos.ActiveSheet.Cells(spCatalogos.ActiveSheet.ActiveRowIndex, spCatalogos.ActiveSheet.Columns("nombreArea").Index).Text = spCatalogos2.ActiveSheet.Cells(fila, spCatalogos2.ActiveSheet.Columns("nombre").Index).Text
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

    Private Sub spProgramas_CellClick(sender As Object, e As FarPoint.Win.Spread.CellClickEventArgs) Handles spProgramas.CellClick

        Dim fila As Integer = e.Row
        spProgramas.ActiveSheet.ActiveRowIndex = fila
        Application.DoEvents()
        Dim valorCelda As Boolean = Convert.ToBoolean(spProgramas.ActiveSheet.Cells(fila, spProgramas.ActiveSheet.Columns("estatus").Index).Value)
        valorCelda = (If((valorCelda = True), False, True))
        If (valorCelda) Then
            ' Guarda.
            GuardarBloqueoUsuarios()
        ElseIf Not valorCelda Then
            ' Elimina.
            EliminarBloqueoUsuarios()
        End If
        CargarProgramas()
        'FormatearSpreadProgramas()

    End Sub

    Private Sub spCatalogos_CellDoubleClick(sender As Object, e As FarPoint.Win.Spread.CellClickEventArgs) Handles spCatalogos.CellDoubleClick

        If (Me.opcionSeleccionada = Opciones.Usuarios) Then
            Dim fila As Integer = e.Row
            spCatalogos.ActiveSheet.ActiveRowIndex = fila
            Dim nivel As Integer = Convert.ToInt32(spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("nivel").Index).Value)
            If (nivel = 0) Then ' Ninguno. Todos los privilegios.
                spProgramas.Visible = False : Application.DoEvents()
            ElseIf (nivel = 1) Then ' Nivel de bloqueo de los modulos. TODO. Pendiente.
            ElseIf (nivel = 2) Then ' Nivel de bloqueo de los programas.
                spProgramas.Visible = True : Application.DoEvents()
                spCatalogos.Height = ((pnlCuerpo.Height - msMenu.Height) / 2) : Application.DoEvents()
                spProgramas.Top = spCatalogos.Height + msMenu.Height + 10 : Application.DoEvents()
                spProgramas.Height = spCatalogos.Height - 10 : Application.DoEvents()
                spProgramas.Width = spCatalogos.Width : Application.DoEvents()
                btnGuardar.BringToFront() : Application.DoEvents()
                btnEliminar.BringToFront() : Application.DoEvents()
                CargarProgramas()
            ElseIf (nivel = 3) Then ' Nivel de bloqueo de los subprogramas. TODO. Pendiente.
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
            txtAyuda.Text = "Sección de Ayuda: " & vbNewLine & vbNewLine & "* Teclas básicas: " & vbNewLine & "F5 sirve para mostrar catálogos. " & vbNewLine & "F6 sirve para eliminar un registro únicamente. " & vbNewLine & "Escape sirve para ocultar catálogos que se encuentren desplegados. " & vbNewLine & vbNewLine & "* Catálogos desplegados: " & vbNewLine & "Cuando se muestra algún catálogo, al seleccionar alguna opción de este, se va mostrando en tiempo real en la captura de donde se originó. Cuando se le da doble clic en alguna opción o a la tecla escape se oculta dicho catálogo. " & vbNewLine & vbNewLine & "* Areas: " & vbNewLine & "En esta pestaña se capturarán todas las areas necesarias. " & vbNewLine & "Existen los botones de guardar/editar y eliminar todo dependiendo lo que se necesite hacer. " & vbNewLine & vbNewLine & "* Usuarios: " & vbNewLine & "En esta parte se capturarán todos los usuarios. " & vbNewLine & "Descripción de los datos que pide: " & vbNewLine & "- Contraseña: esta permite letras y/o números sin ningun problema, no existen restricciones de ningún tipo." & vbNewLine & "- Nivel: 0 es para acceso a todos los programas, excepto los de gerencia. 1 es para los módulos, en este caso como es uno solo, no aplica. 2 es para los programas, si se le da doble clic aparecerán los programas para seleccionar cuales se permitirán y cuales no. 3 es para subprogramas, no aplica en este caso. " & vbNewLine & "- Acceso Total: es solamente para usuarios de gerencia. " & vbNewLine & "Existen los botones de guardar/editar y eliminar todo dependiendo lo que se necesite hacer. " & vbNewLine & vbNewLine & "* Correos: " & vbNewLine & "En este apartado se capturarán todos los usuarios con sus respectivos correos para enviarles sus notificaciones de actividades pendientes que se encuentran retrasadas en tiempos. " & vbNewLine & "Existen los botones de guardar/editar y eliminar todo dependiendo lo que se necesite hacer. " : Application.DoEvents()
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

    Private Function ValidarAccesoTotal() As Boolean

        If ((Not datosUsuario.EAccesoTotal) Or (datosUsuario.EAccesoTotal = 0) Or (datosUsuario.EAccesoTotal = False)) Then
            MsgBox("No tienes permisos suficientes para acceder a este programa.", MsgBoxStyle.Information, "Permisos insuficientes.")
            Return False
        Else
            Return True
        End If

    End Function

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

        If (Me.esPrueba) Then
            'EntidadesCatalogos.BaseDatos.ECadenaConexionCatalogo = "C:\\Berry-Agenda\\BD\\PODC\\Catalogos.mdf"
            LogicaCatalogos.DatosEmpresaPrincipal.instanciaSql = "ANDREW-MAC\SQLEXPRESS"
            LogicaCatalogos.DatosEmpresaPrincipal.usuarioSql = "AdminBerry"
            LogicaCatalogos.DatosEmpresaPrincipal.contrasenaSql = "@berry"
            datosUsuario.EAccesoTotal = True
            datosEmpresa.EId = 1
        Else
            'EntidadesCatalogos.BaseDatos.ECadenaConexionCatalogo = datosEmpresa.EDirectorio & "\\Catalogos.mdf" 
            LogicaCatalogos.DatosEmpresaPrincipal.ObtenerParametrosInformacionEmpresa()
            Me.datosEmpresa.ObtenerParametrosInformacionEmpresa()
            Me.datosUsuario.ObtenerParametrosInformacionUsuario()
            Me.datosArea.ObtenerParametrosInformacionArea()
        End If
        EntidadesCatalogos.BaseDatos.ECadenaConexionCatalogo = "Catalogos"
        EntidadesCatalogos.BaseDatos.ECadenaConexionInformacion = "Informacion"
        EntidadesCatalogos.BaseDatos.ECadenaConexionAgenda = "Agenda"
        EntidadesCatalogos.BaseDatos.AbrirConexionCatalogo()
        EntidadesCatalogos.BaseDatos.AbrirConexionInformacion()
        EntidadesCatalogos.BaseDatos.AbrirConexionAgenda()

    End Sub

    Private Sub CargarEncabezados()

        lblEncabezadoPrograma.Text = "Programa: " + Me.Text
        lblEncabezadoEmpresa.Text = "Empresa: " + datosEmpresa.ENombre
        lblEncabezadoUsuario.Text = "Usuario: " + datosUsuario.ENombre
        lblEncabezadoArea.Text = "Area: " + datosArea.ENombre

    End Sub

    Private Sub AbrirPrograma(nombre As String, salir As Boolean)

        If (Me.esPrueba) Then
            Exit Sub
        End If
        ejecutarProgramaPrincipal.UseShellExecute = True
        ejecutarProgramaPrincipal.FileName = nombre & Convert.ToString(".exe")
        ejecutarProgramaPrincipal.WorkingDirectory = Directory.GetCurrentDirectory()
        ejecutarProgramaPrincipal.Arguments = LogicaCatalogos.DatosEmpresaPrincipal.idEmpresa.ToString().Trim().Replace(" ", "|") & " " & LogicaCatalogos.DatosEmpresaPrincipal.activa.ToString().Trim().Replace(" ", "|") & " " & LogicaCatalogos.DatosEmpresaPrincipal.instanciaSql.ToString().Trim().Replace(" ", "|") & " " & LogicaCatalogos.DatosEmpresaPrincipal.rutaBd.ToString().Trim().Replace(" ", "|") & " " & LogicaCatalogos.DatosEmpresaPrincipal.usuarioSql.ToString().Trim().Replace(" ", "|") & " " & LogicaCatalogos.DatosEmpresaPrincipal.contrasenaSql.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de empresa principal, indice 7 ;)".Replace(" ", "|") & " " & datosEmpresa.EId.ToString().Trim().Replace(" ", "|") & " " & datosEmpresa.ENombre.Trim().Replace(" ", "|") & " " & datosEmpresa.EDescripcion.Trim().Replace(" ", "|") & " " & datosEmpresa.EDomicilio.Trim().Replace(" ", "|") & " " & datosEmpresa.ELocalidad.Trim().Replace(" ", "|") & " " & datosEmpresa.ERfc.Trim().Replace(" ", "|") & " " & datosEmpresa.EDirectorio.Trim().Replace(" ", "|") & " " & datosEmpresa.ELogo.Trim().Replace(" ", "|") & " " & datosEmpresa.EActiva.ToString().Trim().Replace(" ", "|") & " " & datosEmpresa.EEquipo.Trim().Replace(" ", "|") & " " & "Aquí terminan los de empresa, indice 18 ;)".Replace(" ", "|") & " " & datosUsuario.EId.ToString().Trim().Replace(" ", "|") & " " & datosUsuario.ENombre.Trim().Replace(" ", "|") & " " & datosUsuario.EContrasena.Trim().Replace(" ", "|") & " " & datosUsuario.ENivel.ToString().Trim().Replace(" ", "|") & " " & datosUsuario.EAccesoTotal.ToString().Trim().Replace(" ", "|") & " " & datosUsuario.EIdArea.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de usuario, indice 25 ;)".Replace(" ", "|") & " " & datosArea.EId.ToString().Trim().Replace(" ", "|") & " " & datosArea.ENombre.ToString().Trim().Replace(" ", "|") & " " & datosArea.EClave.ToString().Trim().Replace(" ", "|") & " " & "Aquí terminan los de area, indice 29 ;)".Replace(" ", "|")
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

        spCatalogos.ActiveSheet.ClearRange(0, 0, spCatalogos.ActiveSheet.Rows.Count - 1, spCatalogos.ActiveSheet.Columns.Count - 1, False)

    End Sub

    Private Sub FormatearSpread()

        ' Se cargan tipos de datos de spread.
        tipoEntero.DecimalPlaces = 0
        tipoTextoContrasena.PasswordChar = "*"
        ' Se cargan las opciones generales de cada spread.
        spCatalogos.Reset() : Application.DoEvents()
        spCatalogos2.Reset() : Application.DoEvents()
        ControlarSpreadEnter(spCatalogos)
        spCatalogos.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell : Application.DoEvents()
        spCatalogos2.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Midnight : Application.DoEvents()
        spProgramas.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell : Application.DoEvents()
        spCatalogos.Visible = True : Application.DoEvents()
        spCatalogos2.Visible = False : Application.DoEvents()
        spProgramas.Visible = False : Application.DoEvents()
        spCatalogos.ActiveSheet.GrayAreaBackColor = Color.White : Application.DoEvents() 
        spProgramas.ActiveSheet.GrayAreaBackColor = Color.White : Application.DoEvents()
        spCatalogos.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Regular) : Application.DoEvents()
        spCatalogos2.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Regular) : Application.DoEvents()
        spProgramas.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Regular) : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Rows(0).Height = 45 : Application.DoEvents()
        spCatalogos2.ActiveSheet.ColumnHeader.Rows(0).Height = 45 : Application.DoEvents()
        spProgramas.ActiveSheet.ColumnHeader.Rows(0).Height = 45 : Application.DoEvents()
        spCatalogos.ActiveSheet.Rows(-1).Height = 25 : Application.DoEvents()
        spCatalogos2.ActiveSheet.Rows(-1).Height = 25 : Application.DoEvents()
        spProgramas.ActiveSheet.Rows(-1).Height = 25 : Application.DoEvents()
        spCatalogos.ActiveSheetIndex = 0 : Application.DoEvents()
        spCatalogos2.ActiveSheetIndex = 0 : Application.DoEvents()
        spProgramas.ActiveSheetIndex = 0 : Application.DoEvents()

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

    Private Sub SeleccionoAreas()

        Me.Cursor = Cursors.WaitCursor
        miAreas.BackColor = Color.LightSeaGreen
        miUsuarios.BackColor = msMenu.BackColor
        miCorreos.BackColor = msMenu.BackColor
        Me.opcionSeleccionada = Opciones.Areas
        CargarAreas()
        'FormatearSpreadAreas()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ComenzarCargarAreas()

        FormatearSpread()
        CargarAreas()
        'FormatearSpreadAreas()

    End Sub

    Private Sub CargarAreas()

        LimpiarSpread()
        Dim lista As New List(Of EntidadesCatalogos.Areas)
        lista = areas.ObtenerListado()
        spCatalogos.ActiveSheet.DataSource = lista
        spCatalogos.ActiveSheet.Rows.Count += 1
        RestaurarAlturaSpread()
        FormatearSpreadAreas()

    End Sub

    Private Sub GuardarEditarAreas()

        Me.Cursor = Cursors.WaitCursor
        areas.EliminarTodo()
        For filaActiva = 0 To spCatalogos.ActiveSheet.Rows.Count - 1
            Dim id As Integer = spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("id").Index).Value
            Dim nombre As String = spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("nombre").Index).Value
            Dim clave As String = LogicaCatalogos.ValidarLetra(spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("clave").Index).Value)
            If (Not String.IsNullOrEmpty(id)) And (Not String.IsNullOrEmpty(nombre)) Then
                areas.EId = id
                areas.ENombre = nombre
                areas.EClave = clave
                Dim tieneDatos As Boolean = areas.ValidarPorId()
                If (tieneDatos) Then
                    areas.Editar()
                Else
                    areas.Guardar()
                End If
            End If
        Next
        MsgBox("Guardado correcto.", MsgBoxStyle.ApplicationModal, "Correcto.")
        CargarAreas()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub EliminarAreas()

        If (MessageBox.Show("Confirmas que deseas eliminar todo?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            Me.Cursor = Cursors.WaitCursor
            'areas.EliminarTodo()
            For filaActiva = 0 To spCatalogos.ActiveSheet.Rows.Count - 1
                Dim id As Integer = spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("id").Index).Value
                If (id > 0) Then
                    areas.EId = id
                    Dim tieneAreas As Boolean = areas.ValidarActividadPorId()
                    If (Not tieneAreas) Then
                        areas.Eliminar()
                    End If
                End If
            Next
            CargarAreas()
            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub FormatearSpreadAreas()

        spCatalogos.ActiveSheet.Columns(0, spCatalogos.ActiveSheet.Columns.Count - 1).Visible = True : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Rows(0).Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold) : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Rows(0).Height = 35 : Application.DoEvents()
        spCatalogos.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded : Application.DoEvents()
        spCatalogos.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded : Application.DoEvents()
        Dim numeracion As Integer = 0
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "clave" : numeracion += 1
        spCatalogos.ActiveSheet.Columns("id").Width = 100 : Application.DoEvents()
        spCatalogos.ActiveSheet.Columns("nombre").Width = 250 : Application.DoEvents()
        spCatalogos.ActiveSheet.Columns("clave").Width = 150 : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("id").Index).Value = "No.".ToUpper : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("clave").Index).Value = "Clave".ToUpper : Application.DoEvents()

    End Sub

    Private Sub SeleccionoCorreos()

        Me.Cursor = Cursors.WaitCursor
        miCorreos.BackColor = Color.LightSeaGreen
        miAreas.BackColor = msMenu.BackColor
        miUsuarios.BackColor = msMenu.BackColor
        Me.opcionSeleccionada = Opciones.Correos
        CargarCorreos()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub CargarCorreos()

        LimpiarSpread()
        'FormatearSpread()
        correosUsuarios.EIdEmpresa = datosEmpresa.EId
        Dim lista As New List(Of EntidadesCatalogos.CorreosUsuarios)
        lista = correosUsuarios.ObtenerListadoPorEmpresa()
        spCatalogos.ActiveSheet.DataSource = lista
        spCatalogos.ActiveSheet.Rows.Count += 1
        RestaurarAlturaSpread()
        FormatearSpreadCorreos()

    End Sub

    Private Sub GuardarEditarCorreos()

        Me.Cursor = Cursors.WaitCursor
        correos.EliminarTodo()
        For filaActiva = 0 To spCatalogos.ActiveSheet.Rows.Count - 1
            Dim idUsuario As Integer = spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("idUsuario").Index).Value
            Dim direccion As String = spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("direccion").Index).Value
            If (idUsuario > 0) And (Not String.IsNullOrEmpty(direccion)) Then
                correos.EIdUsuario = idUsuario
                correos.EDireccion = direccion
                Dim tieneCorreos As Boolean = correos.ValidarPorIdyDireccion()
                If (Not tieneCorreos) Then
                    correos.Guardar()
                End If
            End If
        Next
        MsgBox("Guardado correcto.", MsgBoxStyle.ApplicationModal, "Correcto.")
        CargarCorreos()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub EliminarCorreos()

        If (MessageBox.Show("Confirmas que deseas eliminar todo?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            Me.Cursor = Cursors.WaitCursor
            correos.EliminarTodo()
            CargarCorreos()
            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub FormatearSpreadCorreos()
         
        spCatalogos.ActiveSheet.Columns(0, spCatalogos.ActiveSheet.Columns.Count - 1).Visible = True : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Rows(0).Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold) : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Rows(0).Height = 35 : Application.DoEvents()
        spCatalogos.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded : Application.DoEvents()
        spCatalogos.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded : Application.DoEvents()
        Dim numeracion As Integer = 0
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "idEmpresa" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "idUsuario" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "nombreUsuario" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "direccion" : numeracion += 1
        spCatalogos.ActiveSheet.Columns("idUsuario").Width = 70 : Application.DoEvents()
        spCatalogos.ActiveSheet.Columns("nombreUsuario").Width = 210 : Application.DoEvents()
        spCatalogos.ActiveSheet.Columns("direccion").Width = 350 : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("idUsuario").Index).Value = "No.".ToUpper : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("nombreUsuario").Index).Value = "Nombre Usuario".ToUpper : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("direccion").Index).Value = "Dirección Correo".ToUpper : Application.DoEvents()
        spCatalogos.ActiveSheet.Columns("idEmpresa").Visible = False : Application.DoEvents()

    End Sub

    Private Sub ControlarSpreadEnter()

        Dim columnaActiva As Integer = spCatalogos.ActiveSheet.ActiveColumnIndex
        If (columnaActiva = spCatalogos.ActiveSheet.Columns.Count - 1) Then
            spCatalogos.ActiveSheet.AddRows(spCatalogos.ActiveSheet.Rows.Count, 1)
        End If
        Dim fila As Integer = spCatalogos.ActiveSheet.ActiveRowIndex
        If (Me.opcionSeleccionada = Opciones.Correos) Then
            If (columnaActiva = spCatalogos.ActiveSheet.Columns("idUsuario").Index) Then
                usuarios.EIdEmpresa = datosEmpresa.EId
                Dim idUsuario As Integer = spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("idUsuario").Index).Value
                usuarios.EId = idUsuario
                If (idUsuario > 0) Then
                    Dim lista As New List(Of EntidadesCatalogos.Usuarios)
                    lista = usuarios.ObtenerListadoPorId
                    If (lista.Count > 0) Then
                        spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("nombreUsuario").Index).Value = lista(0).ENombre
                    End If
                End If
            End If
        ElseIf (Me.opcionSeleccionada = Opciones.Usuarios) Then
            If (spCatalogos.ActiveSheet.ActiveColumnIndex = spCatalogos.ActiveSheet.Columns("idArea").Index) Then
                Dim idArea As Integer = LogicaCatalogos.Funciones.ValidarNumero(spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("idArea").Index).Value.ToString())
                If (idArea > 0) Then
                    areas.EId = idArea
                    Dim lista As New List(Of EntidadesCatalogos.Areas)()
                    lista = areas.ObtenerListadoPorId()
                    If (lista.Count > 0) Then
                        spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("nombreArea").Index).Text = lista(0).ENombre
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub SeleccionoUsuarios()

        Me.Cursor = Cursors.WaitCursor
        miUsuarios.BackColor = Color.LightSeaGreen
        miAreas.BackColor = msMenu.BackColor
        miCorreos.BackColor = msMenu.BackColor
        Me.opcionSeleccionada = Opciones.Usuarios
        CargarUsuarios()
        Me.Cursor = Cursors.Default

    End Sub
     
    Private Sub FormatearSpreadCatalogoUsuarios(ByVal izquierda As Boolean)

        spCatalogos2.ActiveSheet.ColumnHeader.Rows(0).Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold) : Application.DoEvents()
        spCatalogos2.Width = 300 : Application.DoEvents()
        If (izquierda) Then
            spCatalogos2.Location = New Point(spCatalogos.Location.X, spCatalogos.Location.Y) : Application.DoEvents()
        Else
            spCatalogos2.Location = New Point(spCatalogos.Width - spCatalogos2.Width, spCatalogos.Location.Y) : Application.DoEvents()
        End If
        spCatalogos2.Visible = True : Application.DoEvents()
        spCatalogos2.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never : Application.DoEvents() 
        spCatalogos2.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded : Application.DoEvents()
        spCatalogos2.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect : Application.DoEvents()
        spCatalogos2.Height = spCatalogos.Height : Application.DoEvents()
        Dim numeracion As Integer = 0
        spCatalogos2.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spCatalogos2.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spCatalogos2.ActiveSheet.Columns("id").Width = 50 : Application.DoEvents()
        spCatalogos2.ActiveSheet.Columns("nombre").Width = 210 : Application.DoEvents()
        spCatalogos2.ActiveSheet.ColumnHeader.Cells(0, spCatalogos2.ActiveSheet.Columns("id").Index).Value = "No.".ToUpper : Application.DoEvents()
        spCatalogos2.ActiveSheet.ColumnHeader.Cells(0, spCatalogos2.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper : Application.DoEvents()
        spCatalogos2.ActiveSheet.ColumnHeader.Rows(0).Height = 35 : Application.DoEvents()

    End Sub

    Private Sub CargarCatalogoUsuarios()

        usuarios.EIdEmpresa = datosEmpresa.EId
        spCatalogos2.ActiveSheet.DataSource = usuarios.ObtenerListado() : Application.DoEvents()
        spCatalogos2.Focus()

    End Sub

    Private Sub VolverFocoCatalogos()

        spCatalogos.Enabled = True
        spCatalogos.Focus()
        If (Me.opcionSeleccionada = Opciones.Correos) Then
            spCatalogos.ActiveSheet.SetActiveCell(spCatalogos.ActiveSheet.ActiveRowIndex, spCatalogos.ActiveSheet.Columns("idUsuario").Index)
        ElseIf (Me.opcionSeleccionada = Opciones.Usuarios) Then
            spCatalogos.ActiveSheet.SetActiveCell(spCatalogos.ActiveSheet.ActiveRowIndex, spCatalogos.ActiveSheet.Columns("idArea").Index)
        End If
        spCatalogos2.Visible = False

    End Sub

    Private Sub RestaurarAlturaSpread()

        spProgramas.Visible = False : Application.DoEvents()
        spCatalogos.Height = pnlCuerpo.Height - msMenu.Height : Application.DoEvents()

    End Sub

    Private Sub CargarProgramas()

        Try
            programas.EIdEmpresa = Me.idEmpresa
            spProgramas.ActiveSheet.DataSource = programas.ObtenerListadoDeProgramas()
            FormatearSpreadProgramas()
            Dim filaUsuarios As Integer = spCatalogos.ActiveSheet.ActiveRowIndex
            Dim idUsuario As Integer = Convert.ToInt32(spCatalogos.ActiveSheet.Cells(filaUsuarios, spCatalogos.ActiveSheet.Columns("id").Index).Text)
            For fila As Integer = 0 To spProgramas.ActiveSheet.Rows.Count - 1
                Dim idModulo As Integer = Convert.ToInt32(spProgramas.ActiveSheet.Cells(fila, spProgramas.ActiveSheet.Columns("idModulo").Index).Text)
                Dim idPrograma As Integer = Convert.ToInt32(spProgramas.ActiveSheet.Cells(fila, spProgramas.ActiveSheet.Columns("id").Index).Text)
                bloqueoUsuarios.EIdEmpresa = idEmpresa
                bloqueoUsuarios.EIdUsuario = idUsuario
                bloqueoUsuarios.EIdModulo = idModulo
                bloqueoUsuarios.EIdPrograma = idPrograma
                spProgramas.ActiveSheet.Cells(fila, spProgramas.ActiveSheet.Columns("estatus").Index).Value = bloqueoUsuarios.Obtener() : Application.DoEvents()
            Next
            'FormatearSpreadProgramas()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub FormatearSpreadProgramas()

        spProgramas.ActiveSheet.ColumnHeader.Rows(0).Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold) : Application.DoEvents()
        spProgramas.ActiveSheet.Columns.Count = 5 : Application.DoEvents()
        spProgramas.ActiveSheet.Columns(0).Tag = "idEmpresa"
        spProgramas.ActiveSheet.Columns(1).Tag = "idModulo"
        spProgramas.ActiveSheet.Columns(2).Tag = "id"
        spProgramas.ActiveSheet.Columns(3).Tag = "nombre"
        spProgramas.ActiveSheet.Columns(4).Tag = "estatus"
        spProgramas.ActiveSheet.Columns("idEmpresa").Width = 100 : Application.DoEvents()
        spProgramas.ActiveSheet.Columns("idModulo").Width = 90 : Application.DoEvents()
        spProgramas.ActiveSheet.Columns("id").Width = 40 : Application.DoEvents()
        spProgramas.ActiveSheet.Columns("nombre").Width = 280 : Application.DoEvents()
        spProgramas.ActiveSheet.Columns("estatus").Width = 120 : Application.DoEvents()
        spProgramas.ActiveSheet.Columns("idEmpresa").CellType = tipoEntero : Application.DoEvents()
        spProgramas.ActiveSheet.Columns("idModulo").CellType = tipoEntero : Application.DoEvents()
        spProgramas.ActiveSheet.Columns("id").CellType = tipoEntero : Application.DoEvents()
        spProgramas.ActiveSheet.Columns("nombre").CellType = tipoTexto : Application.DoEvents()
        spProgramas.ActiveSheet.Columns("estatus").CellType = tipoBooleano : Application.DoEvents()
        spProgramas.ActiveSheet.ColumnHeader.Cells(0, spProgramas.ActiveSheet.Columns("idEmpresa").Index).Value = "Empresa".ToUpper() : Application.DoEvents()
        spProgramas.ActiveSheet.ColumnHeader.Cells(0, spProgramas.ActiveSheet.Columns("idModulo").Index).Value = "No. Modulo".ToUpper() : Application.DoEvents()
        spProgramas.ActiveSheet.ColumnHeader.Cells(0, spProgramas.ActiveSheet.Columns("id").Index).Value = "No.".ToUpper() : Application.DoEvents()
        spProgramas.ActiveSheet.ColumnHeader.Cells(0, spProgramas.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper() : Application.DoEvents()
        spProgramas.ActiveSheet.ColumnHeader.Cells(0, spProgramas.ActiveSheet.Columns("estatus").Index).Value = "Bloquear".ToUpper() : Application.DoEvents()
        spProgramas.ActiveSheet.Columns("idEmpresa").Visible = False : Application.DoEvents()

    End Sub

    Private Sub GuardarBloqueoUsuarios()

        Dim fila As Integer = spCatalogos.ActiveSheet.ActiveRowIndex
        Dim filaProgramas As Integer = spProgramas.ActiveSheet.ActiveRowIndex
        Dim idEmpresa As Integer = Me.idEmpresa
        Dim idUsuario As Integer = Convert.ToInt32(spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("id").Index).Text)
        Dim idModulo As Integer = Convert.ToInt32(spProgramas.ActiveSheet.Cells(filaProgramas, spProgramas.ActiveSheet.Columns("idModulo").Index).Text)
        Dim idPrograma As Integer = Convert.ToInt32(spProgramas.ActiveSheet.Cells(filaProgramas, spProgramas.ActiveSheet.Columns("id").Index).Text)
        Dim idSubPrograma As Integer = 0
        If (idEmpresa > 0) AndAlso (idUsuario > 0) Then
            bloqueoUsuarios.EIdEmpresa = idEmpresa
            bloqueoUsuarios.EIdUsuario = idUsuario
            bloqueoUsuarios.EIdModulo = idModulo
            bloqueoUsuarios.EIdPrograma = idPrograma
            bloqueoUsuarios.EIdSubPrograma = idSubPrograma
            bloqueoUsuarios.Guardar()
        End If

    End Sub

    Private Sub EliminarBloqueoUsuarios()

        Dim filaProgramas As Integer = spProgramas.ActiveSheet.ActiveRowIndex
        Dim filaAdministrar As Integer = spCatalogos.ActiveSheet.ActiveRowIndex
        Dim idEmpresa As Integer = Me.idEmpresa
        Dim idUsuario As Integer = Convert.ToInt32(spCatalogos.ActiveSheet.Cells(filaAdministrar, spCatalogos.ActiveSheet.Columns("id").Index).Text)
        Dim idModulo As Integer = Convert.ToInt32(spProgramas.ActiveSheet.Cells(filaProgramas, spProgramas.ActiveSheet.Columns("idModulo").Index).Text)
        Dim idPrograma As Integer = Convert.ToInt32(spProgramas.ActiveSheet.Cells(filaProgramas, spProgramas.ActiveSheet.Columns("id").Index).Text)
        Dim idSubPrograma As Integer = 0
        If (idEmpresa > 0) AndAlso (idUsuario > 0) Then
            bloqueoUsuarios.EIdEmpresa = idEmpresa
            bloqueoUsuarios.EIdUsuario = idUsuario
            bloqueoUsuarios.EIdModulo = idModulo
            bloqueoUsuarios.EIdPrograma = idPrograma
            bloqueoUsuarios.EIdSubPrograma = idSubPrograma
            bloqueoUsuarios.Eliminar()
        End If

    End Sub

    Private Sub FormatearSpreadCatalogoAreas()

        spCatalogos2.ActiveSheet.ColumnHeader.Rows(0).Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold) : Application.DoEvents()
        spCatalogos2.Location = New Point(spCatalogos2.Location.X, spCatalogos2.Location.Y) : Application.DoEvents()
        spCatalogos2.Visible = True : Application.DoEvents()
        spCatalogos2.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never : Application.DoEvents()
        spCatalogos2.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded : Application.DoEvents()
        spCatalogos2.ActiveSheet.OperationMode = FarPoint.Win.Spread.OperationMode.SingleSelect : Application.DoEvents()
        spCatalogos2.Height = spCatalogos.Height : Application.DoEvents()
        spCatalogos2.Width = 310 : Application.DoEvents()
        Dim numeracion As Integer = 0
        spCatalogos2.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spCatalogos2.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spCatalogos2.ActiveSheet.Columns(numeracion).Tag = "clave" : numeracion += 1
        spCatalogos2.ActiveSheet.Columns("id").Width = 50 : Application.DoEvents()
        spCatalogos2.ActiveSheet.Columns("nombre").Width = 220 : Application.DoEvents()
        spCatalogos2.ActiveSheet.Columns("id").CellType = tipoEntero : Application.DoEvents()
        spCatalogos2.ActiveSheet.Columns("nombre").CellType = tipoTexto : Application.DoEvents()
        spCatalogos2.ActiveSheet.ColumnHeader.Cells(0, spCatalogos2.ActiveSheet.Columns("id").Index).Value = "No.".ToUpper() : Application.DoEvents()
        spCatalogos2.ActiveSheet.ColumnHeader.Cells(0, spCatalogos2.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper() : Application.DoEvents()
        spCatalogos2.ActiveSheet.ColumnHeader.Rows(0).Height = 35 : Application.DoEvents()
        spCatalogos2.ActiveSheet.Columns("clave").Visible = False : Application.DoEvents()

    End Sub

    Private Sub CargarCatalogoAreas()

        spCatalogos2.DataSource = areas.ObtenerListado() : Application.DoEvents()

    End Sub

    Private Sub CargarUsuarios()

        Try
            LimpiarSpread()
            usuariosAreas.EIdEmpresa = Me.idEmpresa
            spCatalogos.DataSource = usuariosAreas.ObtenerListadoPorEmpresa()
            spProgramas.Visible = False : Application.DoEvents()
            RestaurarAlturaSpread()
            FormatearSpreadUsuarios()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub FormatearSpreadUsuarios()

        spCatalogos.ActiveSheet.Columns(0, spCatalogos.ActiveSheet.Columns.Count - 1).Visible = True : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Rows(0).Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold) : Application.DoEvents() : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Rows(0).Height = 45 : Application.DoEvents()
        spCatalogos.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded : Application.DoEvents()
        spCatalogos.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded : Application.DoEvents()
        Dim numeracion As Integer = 0
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "empresa" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "id" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "nombre" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "contrasena" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "nivel" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "accesoTotal" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "idArea" : numeracion += 1
        spCatalogos.ActiveSheet.Columns(numeracion).Tag = "nombreArea" : numeracion += 1
        spCatalogos.ActiveSheet.Columns("empresa").Width = 220 : Application.DoEvents()
        spCatalogos.ActiveSheet.Columns("id").Width = 40 : Application.DoEvents()
        spCatalogos.ActiveSheet.Columns("nombre").Width = 220 : Application.DoEvents()
        spCatalogos.ActiveSheet.Columns("contrasena").Width = 160 : Application.DoEvents()
        spCatalogos.ActiveSheet.Columns("nivel").Width = 80 : Application.DoEvents()
        spCatalogos.ActiveSheet.Columns("accesoTotal").Width = 120 : Application.DoEvents()
        spCatalogos.ActiveSheet.Columns("idArea").Width = 40 : Application.DoEvents()
        spCatalogos.ActiveSheet.Columns("nombreArea").Width = 220 : Application.DoEvents()
        spCatalogos.ActiveSheet.Columns("empresa").CellType = tipoEntero : Application.DoEvents()
        spCatalogos.ActiveSheet.Columns("id").CellType = tipoEntero : Application.DoEvents()
        spCatalogos.ActiveSheet.Columns("nombre").CellType = tipoTexto : Application.DoEvents()
        spCatalogos.ActiveSheet.Columns("contrasena").CellType = tipoTextoContrasena : Application.DoEvents()
        spCatalogos.ActiveSheet.Columns("nivel").CellType = tipoEntero : Application.DoEvents()
        spCatalogos.ActiveSheet.Columns("accesoTotal").CellType = tipoBooleano : Application.DoEvents()
        spCatalogos.ActiveSheet.Columns("idArea").CellType = tipoEntero : Application.DoEvents()
        spCatalogos.ActiveSheet.Columns("nombreArea").CellType = tipoTexto : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("empresa").Index).Value = "Empresa".ToUpper() : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("id").Index).Value = "No.".ToUpper() : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper() : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("contrasena").Index).Value = "Contraseña".ToUpper() : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("nivel").Index).Value = "Nivel".ToUpper() : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("accesoTotal").Index).Value = "Acceso Total".ToUpper() : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("idArea").Index).Value = "No.".ToUpper() : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("nombreArea").Index).Value = "Nombre Area".ToUpper() : Application.DoEvents()
        spCatalogos.ActiveSheet.Columns("empresa").Visible = False : Application.DoEvents()
        spCatalogos.ActiveSheet.Rows.Count += 1 : Application.DoEvents()

    End Sub

    Private Sub GuardarEditarUsuarios()

        Dim idEmpresa As Integer = Me.idEmpresa
        usuarios.EIdEmpresa = idEmpresa
        usuarios.EliminarTodo()
        For fila As Integer = 0 To spCatalogos.ActiveSheet.Rows.Count - 1
            Dim idUsuario As Integer = LogicaCatalogos.Funciones.ValidarNumero(spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("id").Index).Text)
            Dim nombre As String = spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("nombre").Index).Text
            Dim contrasena As String = LogicaCatalogos.Funciones.ValidarLetra(spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("contrasena").Index).Value)
            Dim nivel As Integer = LogicaCatalogos.Funciones.ValidarNumero(spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("nivel").Index).Text)
            Dim accesoTotal As Boolean = Convert.ToBoolean(spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("accesoTotal").Index).Value)
            Dim idArea As Integer = LogicaCatalogos.Funciones.ValidarNumero(spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("idArea").Index).Text)
            If idEmpresa > 0 AndAlso idUsuario > 0 AndAlso Not String.IsNullOrEmpty(nombre) AndAlso Not String.IsNullOrEmpty(contrasena) AndAlso nivel >= 0 AndAlso idArea > 0 Then
                usuarios.EId = idUsuario
                Dim tieneUsuarios As Boolean = usuarios.ValidarPorId()
                usuarios.ENombre = nombre
                usuarios.EContrasena = contrasena
                usuarios.ENivel = nivel
                usuarios.EAccesoTotal = accesoTotal
                usuarios.EIdArea = idArea
                If nivel = 0 Then
                    bloqueoUsuarios.EIdEmpresa = idEmpresa
                    bloqueoUsuarios.EIdUsuario = idUsuario
                    bloqueoUsuarios.EIdModulo = 0
                    bloqueoUsuarios.EIdPrograma = 0
                    bloqueoUsuarios.EIdSubPrograma = 0
                    bloqueoUsuarios.Eliminar()
                End If
                If Not tieneUsuarios Then
                    usuarios.Guardar()
                Else
                    usuarios.Editar()
                End If
            End If
        Next
        MessageBox.Show("Guardado correcto.", "Correcto.", MessageBoxButtons.OK)
        CargarUsuarios()

    End Sub

    Private Sub EliminarUsuarios()

        If (MessageBox.Show("Confirmas que deseas eliminar todo?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            Dim idEmpresa As Integer = Me.idEmpresa
            If idEmpresa > 0 Then
                usuarios.EIdEmpresa = idEmpresa
                For fila As Integer = 0 To spCatalogos.ActiveSheet.Rows.Count - 1
                    Dim idUsuario As Integer = LogicaCatalogos.Funciones.ValidarNumero(spCatalogos.ActiveSheet.Cells(fila, spCatalogos.ActiveSheet.Columns("id").Index).Text)
                    If idUsuario > 0 Then
                        usuarios.EIdEmpresa = idEmpresa
                        usuarios.EId = idUsuario
                        Dim tieneDatos As Boolean = usuarios.ValidarActividadPorId()
                        If Not tieneDatos Then
                            bloqueoUsuarios.EIdEmpresa = idEmpresa
                            bloqueoUsuarios.EIdUsuario = idUsuario
                            bloqueoUsuarios.EIdModulo = 0
                            bloqueoUsuarios.EIdPrograma = 0
                            bloqueoUsuarios.EIdSubPrograma = 0
                            bloqueoUsuarios.Eliminar()
                            usuarios.Eliminar()
                        End If
                    End If
                Next
                CargarUsuarios()
            End If
        End If

    End Sub

#End Region

#End Region

#Region "Enumeraciones"

    Public Enum Opciones

        Areas = 1
        Usuarios = 2
        Correos = 3

    End Enum

#End Region

End Class