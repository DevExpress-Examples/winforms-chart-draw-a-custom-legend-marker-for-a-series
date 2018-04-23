# How to: draw a custom legend marker for a series


This example demonstrates one of possible ways to use the <a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraChartsChartControl_CustomDrawSeriestopic">CustomDrawSeries</a> event. In this sample the event is used to modify the legend markers of bar series.


<h3>Description</h3>

A custom legend marker is set to the&nbsp;<a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraChartsCustomDrawSeriesEventArgs_LegendMarkerImagetopic">e.LegendMarkerImage</a>&nbsp;property. Note that in this case the&nbsp;<a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraChartsCustomDrawSeriesEventArgs_DisposeLegendMarkerImagetopic">e.DisposeLegendMarkerImage</a>&nbsp;property should be set to true to avoid memory leaks.<br>To customize options used to draw the series, cast <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraChartsCustomDrawSeriesEventArgs_SeriesDrawOptionstopic">e.SeriesDrawOptions</a>&nbsp;to the&nbsp;<a href="https://documentation.devexpress.com/#CoreLibraries/clsDevExpressXtraChartsDrawOptionstopic">DrawOptions&nbsp;</a>class descendant that stores draw options of the required series view type.

<br/>


