using System.Collections.Generic;
using System.ComponentModel;
using BlacksmithPress.Diabetes.Core.Values;
using Microsoft.Practices.Prism.StoreApps;
using Microsoft.Practices.Prism.StoreApps.Interfaces;
using Windows.UI.Xaml;

namespace BlacksmithPress.Diabetes.WinRT.ViewModels
{
    public class DailyTileViewModel : ViewModel, IDailyTileViewModel
    {
        private INavigationService _navigationService;

        public DailyTileViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private string _title = string.Empty;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private IEnumerable<MealCarbohydrates> _meals = default(IEnumerable<MealCarbohydrates>);
        public IEnumerable<MealCarbohydrates> Meals
        {
            get { return _meals; }
            set { SetProperty(ref _meals, value); }
        }

    }
}
