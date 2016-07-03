Imports System.Windows.Media.Animation

Class MainWindow

	Private Sub btnGrow_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)

		Dim widthAnimation As New DoubleAnimation() With {.To = Me.Width - 30, .Duration = TimeSpan.FromSeconds(5)}
		AddHandler widthAnimation.Completed, AddressOf animation_Completed

		Dim heightAnimation As New DoubleAnimation() With {.To = (Me.Height - 50) / 3, .Duration = TimeSpan.FromSeconds(5)}

		btnGrow.BeginAnimation(Button.WidthProperty, widthAnimation)
		btnGrow.BeginAnimation(Button.HeightProperty, heightAnimation)

	End Sub

	Private Sub animation_Completed(ByVal sender As Object, ByVal e As EventArgs)

		'Dim currentWidth As Double = btnGrow.Width
		'btnGrow.BeginAnimation(Button.WidthProperty, Nothing) ' Snap back at the end of the animation
		'btnGrow.Width = currentWidth

		'MessageBox.Show("Completed!")

	End Sub

	Private Sub btnShrink_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

		Dim widthAnimation As New DoubleAnimation() With {.Duration = TimeSpan.FromSeconds(5)}
		Dim heightAnimation As New DoubleAnimation() With {.Duration = TimeSpan.FromSeconds(5)}

		btnGrow.BeginAnimation(Button.WidthProperty, widthAnimation)
		btnGrow.BeginAnimation(Button.HeightProperty, heightAnimation)

	End Sub

	Private Sub btnGrowIncrementally_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

		Dim widthAnimation As New DoubleAnimation() With {.By = 10, .Duration = TimeSpan.FromSeconds(0.5)}
		btnGrowIncrementally.BeginAnimation(Button.WidthProperty, widthAnimation)

	End Sub

	Private Sub sldSpeed_ValueChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)

		fadeStoryboard.SetSpeedRatio(Me, sldSpeed.Value)

	End Sub

	Private Sub storyboard_CurrentTimeInvalidated(ByVal sender As Object, ByVal e As EventArgs)
		' Sender is the clock that was created for this storyboard.
		Dim storyboardClock As Clock = CType(sender, Clock)

		If storyboardClock.CurrentProgress Is Nothing Then
			lblTime.Text = "[[ stopped ]]"
			progressBar.Value = 0
		Else
			lblTime.Text = storyboardClock.CurrentTime.ToString()
			progressBar.Value = CDbl(storyboardClock.CurrentProgress)
		End If
	End Sub

End Class
