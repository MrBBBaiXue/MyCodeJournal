namespace Ecliptae.Wpf.ViewModels
{
    public class MainViewModel
    {
        public static string WindowTitle => "Ecliptae 电子商务系统";
        public bool IsDarkMode { get; set; } = false;
        public void ToggleDarkMode()
        {
            HandyControl.Themes.ThemeManager.Current.ApplicationTheme =
                (IsDarkMode) ? HandyControl.Themes.ApplicationTheme.Dark : HandyControl.Themes.ApplicationTheme.Light;
            IsDarkMode = !IsDarkMode;
            return;
        }

        public MainViewModel()
        {

        }
    }
}
