using System;
using System.Collections.ObjectModel;

namespace Ecliptae.Lib
{
    public class Orders
    {
        public readonly string GUID;

        public readonly string Owner;

        private ObservableCollection<Item> ItemInfo { get; set; }
        
        public Orders(string owner)
        {
            GUID = System.Guid.NewGuid().ToString().Replace("-","").ToUpper();
            Owner = owner;
        }
    }
}