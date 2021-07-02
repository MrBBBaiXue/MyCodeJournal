﻿using Stylet;
using System;
using System.IO;
using HandyControl.Controls;
using Ecliptae.Lib;
using Newtonsoft.Json;

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
            if (File.Exists("api.config"))
            {
                var streamReader = new StreamReader(@"api.config");
                App.ApiAddress = streamReader.ReadLine();
            }
        }

        public void CreateMainWindow()
        => App.WindowManager.ShowWindow(App.MainViewModel);

        public void LoginAndCreateMainWindow()
        {
            var loginInfo = new LoginInfo {
                Account = Account,
                Hash = Password
            };
            loginInfo.GetHash();

            // GET /users/login/
            string url = $"{App.ApiAddress}/users/login/";
            var jsonParam = JsonConvert.SerializeObject(loginInfo);
            var response = APIHelper.RestfulRequest(url, "post", jsonParam);

            MessageBox.Show($"response: {response}\n, loginInfo.Hash: {loginInfo.Hash}.", "Debug Info", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            // ToDo : 每次生成的hashcode不一样！！！
            if (response != null && response != "ERROR")
            {
                App.User = JsonConvert.DeserializeObject<User>(response);
            }
            else
            {
                MessageBox.Show("用户名或密码错误！","错误", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return;
            }         
            CreateMainWindow();
            RequestClose();
        }

        public void SignUpAndCreateMainWindow()
        {
            var loginInfo = new LoginInfo
            {
                Account = Account,
                Hash = Password
            };
            loginInfo.GetHash();
            var user = new User
            {
                Name = Account,
                Hash = loginInfo.Hash,
                Balance = 0.00,
                Level = 5
            };
            user.NewGuid();

            // POST /users/
            string url = $"{App.ApiAddress}/users/";
            var jsonParam = JsonConvert.SerializeObject(user);
            Lib.APIHelper.RestfulRequest(url, "post", jsonParam);

            App.User = user;

            CreateMainWindow();
            RequestClose();
        }
    }
}
