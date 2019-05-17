using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Legends;
using ChartJs.Blazor.ChartJS.LineChart;

namespace BlazorFrontEnd.Components.AppCard
{
    public class CardChartData
    {
        public static LineChartConfig GetLineConfig(string DataType, string app, List<string> Labels, List<object> Points)
        {
            return new LineChartConfig
            {
                CanvasId = app + "-" + DataType.ToLower().Replace(" ", "-"),
                Options = new LineChartOptions
                {
                    Display = true,
                    Responsive = true,
                    Tooltips = new Tooltips
                    {
                        Mode = Mode.point,
                        Intersect = false
                    },
                    Legend = new Legend()
                    {
                        Display = false
                    },
                    Scales = new Scales
                    {
                        xAxes = new List<Axis>
{
                        new Axis
                        {
                            
                            ScaleLabel = new ScaleLabel
                            {
                                LabelString = ""
                            },
                        
                        }
                    },
                        yAxes = new List<Axis>
{
                        new Axis
                        {
                            ScaleLabel = new ScaleLabel
                            {
                                LabelString = ""
                            }
                        }
                    }
                    },
                    Hover = new LineChartOptionsHover
                    {
                        Intersect = true,
                        Mode = Mode.index
                    }
                },
                Data = new LineChartData
                {
                    Labels = Labels,
                    Datasets = new List<LineChartDataset>
{
                    new LineChartDataset
                    {
                        BackgroundColor = "#ff6384",
                        BorderColor = "#ff6384",
                        Data = Points,
                        Fill = false,
                        BorderWidth = 0,
                        PointRadius = 0,
                        PointBorderWidth = 0
                    }
                }
                }
            };
        }
    }
}
