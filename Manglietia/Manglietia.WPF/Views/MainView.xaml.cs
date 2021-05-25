using System.Windows;

namespace Manglietia.WPF.Views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : HandyControl.Controls.Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void FileMenuButton_OnClick(object sender, RoutedEventArgs e)
        {
            FileMenu.IsOpen = true;
        }
    }
}
