Imports CustomDrawingSample.Model
Imports DevExpress.Drawing
Imports DevExpress.XtraCharts
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Linq

Namespace CustomDrawingSample
    Partial Public Class Form1
        Inherits DevExpress.XtraEditors.XtraForm

        Private trackedSeriesName As String
        Private photoCache As New Dictionary(Of String, DXImage)()

#Region "#Constants"
        Private Const borderSize As Integer = 5
        Private Const scaledPhotoWidth As Integer = 48
        Private Const scaledPhotoHeight As Integer = 51
        ' Width and height of scaled photo with border.
        Private Const totalWidth As Integer = 58
        Private Const totalHeight As Integer = 61

        ' Rects required to create a custom legend series marker.
        Private Shared ReadOnly photoRect As New Rectangle(borderSize, borderSize, scaledPhotoWidth, scaledPhotoHeight)
        Private Shared ReadOnly totalRect As New Rectangle(0, 0, totalWidth, totalHeight)
#End Region

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
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
                Using stream As New MemoryStream(employee.Photo)
                    If Not photoCache.ContainsKey(employee.FullName) Then
                        photoCache.Add(employee.FullName, DXImage.FromStream(stream))
                    End If
                End Using
            Next employee
        End Sub

#Region "#CustomDrawSeriesImplementation"
        Private Sub OnCustomDrawSeries(ByVal sender As Object, ByVal e As CustomDrawSeriesEventArgs)
            Dim isSelected As Boolean = e.Series.Name.Equals(trackedSeriesName)
            ' Design a series marker image.
            Dim image As New DXBitmap(totalWidth, totalHeight)
            Using graphics As DXGraphics = DXGraphics.FromImage(image)
                Using fillBrush = If(isSelected, CType(New DXHatchBrush(HatchStyle.DarkDownwardDiagonal, e.LegendDrawOptions.Color, e.LegendDrawOptions.ActualColor2), DXBrush), CType(New DXSolidBrush(e.LegendDrawOptions.Color), DXBrush))
                    graphics.FillRectangle(fillBrush, totalRect)
                End Using
                Dim photo As DXImage = Nothing
                If photoCache.TryGetValue(e.Series.Name, photo) Then
                    graphics.DrawImage(photo, photoRect)
                End If
            End Using
            e.DXLegendMarkerImage = image
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
