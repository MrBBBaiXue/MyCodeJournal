using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HandyControl;

namespace PokerDealer.WPF.Views
{

    /// <summary>
    /// MainWindow.xaml 的后台逻辑
    /// </summary>
    public partial class MainWindow : HandyControl.Controls.GlowWindow
    {       
        public MainWindow()
        {
            InitializeComponent();
            DataContext = App.MainWindowViewModel;
        }
    }
}
