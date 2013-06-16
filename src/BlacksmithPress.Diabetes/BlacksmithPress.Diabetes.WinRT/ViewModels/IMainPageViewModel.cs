using System.Collections.Generic;
using System.ComponentModel;
using Windows.UI.Xaml.Navigation;

namespace BlacksmithPress.Diabetes.WinRT.ViewModels
{
    public interface IMainPageViewModel
    {
        IEnumerable<IDailyTileViewModel> DailyTiles { get; set; }
        void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode, Dictionary<string, object> viewModelState);
        void OnNavigatedFrom(Dictionary<string, object> viewModelState, bool suspending);
        event PropertyChangedEventHandler PropertyChanged;
    }
}