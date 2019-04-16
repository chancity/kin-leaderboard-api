using ChartJs.Blazor.ChartJS.LineChart;
using ChartJs.Blazor.Charts;
using Microsoft.AspNetCore.Components;

namespace BlazorFrontEnd.Comp
{
    public class BaseKinLineChart : ComponentBase
    {
        [Parameter]
        public string Labels { get; set; }
        [Parameter]
        public double[] Points { get; set; }
        [Parameter]
        public LineChartConfig LineChartConfig { get; set; }
        [Parameter]
        public ChartJsLineChart LineChartJs { get; set; }
    }
}
