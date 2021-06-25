using System.Windows;
using Ecliptae.Wpf.ViewModels;
using Stylet;

namespace Ecliptae.Wpf
{
    public partial class App : Application
    {
        public static MainViewModel MainViewModel { get; set; } = new MainViewModel();

        // Variables
        public static IWindowManager WindowManager;

        public static void ToggleDarkMode() =>

        HandyControl.Themes.ThemeManager.Current.ApplicationTheme =
        (HandyControl.Themes.ThemeManager.Current.ApplicationTheme ==
        HandyControl.Themes.ApplicationTheme.Light)
        ? HandyControl.Themes.ApplicationTheme.Dark
        : HandyControl.Themes.ApplicationTheme.Light;

        public App()
        {
           
        }
    }
}
