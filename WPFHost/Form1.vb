Public Class Form1

    Private Sub btnNewDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewDate.Click
        Dim wpfCtrl As UserControl1 = CType(ElementHost1.Child, UserControl1)
        wpfCtrl.tbxContent.Text = DateTime.Now.ToLongTimeString()
    End Sub
End Class
