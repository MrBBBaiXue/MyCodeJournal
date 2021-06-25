using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Stylet;

namespace Ecliptae.Wpf.ViewModels
{
    public class LoginViewModel
    {
        public string LoginButtonText => " Login ";

        public LoginViewModel(IWindowManager windowManager)
        {
            App.WindowManager = windowManager;
        }

        public LoginViewModel()
        {

        }
        public void CreateMainWindow()
        {
            App.WindowManager.ShowWindow(App.MainViewModel);
        }
    }
}
