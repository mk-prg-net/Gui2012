Imports wpf = System.Windows
Public Class Zeichnung
    Public Elemente As New List(Of wpf.Shapes.Shape)

    Public Sub zeichne(ByVal zeichenbrett As wpf.Controls.Canvas)
        zeichenbrett.Children.Clear()

        For Each sh In Elemente
            zeichenbrett.Children.Add(sh)
        Next
    End Sub

    Public Sub auswählen(ByVal ix As Integer)
        For i As Integer = 0 To Elemente.Count - 1
            If i = ix Then
                Elemente(i).Fill = Brushes.Red
                Elemente(i).Stroke = Brushes.Blue
            Else
                Elemente(i).Fill = Brushes.Transparent
                Elemente(i).Stroke = Brushes.Black
            End If
        Next
    End Sub

    Public Sub auswählen(ByVal pos As Point)
        For i As Integer = 0 To Elemente.Count - 1
            If Elemente(i).IsMouseOver Then
                'Elemente(i).Fill = Brushes.Red
                Elemente(i).Stroke = Brushes.Blue
            Else
                'Elemente(i).Fill = Brushes.Transparent
                Elemente(i).Stroke = Brushes.Black
            End If
        Next
    End Sub
End Class
