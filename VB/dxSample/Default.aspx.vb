Imports DevExpress.XtraCharts
Imports DevExpress.XtraCharts.Web
Imports System
Imports System.Data
Imports System.Globalization

Namespace dxSample
    Partial Public Class [Default]
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            Me.Viewer.Controls.Clear()
            Dim chartControl As WebChartControl = CreateWebChartControl()
            chartControl.Height = New System.Web.UI.WebControls.Unit(300)
            chartControl.Width = New System.Web.UI.WebControls.Unit(600)
            Dim series1 As Series = CreateSeries("Series1", 1)
            Dim series2 As Series = CreateSeries("Series2", 2)
            chartControl.Series.Add(series1)
            chartControl.Series.Add(series2)
            Me.Viewer.Controls.Add(chartControl)
        End Sub

        Private Function CreateWebChartControl() As WebChartControl
            Dim chartControl As New WebChartControl()
            chartControl.Legend.UseCheckBoxes = True
            chartControl.EnableViewState = False
            chartControl.SaveStateOnCallbacks = False
            AddHandler chartControl.LegendItemChecked, AddressOf chartControl_LegendItemChecked
            Return chartControl
        End Function
        Private Function CreateSeries(ByVal seriesName As String, ByVal randomValueSeek As Integer) As Series
            Dim series As New Series(seriesName, ViewType.Line)
            series.ArgumentDataMember = "Argument"
            series.ValueDataMembers(0) = "Value"
            series.DataSource = CreateTestDataTable(randomValueSeek)
            series.CheckedInLegend = LoadSeriesLegendCheckState(seriesName)
            Return series
        End Function
        Private Function LoadSeriesLegendCheckState(ByVal seriesName As String) As Boolean
            Dim state As Object = Session(seriesName & "LegendCheckState")
            If state Is Nothing Then
                Return True
            Else
                Return DirectCast(state, Boolean)
            End If
        End Function
        Private Sub SaveSeriesLegendCheckState(ByVal seriesName As String, ByVal state As Boolean)
            Session(seriesName & "LegendCheckState") = state
        End Sub
        Private Sub chartControl_LegendItemChecked(ByVal sender As Object, ByVal e As LegendItemCheckedEventArgs)
            Dim chartControl As WebChartControl = DirectCast(sender, WebChartControl)
            For Each series As Series In chartControl.Series
                SaveSeriesLegendCheckState(series.Name, series.CheckedInLegend)
            Next series
        End Sub
        Private Function CreateTestDataTable(ByVal seek As Integer) As DataTable
            Const rowCount As Integer = 15
            Dim table = New DataTable("Test")
            table.Columns.Add("Argument", GetType(Object))
            table.Columns.Add("Value", GetType(Integer))
            Dim rnd = New Random(seek)
            For i = 1 To rowCount - 1
                Dim row = table.NewRow()
                row("Argument") = String.Format(CultureInfo.CurrentCulture, "Week {0}", i)
                row("Value") = rnd.Next(40, 80)
                table.Rows.Add(row)
            Next i
            Return table
        End Function
    End Class
End Namespace