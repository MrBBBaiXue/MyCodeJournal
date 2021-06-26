using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecliptae.Wpf.ViewModels
{
    public class ItemViewModel
    {
        public string WindowTitleText { get; set; } = "物品信息";
        public void ToggleDarkMode() => App.ToggleDarkMode();
    }
}
