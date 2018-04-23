using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Web;
using System;
using System.Data;
using System.Globalization;

namespace dxSample {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            this.Viewer.Controls.Clear();
            WebChartControl chartControl = CreateWebChartControl();
            chartControl.Height = new System.Web.UI.WebControls.Unit(300);
            chartControl.Width = new System.Web.UI.WebControls.Unit(600);
            Series series1 = CreateSeries("Series1", 1);
            Series series2 = CreateSeries("Series2", 2);
            chartControl.Series.Add(series1);
            chartControl.Series.Add(series2);
            this.Viewer.Controls.Add(chartControl);
        }

        WebChartControl CreateWebChartControl() {
            WebChartControl chartControl = new WebChartControl();
            chartControl.Legend.UseCheckBoxes = true;
            chartControl.EnableViewState = false;     
            chartControl.SaveStateOnCallbacks = false;
            chartControl.LegendItemChecked += chartControl_LegendItemChecked; 
            return chartControl;
        }
        Series CreateSeries(string seriesName, int randomValueSeek) {
            Series series = new Series(seriesName, ViewType.Line);
            series.ArgumentDataMember = "Argument";
            series.ValueDataMembers[0] = "Value";
            series.DataSource = CreateTestDataTable(randomValueSeek);
            series.CheckedInLegend = LoadSeriesLegendCheckState(seriesName); 
            return series;
        }
        bool LoadSeriesLegendCheckState(string seriesName) {
            object state = Session[seriesName + "LegendCheckState"];
            if (state == null)
                return true;
            else
                return (bool)state;
        }
        void SaveSeriesLegendCheckState(string seriesName, bool state) {
            Session[seriesName + "LegendCheckState"] = state;
        }
        void chartControl_LegendItemChecked(object sender, LegendItemCheckedEventArgs e) {
            WebChartControl chartControl = (WebChartControl)sender;
            foreach (Series series in chartControl.Series)
                SaveSeriesLegendCheckState(series.Name, series.CheckedInLegend);
        }
        DataTable CreateTestDataTable(int seek) {
            const int rowCount = 15;
            var table = new DataTable("Test");
            table.Columns.Add("Argument", typeof(object));
            table.Columns.Add("Value", typeof(int));
            var rnd = new Random(seek);
            for (var i = 1; i < rowCount; i++) {
                var row = table.NewRow();
                row["Argument"] = string.Format(CultureInfo.CurrentCulture, "Week {0}", i);
                row["Value"] = rnd.Next(40, 80);
                table.Rows.Add(row);
            }
            return table;
        }
    }
}