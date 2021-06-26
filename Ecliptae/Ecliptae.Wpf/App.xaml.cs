using System.Windows;
using Ecliptae.Wpf.ViewModels;
using HandyControl.Themes;
using Stylet;

namespace Ecliptae.Wpf
{
    public partial class App : Application
    {
        public static MainViewModel MainViewModel { get; set; } = new MainViewModel();

        // Variables
        public static IWindowManager WindowManager;

        public static void ToggleDarkMode() =>
            ThemeManager.Current.ApplicationTheme =
            (ThemeManager.Current.ApplicationTheme == ApplicationTheme.Light)
            ? ApplicationTheme.Dark : ApplicationTheme.Light;

        public App()
        {
            HandyControl.Themes.ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light;
        }
    }
}
