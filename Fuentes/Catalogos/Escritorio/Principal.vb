Public Class Principal

    Dim areas As New EntidadesCatalogos.Areas
    Public datosEmpresa As New LogicaCatalogos.DatosEmpresa()
    Public datosUsuario As New LogicaCatalogos.datosUsuario()
    Public datosArea As New LogicaCatalogos.DatosArea()
    Public tipoTexto As New FarPoint.Win.Spread.CellType.TextCellType() 
    Public tipoEntero As New FarPoint.Win.Spread.CellType.NumberCellType()
    Public tipoDoble As New FarPoint.Win.Spread.CellType.NumberCellType()
    Public tipoPorcentaje As New FarPoint.Win.Spread.CellType.PercentCellType()
    Public tipoHora As New FarPoint.Win.Spread.CellType.DateTimeCellType()
    Public tipoFecha As New FarPoint.Win.Spread.CellType.DateTimeCellType()
    Public opcionSeleccionada As Integer = 0

#Region "Eventos"

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Centrar()
        AsignarTooltips()
        ConfigurarConexiones() 
        CargarEncabezados()
        SeleccionoAreas()
        ComenzarCargarAreas()
        CargarTiposDeDatos()
        'Me.opcionSeleccionada = Reportes.Areas

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click

        Application.Exit()

    End Sub

    Private Sub miArea_Click(sender As Object, e As EventArgs) Handles miArea.Click

        SeleccionoAreas()
        ComenzarCargarAreas()

    End Sub

    Private Sub miOpcion2_Click(sender As Object, e As EventArgs) Handles miOpcion2.Click

        miOpcion2.BackColor = Color.LightSeaGreen
        miArea.BackColor = msMenu.BackColor
        Me.opcionSeleccionada = Reportes.Opcion2

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

        Dim esPrueba As Boolean = False
        If (esPrueba) Then
            'baseDatos.CadenaConexionInformacion = "C:\\Berry-Agenda\\BD\\PODC\\Catalogos.mdf"
            EntidadesCatalogos.BaseDatos.ECadenaConexionCatalogo = "Catalogos"
        Else
            Me.datosEmpresa.ObtenerParametrosInformacionEmpresa()
            Me.datosUsuario.ObtenerParametrosInformacionUsuario()
            Me.datosArea.ObtenerParametrosInformacionArea()
            EntidadesCatalogos.BaseDatos.ECadenaConexionCatalogo = "Catalogos" 'datosEmpresa.EDirectorio & "\\Catalogos.mdf" 
        End If
        EntidadesCatalogos.BaseDatos.AbrirConexionCatalogo()

    End Sub

    Private Sub CargarEncabezados()

        lblEncabezadoPrograma.Text = "Programa: " + Me.Text
        lblEncabezadoEmpresa.Text = "Empresa: " + datosEmpresa.ENombre
        lblEncabezadoUsuario.Text = "Usuario: " + datosUsuario.ENombre
        lblEncabezadoArea.Text = "Area: " + datosArea.ENombre

    End Sub

    Private Sub SeleccionoAreas()

        miArea.BackColor = Color.LightSeaGreen
        miOpcion2.BackColor = msMenu.BackColor
        Me.opcionSeleccionada = Reportes.Areas
        CargarAreas()

    End Sub

    Private Sub ComenzarCargarAreas()

        FormatearSpread()
        CargarAreas()
        FormatearSpreadAreas()

    End Sub

    Private Sub CargarAreas()

        Dim lista As New List(Of EntidadesCatalogos.Areas)
        lista = areas.ObtenerListado()
        spCatalogos.ActiveSheet.DataSource = lista
        spCatalogos.ActiveSheet.Rows.Count += 1

    End Sub

    Private Sub GuardarEditarAreas()

        areas.EliminarTodo()
        For filaActiva = 0 To spCatalogos.ActiveSheet.Rows.Count - 1
            Dim id As Integer = spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("id").Index).Value
            Dim nombre As String = spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("nombre").Index).Value
            Dim clave As String = LogicaCatalogos.ValidarLetra(spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("clave").Index).Value)
            If (Not String.IsNullOrEmpty(id)) And (Not String.IsNullOrEmpty(nombre)) Then
                areas.EId = id
                areas.ENombre = nombre
                areas.EClave = clave
                Dim tieneAreas As Boolean = areas.ValidarPorNumero()
                If tieneAreas Then
                    areas.Editar()
                Else
                    areas.Guardar()
                End If
            End If
        Next
        MsgBox("Guardado correcto.", MsgBoxStyle.ApplicationModal, "Correcto.")
        CargarAreas()

    End Sub

    Private Sub EliminarAreasEnter()

        'Dim id As String = spCatalogos.ActiveSheet.Cells(filaActiva, spCatalogos.ActiveSheet.Columns("id").Index).Value
        'If (Not String.IsNullOrEmpty(id)) Then
        '    areas.EId = LogicaCatalogos.Funciones.ValidarNumero(id)
        '    areas.Eliminar()
        '    CargarAreas()
        'End If

    End Sub

    Private Sub EliminarAreas()

        If (MessageBox.Show("Confirmas que deseas eliminar todo?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            areas.EliminarTodo()
            CargarAreas()
        End If

    End Sub

    Private Sub FormatearSpread()

        spCatalogos.Reset() : Application.DoEvents()
        ControlarSpreadEnter(spCatalogos)
        spCatalogos.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Seashell
        spCatalogos.Visible = True : Application.DoEvents()
        spCatalogos.ActiveSheet.GrayAreaBackColor = Color.White : Application.DoEvents()
        spCatalogos.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold) : Application.DoEvents()
        spCatalogos.ActiveSheet.Rows(-1).Height = 30 : Application.DoEvents()
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
        'spCatalogos.ActiveSheet.Columns("clave").CellType =
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("id").Index).Value = "Id".ToUpper : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("nombre").Index).Value = "Nombre".ToUpper : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Cells(0, spCatalogos.ActiveSheet.Columns("clave").Index).Value = "Clave".ToUpper : Application.DoEvents()
        spCatalogos.ActiveSheet.ColumnHeader.Rows(0).Height = 35 : Application.DoEvents()

    End Sub

    Private Sub ControlarSpreadEnter()

        Dim columnaActiva As Integer = spCatalogos.ActiveSheet.ActiveColumnIndex
        ' Guardar o editar. 
        If (columnaActiva = spCatalogos.ActiveSheet.Columns.Count - 1) Then
            spCatalogos.ActiveSheet.AddRows(spCatalogos.ActiveSheet.Rows.Count, 1)
            'Dim filaActiva As Integer = spCatalogos.ActiveSheet.ActiveRowIndex 
            'If (Me.opcionSeleccionada = Reportes.Areas) Then
            '    'GuardarEditarAreas()
            'ElseIf (Me.opcionSeleccionada = Reportes.Opcion2) Then
            '    'GuardarEditarEmpresas()
            'End If
        End If

    End Sub

#End Region

    Private Sub spCatalogos_DialogKey(sender As Object, e As FarPoint.Win.Spread.DialogKeyEventArgs) Handles spCatalogos.DialogKey

        If (e.KeyData = Keys.Enter) Then
            ControlarSpreadEnter() ' Metodo descontinuado.
        End If

    End Sub

    Private Sub spCatalogos_KeyDown(sender As Object, e As KeyEventArgs) Handles spCatalogos.KeyDown

        If e.KeyData = Keys.F1 Then ' Abrir catalogos.
            'Dim columnaActiva As Integer = spCatalogos.ActiveSheet.ActiveColumnIndex
            '    if (columnaActiva = spCatalogos.ActiveSheet.Columns["idProductor"].Index) then
            '         Catalogos.opcionSeleccionada = (int)LogicaTarima.NumeracionCatalogos.Numeracion.productor;
            '        new Escritorio.Catalogos().Show();
            'End If
        ElseIf e.KeyData = Keys.F5 Then ' Eliminar un registro.
            If (MessageBox.Show("Confirmas que deseas eliminar el registro seleccionado?", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                Dim fila As Integer = spCatalogos.ActiveSheet.ActiveRowIndex
                If (Me.opcionSeleccionada = Reportes.Areas) Then
                    spCatalogos.ActiveSheet.Rows.Remove(fila, 1)
                ElseIf (Me.opcionSeleccionada = Reportes.Opcion2) Then

                End If
            End If
        ElseIf (e.KeyData = Keys.Enter) Then
            ControlarSpreadEnter() ' Metodo descontinuado.
        End If

    End Sub

    Public Enum Reportes

        Areas = 1
        Opcion2 = 2

    End Enum

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If (Me.opcionSeleccionada = Reportes.Areas) Then
            GuardarEditarAreas()
        ElseIf (Me.opcionSeleccionada = Reportes.Opcion2) Then

        End If

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        If (Me.opcionSeleccionada = Reportes.Areas) Then
            EliminarAreas()
        ElseIf (Me.opcionSeleccionada = Reportes.Opcion2) Then

        End If

    End Sub

End Class