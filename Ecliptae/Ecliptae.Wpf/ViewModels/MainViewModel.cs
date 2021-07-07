using Ecliptae.Lib;
using HandyControl.Controls;
using Newtonsoft.Json;
using Stylet;

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
        public User User { get; set; } = App.User;

        public MainViewModel()
        {
            Items = new OptimizedObservableCollection<Item>();
            Carts = new OptimizedObservableCollection<OrderItem>();
            ShopItems = new OptimizedObservableCollection<Item>();
            UpdateInfo();
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
            var orderItems = new OptimizedObservableCollection<OrderItem>();
            var orderItem = new OrderItem
            {
                Item = SelectedItem,
                Count = 1
            };
            orderItems.Add(orderItem);
            TryPlaceOrder(orderItems);
        }

        /// Cart Item Operations ///
        public void RemoveItemFromCart()
        => Carts.Remove(SelectedCartItem);
        public bool VerifyCart(OptimizedObservableCollection<OrderItem> orderItems)
        => CalculateCost(orderItems) <= App.User.Balance;
        public double CalculateCost(OptimizedObservableCollection<OrderItem> orderItems)
        {
            double cost = 0.00;
            foreach (var orderItem in orderItems)
                cost += orderItem.Item.Price * orderItem.Count;
            return cost;
        }
        public void SubmitPayment()
        {
            if (TryPlaceOrder(Carts))
                Carts = new OptimizedObservableCollection<OrderItem>();
        }
        public bool TryPlaceOrder(OptimizedObservableCollection<OrderItem> orderItems)
        {
            if (orderItems.Count == 0)
                return false;
            foreach(var orderItem in orderItems)
            {
                if (orderItem.Item.Storage <= 0)
                {
                    MessageBox.Show("库存不足！", "错误", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                    return false;
                }
            }
            if (VerifyCart(orderItems))
            {
                // Place Order
                var order = new Order
                {
                    Owner = User.GUID,
                    Items = orderItems
                };
                order.NewGuid();
                // POST /orders/
                {
                    string url = $"{App.ApiAddress}/orders/";
                    var jsonParam = JsonConvert.SerializeObject(order);
                    APIHelper.RestfulRequest(url, "post", jsonParam);
                }
                // PUT /users/
                {
                    App.User.Balance -= CalculateCost(orderItems);
                    // PUT /users/
                    string url = $"{App.ApiAddress}/users/";
                    var jsonParam = JsonConvert.SerializeObject(App.User);
                    APIHelper.RestfulRequest(url, "put", jsonParam);
                    User = App.User;
                    NotifyOfPropertyChange("User");
                }
                // PUT /items/
                {
                    foreach (var orderItem in orderItems)
                    {
                        var item = orderItem.Item;
                        item.Storage -= orderItem.Count;
                        string url = $"{App.ApiAddress}/items/";
                        var jsonParam = JsonConvert.SerializeObject(item);
                        APIHelper.RestfulRequest(url, "put", jsonParam);
                    }
                }
                MessageBox.Show("购买成功！", "信息", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                UpdateInfo();
                return true;
            }
            else
            {
                MessageBox.Show("余额不足，请充值！", "错误", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                return false;
            }
        }

        public void IncreaseCount()
        {
            SelectedCartItem.Count++;
            NotifyOfPropertyChange("Carts");
        }
        public void DecreaseCount()
        {
            if (SelectedCartItem.Count == 1)
                return;
            else
                SelectedCartItem.Count--;
            NotifyOfPropertyChange("Carts");
        }

        /// Shop Item Operations ///
        public void EditShopItem()
        {
            var shopItemViewModel = new EditItemViewModel()
            {
                Item = SelectedShopItem,
                IsNewItem = false
            };
            App.WindowManager.ShowDialog(shopItemViewModel);
        }
        public void RemoveItemFromShop()
        {
            // DELETE /items/guid={guid}
            var guid = SelectedShopItem.GUID;
            string url = $"{App.ApiAddress}/items/guid={guid}";
            APIHelper.RestfulRequest(url, "delete", string.Empty);
            UpdateInfo();
        }
        public void AddShopItem()
        {
            // POST /items/
            var item = new Item
            {
                Name = "New Item",
                Owner = App.User.GUID,
                Description = "",
                Price = 0.00,
                Storage = 100
            };
            item.NewGuid();
            var shopItemViewModel = new EditItemViewModel()
            {
                Item = item,
                IsNewItem = true
            };
            App.WindowManager.ShowDialog(shopItemViewModel);
        }

        /// Information Update ///
        public void UpdateInfo()
        {
            {
                // GET /items/
                string url = $"{App.ApiAddress}/items/";
                var json = APIHelper.RestfulGet(url);
                Items = JsonConvert.DeserializeObject<OptimizedObservableCollection<Item>>(json);
            }
            {
                // POST /items/user/
                string url = $"{App.ApiAddress}/items/user/";
                var jsonParam = JsonConvert.SerializeObject(App.User);
                var response = APIHelper.RestfulRequest(url, "post", jsonParam);
                ShopItems = JsonConvert.DeserializeObject<OptimizedObservableCollection<Item>>(response);
            }
        }

        /// Personal Operations ///
        public void Charge()
        {
            App.User.Balance += 100;
            User = App.User;
            NotifyOfPropertyChange("User");
            // PUT /users/
            string url = $"{App.ApiAddress}/users/";
            var jsonParam = JsonConvert.SerializeObject(App.User);
            APIHelper.RestfulRequest(url, "put", jsonParam);
        }
    }
}
