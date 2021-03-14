using System;
using System.Collections.Generic;
using KSInventory.ViewModels;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace KSInventory.Views
{
    [Preserve(AllMembers = true)]
    public partial class ProductSalesGraphView : ContentView
    {
        List<ChartEntry> chartEntries = new List<ChartEntry>()
        {
            new ChartEntry(212)
            {
                Label = "UWP",
                ValueLabel = "212",
                Color = SKColor.Parse("#2c3e50")
            },
            new ChartEntry(248)
            {
                Label = "Android",
                ValueLabel = "248",
                Color = SKColor.Parse("#77d065")
            },
            new ChartEntry(128)
            {
                Label = "iOS",
                ValueLabel = "128",
                Color = SKColor.Parse("#b455b6")
            },
            new ChartEntry(514)
            {
                Label = "Shared",
                ValueLabel = "514",
                Color = SKColor.Parse("#3498db")
            },
            new ChartEntry(212)
            {
                Label = "UWP",
                ValueLabel = "212",
                Color = SKColor.Parse("#2c3e50")
            },
            new ChartEntry(248)
            {
                Label = "Android",
                ValueLabel = "248",
                Color = SKColor.Parse("#77d065")
            },
            new ChartEntry(128)
            {
                Label = "iOS",
                ValueLabel = "128",
                Color = SKColor.Parse("#b455b6")
            },
            new ChartEntry(514)
            {
                Label = "Shared",
                ValueLabel = "514",
                Color = SKColor.Parse("#3498db")
            },
            new ChartEntry(212)
            {
                Label = "UWP",
                ValueLabel = "212",
                Color = SKColor.Parse("#2c3e50")
            },
            new ChartEntry(248)
            {
                Label = "Android",
                ValueLabel = "248",
                Color = SKColor.Parse("#77d065")
            },
            new ChartEntry(128)
            {
                Label = "iOS",
                ValueLabel = "128",
                Color = SKColor.Parse("#b455b6")
            },
            new ChartEntry(514)
            {
                Label = "Shared",
                ValueLabel = "514",
                Color = SKColor.Parse("#3498db")
            },
            new ChartEntry(212)
            {
                Label = "UWP",
                ValueLabel = "212",
                Color = SKColor.Parse("#2c3e50")
            },
            new ChartEntry(248)
            {
                Label = "Android",
                ValueLabel = "248",
                Color = SKColor.Parse("#77d065")
            },
            new ChartEntry(128)
            {
                Label = "iOS",
                ValueLabel = "128",
                Color = SKColor.Parse("#b455b6")
            },
            new ChartEntry(514)
            {
                Label = "Shared",
                ValueLabel = "514",
                Color = SKColor.Parse("#3498db")
            },
            new ChartEntry(212)
            {
                Label = "UWP",
                ValueLabel = "212",
                Color = SKColor.Parse("#2c3e50")
            },
            new ChartEntry(248)
            {
                Label = "Android",
                ValueLabel = "248",
                Color = SKColor.Parse("#77d065")
            },
            new ChartEntry(128)
            {
                Label = "iOS",
                ValueLabel = "128",
                Color = SKColor.Parse("#b455b6")
            },
            new ChartEntry(514)
            {
                Label = "Shared",
                ValueLabel = "514",
                Color = SKColor.Parse("#3498db")
            },
            new ChartEntry(212)
            {
                Label = "UWP",
                ValueLabel = "212",
                Color = SKColor.Parse("#2c3e50")
            },
            new ChartEntry(248)
            {
                Label = "Android",
                ValueLabel = "248",
                Color = SKColor.Parse("#77d065")
            },
            new ChartEntry(128)
            {
                Label = "iOS",
                ValueLabel = "128",
                Color = SKColor.Parse("#b455b6")
            },
            new ChartEntry(514)
            {
                Label = "Shared",
                ValueLabel = "514",
                Color = SKColor.Parse("#3498db")
            }

        };
        public ProductSalesGraphView()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<object>(this, "InitializeGraph", (sender) =>
              {
                  if (this.BindingContext is ProductViewModel productViewModel)
                  {
                      chart.Chart = new LineChart()
                      {
                          Entries = productViewModel.ChartEntries,
                          LineMode = LineMode.Straight,
                          LineSize = 4,
                          PointMode = PointMode.Circle,
                          PointSize = 8, EnableYFadeOutGradient = true
                      };
                  }
              });
        }
    }
}
