Imports System.Data
Imports System.Data.SqlClient

Imports DataLayer

Public Class Compras
    Dim folioMovimientoAntesDeModificar As String
    Dim fechaMovimientoAntesDeModificar As Date
    Dim statusMovimientoAntesDeModificar As Boolean

    Private Sub Compras_Load(sender As Object, e As EventArgs) Handles Me.Load

        LlenaDataGrid()

        If (Me.DataGridCompras.Rows.Count > 0) Then
            Me.cmdInsertarModificarDetalle.Enabled = True
            'Scroll to the first row.
            Me.DataGridCompras.FirstDisplayedScrollingRowIndex = 0

            'Clear the last selection
            Me.DataGridCompras.ClearSelection()

            'Select the first row.
            Me.DataGridCompras.Rows(0).Selected = True

            Dim idMovimiento As String
            Dim folioMovimiento As String
            Dim fechaMovimiento As Date
            Dim totalMovimiento As String
            Dim statusMovimiento As Boolean

            idMovimiento = DataGridCompras.Rows(0).Cells(0).Value.ToString()
            folioMovimiento = DataGridCompras.Rows(0).Cells(1).Value.ToString()
            fechaMovimiento = Convert.ToDateTime(DataGridCompras.Rows(0).Cells(2).Value.ToString())
            totalMovimiento = DataGridCompras.Rows(0).Cells(3).Value.ToString()
            statusMovimiento = Convert.ToBoolean(DataGridCompras.Rows(0).Cells(4).Value.ToString())

            Me.lblIdMovimiento.Text = idMovimiento
            Me.txtFolioMovimiento.Text = folioMovimiento
            Me.dateMovimiento.Value = fechaMovimiento
            Me.txtTotal.Text = totalMovimiento
            Me.chkStatus.Checked = statusMovimiento
            If statusMovimiento Then
                Me.lblStatusTexto.Text = "Vigente"
            Else
                Me.lblStatusTexto.Text = "Cancelada"
            End If
        Else
            Me.cmdInsertarModificarDetalle.Enabled = False
        End If

    End Sub

    Private Sub LlenaDataGrid()
        Dim ds As New DataSet()
        Dim SQLHelper As New SQLHelper()

        Dim arrParams() As SqlParameter = {
            SQLHelper.CreateParameter("@Tipo", SqlDbType.SmallInt, 1)
        }

        ds = SQLHelper.GetDataSet("sp_ObtenerMovimientosEncabezados", CommandType.StoredProcedure, arrParams)

        If (ds.Tables(0).Rows.Count > 0) Then
            Me.txtFolioMovimiento.Enabled = False
            Me.dateMovimiento.Enabled = False
            Me.chkStatus.Enabled = False

            Me.cmdNueva.Enabled = True
            Me.cmdInsertar.Enabled = False
            Me.cmdModificar.Enabled = True

            DataGridCompras.DataSource = ds.Tables(0)
            DataGridCompras.Refresh()

            DataGridCompras.Columns(0).Visible = False


        Else

            Me.cmdNueva.Enabled = False
            Me.cmdInsertar.Enabled = True
            Me.cmdModificar.Enabled = False


        End If

        ds = Nothing
    End Sub

    Private Sub cmdInsertar_Click(sender As Object, e As EventArgs) Handles cmdInsertar.Click
        Dim SQLHelper As New SQLHelper()
        Dim ds As New DataSet()

        Dim folioMovimiento As String
        Dim fechaMovimiento As Date

        folioMovimiento = Trim(Me.txtFolioMovimiento.Text)
        fechaMovimiento = dateMovimiento.Value

        If folioMovimiento.Length < 3 Then
            MessageBox.Show("El folio de movimiento debe de ser al menos 3 letras y numeros")
            Me.txtFolioMovimiento.Select()
            Exit Sub
        End If


        Dim arrParams() As SqlParameter = {
            SQLHelper.CreateParameter("@Tipo", SqlDbType.SmallInt, 1),
            SQLHelper.CreateParameter("@Folio", SqlDbType.VarChar, folioMovimiento),
            SQLHelper.CreateParameter("@Fecha", SqlDbType.DateTime, fechaMovimiento)
        }

        ds = SQLHelper.GetDataSet("sp_InsertarMovimientoEncabezado", CommandType.StoredProcedure, arrParams)

        Dim objectResultadoInsercion As Object = ds.Tables(0).Rows.Item(0).Item("ResultadoInsercion")

        If (objectResultadoInsercion.ToString() = "Exito") Then
            MessageBox.Show("Se insertó correctamente la compra")


            Me.txtFolioMovimiento.Enabled = False
            Me.dateMovimiento.Enabled = False

            Me.cmdNueva.Text = "N&ueva"

            Dim objectIdMovimiento As Object = ds.Tables(0).Rows.Item(0).Item("IdMovimiento")
            lblIdMovimiento.Text = objectIdMovimiento.ToString()

            LlenaDataGrid()

            Me.txtTotal.Text = "0.00"
            Me.lblStatusTexto.Text = "Vigente"

            Dim nLastIndex As Integer
            nLastIndex = DataGridCompras.Rows.Count - 1
            Dim nColumnIndex As Integer
            nColumnIndex = 2

            'Scroll to the last row.
            Me.DataGridCompras.FirstDisplayedScrollingRowIndex = nLastIndex

            'Clear the last selection
            Me.DataGridCompras.ClearSelection()

            'Select the last row.
            Me.DataGridCompras.Rows(nLastIndex).Selected = True


        Else
            If (objectResultadoInsercion.ToString() = "Error Folio de Movimiento Ya Existe") Then
                MessageBox.Show("El Folio del Movimiento ya existe")
                Me.txtFolioMovimiento.Select()

                'se pueden agregar otros errores u excepciones
            End If
        End If
    End Sub

    Private Sub cmdNueva_Click(sender As Object, e As EventArgs) Handles cmdNueva.Click
        If (Me.cmdNueva.Text = "N&ueva") Then
            Me.cmdNueva.Text = "&Cancelar"

            Me.txtFolioMovimiento.Text = ""
            Me.dateMovimiento.Value = Now
            Me.txtTotal.Text = ""
            Me.chkStatus.Checked = True
            Me.lblStatusTexto.Text = "Vigente"
            Me.lblIdMovimiento.Text = ""

            Me.txtFolioMovimiento.Enabled = True
            Me.dateMovimiento.Enabled = True
            Me.txtFolioMovimiento.Select()

            Me.cmdInsertar.Enabled = True
            Me.cmdModificar.Enabled = False
        Else
            Me.cmdNueva.Text = "N&ueva"

            LlenaDataGrid()

            'Scroll to the first row.
            Me.DataGridCompras.FirstDisplayedScrollingRowIndex = 0

            'Clear the last selection
            Me.DataGridCompras.ClearSelection()

            'Select the first row.
            Me.DataGridCompras.Rows(0).Selected = True

            Dim idMovimiento As String
            Dim folioMovimiento As String
            Dim fechaMovimiento As Date
            Dim totalMovimiento As String
            Dim statusMovimiento As Boolean

            idMovimiento = DataGridCompras.Rows(0).Cells(0).Value.ToString()
            folioMovimiento = DataGridCompras.Rows(0).Cells(1).Value.ToString()
            fechaMovimiento = Convert.ToDateTime(DataGridCompras.Rows(0).Cells(2).Value.ToString())
            totalMovimiento = DataGridCompras.Rows(0).Cells(3).Value.ToString()
            statusMovimiento = Convert.ToBoolean(DataGridCompras.Rows(0).Cells(4).Value.ToString())

            Me.lblIdMovimiento.Text = idMovimiento
            Me.txtFolioMovimiento.Text = folioMovimiento
            Me.dateMovimiento.Value = fechaMovimiento
            Me.txtTotal.Text = totalMovimiento
            If statusMovimiento Then
                Me.lblStatusTexto.Text = "Vigente"
            Else
                Me.lblStatusTexto.Text = "Cancelada"
            End If

            Me.cmdModificar.Enabled = True

            Me.txtFolioMovimiento.Enabled = False
            Me.dateMovimiento.Enabled = False

            Me.cmdInsertar.Enabled = False

        End If
    End Sub

    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        If (Me.cmdModificar.Text = "&Modificar") Then
            Me.DataGridCompras.Enabled = False
            Me.txtFolioMovimiento.Enabled = True
            Me.dateMovimiento.Enabled = True
            Me.chkStatus.Enabled = True
            Me.cmdCancelar.Visible = True


            Me.txtFolioMovimiento.Select()
            Me.cmdModificar.Text = "&Guardar"

            folioMovimientoAntesDeModificar = Me.txtFolioMovimiento.Text
            fechaMovimientoAntesDeModificar = Me.dateMovimiento.Value
            statusMovimientoAntesDeModificar = Me.chkStatus.Checked

        Else

            Dim SQLHelper As New SQLHelper()
            Dim ds As New DataSet()

            Dim idMovimiento As String
            Dim folioMovimiento As String
            Dim fechaMovimiento As Date
            Dim statusMovimiento As Boolean

            idMovimiento = Convert.ToInt32(Me.lblIdMovimiento.Text)
            folioMovimiento = Trim(Me.txtFolioMovimiento.Text)
            fechaMovimiento = Me.dateMovimiento.Value
            statusMovimiento = Me.chkStatus.Checked

            If folioMovimiento.Length < 3 Then
                MessageBox.Show("El folio del movimiento debe de ser al menos 3 letras y numeros")
                Me.txtFolioMovimiento.Select()
                Exit Sub
            End If



            Dim arrParams() As SqlParameter = {
                SQLHelper.CreateParameter("@IdMovimiento", SqlDbType.Int, idMovimiento),
                SQLHelper.CreateParameter("@Folio", SqlDbType.VarChar, folioMovimiento),
                SQLHelper.CreateParameter("@Fecha", SqlDbType.DateTime, fechaMovimiento),
                SQLHelper.CreateParameter("@Status", SqlDbType.Bit, statusMovimiento)
                }
            ds = SQLHelper.GetDataSet("sp_ActualizarMovimientoEncabezado", CommandType.StoredProcedure, arrParams)

            Dim objectResultadoActualizacion As Object = ds.Tables(0).Rows.Item(0).Item("ResultadoActualizacion")

            If (objectResultadoActualizacion.ToString() = "Exito") Then
                MessageBox.Show("Se actualizó correctamente el Movimiento")


                Me.txtFolioMovimiento.Enabled = False
                Me.dateMovimiento.Enabled = False
                Me.chkStatus.Checked = statusMovimiento 'quien sabe porque se resetea el valor
                Me.chkStatus.Enabled = False

                Me.cmdNueva.Enabled = True
                Me.DataGridCompras.Enabled = True

                LlenaDataGrid()

                Dim rowindex As Integer
                For Each row As DataGridViewRow In DataGridCompras.Rows
                    If row.Cells.Item("IdMovimiento").Value.ToString() = idMovimiento.ToString() Then
                        rowindex = row.Index
                        'MsgBox(rowindex.ToString())

                        'Scroll to the specific row.
                        Me.DataGridCompras.FirstDisplayedScrollingRowIndex = rowindex

                        'Clear the last selection
                        Me.DataGridCompras.ClearSelection()

                        'Select the specific row.
                        Me.DataGridCompras.Rows(rowindex).Selected = True

                        Exit For
                    End If
                Next

                'no se quedan los valores, esta raro, en productos no pasa lo mismo:
                Me.lblIdMovimiento.Text = idMovimiento
                Me.txtFolioMovimiento.Text = folioMovimiento
                Me.dateMovimiento.Value = fechaMovimiento
                Me.chkStatus.Checked = statusMovimiento
                If statusMovimiento Then
                    Me.lblStatusTexto.Text = "Vigente"
                Else
                    Me.lblStatusTexto.Text = "Cancelada"
                End If

            Else
                If (objectResultadoActualizacion.ToString() = "Error Folio Ya Existe") Then
                    MessageBox.Show("El Folio de Movimiento ya existe")
                    Me.txtFolioMovimiento.Select()

                    'se pueden agregar otros errores u excepciones
                End If
            End If

            Me.cmdModificar.Text = "&Modificar"
            Me.cmdCancelar.Visible = False

        End If
    End Sub

    Private Sub DataGridCompras_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridCompras.CellContentClick
        If (e.RowIndex >= 0) Then
            Dim idMovimiento As String
            Dim folioMovimiento As String
            Dim fechaMovimiento As Date
            Dim totalMovimiento As String
            Dim statusMovimiento As Boolean

            idMovimiento = DataGridCompras.Rows(e.RowIndex).Cells(0).Value.ToString()
            folioMovimiento = DataGridCompras.Rows(e.RowIndex).Cells(1).Value.ToString()
            fechaMovimiento = Convert.ToDateTime(DataGridCompras.Rows(e.RowIndex).Cells(2).Value.ToString())
            totalMovimiento = DataGridCompras.Rows(e.RowIndex).Cells(3).Value.ToString()
            statusMovimiento = Convert.ToBoolean(DataGridCompras.Rows(e.RowIndex).Cells(4).Value.ToString())

            Me.lblIdMovimiento.Text = idMovimiento
            Me.txtFolioMovimiento.Text = folioMovimiento
            Me.dateMovimiento.Value = fechaMovimiento
            Me.txtTotal.Text = totalMovimiento
            If statusMovimiento Then
                Me.lblStatusTexto.Text = "Vigente"
            Else
                Me.lblStatusTexto.Text = "Cancelada"
            End If

        End If
    End Sub

    Private Sub DataGridCompras_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridCompras.CellMouseClick
        If (e.RowIndex >= 0) Then
            Dim idMovimiento As String
            Dim folioMovimiento As String
            Dim fechaMovimiento As Date
            Dim totalMovimiento As String
            Dim statusMovimiento As Boolean

            idMovimiento = DataGridCompras.Rows(e.RowIndex).Cells(0).Value.ToString()
            folioMovimiento = DataGridCompras.Rows(e.RowIndex).Cells(1).Value.ToString()
            fechaMovimiento = Convert.ToDateTime(DataGridCompras.Rows(e.RowIndex).Cells(2).Value.ToString())
            totalMovimiento = DataGridCompras.Rows(e.RowIndex).Cells(3).Value.ToString()
            statusMovimiento = Convert.ToBoolean(DataGridCompras.Rows(e.RowIndex).Cells(4).Value.ToString())

            Me.lblIdMovimiento.Text = idMovimiento
            Me.txtFolioMovimiento.Text = folioMovimiento
            Me.dateMovimiento.Value = fechaMovimiento
            Me.txtTotal.Text = totalMovimiento
            Me.chkStatus.Checked = statusMovimiento
            If statusMovimiento Then
                Me.lblStatusTexto.Text = "Vigente"
            Else
                Me.lblStatusTexto.Text = "Cancelada"
            End If

        End If
    End Sub

    Private Sub DataGridCompras_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridCompras.CellClick
        If (e.RowIndex >= 0) Then
            Dim idMovimiento As String
            Dim folioMovimiento As String
            Dim fechaMovimiento As Date
            Dim totalMovimiento As String
            Dim statusMovimiento As Boolean

            idMovimiento = DataGridCompras.Rows(e.RowIndex).Cells(0).Value.ToString()
            folioMovimiento = DataGridCompras.Rows(e.RowIndex).Cells(1).Value.ToString()
            fechaMovimiento = Convert.ToDateTime(DataGridCompras.Rows(e.RowIndex).Cells(2).Value.ToString())
            totalMovimiento = DataGridCompras.Rows(e.RowIndex).Cells(3).Value.ToString()
            statusMovimiento = Convert.ToBoolean(DataGridCompras.Rows(e.RowIndex).Cells(4).Value.ToString())

            Me.lblIdMovimiento.Text = idMovimiento
            Me.txtFolioMovimiento.Text = folioMovimiento
            Me.dateMovimiento.Value = fechaMovimiento
            Me.txtTotal.Text = totalMovimiento
            Me.chkStatus.Checked = statusMovimiento
            If statusMovimiento Then
                Me.lblStatusTexto.Text = "Vigente"
            Else
                Me.lblStatusTexto.Text = "Cancelada"
            End If

        End If
    End Sub

    Private Sub DataGridCompras_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridCompras.RowEnter
        If (e.RowIndex >= 0) Then
            Dim idMovimiento As String
            Dim folioMovimiento As String
            Dim fechaMovimiento As Date
            Dim totalMovimiento As String
            Dim statusMovimiento As Boolean

            idMovimiento = DataGridCompras.Rows(e.RowIndex).Cells(0).Value.ToString()
            folioMovimiento = DataGridCompras.Rows(e.RowIndex).Cells(1).Value.ToString()
            fechaMovimiento = Convert.ToDateTime(DataGridCompras.Rows(e.RowIndex).Cells(2).Value.ToString())
            totalMovimiento = DataGridCompras.Rows(e.RowIndex).Cells(3).Value.ToString()
            statusMovimiento = Convert.ToBoolean(DataGridCompras.Rows(e.RowIndex).Cells(4).Value.ToString())

            Me.lblIdMovimiento.Text = idMovimiento
            Me.txtFolioMovimiento.Text = folioMovimiento
            Me.dateMovimiento.Value = fechaMovimiento
            Me.txtTotal.Text = totalMovimiento
            Me.chkStatus.Checked = statusMovimiento
            If statusMovimiento Then
                Me.lblStatusTexto.Text = "Vigente"
            Else
                Me.lblStatusTexto.Text = "Cancelada"
            End If

        End If
    End Sub

    Private Sub chkStatus_CheckedChanged(sender As Object, e As EventArgs) Handles chkStatus.CheckedChanged
        If Me.chkStatus.Checked Then
            Me.lblStatusTexto.Text = "Vigente"
        Else
            Me.lblStatusTexto.Text = "Cancelada"
        End If
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.cmdCancelar.Visible = False
        Me.cmdModificar.Text = "&Modificar"

        Me.txtFolioMovimiento.Text = folioMovimientoAntesDeModificar
        Me.dateMovimiento.Value = fechaMovimientoAntesDeModificar
        Me.chkStatus.Checked = statusMovimientoAntesDeModificar

        If statusMovimientoAntesDeModificar Then
            Me.lblStatusTexto.Text = "Vigente"
        Else
            Me.lblStatusTexto.Text = "Cancelada"
        End If

        Me.DataGridCompras.Enabled = True
        Me.txtFolioMovimiento.Enabled = False
        Me.dateMovimiento.Enabled = False
        Me.chkStatus.Enabled = False


    End Sub

    Private Sub cmdInsertarModificarDetalle_Click(sender As Object, e As EventArgs) Handles cmdInsertarModificarDetalle.Click
        Dim idMovimiento As Integer

        idMovimiento = Convert.ToInt32(Me.lblIdMovimiento.Text)

        Dim detalleMovimientos = New DetalleMovimientos(idMovimiento)
        detalleMovimientos.Show()


    End Sub
End Class