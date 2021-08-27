<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128575316/15.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T470764)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Default.aspx.cs](./CS/dxSample/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/dxSample/Default.aspx.vb))
<!-- default file list end -->
# How to preserve the Legend checkbox item state when the Series items are created manually
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t470764/)**
<!-- run online end -->


<p><strong>NOTE. </strong>Starting with v17.1, you can optionally save legend checkbox state for the chart's Series collection on callbacks. To activate this feature, enable the WebChartcontrol.<strong>SaveStateOnCallbacks</strong> option. If you prefer to use the manual Legend state initialization approach, set the <strong>SaveStateOnCallbacks</strong> property to <strong>False</strong>.<br><br>WebChartControl does not cache information about Series items and data source initialized at runtime. As a result, the <a href="https://documentation.devexpress.com/#AspNet/CustomDocument16242">Legend item checkbox state</a> cannot be applied correctly. This example illustrates how to save the Legend state into a Session variable and restore it using the Page_Load event handler. The <a href="https://documentation.devexpress.com/#AspNet/DevExpressXtraChartsWebWebChartControl_LegendItemCheckedtopic">WebChartControl.LegendItemChecked</a> event is used to obtain the current Legend panel state. Note that it is also required to disable the internal viewstate management using the WebChartControl.EnableViewState and WebChartControl.SaveStateOnCallbacks properties.<br><br>See also:<br><br><a href="https://www.devexpress.com/Support/Center/p/T470781">How to preserve the Legend checkbox item state when the Series Template approach is used to generate the Series collection</a>;<br><a href="https://www.devexpress.com/Support/Center/p/T504189">How to preserve the Legend checkbox item state in an ASP.NET MVC application</a>.</p>

<br/>


