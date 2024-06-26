<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128574502/22.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T332672)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# Chart for WinForms - Draw a Custom Legend Marker for a Series

This example demonstrates how to use the [CustomDrawSeries](https://docs.devexpress.com/WindowsForms/DevExpress.XtraCharts.ChartControl.CustomDrawSeries?v=22.2&p=netframework) event to modify the legend markers of bar series.

![Chart](./image/Chart.png)

Assign a custom legend marker to the [LegendMarkerImage](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraCharts.CustomDrawSeriesEventArgsBase.LegendMarkerImage?p=netframework) property. Set the [DisposeLegendMarkerImage](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraCharts.CustomDrawSeriesEventArgsBase.DisposeLegendMarkerImage?p=netframework) property to `true` to avoid memory leaks. To customize options used to draw the series, cast [e.SeriesDrawOptions](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraCharts.CustomDrawSeriesEventArgsBase.SeriesDrawOptions) to the
[DrawOptions](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraCharts.DrawOptions?v=22.2) class descendant that stores draw options of the required series view type.

## Files to Review

* **[Form1.cs](./CS/CustomDrawingSample/Form1.cs) (VB: [Form1.vb](./VB/CustomDrawingSample/Form1.vb))**
* [Employee.cs](./CS/CustomDrawingSample/Model/Employee.cs) (VB: [Employee.vb](./VB/CustomDrawingSample/Model/Employee.vb))
* [NwindDbContext.cs](./CS/CustomDrawingSample/Model/NwindDbContext.cs) (VB: [NwindDbContext.vb](./VB/CustomDrawingSample/Model/NwindDbContext.vb))
* [Order.cs](./CS/CustomDrawingSample/Model/Order.cs) (VB: [Order.vb](./VB/CustomDrawingSample/Model/Order.vb))

## Documentation 

[Legend Marker](https://docs.devexpress.com/WindowsForms/1985/controls-and-libraries/chart-control/visual-elements/legend-marker?p=netframework)

## More Examples

- [Chart for WinForms - How to Add Images for Legend Items](https://github.com/DevExpress-Examples/how-to-provide-images-for-legend-items-e2123)
- [Chart for WinForms - Draw a Custom Legend Marker for a Series Point](https://github.com/DevExpress-Examples/winforms-chart-draw-a-custom-legend-marker-for-a-series-point)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-chart-draw-a-custom-legend-marker-for-a-series&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-chart-draw-a-custom-legend-marker-for-a-series&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
