﻿using System.Windows.Controls;
using Ecliptae.Wpf.Views;

namespace Ecliptae.Wpf.ViewModels
{
    public class MainViewModel
    {
        public string WindowTitle { get; set; } = "Ecliptae 电子商务系统";
        public void ToggleDarkMode() => App.ToggleDarkMode();

        public MainViewModel()
        {

        }
    }
}
