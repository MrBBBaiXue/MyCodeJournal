using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecliptae.Lib;
using HandyControl.Controls;
using Newtonsoft.Json;
using Stylet;
using MsgBox = HandyControl.Controls.MessageBox;

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
            {
                var comment = new Comment
                {
                    Owner = App.User.GUID,
                    Item = Item.GUID,
                    Content = CommentText,
                    Star = CommentStar
                };
                comment.NewGuid();
                // POST /comments/
                string url = $"{App.ApiAddress}/comments/";
                var jsonParam = JsonConvert.SerializeObject(comment);
                var response = APIHelper.RestfulRequest(url, "post", jsonParam);
            }
            {
                // GET /comments/item={itemGuid}
                string itemGuid = Item.GUID;
                string url = $"{App.ApiAddress}/comments/item={itemGuid}";
                var json = APIHelper.RestfulGet(url);
                Comments = JsonConvert.DeserializeObject<OptimizedObservableCollection<Comment>>(json);
            }
            // Clear content
            CommentStar = 3;
            CommentText = "";
            return;
        }

    }
}
