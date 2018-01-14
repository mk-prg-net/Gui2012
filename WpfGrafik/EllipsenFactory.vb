Public Class EllipsenFactory
    Inherits ShapeFactory

    Public Sub New()
        _StepCount = 2
    End Sub


    Protected Overrides Function createShape() As System.Windows.Shapes.Shape
        Return New Ellipse() With {
                                   .HorizontalAlignment = HorizontalAlignment.Left,
                                   .VerticalAlignment = VerticalAlignment.Top,
                                   .Margin = New Thickness() With {.Top = Math.Min(bases(0).Y, bases(1).Y),
                                                                   .Left = Math.Min(bases(0).X, bases(1).X)},
                                   .Stroke = Brushes.Black,
                                   .Width = Math.Abs(bases(0).X - bases(1).X),
                                   .Height = Math.Abs(bases(0).Y - bases(1).Y)}

    End Function
End Class
