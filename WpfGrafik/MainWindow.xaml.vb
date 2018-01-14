Class MainWindow 

    ' Zentraler Meldungshub
    Dim log As New mko.CLogVb()

    ' Zeichnung als Liste aus Shape- Elementen
    Dim zb As New Zeichnung

    ' Referenz auf eine Generator für eine Ellipse/Linie/Knick (= Shape)
    ' Der Generator erzeugt die Figur über Stützpunkte, die mit der Maus eingegeben werden
    Dim factory As ShapeFactory = New LinienFactory()

    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        AddHandler log.EventError, Sub(no, msg)
                                       lblStatus.Content = String.Format("{0,7:T} Err: {1}", DateTime.Now, msg)
                                   End Sub

        AddHandler log.EventMsg, Sub(no, msg)
                                     lblStatus.Content = String.Format("{0,7:T} Msg: {1}", DateTime.Now, msg)
                                 End Sub

        AddHandler log.EventStatus, Sub(no, msg)
                                        lblStatus.Content = String.Format("{0,7:T} Sta: {1}", DateTime.Now, msg)
                                    End Sub

    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MenuItem1.Click
        Application.Current.Shutdown()
    End Sub

    Private Sub Canvas1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles Canvas1.MouseDown
        If factory Is Nothing Then
            zb.auswählen(e.GetPosition(Canvas1))
            zb.zeichne(Canvas1)
        ElseIf factory.CollectBaseAndCreateShape(e.GetPosition(Canvas1), zb) Then
            zb.zeichne(Canvas1)
            lbxDrawingElements.Items.Add(New ListBoxItem() With {.Content = factory.GetType().Name})
        End If
        e.Handled = True
    End Sub

    Private Sub btnDrawEllipse_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnDrawEllipse.Click
        factory = New EllipsenFactory()
        log.LogStatus(0, "Ellipse erzeugen")
    End Sub

    Private Sub btnDrawLine_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnDrawLine.Click
        factory = New LinienFactory()
        log.LogStatus(0, "Linie erzeugen")
    End Sub
   
    Private Sub btnDrawKnick_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnDrawKnick.Click
        factory = New KnickFactory()
        log.LogStatus(0, "Knick erzeugen")
    End Sub

    Private Sub btnClearDrawing_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnClearDrawing.Click
        zb.Elemente.Clear()
        lbxDrawingElements.Items.Clear()
        Canvas1.Children.Clear()
    End Sub

    Private Sub lbxDrawingElements_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles lbxDrawingElements.SelectionChanged
        Dim lbx As ListBox = CType(sender, ListBox)
        Dim ix As Integer = lbx.SelectedIndex

        zb.auswählen(ix)
        zb.zeichne(Canvas1)
    End Sub

    Private Sub btnSelectElement_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles btnSelectElement.Click
        factory = Nothing
    End Sub
End Class
