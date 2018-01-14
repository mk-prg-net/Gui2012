<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnNewDate = New System.Windows.Forms.Button()
        Me.ElementHost1 = New System.Windows.Forms.Integration.ElementHost()
        Me.UserControl11 = New WPFHost.UserControl1()
        Me.SuspendLayout()
        '
        'btnNewDate
        '
        Me.btnNewDate.Location = New System.Drawing.Point(14, 413)
        Me.btnNewDate.Name = "btnNewDate"
        Me.btnNewDate.Size = New System.Drawing.Size(297, 39)
        Me.btnNewDate.TabIndex = 1
        Me.btnNewDate.Text = "Neues Datum in WPF Ctrl ausgeben"
        Me.btnNewDate.UseVisualStyleBackColor = True
        '
        'ElementHost1
        '
        Me.ElementHost1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ElementHost1.Location = New System.Drawing.Point(0, 0)
        Me.ElementHost1.Name = "ElementHost1"
        Me.ElementHost1.Size = New System.Drawing.Size(468, 464)
        Me.ElementHost1.TabIndex = 0
        Me.ElementHost1.Text = "ElementHost1"
        Me.ElementHost1.Child = Me.UserControl11
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 464)
        Me.Controls.Add(Me.btnNewDate)
        Me.Controls.Add(Me.ElementHost1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ElementHost1 As System.Windows.Forms.Integration.ElementHost
    Friend UserControl11 As WPFHost.UserControl1
    Friend WithEvents btnNewDate As System.Windows.Forms.Button

End Class
