<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128574502/15.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T332672)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* **[Form1.cs](./CS/CustomDrawingSample/Form1.cs) (VB: [Form1.vb](./VB/CustomDrawingSample/Form1.vb))**
* [Employee.cs](./CS/CustomDrawingSample/Model/Employee.cs) (VB: [Employee.vb](./VB/CustomDrawingSample/Model/Employee.vb))
* [NwindDbContext.cs](./CS/CustomDrawingSample/Model/NwindDbContext.cs) (VB: [NwindDbContext.vb](./VB/CustomDrawingSample/Model/NwindDbContext.vb))
* [Order.cs](./CS/CustomDrawingSample/Model/Order.cs) (VB: [Order.vb](./VB/CustomDrawingSample/Model/Order.vb))
<!-- default file list end -->
# How to: draw a custom legend marker for a series


This example demonstrates one of possible ways to use the <a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraChartsChartControl_CustomDrawSeriestopic">CustomDrawSeries</a> event. In this sample the event is used to modify the legend markers of bar series.


<h3>Description</h3>

A custom legend marker is set to the&nbsp;<a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraChartsCustomDrawSeriesEventArgs_LegendMarkerImagetopic">e.LegendMarkerImage</a>&nbsp;property. Note that in this case the&nbsp;<a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraChartsCustomDrawSeriesEventArgs_DisposeLegendMarkerImagetopic">e.DisposeLegendMarkerImage</a>&nbsp;property should be set to true to avoid memory leaks.<br>To customize options used to draw the series, cast <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraChartsCustomDrawSeriesEventArgs_SeriesDrawOptionstopic">e.SeriesDrawOptions</a>&nbsp;to the&nbsp;<a href="https://documentation.devexpress.com/#CoreLibraries/clsDevExpressXtraChartsDrawOptionstopic">DrawOptions&nbsp;</a>class descendant that stores draw options of the required series view type.

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-chart-draw-a-custom-legend-marker-for-a-series&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-chart-draw-a-custom-legend-marker-for-a-series&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
