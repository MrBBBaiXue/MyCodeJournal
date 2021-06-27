using Stylet;
using System;
using System.IO;
using HandyControl.Controls;

namespace Ecliptae.Wpf.ViewModels
{
    public class LoginViewModel : Screen
    {
        public string WindowTitleText { get; } = "账户登录";
        public string LoginButtonText { get; } = "登录";
        public string SignUpButtonText { get; } = "注册";
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
            // Password Notifications for testing.
            CreateMainWindow();
            CloseWindow();
        }

        public void SignUpAndCreateMainWindow()
        {
            // ToDo : Sign Up logic

            CreateMainWindow();
            CloseWindow();
        }

        private bool Login()
        {
            return false;
        }

        private bool SignUp()
        {
            return true;
        }

        private void CloseWindow()
        {
            RequestClose();
        }

    }
}
