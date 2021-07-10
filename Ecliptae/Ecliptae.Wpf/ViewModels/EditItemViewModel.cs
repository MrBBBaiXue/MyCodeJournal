using Ecliptae.Lib;
using Newtonsoft.Json;
using Stylet;

namespace Ecliptae.Wpf.ViewModels
{
    public class EditItemViewModel : Screen
    {
        public string WindowTitleText { get; set; } = "编辑商品信息";
        public Item Item { get; set; } = new Item();
        public void ToggleDarkMode() => App.ToggleDarkMode();
        public bool IsNewItem { get; set; } = false;
        public void SubmitEdit()
        {
            {
                // POST/PUT /items/
                string url = $"{App.ApiAddress}/items/";
                var jsonParam = JsonConvert.SerializeObject(Item);
                var method = IsNewItem ? "post" : "put";
                APIHelper.RestfulRequest(url, method, jsonParam);
            }
            App.MainViewModel.UpdateInfo();
            RequestClose();
        }

    }
}
