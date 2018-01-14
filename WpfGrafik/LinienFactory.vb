Public Class LinienFactory
    Inherits ShapeFactory

    Public Sub New()
        _StepCount = 2
    End Sub

    Protected Overrides Function createShape() As System.Windows.Shapes.Shape
        Return New Line() With {
                                   .Stroke = Brushes.Black,
                                   .StrokeThickness = 5,
                                   .X1 = bases(0).X,
                                   .X2 = bases(1).X,
                                   .Y1 = bases(0).Y,
                                   .Y2 = bases(1).Y}
    End Function
End Class
