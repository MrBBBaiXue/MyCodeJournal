using System.Collections.ObjectModel;
using Ecliptae.Lib;

namespace Ecliptae.Wpf.ViewModels
{
    public class MainViewModel
    {
        public string WindowTitleText { get; } = "Ecliptae 商城";
        public void ToggleDarkMode() => App.ToggleDarkMode();
        public bool IsSeller => (App.User.Level == 1);
        public ObservableCollection<Item> Items { get; set; }

        public MainViewModel()
        {
            Items = new ObservableCollection<Item>();
        }
    }
}
