Public Class DrawingCanvas
	Inherits Canvas

	Private visuals As New List(Of Visual)()
	Private hits As New List(Of DrawingVisual)()

	''' <summary>
	''' Get number of visuals currently available
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Protected Overrides ReadOnly Property VisualChildrenCount As Integer

		Get
			Return visuals.Count
		End Get

	End Property

	''' <summary>
	''' Return current child by index
	''' </summary>
	''' <param name="index"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	Protected Overrides Function GetVisualChild(ByVal index As Integer) As System.Windows.Media.Visual

		Return visuals(index)

	End Function

	''' <summary>
	''' Add a new visual to the DrawingCanvas
	''' </summary>
	''' <param name="vis"></param>
	''' <remarks></remarks>
	Public Sub AddVisual(ByVal vis As Visual)

		visuals.Add(vis)
		MyBase.AddVisualChild(vis)
		MyBase.AddLogicalChild(vis)

	End Sub

	''' <summary>
	''' Remove selected visual from the DrawingCanvas
	''' </summary>
	''' <param name="vis"></param>
	''' <remarks></remarks>
	Public Sub DeleteVisual(ByVal vis As Visual)

		visuals.Remove(vis)
		MyBase.RemoveVisualChild(vis)
		MyBase.RemoveLogicalChild(vis)

	End Sub

	''' <summary>
	''' Return visual object at the specified position
	''' </summary>
	''' <param name="pt"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Function GetVisual(ByVal pt As Point) As DrawingVisual

		Dim hitResult As HitTestResult = VisualTreeHelper.HitTest(Me, pt)
		Return (TryCast(hitResult.VisualHit, DrawingVisual))

	End Function

	Public Function GetVisuals(ByVal region As Geometry) As List(Of DrawingVisual)

		hits.Clear()

		Dim parameters As New GeometryHitTestParameters(region)
		Dim callback As New HitTestResultCallback(AddressOf Me.HitTestCallback)
		VisualTreeHelper.HitTest(Me, Nothing, callback, parameters)
		Return (hits)

	End Function

	''' <summary>
	''' Method called when multiple hits are registered
	''' </summary>
	''' <param name="result"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	Private Function HitTestCallback(ByVal result As HitTestResult) As HitTestResultBehavior

		Dim geometryResult As GeometryHitTestResult = CType(result, GeometryHitTestResult)
		Dim visual As DrawingVisual = TryCast(result.VisualHit, DrawingVisual)

		If visual IsNot Nothing AndAlso geometryResult.IntersectionDetail = IntersectionDetail.FullyInside Then
			hits.Add(visual)
		End If

		Return (HitTestResultBehavior.Continue)

	End Function

End Class
