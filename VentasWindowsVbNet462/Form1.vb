Imports DataLayer

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim SQLHelper As New SQLHelper()
        ' SQLHelper.GetDataSet("select * from Productos", CommandType.Text)
        SQLHelper.GetDataSet("sp_ObtenProductos", CommandType.StoredProcedure)

    End Sub

    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click
        Dim ABCProductos = New ABCProductos()
        ABCProductos.Show()

    End Sub

    Private Sub ComprasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComprasToolStripMenuItem.Click
        Dim Compras = New Compras()
        Compras.Show()
    End Sub
End Class
