using CustomDrawingSample.Model;
using DevExpress.Drawing;
using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;

namespace CustomDrawingSample {
    public partial class Form1 : DevExpress.XtraEditors.XtraForm {
        string trackedSeriesName;
        Dictionary<string, DXImage> photoCache = new Dictionary<string, DXImage>();

        #region #Constants
        const int borderSize = 5;
        const int scaledPhotoWidth = 48;
        const int scaledPhotoHeight = 51;
        // Width and height of scaled photo with border.
        const int totalWidth = 58;
        const int totalHeight = 61;

        // Rects required to create a custom legend series marker.
        static readonly Rectangle photoRect = new Rectangle(
                borderSize, borderSize,
                scaledPhotoWidth, scaledPhotoHeight);
        static readonly Rectangle totalRect = new Rectangle(
                0, 0,
                totalWidth, totalHeight);
        #endregion

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            using (var context = new NwindDbContext()) {
                InitPhotoCache(context.Employees);
                chart.DataSource = context.Orders.ToList();
            }

            chart.SeriesDataMember = "Employee.FullName";
            chart.SeriesTemplate.ArgumentDataMember = "OrderDate";
            chart.SeriesTemplate.ValueDataMembers.AddRange("Freight");

            XYDiagram diagram = chart.Diagram as XYDiagram;
            if (diagram != null) {
                diagram.AxisX.DateTimeScaleOptions.AggregateFunction = AggregateFunction.Sum;
                diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Year;
            }

            chart.CustomDrawSeries += OnCustomDrawSeries;
            chart.ObjectHotTracked += OnObjectHotTracked;
        }

        private void OnObjectHotTracked(object sender, HotTrackEventArgs e) {
            trackedSeriesName = e.HitInfo.InSeries ? ((Series)e.HitInfo.Series).Name : null;
        }

        void InitPhotoCache(IEnumerable<Employee> employees) {
            photoCache.Clear();
            foreach (var employee in employees) {
                using (MemoryStream stream = new MemoryStream(employee.Photo)) {
                    if (!photoCache.ContainsKey(employee.FullName))
                        photoCache.Add(employee.FullName, DXImage.FromStream(stream));
                }
            }
        }

        #region #CustomDrawSeriesImplementation
        private void OnCustomDrawSeries(object sender, CustomDrawSeriesEventArgs e) {
            bool isSelected = e.Series.Name.Equals(trackedSeriesName);
            // Design a series marker image.
            DXBitmap image = new DXBitmap(totalWidth, totalHeight);
            using (DXGraphics graphics = DXGraphics.FromImage(image)) {
                using (var fillBrush = isSelected ? (DXBrush)new DXHatchBrush(DXHatchStyle.DarkDownwardDiagonal,
                                                                          e.LegendDrawOptions.Color,
                                                                          e.LegendDrawOptions.ActualColor2)
                                                  : (DXBrush)new DXSolidBrush(e.LegendDrawOptions.Color)) {
                    graphics.FillRectangle(fillBrush, totalRect);
                }
                DXImage photo;
                if (photoCache.TryGetValue(e.Series.Name, out photo))
                    graphics.DrawImage(photo, photoRect);
            }
            e.DXLegendMarkerImage = image;
            e.DisposeLegendMarkerImage = true;

            BarDrawOptions options = e.SeriesDrawOptions as BarDrawOptions;
            if (options != null && isSelected) {
                options.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Hatch;
                ((HatchFillOptions)options.FillStyle.Options).HatchStyle = HatchStyle.DarkDownwardDiagonal;
            }
        }
        #endregion
    }
}
