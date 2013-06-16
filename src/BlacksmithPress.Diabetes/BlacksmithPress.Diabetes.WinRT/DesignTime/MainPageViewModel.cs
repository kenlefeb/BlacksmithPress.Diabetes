using System;
using System.Collections.Generic;
using BlacksmithPress.Diabetes.Core.Values;
using Runtime=BlacksmithPress.Diabetes.WinRT.ViewModels;
using Microsoft.Practices.Prism.StoreApps;
using Microsoft.Practices.Prism.StoreApps.Interfaces;

namespace BlacksmithPress.Diabetes.WinRT.DesignTime
{
    public class MainPageViewModel : ViewModel, Runtime.IMainPageViewModel
    {
        public MainPageViewModel()
        {
            var randomizer = new Random(DateTime.Now.Millisecond);

            var startDate = DateTime.Today.Subtract(new TimeSpan(randomizer.Next(0,7), 0, 0, 0));
            var endDate = DateTime.Now;

            var tiles = new List<Runtime.IDailyTileViewModel>();
            foreach(var thisDay in new DateRange(startDate, endDate).Dates)
                tiles.Add(new DailyTileViewModel(thisDay.ToString("ddd d MMMM yyyy")));

            DailyTiles = tiles;
        }

        private IEnumerable<Runtime.IDailyTileViewModel> _dailyTiles = default(IEnumerable<Runtime.IDailyTileViewModel>);
        public IEnumerable<Runtime.IDailyTileViewModel> DailyTiles
        {
            get { return _dailyTiles; }
            set { SetProperty(ref _dailyTiles, value); }
        }
    }

    public class DateRange
    {
        private readonly TimeSpan _oneDay = new TimeSpan(1, 0, 0, 0);

        public DateRange(DateTime start, DateTime end)
        {
            var thisDate = start;
            do
            {
                _dates.Add(thisDate);
                thisDate += _oneDay;

            } while (thisDate <= end);
        }

        private List<DateTime> _dates = new List<DateTime>();
        public IEnumerable<DateTime> Dates
        {
            get { return _dates; }
        }

    }
}
