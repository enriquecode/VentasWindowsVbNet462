<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ABCProductos
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
        Me.txtClaveProducto = New System.Windows.Forms.TextBox()
        Me.lblClaveProducto = New System.Windows.Forms.Label()
        Me.lblNombreProducto = New System.Windows.Forms.Label()
        Me.txtNombreProducto = New System.Windows.Forms.TextBox()
        Me.lblExistencia = New System.Windows.Forms.Label()
        Me.txtExistencia = New System.Windows.Forms.TextBox()
        Me.DataGridProductos = New System.Windows.Forms.DataGridView()
        Me.cmdInsertar = New System.Windows.Forms.Button()
        Me.cmdNuevo = New System.Windows.Forms.Button()
        Me.cmdModificar = New System.Windows.Forms.Button()
        Me.lblIdProducto = New System.Windows.Forms.Label()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        CType(Me.DataGridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtClaveProducto
        '
        Me.txtClaveProducto.Location = New System.Drawing.Point(84, 27)
        Me.txtClaveProducto.Name = "txtClaveProducto"
        Me.txtClaveProducto.Size = New System.Drawing.Size(100, 20)
        Me.txtClaveProducto.TabIndex = 1
        '
        'lblClaveProducto
        '
        Me.lblClaveProducto.AutoSize = True
        Me.lblClaveProducto.Location = New System.Drawing.Point(12, 30)
        Me.lblClaveProducto.Name = "lblClaveProducto"
        Me.lblClaveProducto.Size = New System.Drawing.Size(34, 13)
        Me.lblClaveProducto.TabIndex = 0
        Me.lblClaveProducto.Text = "&Clave"
        '
        'lblNombreProducto
        '
        Me.lblNombreProducto.AutoSize = True
        Me.lblNombreProducto.Location = New System.Drawing.Point(12, 57)
        Me.lblNombreProducto.Name = "lblNombreProducto"
        Me.lblNombreProducto.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreProducto.TabIndex = 2
        Me.lblNombreProducto.Text = "&Nombre"
        '
        'txtNombreProducto
        '
        Me.txtNombreProducto.Location = New System.Drawing.Point(84, 53)
        Me.txtNombreProducto.Name = "txtNombreProducto"
        Me.txtNombreProducto.Size = New System.Drawing.Size(100, 20)
        Me.txtNombreProducto.TabIndex = 3
        '
        'lblExistencia
        '
        Me.lblExistencia.AutoSize = True
        Me.lblExistencia.Location = New System.Drawing.Point(12, 89)
        Me.lblExistencia.Name = "lblExistencia"
        Me.lblExistencia.Size = New System.Drawing.Size(55, 13)
        Me.lblExistencia.TabIndex = 4
        Me.lblExistencia.Text = "Existencia"
        '
        'txtExistencia
        '
        Me.txtExistencia.Enabled = False
        Me.txtExistencia.Location = New System.Drawing.Point(84, 85)
        Me.txtExistencia.Name = "txtExistencia"
        Me.txtExistencia.Size = New System.Drawing.Size(100, 20)
        Me.txtExistencia.TabIndex = 5
        '
        'DataGridProductos
        '
        Me.DataGridProductos.AllowUserToAddRows = False
        Me.DataGridProductos.AllowUserToDeleteRows = False
        Me.DataGridProductos.AllowUserToResizeColumns = False
        Me.DataGridProductos.AllowUserToResizeRows = False
        Me.DataGridProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridProductos.Location = New System.Drawing.Point(30, 160)
        Me.DataGridProductos.MultiSelect = False
        Me.DataGridProductos.Name = "DataGridProductos"
        Me.DataGridProductos.ReadOnly = True
        Me.DataGridProductos.Size = New System.Drawing.Size(422, 150)
        Me.DataGridProductos.TabIndex = 6
        '
        'cmdInsertar
        '
        Me.cmdInsertar.Location = New System.Drawing.Point(239, 56)
        Me.cmdInsertar.Name = "cmdInsertar"
        Me.cmdInsertar.Size = New System.Drawing.Size(75, 23)
        Me.cmdInsertar.TabIndex = 7
        Me.cmdInsertar.Text = "&Insertar"
        Me.cmdInsertar.UseVisualStyleBackColor = True
        '
        'cmdNuevo
        '
        Me.cmdNuevo.Location = New System.Drawing.Point(239, 27)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(75, 23)
        Me.cmdNuevo.TabIndex = 8
        Me.cmdNuevo.Text = "N&uevo"
        Me.cmdNuevo.UseVisualStyleBackColor = True
        '
        'cmdModificar
        '
        Me.cmdModificar.Location = New System.Drawing.Point(239, 89)
        Me.cmdModificar.Name = "cmdModificar"
        Me.cmdModificar.Size = New System.Drawing.Size(75, 23)
        Me.cmdModificar.TabIndex = 9
        Me.cmdModificar.Text = "&Modificar"
        Me.cmdModificar.UseVisualStyleBackColor = True
        '
        'lblIdProducto
        '
        Me.lblIdProducto.AutoSize = True
        Me.lblIdProducto.Location = New System.Drawing.Point(371, 33)
        Me.lblIdProducto.Name = "lblIdProducto"
        Me.lblIdProducto.Size = New System.Drawing.Size(59, 13)
        Me.lblIdProducto.TabIndex = 10
        Me.lblIdProducto.Text = "IdProducto"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(330, 89)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelar.TabIndex = 11
        Me.cmdCancelar.Text = "C&ancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        Me.cmdCancelar.Visible = False
        '
        'ABCProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.lblIdProducto)
        Me.Controls.Add(Me.cmdModificar)
        Me.Controls.Add(Me.cmdNuevo)
        Me.Controls.Add(Me.cmdInsertar)
        Me.Controls.Add(Me.DataGridProductos)
        Me.Controls.Add(Me.txtExistencia)
        Me.Controls.Add(Me.lblExistencia)
        Me.Controls.Add(Me.txtNombreProducto)
        Me.Controls.Add(Me.lblNombreProducto)
        Me.Controls.Add(Me.lblClaveProducto)
        Me.Controls.Add(Me.txtClaveProducto)
        Me.Name = "ABCProductos"
        Me.Text = "ABCProductos"
        CType(Me.DataGridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtClaveProducto As TextBox
    Friend WithEvents lblClaveProducto As Label
    Friend WithEvents lblNombreProducto As Label
    Friend WithEvents txtNombreProducto As TextBox
    Friend WithEvents lblExistencia As Label
    Friend WithEvents txtExistencia As TextBox
    Friend WithEvents DataGridProductos As DataGridView
    Friend WithEvents cmdInsertar As Button
    Friend WithEvents cmdNuevo As Button
    Friend WithEvents cmdModificar As Button
    Friend WithEvents lblIdProducto As Label
    Friend WithEvents cmdCancelar As Button
End Class
