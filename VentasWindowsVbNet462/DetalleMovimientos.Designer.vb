<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DetalleMovimientos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.comboProductos = New System.Windows.Forms.ComboBox()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.DataGridDetalle = New System.Windows.Forms.DataGridView()
        Me.cmdAgregar = New System.Windows.Forms.Button()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.cmdModificar = New System.Windows.Forms.Button()
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdNuevo = New System.Windows.Forms.Button()
        Me.cmdGuardarBD = New System.Windows.Forms.Button()
        CType(Me.DataGridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'comboProductos
        '
        Me.comboProductos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.comboProductos.FormattingEnabled = True
        Me.comboProductos.Location = New System.Drawing.Point(106, 31)
        Me.comboProductos.Name = "comboProductos"
        Me.comboProductos.Size = New System.Drawing.Size(410, 21)
        Me.comboProductos.TabIndex = 1
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.Location = New System.Drawing.Point(12, 34)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(50, 13)
        Me.lblProducto.TabIndex = 0
        Me.lblProducto.Text = "Pr&oducto"
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Location = New System.Drawing.Point(15, 66)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(49, 13)
        Me.lblCantidad.TabIndex = 2
        Me.lblCantidad.Text = "&Cantidad"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(106, 63)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(100, 20)
        Me.txtCantidad.TabIndex = 3
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPrecio
        '
        Me.lblPrecio.AutoSize = True
        Me.lblPrecio.Location = New System.Drawing.Point(18, 94)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(37, 13)
        Me.lblPrecio.TabIndex = 4
        Me.lblPrecio.Text = "&Precio"
        '
        'txtPrecio
        '
        Me.txtPrecio.Location = New System.Drawing.Point(106, 94)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(100, 20)
        Me.txtPrecio.TabIndex = 5
        Me.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DataGridDetalle
        '
        Me.DataGridDetalle.AllowUserToAddRows = False
        Me.DataGridDetalle.AllowUserToDeleteRows = False
        Me.DataGridDetalle.AllowUserToOrderColumns = True
        Me.DataGridDetalle.AllowUserToResizeColumns = False
        Me.DataGridDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridDetalle.Location = New System.Drawing.Point(18, 195)
        Me.DataGridDetalle.Name = "DataGridDetalle"
        Me.DataGridDetalle.ReadOnly = True
        Me.DataGridDetalle.Size = New System.Drawing.Size(656, 150)
        Me.DataGridDetalle.TabIndex = 9
        '
        'cmdAgregar
        '
        Me.cmdAgregar.Location = New System.Drawing.Point(245, 92)
        Me.cmdAgregar.Name = "cmdAgregar"
        Me.cmdAgregar.Size = New System.Drawing.Size(75, 23)
        Me.cmdAgregar.TabIndex = 8
        Me.cmdAgregar.Text = "A&gregar"
        Me.cmdAgregar.UseVisualStyleBackColor = True
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(21, 125)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(31, 13)
        Me.lblTotal.TabIndex = 6
        Me.lblTotal.Text = "Total"
        '
        'txtTotal
        '
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(106, 125)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtTotal.TabIndex = 7
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdModificar
        '
        Me.cmdModificar.Enabled = False
        Me.cmdModificar.Location = New System.Drawing.Point(245, 126)
        Me.cmdModificar.Name = "cmdModificar"
        Me.cmdModificar.Size = New System.Drawing.Size(75, 23)
        Me.cmdModificar.TabIndex = 10
        Me.cmdModificar.Text = "&Modificar"
        Me.cmdModificar.UseVisualStyleBackColor = True
        '
        'cmdEliminar
        '
        Me.cmdEliminar.Enabled = False
        Me.cmdEliminar.Location = New System.Drawing.Point(245, 156)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(75, 23)
        Me.cmdEliminar.TabIndex = 11
        Me.cmdEliminar.Text = "&Eliminar"
        Me.cmdEliminar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(327, 126)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelar.TabIndex = 12
        Me.cmdCancelar.Text = "C&ancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        Me.cmdCancelar.Visible = False
        '
        'cmdNuevo
        '
        Me.cmdNuevo.Enabled = False
        Me.cmdNuevo.Location = New System.Drawing.Point(245, 58)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(75, 23)
        Me.cmdNuevo.TabIndex = 13
        Me.cmdNuevo.Text = "&Nuevo"
        Me.cmdNuevo.UseVisualStyleBackColor = True
        '
        'cmdGuardarBD
        '
        Me.cmdGuardarBD.Location = New System.Drawing.Point(353, 97)
        Me.cmdGuardarBD.Name = "cmdGuardarBD"
        Me.cmdGuardarBD.Size = New System.Drawing.Size(75, 62)
        Me.cmdGuardarBD.TabIndex = 14
        Me.cmdGuardarBD.Text = "Guardar en &Sistema"
        Me.cmdGuardarBD.UseVisualStyleBackColor = True
        '
        'DetalleMovimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.cmdGuardarBD)
        Me.Controls.Add(Me.cmdNuevo)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdEliminar)
        Me.Controls.Add(Me.cmdModificar)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.cmdAgregar)
        Me.Controls.Add(Me.DataGridDetalle)
        Me.Controls.Add(Me.txtPrecio)
        Me.Controls.Add(Me.lblPrecio)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.lblCantidad)
        Me.Controls.Add(Me.lblProducto)
        Me.Controls.Add(Me.comboProductos)
        Me.Name = "DetalleMovimientos"
        Me.Text = "Detalle de Movimientos"
        CType(Me.DataGridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents comboProductos As ComboBox
    Friend WithEvents lblProducto As Label
    Friend WithEvents lblCantidad As Label
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents lblPrecio As Label
    Friend WithEvents txtPrecio As TextBox
    Friend WithEvents DataGridDetalle As DataGridView
    Friend WithEvents cmdAgregar As Button
    Friend WithEvents lblTotal As Label
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents cmdModificar As Button
    Friend WithEvents cmdEliminar As Button
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents cmdNuevo As Button
    Friend WithEvents cmdGuardarBD As Button
End Class
