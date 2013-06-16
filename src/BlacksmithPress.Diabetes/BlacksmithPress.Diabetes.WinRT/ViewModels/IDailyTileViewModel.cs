using System.Collections.Generic;
using System.ComponentModel;
using BlacksmithPress.Diabetes.Core.Values;
using Windows.UI.Xaml.Navigation;

namespace BlacksmithPress.Diabetes.WinRT.ViewModels
{
    public interface IDailyTileViewModel
    {
        string Title { get; set; }
        IEnumerable<MealCarbohydrates> Meals { get; set; }
        void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode, Dictionary<string, object> viewModelState);
        void OnNavigatedFrom(Dictionary<string, object> viewModelState, bool suspending);
        event PropertyChangedEventHandler PropertyChanged;
    }
}