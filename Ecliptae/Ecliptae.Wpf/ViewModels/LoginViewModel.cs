using Stylet;

namespace Ecliptae.Wpf.ViewModels
{
    public class LoginViewModel
    {
        public string WindowTitleText { get; set; } = "账户登录";
        public string LoginButtonText { get; set; } = "登录";
        public string SignUpButtonText { get; set; } = "注册";
        public void ToggleDarkMode() => App.ToggleDarkMode();
        public LoginViewModel(IWindowManager windowManager)
        {
            App.WindowManager = windowManager;
        }

        public LoginViewModel()
        {

        }
        public void CreateMainWindow()
        => App.WindowManager.ShowWindow(App.MainViewModel);
        public void LoginAndCreateMainWindow()
        {

        }

        public void SignUpAndCreateMainWindow()
        {
            // ToDo : Sign Up logic
            //CreateMainWindow();
            App.WindowManager.ShowDialog(App.ItemViewModel);
        }

        public void SignUp()
        {

        }

    }
}
