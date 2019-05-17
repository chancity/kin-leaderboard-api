using System;
using System.Linq;
using System.Threading.Tasks;
using BlazorFrontEnd.Api;
using ChartJs.Blazor.ChartJS.LineChart;
using ChartJs.Blazor.Charts;
using kin_leaderboard_frontend.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorFrontEnd.Components.AppCard
{
    public class AppCard : ComponentBase
    {
        [Inject]
        protected ApiClient Http { get; private set; }

        [Parameter]
        protected Appp App { get; set; }

        [Parameter]
        private string StartDay { get; set; } = "0";

        [Parameter]
        private string EndDay { get; set; } = "9554006396";

        protected AppMetric[] AppMetrics { get; set; }

        protected ChartJsLineChart lineChartJs;
        protected LineChartConfig lineChartConfig;
        public AppCard(Appp app)
        {
            App = app;
        }
        public AppCard()
        {

        }

        protected override async Task OnInitAsync()
        {
            AppMetrics = await Http.GetJsonAsync<AppMetric[]>($"api/Metrics/{App.AppId}/{StartDay}/{EndDay}");
            AppMetrics = AppMetrics.Reverse().ToArray();
            var labels = AppMetrics.Select(x => DateTimeOffset.FromUnixTimeSeconds(x.EpochTime).LocalDateTime.ToString("MM/dd")).ToList();
            var points = AppMetrics.Select(x => x.OperationCount).OfType<object>().ToList();
            lineChartConfig = CardChartData.GetLineConfig("Operations by day", App.AppId, labels, points);
            lineChartJs = new ChartJsLineChart();
        }
    }


}
