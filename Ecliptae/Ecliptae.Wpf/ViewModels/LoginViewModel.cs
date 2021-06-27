using Stylet;
using System;
using System.IO;

namespace Ecliptae.Wpf.ViewModels
{
    public class LoginViewModel : Screen
    {
        public string WindowTitleText { get; set; } = "账户登录";
        public string LoginButtonText { get; set; } = "登录";
        public string SignUpButtonText { get; set; } = "注册";
        public string Account { get; set; }
        public string Password { get; set; }
        public void ToggleDarkMode() => App.ToggleDarkMode();

        public LoginViewModel(IWindowManager windowManager)
        {
            App.WindowManager = windowManager;
            if (File.Exists("api-address.config"))
            {
                var streamReader = new StreamReader(@"api-address.config");
                App.ApiAddress = streamReader.ReadLine();
            }
        }

        public void CreateMainWindow()
        => App.WindowManager.ShowWindow(App.MainViewModel);

        public void LoginAndCreateMainWindow()
        {
            // ToDo : Login Logic

            CreateMainWindow();
            CloseWindow();
        }

        public void SignUpAndCreateMainWindow()
        {
            // ToDo : Sign Up logic

            CreateMainWindow();
            CloseWindow();
        }

        public bool VerifyAccess()
        {
            return false;
        }

        private void CloseWindow()
        {
            RequestClose();
        }

    }
}
