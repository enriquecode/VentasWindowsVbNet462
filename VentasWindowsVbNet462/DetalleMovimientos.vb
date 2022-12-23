Imports System.Data.SqlClient

Imports DataLayer

Public Class DetalleMovimientos

    Dim idMovimiento As Integer
    Dim dsDataGridDetalle As DataSet


    Public Sub New(ByVal idMovimientoRecibido As Integer)

        idMovimiento = idMovimientoRecibido

        InitializeComponent()


    End Sub

    Private Sub DetalleMovimientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenaProductos()
        LlenarDetalle()
    End Sub

    Private Sub LlenaProductos()
        Dim ds As New DataSet()
        Dim SQLHelper As New SQLHelper()

        ds = SQLHelper.GetDataSet("SELECT IdProducto, Clave + ' | ' + Nombre AS Nombre FROM dbo.Productos WITH(NOLOCK)", CommandType.Text)

        If (ds.Tables(0).Rows.Count > 0) Then
            comboProductos.DataSource = ds.Tables(0)
            comboProductos.ValueMember = ds.Tables(0).Columns("IdProducto").ToString()
            comboProductos.DisplayMember = ds.Tables(0).Columns("Nombre").ToString()


            'For i = 0 To ds.Tables(0).Rows.Count - 1
            '    comboProductos.Items.Add(ds.Tables(0).Rows(i).Item(0).ToString)
            'Next
        End If
    End Sub

    Private Sub LlenarDetalle()
        Dim ds As New DataSet()
        Dim SQLHelper As New SQLHelper()

        Dim arrParams() As SqlParameter = {
            SQLHelper.CreateParameter("@IdMovimiento", SqlDbType.Int, idMovimiento)
        }

        dsDataGridDetalle = SQLHelper.GetDataSet("sp_ObtenerDetalleMovimiento", CommandType.StoredProcedure, arrParams)

        If (dsDataGridDetalle.Tables(0).Rows.Count > 0) Then

            DataGridDetalle.DataSource = dsDataGridDetalle.Tables(0)
            DataGridDetalle.Refresh()

            DataGridDetalle.Columns(0).Visible = False
            DataGridDetalle.Columns(1).Visible = False


        Else

            'Me.cmdNueva.Enabled = False
            'Me.cmdInsertar.Enabled = True
            'Me.cmdModificar.Enabled = False


        End If

        ds = Nothing
    End Sub

    Private Sub cmdAgregar_Click(sender As Object, e As EventArgs) Handles cmdAgregar.Click


        Dim cantidad As Decimal
        Dim precio As Decimal
        Dim total As Decimal

        If Me.txtCantidad.Text <> "" And Val(Me.txtCantidad.Text) > 0 Then
            cantidad = Math.Round(Val(Me.txtCantidad.Text), 2)
        Else
            MsgBox("Se debe de capturar una cantidad de articulos mayor a cero")
            Exit Sub
        End If

        If Me.txtPrecio.Text <> "" And Val(Me.txtPrecio.Text) > 0 Then
            precio = Math.Round(Val(Me.txtPrecio.Text), 2)
        Else
            MsgBox("Se debe de capturar un precio mayor a cero")
            Exit Sub
        End If

        total = Val(Me.txtTotal.Text)

        Dim idProducto As String
        idProducto = comboProductos.SelectedValue.ToString()

        Dim productoEncontrado As Boolean
        productoEncontrado = False
        'se busca si ya existe el producto si es así no permite continuar
        Dim rowindex As Integer
        For Each row As DataGridViewRow In DataGridDetalle.Rows
            If row.Cells.Item("IdProducto").Value.ToString() = idProducto Then
                productoEncontrado = True
                rowindex = row.Index
                'MsgBox(rowindex.ToString())

                'Scroll to the specific row.
                Me.DataGridDetalle.FirstDisplayedScrollingRowIndex = rowindex

                'Clear the last selection
                Me.DataGridDetalle.ClearSelection()

                'Select the specific row.
                Me.DataGridDetalle.Rows(rowindex).Selected = True

                Exit For
            End If
        Next

        If productoEncontrado Then
            MsgBox("El Producto Ya está en el detalle del Movimiento, seleccionar otro articulo")
            Exit Sub
        End If

        Dim MyNewRow As DataRow
        MyNewRow = dsDataGridDetalle.Tables(0).NewRow

        Dim claveAndNombreProducto As String
        claveAndNombreProducto = comboProductos.Text

        Dim claveAndNombreProductoArray As String() = claveAndNombreProducto.Split(New Char() {"|"c})

        Dim claveProducto As String
        Dim nombreProducto As String

        claveProducto = RTrim(claveAndNombreProductoArray(0))
        nombreProducto = LTrim(claveAndNombreProductoArray(1))

        With MyNewRow
            .Item(0) = 0
            .Item(1) = idProducto
            .Item(2) = claveProducto
            .Item(3) = nombreProducto
            .Item(4) = cantidad
            .Item(5) = precio
            .Item(6) = total
        End With


        dsDataGridDetalle.Tables(0).Rows.Add(MyNewRow)
        dsDataGridDetalle.Tables(0).AcceptChanges()

        'If DataGridDetalle.DataSource
        DataGridDetalle.DataSource = dsDataGridDetalle.Tables(0)
        DataGridDetalle.Refresh()

        DataGridDetalle.Columns(0).Visible = False
        DataGridDetalle.Columns(1).Visible = False
        'Me.DataGridDetalle.


    End Sub

    Private Sub txtCantidad_TextChanged(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged
        If Me.txtCantidad.Text <> "" And Val(Me.txtCantidad.Text) > 0 Then
            If Me.txtPrecio.Text <> "" And Val(Me.txtPrecio.Text) > 0 Then
                Me.txtTotal.Text = Math.Round(Val(Me.txtCantidad.Text) * Val(Me.txtPrecio.Text), 2)
            End If
        End If
    End Sub

    Private Sub txtPrecio_TextChanged(sender As Object, e As EventArgs) Handles txtPrecio.TextChanged
        If Me.txtPrecio.Text <> "" And Val(Me.txtPrecio.Text) > 0 Then
            If Me.txtCantidad.Text <> "" And Val(Me.txtCantidad.Text) > 0 Then
                Me.txtTotal.Text = Math.Round(Val(Me.txtCantidad.Text) * Val(Me.txtPrecio.Text), 2)
            End If
        End If
    End Sub

    Private Sub DataGridDetalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridDetalle.CellContentClick

        If (e.RowIndex >= 0) Then
            Me.cmdNuevo.Enabled = True
            Me.cmdAgregar.Enabled = False
            Me.cmdModificar.Enabled = True
            Me.cmdEliminar.Enabled = True
            Me.cmdModificar.Text = "&Modificar"
            Me.cmdCancelar.Visible = False
            Me.txtCantidad.Enabled = False
            Me.txtPrecio.Enabled = False

            Dim idProducto As Integer
            Dim claveProducto As String
            Dim nombreProducto As String
            Dim cantidadProducto As String
            Dim precioProducto As String
            Dim total As String

            idProducto = Convert.ToInt32(DataGridDetalle.Rows(e.RowIndex).Cells(1).Value.ToString())
            claveProducto = DataGridDetalle.Rows(e.RowIndex).Cells(2).Value.ToString()
            nombreProducto = DataGridDetalle.Rows(e.RowIndex).Cells(3).Value.ToString()
            cantidadProducto = DataGridDetalle.Rows(e.RowIndex).Cells(4).Value.ToString()
            precioProducto = DataGridDetalle.Rows(e.RowIndex).Cells(5).Value.ToString()
            total = DataGridDetalle.Rows(e.RowIndex).Cells(6).Value.ToString()

            Me.comboProductos.SelectedValue = idProducto
            comboProductos.Enabled = False


            'Me.lblIdProducto.Text = idProducto
            'Me.txtClaveProducto.Text = claveProducto
            'Me.txtNombreProducto.Text = nombreProducto
            Me.txtCantidad.Text = cantidadProducto
            Me.txtPrecio.Text = precioProducto
            Me.txtTotal.Text = total
        End If
    End Sub

    Private Sub DataGridDetalle_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridDetalle.CellMouseClick
        If (e.RowIndex >= 0) Then
            Me.cmdNuevo.Enabled = True
            Me.cmdAgregar.Enabled = False
            Me.cmdModificar.Enabled = True
            Me.cmdEliminar.Enabled = True
            Me.cmdModificar.Text = "&Modificar"
            Me.cmdCancelar.Visible = False
            Me.txtCantidad.Enabled = False
            Me.txtPrecio.Enabled = False

            Dim idProducto As Integer
            Dim claveProducto As String
            Dim nombreProducto As String
            Dim cantidadProducto As String
            Dim precioProducto As String
            Dim total As String

            idProducto = Convert.ToInt32(DataGridDetalle.Rows(e.RowIndex).Cells(1).Value.ToString())
            claveProducto = DataGridDetalle.Rows(e.RowIndex).Cells(2).Value.ToString()
            nombreProducto = DataGridDetalle.Rows(e.RowIndex).Cells(3).Value.ToString()
            cantidadProducto = DataGridDetalle.Rows(e.RowIndex).Cells(4).Value.ToString()
            precioProducto = DataGridDetalle.Rows(e.RowIndex).Cells(5).Value.ToString()
            total = DataGridDetalle.Rows(e.RowIndex).Cells(6).Value.ToString()

            Me.comboProductos.SelectedValue = idProducto
            comboProductos.Enabled = False


            'Me.lblIdProducto.Text = idProducto
            'Me.txtClaveProducto.Text = claveProducto
            'Me.txtNombreProducto.Text = nombreProducto
            Me.txtCantidad.Text = cantidadProducto
            Me.txtPrecio.Text = precioProducto
            Me.txtTotal.Text = total
        End If
    End Sub

    Private Sub DataGridDetalle_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridDetalle.CellClick
        If (e.RowIndex >= 0) Then
            Me.cmdNuevo.Enabled = True
            Me.cmdAgregar.Enabled = False
            Me.cmdModificar.Enabled = True
            Me.cmdEliminar.Enabled = True
            Me.cmdModificar.Text = "&Modificar"
            Me.cmdCancelar.Visible = False
            Me.txtCantidad.Enabled = False
            Me.txtPrecio.Enabled = False

            Dim idProducto As Integer
            Dim claveProducto As String
            Dim nombreProducto As String
            Dim cantidadProducto As String
            Dim precioProducto As String
            Dim total As String

            idProducto = Convert.ToInt32(DataGridDetalle.Rows(e.RowIndex).Cells(1).Value.ToString())
            claveProducto = DataGridDetalle.Rows(e.RowIndex).Cells(2).Value.ToString()
            nombreProducto = DataGridDetalle.Rows(e.RowIndex).Cells(3).Value.ToString()
            cantidadProducto = DataGridDetalle.Rows(e.RowIndex).Cells(4).Value.ToString()
            precioProducto = DataGridDetalle.Rows(e.RowIndex).Cells(5).Value.ToString()
            total = DataGridDetalle.Rows(e.RowIndex).Cells(6).Value.ToString()

            Me.comboProductos.SelectedValue = idProducto
            comboProductos.Enabled = False


            'Me.lblIdProducto.Text = idProducto
            'Me.txtClaveProducto.Text = claveProducto
            'Me.txtNombreProducto.Text = nombreProducto
            Me.txtCantidad.Text = cantidadProducto
            Me.txtPrecio.Text = precioProducto
            Me.txtTotal.Text = total
        End If
    End Sub

    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click

        Me.txtCantidad.Enabled = True
        Me.txtPrecio.Enabled = True

        If (Me.cmdModificar.Text = "&Modificar") Then
            Me.cmdNuevo.Enabled = True
            Me.cmdAgregar.Enabled = False
            'Me.cmdEliminar.Enabled = False
            Me.cmdModificar.Text = "Guar&dar"
            Me.txtCantidad.Select()
            Me.cmdGuardarBD.Visible = False
            Me.cmdCancelar.Visible = True

        Else
            Me.cmdNuevo.Enabled = False
            Me.cmdAgregar.Enabled = True
            'Me.cmdEliminar.Enabled = True
            Me.cmdGuardarBD.Visible = True
            Me.cmdCancelar.Visible = False
            Me.cmdModificar.Text = "&Modificar"
        End If


    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.cmdModificar.Text = "&Modificar"
        Me.cmdCancelar.Visible = False
        Me.cmdNuevo.Enabled = False
        Me.cmdAgregar.Enabled = True
        Me.cmdModificar.Enabled = False
        Me.cmdEliminar.Enabled = False
        Me.comboProductos.Enabled = True
        Me.txtCantidad.Text = ""
        Me.txtPrecio.Text = ""
        Me.txtTotal.Text = "0.0"
        Me.comboProductos.SelectedIndex = 0

    End Sub

    Private Sub cmdEliminar_Click(sender As Object, e As EventArgs) Handles cmdEliminar.Click

        Me.cmdGuardarBD.Visible = True

        Me.cmdModificar.Enabled = False
        Me.cmdCancelar.Visible = False
        Me.cmdEliminar.Enabled = False
        'Me.comboProductos.Enabled = True
        Me.txtCantidad.Text = ""
        Me.txtPrecio.Text = ""
        Me.txtTotal.Text = "0.0"
        Me.comboProductos.SelectedIndex = 0

        Dim iRowIndex As Integer
        iRowIndex = Convert.ToInt32(Me.DataGridDetalle.CurrentCell.RowIndex)

        'For i As Integer = 0 To Me.DataGridDetalle.SelectedCells.Count - 1
        '    iRowIndex = Me.DataGridDetalle.SelectedCells.Item(i).RowIndex
        'Next
        dsDataGridDetalle.Tables(0).Rows.RemoveAt(iRowIndex)
        dsDataGridDetalle.Tables(0).AcceptChanges()

        Me.DataGridDetalle.Refresh()

    End Sub

    Private Sub cmdNuevo_Click(sender As Object, e As EventArgs) Handles cmdNuevo.Click
        Me.cmdNuevo.Enabled = False
        Me.cmdAgregar.Enabled = True
        Me.cmdModificar.Enabled = False
        Me.cmdCancelar.Visible = False
        Me.cmdGuardarBD.Visible = True

        Me.cmdEliminar.Enabled = False
        Me.txtCantidad.Text = ""
        Me.txtPrecio.Text = ""
        Me.txtTotal.Text = "0.0"
        Me.comboProductos.Enabled = True
        Me.txtCantidad.Enabled = True
        Me.txtPrecio.Enabled = True
        Me.comboProductos.SelectedIndex = 0
        Me.comboProductos.Select()

    End Sub

    Private Sub cmdGuardarBD_Click(sender As Object, e As EventArgs) Handles cmdGuardarBD.Click
        If (dsDataGridDetalle.Tables(0).Rows.Count = 0) Then
            MsgBox("Debe de tener al menos un registro la compra, si ya está afectada esta compra, se requiere cancelar la Compra")
            Exit Sub
        End If
    End Sub
End Class