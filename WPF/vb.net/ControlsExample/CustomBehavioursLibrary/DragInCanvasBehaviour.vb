Imports System.Windows.Interactivity	' Behavior
Imports System.Windows					' UIElement
Imports System.Windows.Controls			' Canvas
Imports System.Windows.Input			' MouseButtonEventArgs
Imports System.Windows.Media			' VisualTreeHelper

Public Class DragInCanvasBehaviour
	Inherits Behavior(Of UIElement)

	' Variables
	Private canvas As Canvas					' Keep track of the canvas where this element is placed
	Private isDragging As Boolean = False		' Keep track of when element is dragged
	Private mouseOffset As Point				' Record exact position of where the click was made

	Protected Overrides Sub OnAttached()
		MyBase.OnAttached()

		' Hook up event handlers
		AddHandler AssociatedObject.MouseLeftButtonDown, AddressOf AssociatedObject_MouseLeftButtonDown
		AddHandler AssociatedObject.MouseMove, AddressOf AssociatedObject_MouseMove
		AddHandler AssociatedObject.MouseLeftButtonUp, AddressOf AssociatedObject_MouseLeftButtonUp

	End Sub

	Protected Overrides Sub OnDetaching()
		MyBase.OnDetaching()

		' Detach event handlers
		RemoveHandler AssociatedObject.MouseLeftButtonDown, AddressOf AssociatedObject_MouseLeftButtonDown
		RemoveHandler AssociatedObject.MouseMove, AddressOf AssociatedObject_MouseMove
		RemoveHandler AssociatedObject.MouseLeftButtonUp, AddressOf AssociatedObject_MouseLeftButtonUp

	End Sub

	Private Sub AssociatedObject_MouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)

		If canvas Is Nothing Then
			canvas = CType(VisualTreeHelper.GetParent(Me.AssociatedObject), Canvas)
		End If

		isDragging = True								' Dragging mode begins
		mouseOffset = e.GetPosition(AssociatedObject)	' Get position of the click related to AssociatedObject
		AssociatedObject.CaptureMouse()					' Capture the mouse - so all mouse events are still received

	End Sub

	Private Sub AssociatedObject_MouseLeftButtonUp(ByVal sender As Object, ByVal e As MouseButtonEventArgs)

		If isDragging Then
			AssociatedObject.ReleaseMouseCapture()
			isDragging = False
		End If

	End Sub

	Private Sub AssociatedObject_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)

		If isDragging Then
			Dim point As Point = e.GetPosition(canvas) ' Get the position of the element relative to the canvas
			' Move the element
			AssociatedObject.SetValue(canvas.TopProperty, point.Y - mouseOffset.Y)
			AssociatedObject.SetValue(canvas.LeftProperty, point.X - mouseOffset.X)
		End If

	End Sub

End Class
