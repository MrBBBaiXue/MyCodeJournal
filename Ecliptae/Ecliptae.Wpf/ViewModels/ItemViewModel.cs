using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecliptae.Lib;
using HandyControl.Controls;
using Stylet;

namespace Ecliptae.Wpf.ViewModels
{
    public class ItemViewModel : Screen
    {
        public string WindowTitleText { get; set; } = "物品详情";
        public Item Item { get; set; } = new Item();
        public void ToggleDarkMode() => App.ToggleDarkMode();
        public OptimizedObservableCollection<Comment> Comments { get; set; } =
            new OptimizedObservableCollection<Comment> { };

        // Submit comment

        public int CommentStar { get; set; } = 3;
        public string CommentText { get; set; } = "";
        public void SendComment()
        {
            // ToDo : Send Comment
            return;
        }
    }
}
