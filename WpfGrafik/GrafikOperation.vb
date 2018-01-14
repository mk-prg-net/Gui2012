Imports wpf = System.Windows
Public Class GrafikOperation

    Public Enum EnumOp
        LinieZeichnen
        EllipseZeichnen
    End Enum

    Dim _op As EnumOp = EnumOp.LinieZeichnen
    Public Property Op As EnumOp
        Get
            Return _op
        End Get
        Set(ByVal value As EnumOp)
            If _op <> value Then
                starteOp = True
            End If
            _op = value
        End Set
    End Property
    Public Zeichnung As New List(Of wpf.Shapes.Shape)

    Public start As wpf.Point
    Public ende As wpf.Point

    Public starteOp As Boolean = True

    Public Z As Zeichnung
    Public cv As wpf.Controls.Canvas

    Public Sub exe(ByVal pos As wpf.Point)
        If starteOp Then
            starteOp = False
            start = pos
        Else
            starteOp = True
            ende = pos

            Select Case Op
                Case EnumOp.EllipseZeichnen
                    Z.Elemente.Add(New Ellipse() With {
                                   .HorizontalAlignment = HorizontalAlignment.Left,
                                   .VerticalAlignment = VerticalAlignment.Top,
                                   .Margin = New Thickness() With {.Top = Math.Min(start.Y, ende.Y),
                                                                   .Left = Math.Min(start.X, ende.X)},
                                   .Stroke = Brushes.Black,
                                   .Width = Math.Abs(start.X - ende.X),
                                   .Height = Math.Abs(start.Y - ende.Y)})
                Case EnumOp.LinieZeichnen
                    Z.Elemente.Add(New Line() With {
                                   .Stroke = Brushes.Black,
                                   .StrokeThickness = 5,
                                   .Fill = Brushes.Black,
                                   .Width = Math.Abs(start.X - ende.X),
                                   .Height = Math.Abs(start.Y - ende.Y),
                                   .X1 = start.X,
                                   .X2 = ende.X,
                                   .Y1 = start.Y,
                                   .Y2 = ende.Y})
            End Select

            Z.zeichne(cv)

        End If
    End Sub


End Class
