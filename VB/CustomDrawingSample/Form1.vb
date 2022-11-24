Imports CustomDrawingSample.Model
Imports DevExpress.XtraCharts
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Linq
Imports System.Windows.Forms

Namespace CustomDrawingSample

    Public Partial Class Form1
        Inherits Form

        Private trackedSeriesName As String

        Private photoCache As Dictionary(Of String, Image) = New Dictionary(Of String, Image)()

#Region "#Constants"
        Const borderSize As Integer = 5

        Const scaledPhotoWidth As Integer = 48

        Const scaledPhotoHeight As Integer = 51

        ' Width and height of scaled photo with border.
        Const totalWidth As Integer = 58

        Const totalHeight As Integer = 61

        ' Rects required to create a custom legend series marker.
        Private Shared ReadOnly photoRect As Rectangle = New Rectangle(borderSize, borderSize, scaledPhotoWidth, scaledPhotoHeight)

        Private Shared ReadOnly totalRect As Rectangle = New Rectangle(0, 0, totalWidth, totalHeight)

#End Region
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            Using context = New NwindDbContext()
                InitPhotoCache(context.Employees)
                chart.DataSource = context.Orders.ToList()
            End Using

            chart.SeriesDataMember = "Employee.FullName"
            chart.SeriesTemplate.ArgumentDataMember = "OrderDate"
            chart.SeriesTemplate.ValueDataMembers.AddRange("Freight")
            Dim diagram As XYDiagram = TryCast(chart.Diagram, XYDiagram)
            If diagram IsNot Nothing Then
                diagram.AxisX.DateTimeScaleOptions.AggregateFunction = AggregateFunction.Sum
                diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Year
            End If

            AddHandler chart.CustomDrawSeries, AddressOf OnCustomDrawSeries
            AddHandler chart.ObjectHotTracked, AddressOf OnObjectHotTracked
        End Sub

        Private Sub OnObjectHotTracked(ByVal sender As Object, ByVal e As HotTrackEventArgs)
            trackedSeriesName = If(e.HitInfo.InSeries, CType(e.HitInfo.Series, Series).Name, Nothing)
        End Sub

        Private Sub InitPhotoCache(ByVal employees As IEnumerable(Of Employee))
            photoCache.Clear()
            For Each employee In employees
                Dim stream As MemoryStream = New MemoryStream(employee.Photo)
                If Not photoCache.ContainsKey(employee.FullName) Then photoCache.Add(employee.FullName, Image.FromStream(stream))
            Next
        End Sub

#Region "#CustomDrawSeriesImplementation"
        Private Sub OnCustomDrawSeries(ByVal sender As Object, ByVal e As CustomDrawSeriesEventArgs)
            Dim isSelected As Boolean = e.Series.Name.Equals(trackedSeriesName)
            ' Design a series marker image.
            Dim image As Bitmap = New Bitmap(totalWidth, totalHeight)
            Using graphics As Graphics = Graphics.FromImage(image)
                Dim fillBrush As Brush = If(isSelected, CType(New HatchBrush(HatchStyle.DarkDownwardDiagonal, e.LegendDrawOptions.Color, e.LegendDrawOptions.ActualColor2), Brush), CType(New SolidBrush(e.LegendDrawOptions.Color), Brush))
                graphics.FillRectangle(fillBrush, totalRect)
                Dim photo As Image
                If photoCache.TryGetValue(e.Series.Name, photo) Then graphics.DrawImage(photo, photoRect)
            End Using

            e.LegendMarkerImage = image
            e.DisposeLegendMarkerImage = True
            Dim options As BarDrawOptions = TryCast(e.SeriesDrawOptions, BarDrawOptions)
            If options IsNot Nothing AndAlso isSelected Then
                options.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Hatch
                CType(options.FillStyle.Options, HatchFillOptions).HatchStyle = HatchStyle.DarkDownwardDiagonal
            End If
        End Sub
#End Region
    End Class
End Namespace
