Imports wpf = System.Windows
' Basisklasse für Algorithmen zum Erzeugen von 2d- Grafikprimitiven mit der Maus
Public MustInherit Class ShapeFactory

    Protected _StepCount As Integer
    Protected ReadOnly Property BuildStepCount As Integer
        Get
            Return _StepCount
        End Get
    End Property

    Dim _Step As Integer = 0
    Public ReadOnly Property BuildStep As Integer
        Get
            Return _Step
        End Get
    End Property

    ' Liste der Stützstellen, auf denen die Figur erzeugt wird (z.B. Start & Endpunkt einer Linie)
    Protected bases As New List(Of wpf.Point)

    ' Mit der Methode werden alle Stützpunkte der Figur erfasst. Nach erfassen des letzten 
    ' Stützpunktes wird die Figur erzeugt und der Zeichnung hinzugefügt
    Public Function CollectBaseAndCreateShape(ByVal pos As wpf.Point, ByVal drawing As Zeichnung) As Boolean
        If _Step < _StepCount - 1 Then
            _Step += 1
            bases.Add(pos)
            Return False
        Else
            bases.Add(pos)
            drawing.Elemente.Add(createShape())

            ' Für nächste erfassung von Stützpunkten bereitmachen
            _Step = 0
            bases.Clear()
            Return True
        End If
    End Function


    ' In einer abgeleiteten Klasse wird in dieser virtuellen Methode über den Stütztstellen 
    ' die eigentliche Figur erzeugt
    Protected MustOverride Function createShape() As wpf.Shapes.Shape

End Class
