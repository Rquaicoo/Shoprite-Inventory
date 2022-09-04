using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shoprite_Ghana_Limited.Model;

namespace Shoprite_Ghana_Limited.ViewModel
{
    internal class Chart
    {
        public List<SalesData> Data { get; set; }
        public List<SalesData> DailyData { get; set; }

        public Chart()
        {
            Data = new List<SalesData>()
            {
                new SalesData { month = "Jan", sales = 300 },
                new SalesData { month = "Feb", sales = 100 },
                new SalesData { month = "Mar", sales = 450 },
                new SalesData { month = "Apr", sales = 420 },
                new SalesData { month = "May", sales = 47 },
                new SalesData { month = "Jun", sales = 20 },
                new SalesData { month = "Jul", sales = 828 },
                new SalesData { month = "Aug", sales = 210 },
                new SalesData { month = "Sep", sales = 356 },
                new SalesData { month = "Oct", sales = 382 },
                new SalesData { month = "Nov", sales = 150 },
                new SalesData { month = "Dec", sales = 900 },
            };

            DailyData = new List<SalesData>()
            {
                new SalesData { month = "09:00", sales = 300 },
                new SalesData { month = "10:00", sales = 100 },
                new SalesData { month = "11:00", sales = 450 },
                new SalesData { month = "12:00", sales = 420 },
                new SalesData { month = "13:00", sales = 47 },
                new SalesData { month = "14:00", sales = 20 },
                new SalesData { month = "15:00", sales = 828 },
                new SalesData { month = "16:00", sales = 210 },
                new SalesData { month = "17:00", sales = 356 },
                new SalesData { month = "18:00", sales = 382 },
                new SalesData { month = "19:00", sales = 150 },
                new SalesData { month = "20:00", sales = 900 },
            };
        }
    }
}
