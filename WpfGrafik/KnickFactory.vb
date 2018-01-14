Public Class KnickFactory
    Inherits ShapeFactory

    Sub New()
        _StepCount = 3
    End Sub

    Protected Overrides Function createShape() As System.Windows.Shapes.Shape
        Dim pc As New PointCollection()
        pc.Add(bases(0))
        pc.Add(bases(1))
        pc.Add(bases(2))

        Return New Polyline() With {
            .HorizontalAlignment = HorizontalAlignment.Left,
            .VerticalAlignment = VerticalAlignment.Top,
            .Stroke = Brushes.Black,
            .StrokeThickness = 5,
            .Points = pc}

    End Function
End Class
