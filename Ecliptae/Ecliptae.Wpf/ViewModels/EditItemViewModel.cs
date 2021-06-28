using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecliptae.Lib;

namespace Ecliptae.Wpf.ViewModels
{
    public class EditItemViewModel
    {
        public string WindowTitleText { get; set; } = "编辑商品信息";
        public Item Item { get; set; } = new Item();
        public void ToggleDarkMode() => App.ToggleDarkMode();
        public void SubmitEdit()
        {
            // ToDo : Submit Edit
        }

    }
}
