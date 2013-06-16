using System.Collections.Generic;
using Microsoft.Practices.Prism.StoreApps;
using Microsoft.Practices.Prism.StoreApps.Interfaces;

namespace BlacksmithPress.Diabetes.WinRT.ViewModels
{
    public class MainPageViewModel : ViewModel, IMainPageViewModel
    {
        private INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private IEnumerable<IDailyTileViewModel> _dailyTiles = default(IEnumerable<IDailyTileViewModel>);
        public IEnumerable<IDailyTileViewModel> DailyTiles
        {
            get { return _dailyTiles; }
            set { SetProperty(ref _dailyTiles, value); }
        }

    }
}
