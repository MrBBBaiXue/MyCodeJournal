using System.Collections.ObjectModel;
using Ecliptae.Lib;
using HandyControl.Controls;
using Stylet;
using Newtonsoft.Json;

namespace Ecliptae.Wpf.ViewModels
{
    public class MainViewModel : Screen
    {
        public string WindowTitleText { get; } = "Ecliptae 商城";
        public void ToggleDarkMode() => App.ToggleDarkMode();
        public bool IsSeller => (App.User.Level == 1);
        public OptimizedObservableCollection<Item> Items { get; set; }
        public OptimizedObservableCollection<OrderItem> Carts { get; set; }
        public OptimizedObservableCollection<Item> ShopItems { get; set; }
        public Item? SelectedItem { get; set; }
        public OrderItem? SelectedCartItem { get; set; }
        public Item? SelectedShopItem { get; set; }
        public User User => App.User;

        public MainViewModel()
        {
            Items = new OptimizedObservableCollection<Item>();
            {
                // GET /items/
                string url = $"{App.ApiAddress}/items/";
                var json = APIHelper.RestfulGet(url);
                Items = JsonConvert.DeserializeObject<OptimizedObservableCollection<Item>>(json);
            }

            Carts = new OptimizedObservableCollection<OrderItem>();

            ShopItems = new OptimizedObservableCollection<Item>();
            {
                // POST /items/user/
                string url = $"{App.ApiAddress}/items/user/";
                var jsonParam = JsonConvert.SerializeObject(App.User);
                var response = APIHelper.RestfulRequest(url, "post", jsonParam);
                ShopItems = JsonConvert.DeserializeObject<OptimizedObservableCollection<Item>>(response);
            }
        }

        /// Item Operations ///
        public void ShowItemInfo()
        {
            // GET /comments/item={itemGuid}
            string itemGuid = SelectedItem.GUID;
            string url = $"{App.ApiAddress}/comments/item={itemGuid}";
            var json = APIHelper.RestfulGet(url);
            var comments = JsonConvert.DeserializeObject<OptimizedObservableCollection<Comment>>(json);

            var itemViewModel = new ItemViewModel
            {
                Item = SelectedItem,
                Comments = comments
            };
            App.WindowManager.ShowDialog(itemViewModel);
        }
        public void AddItemToCart()
        {
            foreach (var item in Carts)
            {
                if (item.Item.GUID == SelectedItem.GUID)
                    return;
            }
            // Add Item
            var orderItem = new OrderItem
            {
                Item = SelectedItem,
                Count = 1
            };
            Carts.Add(orderItem);
        }
        public void BuyItem()
        {
            // Place Order
        }

        /// Cart Item Operations ///
        public void OnCartItemNumericUpDownValueChanged()
        {
            if (SelectedCartItem != null && SelectedCartItem.Count <= 0)
                RemoveItemFromCart();
        }
        public void RemoveItemFromCart()
        => Carts.Remove(SelectedCartItem);

        public bool VerifyCart()
        {
            double cost = 0.00;
            return true;
        }

        public void SubmitPayment()
        {
            if (VerifyCart())
            {
                // place order
            }
            else
            {
                MessageBox.Show("余额不足", "错误", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        /// Shop Item Operations ///
        public void EditShopItem()
        {
            var shopItemViewModel = new EditItemViewModel()
            {
                Item = SelectedShopItem,
            };
            App.WindowManager.ShowDialog(shopItemViewModel);
        }
        public void RemoveItemFromShop()
        {

        }
        public void AddShopItem()
        {

        }
    }
}
