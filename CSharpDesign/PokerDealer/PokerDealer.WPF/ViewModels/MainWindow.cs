using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PokerDealer.WPF.ViewModels
{
    public class MainWindow : NotificationObject
    {
        public string WindowTitle { get; set; }
        public DelegateCommand NightModeToggleButtonClickEvent { get; set; }
        public ObservableCollection<PokerSet> Pokers { get; set; }
        public void NightModeToggleButtonClick(object parameter)
        {
            HandyControl.Themes.ThemeManager.Current.ApplicationTheme =
                (HandyControl.Themes.ThemeManager.Current.ApplicationTheme != HandyControl.Themes.ApplicationTheme.Dark) ?
                HandyControl.Themes.ApplicationTheme.Dark : HandyControl.Themes.ApplicationTheme.Light;
        }

        public DelegateCommand ImportCommand { get; set; }
        public void Import(object parameter)
        {
            while (Pokers.Count > 0)
            {
                Pokers.RemoveAt(0);
            }
            string path;
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                InitialDirectory = Environment.CurrentDirectory
            };
            if ((bool)dialog.ShowDialog())
            {
                path = dialog.FileName;
                var pokerData = new PokerData(path);
                // List to ObservableCollection
                foreach (var pokerSet in pokerData.Read())
                {
                    Pokers.Add(pokerSet);
                }
            }
        }
        public DelegateCommand GenerateCommand { get; set; }
        public void Generate(object parameter)
        {
            // Remove Items
            while(Pokers.Count > 0)
            {
                Pokers.RemoveAt(0);
            }
            var pokerPool = PokerOperation.GeneratePokerPool();
            for (var i = 1; i <= 4; i++)
            {
                Pokers.Add(PokerOperation.GeneratePokerSet(pokerPool, i, 13));
            }
        }

        public DelegateCommand SaveCommand { get; set; }
        public void Save(object parameter)
        {
            string path;
            var dialog = new Microsoft.Win32.SaveFileDialog
            {
                InitialDirectory = Environment.CurrentDirectory
            };
            if ((bool)dialog.ShowDialog())
            {
                path = dialog.FileName;
                var pokerData = new PokerData(path);
                // ObservableCollection to List
                var pokerList = new List<PokerSet> { };
                foreach (var pokerSet in Pokers)
                {
                    pokerList.Add(pokerSet);
                }
                pokerData.Write(pokerList);
            }
        }

        public MainWindow()
        {
            WindowTitle = "PokerDealer 发牌手";
            Pokers = new ObservableCollection<PokerSet> { };
            NightModeToggleButtonClickEvent = new DelegateCommand(new Action<object>(NightModeToggleButtonClick));
            ImportCommand = new DelegateCommand(new Action<object>(Import));
            GenerateCommand = new DelegateCommand(new Action<object>(Generate));
            SaveCommand = new DelegateCommand(new Action<object>(Save));
        }
    }
}
