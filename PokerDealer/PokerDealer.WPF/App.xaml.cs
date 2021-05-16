using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PokerDealer.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ViewModels.MainWindow MainWindowViewModel { get; set; }
        public static new Views.MainWindow MainWindow { get; set; }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // 初始化程序UI
            MainWindowViewModel = new ViewModels.MainWindow();
            CreateMainWindow();
        }

        private void CreateMainWindow()
        {
            var MainWindow = new PokerDealer.WPF.Views.MainWindow();
            MainWindow.Show();
            return;
        }
    }
}
