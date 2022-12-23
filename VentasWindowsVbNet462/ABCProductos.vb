Imports System.Data
Imports System.Data.SqlClient

Imports DataLayer

Public Class ABCProductos
    Dim claveProductoAntesDeModificar As String
    Dim nombreProductoAntesDeModificar As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub ABCProductos_Load(sender As Object, e As EventArgs) Handles Me.Load

        LlenaDataGrid()

        If (DataGridProductos.Rows.Count > 0) Then

            Dim nColumnIndex As Integer
            nColumnIndex = 2

            'Scroll to the last row.
            Me.DataGridProductos.FirstDisplayedScrollingRowIndex = 0

            'Clear the last selection
            Me.DataGridProductos.ClearSelection()

            'Select the last row.
            Me.DataGridProductos.Rows(0).Selected = True

            Dim idProducto As String
            Dim claveProducto As String
            Dim nombreProducto As String
            Dim existenciaProducto As String

            idProducto = DataGridProductos.Rows(0).Cells(0).Value.ToString()
            claveProducto = DataGridProductos.Rows(0).Cells(1).Value.ToString()
            nombreProducto = DataGridProductos.Rows(0).Cells(2).Value.ToString()
            existenciaProducto = DataGridProductos.Rows(0).Cells(3).Value.ToString()

            Me.lblIdProducto.Text = idProducto
            Me.txtClaveProducto.Text = claveProducto
            Me.txtNombreProducto.Text = nombreProducto
            Me.txtExistencia.Text = existenciaProducto

        End If
    End Sub
    Private Sub cmdNuevo_Click(sender As Object, e As EventArgs) Handles cmdNuevo.Click
        If (Me.cmdNuevo.Text = "N&uevo") Then
            Me.cmdNuevo.Text = "&Cancelar"

            Me.txtClaveProducto.Text = ""
            Me.txtNombreProducto.Text = ""
            Me.txtExistencia.Text = ""
            Me.lblIdProducto.Text = ""

            Me.txtClaveProducto.Enabled = True
            Me.txtNombreProducto.Enabled = True
            Me.txtClaveProducto.Select()

            Me.cmdInsertar.Enabled = True
            Me.cmdModificar.Enabled = False
        Else
            Me.cmdNuevo.Text = "N&uevo"

            LlenaDataGrid()


            'Scroll to the first row.
            Me.DataGridProductos.FirstDisplayedScrollingRowIndex = 0

            'Clear the last selection
            Me.DataGridProductos.ClearSelection()

            'Select the first row.
            Me.DataGridProductos.Rows(0).Selected = True

            Dim idProducto As String
            Dim claveProducto As String
            Dim nombreProducto As String
            Dim existenciaProducto As String

            idProducto = DataGridProductos.Rows(0).Cells(0).Value.ToString()
            claveProducto = DataGridProductos.Rows(0).Cells(1).Value.ToString()
            nombreProducto = DataGridProductos.Rows(0).Cells(2).Value.ToString()
            existenciaProducto = DataGridProductos.Rows(0).Cells(3).Value.ToString()

            Me.lblIdProducto.Text = idProducto
            Me.txtClaveProducto.Text = claveProducto
            Me.txtNombreProducto.Text = nombreProducto
            Me.txtExistencia.Text = existenciaProducto

            Me.cmdModificar.Enabled = True

            Me.txtClaveProducto.Enabled = False
            Me.txtNombreProducto.Enabled = False

            Me.cmdInsertar.Enabled = False

        End If

    End Sub
    Private Sub cmdInsertar_Click(sender As Object, e As EventArgs) Handles cmdInsertar.Click
        Dim SQLHelper As New SQLHelper()
        Dim ds As New DataSet()

        Dim claveProducto As String
        Dim nombreProducto As String

        claveProducto = Trim(Me.txtClaveProducto.Text)
        nombreProducto = Trim(Me.txtNombreProducto.Text)

        If claveProducto.Length < 5 Then
            MessageBox.Show("La clave del producto debe de ser al menos 5 letras y numeros")
            Me.txtClaveProducto.Select()
            Exit Sub
        End If

        If nombreProducto.Length < 5 Then
            MessageBox.Show("El nombre del producto debe de ser al menos 5 letras y numeros")
            Me.txtNombreProducto.Select()
            Exit Sub
        End If

        Dim arrParams() As SqlParameter = {
            SQLHelper.CreateParameter("@Clave", SqlDbType.VarChar, claveProducto),
            SQLHelper.CreateParameter("@Nombre", SqlDbType.VarChar, nombreProducto)
        }

        ds = SQLHelper.GetDataSet("sp_InsertarProducto", CommandType.StoredProcedure, arrParams)

        Dim objectResultadoInsercion As Object = ds.Tables(0).Rows.Item(0).Item("ResultadoInsercion")

        If (objectResultadoInsercion.ToString() = "Exito") Then
            MessageBox.Show("Se insertó correctamente el producto")


            Me.txtClaveProducto.Enabled = False
            Me.txtNombreProducto.Enabled = False

            'Me.cmdNuevo.Enabled = True
            Me.cmdNuevo.Text = "N&uevo"

            Dim objectIdProducto As Object = ds.Tables(0).Rows.Item(0).Item("IdProducto")
            lblIdProducto.Text = objectIdProducto.ToString()

            LlenaDataGrid()

            'Me.txtClaveProducto.Text = ""
            'Me.txtNombreProducto.Text = ""
            Me.txtExistencia.Text = "0.00"

            Dim nLastIndex As Integer
            nLastIndex = DataGridProductos.Rows.Count - 1
            Dim nColumnIndex As Integer
            nColumnIndex = 2

            'Scroll to the last row.
            Me.DataGridProductos.FirstDisplayedScrollingRowIndex = nLastIndex

            'Clear the last selection
            Me.DataGridProductos.ClearSelection()

            'Select the last row.
            Me.DataGridProductos.Rows(nLastIndex).Selected = True


        Else
            If (objectResultadoInsercion.ToString() = "Error Clave Ya Existe") Then
                MessageBox.Show("La clave del producto ya existe")
                Me.txtClaveProducto.Select()

                'se pueden agregar otros errores u excepciones
            End If
        End If

    End Sub

    Private Sub LlenaDataGrid()
        Dim ds As New DataSet()
        Dim SQLHelper As New SQLHelper()

        ds = SQLHelper.GetDataSet("sp_ObtenerProductos", CommandType.StoredProcedure)

        If (ds.Tables(0).Rows.Count > 0) Then
            Me.txtClaveProducto.Enabled = False
            Me.txtNombreProducto.Enabled = False

            Me.cmdNuevo.Enabled = True
            Me.cmdInsertar.Enabled = False
            Me.cmdModificar.Enabled = True

            DataGridProductos.DataSource = ds.Tables(0)
            DataGridProductos.Refresh()

            DataGridProductos.Columns(0).Visible = False


        Else

            Me.cmdNuevo.Enabled = False
            Me.cmdInsertar.Enabled = True
            Me.cmdModificar.Enabled = False


        End If

        ds = Nothing
    End Sub

    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        If (Me.cmdModificar.Text = "&Modificar") Then
            Me.DataGridProductos.Enabled = False
            Me.txtClaveProducto.Enabled = True
            Me.txtNombreProducto.Enabled = True
            Me.txtClaveProducto.Select()
            Me.cmdCancelar.Visible = True

            Me.cmdModificar.Text = "&Guardar"

            claveProductoAntesDeModificar = Me.txtClaveProducto.Text
            nombreProductoAntesDeModificar = Me.txtNombreProducto.Text
        Else

            Dim SQLHelper As New SQLHelper()
            Dim ds As New DataSet()

            Dim idProducto As Integer
            Dim claveProducto As String
            Dim nombreProducto As String

            idProducto = Convert.ToInt32(Me.lblIdProducto.Text)
            claveProducto = Trim(Me.txtClaveProducto.Text)
            nombreProducto = Trim(Me.txtNombreProducto.Text)

            If claveProducto.Length < 5 Then
                MessageBox.Show("La clave del producto debe de ser al menos 5 letras y numeros")
                Exit Sub
            End If

            If nombreProducto.Length < 5 Then
                MessageBox.Show("El nombre del producto debe de ser al menos 5 letras y numeros")
                Me.txtNombreProducto.Select()
                Exit Sub
            End If

            Dim arrParams() As SqlParameter = {
                SQLHelper.CreateParameter("@IdProducto", SqlDbType.Int, idProducto),
                SQLHelper.CreateParameter("@Clave", SqlDbType.VarChar, claveProducto),
                SQLHelper.CreateParameter("@Nombre", SqlDbType.VarChar, nombreProducto)
                }
            ds = SQLHelper.GetDataSet("sp_ActualizarProducto", CommandType.StoredProcedure, arrParams)

            Dim objectResultadoActualizacion As Object = ds.Tables(0).Rows.Item(0).Item("ResultadoActualizacion")

            If (objectResultadoActualizacion.ToString() = "Exito") Then
                MessageBox.Show("Se actualizó correctamente el producto")


                Me.txtClaveProducto.Enabled = False
                Me.txtNombreProducto.Enabled = False

                Me.cmdNuevo.Enabled = True
                Me.DataGridProductos.Enabled = True

                'Dim objectIdProducto As Object = ds.Tables(0).Rows.Item(0).Item("IdProducto")
                'lblIdProducto.Text = objectIdProducto.ToString()

                LlenaDataGrid()

                Dim rowindex As Integer
                For Each row As DataGridViewRow In DataGridProductos.Rows
                    If row.Cells.Item("IdProducto").Value.ToString() = idProducto.ToString() Then
                        rowindex = row.Index
                        'MsgBox(rowindex.ToString())

                        'Scroll to the specific row.
                        Me.DataGridProductos.FirstDisplayedScrollingRowIndex = rowindex

                        'Clear the last selection
                        Me.DataGridProductos.ClearSelection()

                        'Select the specific row.
                        Me.DataGridProductos.Rows(rowindex).Selected = True

                        Exit For
                    End If
                Next

            Else
                If (objectResultadoActualizacion.ToString() = "Error Clave Ya Existe") Then
                    MessageBox.Show("La clave del producto ya existe")
                    Me.txtClaveProducto.Select()

                    'se pueden agregar otros errores u excepciones
                End If
            End If

            Me.cmdModificar.Text = "&Modificar"
            Me.cmdCancelar.Visible = False

        End If
    End Sub

    Private Sub DataGridProductos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridProductos.CellContentClick
        If (e.RowIndex >= 0) Then
            Dim idProducto As String
            Dim claveProducto As String
            Dim nombreProducto As String
            Dim existenciaProducto As String

            idProducto = DataGridProductos.Rows(e.RowIndex).Cells(0).Value.ToString()
            claveProducto = DataGridProductos.Rows(e.RowIndex).Cells(1).Value.ToString()
            nombreProducto = DataGridProductos.Rows(e.RowIndex).Cells(2).Value.ToString()
            existenciaProducto = DataGridProductos.Rows(e.RowIndex).Cells(3).Value.ToString()

            Me.lblIdProducto.Text = idProducto
            Me.txtClaveProducto.Text = claveProducto
            Me.txtNombreProducto.Text = nombreProducto
            Me.txtExistencia.Text = existenciaProducto

        End If
    End Sub

    Private Sub DataGridProductos_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridProductos.CellMouseClick
        If (e.RowIndex >= 0) Then
            Dim idProducto As String
            Dim claveProducto As String
            Dim nombreProducto As String
            Dim existenciaProducto As String

            idProducto = DataGridProductos.Rows(e.RowIndex).Cells(0).Value.ToString()
            claveProducto = DataGridProductos.Rows(e.RowIndex).Cells(1).Value.ToString()
            nombreProducto = DataGridProductos.Rows(e.RowIndex).Cells(2).Value.ToString()
            existenciaProducto = DataGridProductos.Rows(e.RowIndex).Cells(3).Value.ToString()

            Me.lblIdProducto.Text = idProducto
            Me.txtClaveProducto.Text = claveProducto
            Me.txtNombreProducto.Text = nombreProducto
            Me.txtExistencia.Text = existenciaProducto

        End If
    End Sub

    Private Sub DataGridProductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridProductos.CellClick
        If (e.RowIndex >= 0) Then
            Dim idProducto As String
            Dim claveProducto As String
            Dim nombreProducto As String
            Dim existenciaProducto As String

            idProducto = DataGridProductos.Rows(e.RowIndex).Cells(0).Value.ToString()
            claveProducto = DataGridProductos.Rows(e.RowIndex).Cells(1).Value.ToString()
            nombreProducto = DataGridProductos.Rows(e.RowIndex).Cells(2).Value.ToString()
            existenciaProducto = DataGridProductos.Rows(e.RowIndex).Cells(3).Value.ToString()

            Me.lblIdProducto.Text = idProducto
            Me.txtClaveProducto.Text = claveProducto
            Me.txtNombreProducto.Text = nombreProducto
            Me.txtExistencia.Text = existenciaProducto

        End If
    End Sub

    Private Sub DataGridProductos_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridProductos.RowEnter
        If (e.RowIndex >= 0) Then
            Dim idProducto As String
            Dim claveProducto As String
            Dim nombreProducto As String
            Dim existenciaProducto As String

            idProducto = DataGridProductos.Rows(e.RowIndex).Cells(0).Value.ToString()
            claveProducto = DataGridProductos.Rows(e.RowIndex).Cells(1).Value.ToString()
            nombreProducto = DataGridProductos.Rows(e.RowIndex).Cells(2).Value.ToString()
            existenciaProducto = DataGridProductos.Rows(e.RowIndex).Cells(3).Value.ToString()

            Me.lblIdProducto.Text = idProducto
            Me.txtClaveProducto.Text = claveProducto
            Me.txtNombreProducto.Text = nombreProducto
            Me.txtExistencia.Text = existenciaProducto

        End If
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.cmdCancelar.Visible = False
        Me.cmdModificar.Text = "&Modificar"

        Me.txtClaveProducto.Text = claveProductoAntesDeModificar
        Me.txtNombreProducto.Text = nombreProductoAntesDeModificar

        Me.DataGridProductos.Enabled = True
        Me.txtClaveProducto.Enabled = False
        Me.txtNombreProducto.Enabled = False


    End Sub
End Class