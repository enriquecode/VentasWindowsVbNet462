<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Compras
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblIdMovimiento = New System.Windows.Forms.Label()
        Me.cmdModificar = New System.Windows.Forms.Button()
        Me.cmdNueva = New System.Windows.Forms.Button()
        Me.cmdInsertar = New System.Windows.Forms.Button()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblFechaMovimiento = New System.Windows.Forms.Label()
        Me.lblFolioMovimiento = New System.Windows.Forms.Label()
        Me.txtFolioMovimiento = New System.Windows.Forms.TextBox()
        Me.DataGridCompras = New System.Windows.Forms.DataGridView()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblStatusTexto = New System.Windows.Forms.Label()
        Me.dateMovimiento = New System.Windows.Forms.DateTimePicker()
        Me.chkStatus = New System.Windows.Forms.CheckBox()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdInsertarModificarDetalle = New System.Windows.Forms.Button()
        CType(Me.DataGridCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblIdMovimiento
        '
        Me.lblIdMovimiento.AutoSize = True
        Me.lblIdMovimiento.Location = New System.Drawing.Point(377, 30)
        Me.lblIdMovimiento.Name = "lblIdMovimiento"
        Me.lblIdMovimiento.Size = New System.Drawing.Size(70, 13)
        Me.lblIdMovimiento.TabIndex = 21
        Me.lblIdMovimiento.Text = "IdMovimiento"
        '
        'cmdModificar
        '
        Me.cmdModificar.Location = New System.Drawing.Point(245, 86)
        Me.cmdModificar.Name = "cmdModificar"
        Me.cmdModificar.Size = New System.Drawing.Size(75, 23)
        Me.cmdModificar.TabIndex = 22
        Me.cmdModificar.Text = "&Modificar"
        Me.cmdModificar.UseVisualStyleBackColor = True
        '
        'cmdNueva
        '
        Me.cmdNueva.Location = New System.Drawing.Point(245, 24)
        Me.cmdNueva.Name = "cmdNueva"
        Me.cmdNueva.Size = New System.Drawing.Size(75, 23)
        Me.cmdNueva.TabIndex = 20
        Me.cmdNueva.Text = "N&ueva"
        Me.cmdNueva.UseVisualStyleBackColor = True
        '
        'cmdInsertar
        '
        Me.cmdInsertar.Location = New System.Drawing.Point(245, 53)
        Me.cmdInsertar.Name = "cmdInsertar"
        Me.cmdInsertar.Size = New System.Drawing.Size(75, 23)
        Me.cmdInsertar.TabIndex = 21
        Me.cmdInsertar.Text = "&Insertar"
        Me.cmdInsertar.UseVisualStyleBackColor = True
        '
        'txtTotal
        '
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(112, 83)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtTotal.TabIndex = 16
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(18, 86)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(31, 13)
        Me.lblTotal.TabIndex = 15
        Me.lblTotal.Text = "Total"
        '
        'lblFechaMovimiento
        '
        Me.lblFechaMovimiento.AutoSize = True
        Me.lblFechaMovimiento.Location = New System.Drawing.Point(18, 54)
        Me.lblFechaMovimiento.Name = "lblFechaMovimiento"
        Me.lblFechaMovimiento.Size = New System.Drawing.Size(91, 13)
        Me.lblFechaMovimiento.TabIndex = 13
        Me.lblFechaMovimiento.Text = "F&echaMovimiento"
        '
        'lblFolioMovimiento
        '
        Me.lblFolioMovimiento.AutoSize = True
        Me.lblFolioMovimiento.Location = New System.Drawing.Point(18, 27)
        Me.lblFolioMovimiento.Name = "lblFolioMovimiento"
        Me.lblFolioMovimiento.Size = New System.Drawing.Size(29, 13)
        Me.lblFolioMovimiento.TabIndex = 11
        Me.lblFolioMovimiento.Text = "&Folio"
        '
        'txtFolioMovimiento
        '
        Me.txtFolioMovimiento.Location = New System.Drawing.Point(112, 23)
        Me.txtFolioMovimiento.Name = "txtFolioMovimiento"
        Me.txtFolioMovimiento.Size = New System.Drawing.Size(100, 20)
        Me.txtFolioMovimiento.TabIndex = 12
        '
        'DataGridCompras
        '
        Me.DataGridCompras.AllowUserToAddRows = False
        Me.DataGridCompras.AllowUserToDeleteRows = False
        Me.DataGridCompras.AllowUserToOrderColumns = True
        Me.DataGridCompras.AllowUserToResizeColumns = False
        Me.DataGridCompras.AllowUserToResizeRows = False
        Me.DataGridCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridCompras.Location = New System.Drawing.Point(24, 154)
        Me.DataGridCompras.MultiSelect = False
        Me.DataGridCompras.Name = "DataGridCompras"
        Me.DataGridCompras.ReadOnly = True
        Me.DataGridCompras.Size = New System.Drawing.Size(450, 147)
        Me.DataGridCompras.TabIndex = 22
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(21, 115)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(37, 13)
        Me.lblStatus.TabIndex = 17
        Me.lblStatus.Text = "&Status"
        '
        'lblStatusTexto
        '
        Me.lblStatusTexto.AutoSize = True
        Me.lblStatusTexto.Location = New System.Drawing.Point(150, 115)
        Me.lblStatusTexto.Name = "lblStatusTexto"
        Me.lblStatusTexto.Size = New System.Drawing.Size(0, 13)
        Me.lblStatusTexto.TabIndex = 19
        '
        'dateMovimiento
        '
        Me.dateMovimiento.CustomFormat = ""
        Me.dateMovimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dateMovimiento.Location = New System.Drawing.Point(115, 49)
        Me.dateMovimiento.MaxDate = New Date(2032, 12, 31, 0, 0, 0, 0)
        Me.dateMovimiento.MinDate = New Date(2022, 1, 1, 0, 0, 0, 0)
        Me.dateMovimiento.Name = "dateMovimiento"
        Me.dateMovimiento.Size = New System.Drawing.Size(97, 20)
        Me.dateMovimiento.TabIndex = 23
        Me.dateMovimiento.Value = New Date(2022, 12, 22, 0, 0, 0, 0)
        '
        'chkStatus
        '
        Me.chkStatus.AutoSize = True
        Me.chkStatus.Location = New System.Drawing.Point(115, 114)
        Me.chkStatus.Name = "chkStatus"
        Me.chkStatus.Size = New System.Drawing.Size(15, 14)
        Me.chkStatus.TabIndex = 18
        Me.chkStatus.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(326, 86)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelar.TabIndex = 23
        Me.cmdCancelar.Text = "&Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        Me.cmdCancelar.Visible = False
        '
        'cmdInsertarModificarDetalle
        '
        Me.cmdInsertarModificarDetalle.Location = New System.Drawing.Point(539, 209)
        Me.cmdInsertarModificarDetalle.Name = "cmdInsertarModificarDetalle"
        Me.cmdInsertarModificarDetalle.Size = New System.Drawing.Size(75, 51)
        Me.cmdInsertarModificarDetalle.TabIndex = 24
        Me.cmdInsertarModificarDetalle.Text = "Insertar Modificar &Detalle"
        Me.cmdInsertarModificarDetalle.UseVisualStyleBackColor = True
        '
        'Compras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.cmdInsertarModificarDetalle)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.chkStatus)
        Me.Controls.Add(Me.dateMovimiento)
        Me.Controls.Add(Me.lblStatusTexto)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.DataGridCompras)
        Me.Controls.Add(Me.lblIdMovimiento)
        Me.Controls.Add(Me.cmdModificar)
        Me.Controls.Add(Me.cmdNueva)
        Me.Controls.Add(Me.cmdInsertar)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblFechaMovimiento)
        Me.Controls.Add(Me.lblFolioMovimiento)
        Me.Controls.Add(Me.txtFolioMovimiento)
        Me.Name = "Compras"
        Me.Text = "Compras"
        CType(Me.DataGridCompras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblIdMovimiento As Label
    Friend WithEvents cmdModificar As Button
    Friend WithEvents cmdNueva As Button
    Friend WithEvents cmdInsertar As Button
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblFechaMovimiento As Label
    Friend WithEvents lblFolioMovimiento As Label
    Friend WithEvents txtFolioMovimiento As TextBox
    Friend WithEvents DataGridCompras As DataGridView
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblStatusTexto As Label
    Friend WithEvents dateMovimiento As DateTimePicker
    Friend WithEvents chkStatus As CheckBox
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents cmdInsertarModificarDetalle As Button
End Class
