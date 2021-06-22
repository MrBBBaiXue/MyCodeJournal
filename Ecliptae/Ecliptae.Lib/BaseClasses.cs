using System;
using System.Collections.ObjectModel;

namespace Ecliptae.Lib
{
    public class Order
    {
        public readonly string GUID;

        public readonly string Owner;

        private ObservableCollection<Item> ItemInfo { get; set; }
        
        public Order(string owner)
        {
            GUID = System.Guid.NewGuid().ToString().Replace("-","").ToUpper();
            Owner = owner;
        }
    }

    public class Item
    {
        public readonly string GUID;
        public string Name;
        public string Description;
        public float Price;
        public int Storage;
        public readonly string Owner;

        public Item(string owner)
        {
            GUID = System.Guid.NewGuid().ToString().Replace("-", "").ToUpper();
            Owner = owner;
        }

    }

    public class User
    {
        public readonly string GUID;
        public string Name;
        private string Hash;
        private float Balance;
        public int Level;

    }

    public class Comment
    {
        public readonly string GUID;
        public string Owner;
        public string Item;
        public string Content;
        public int Star;

        public Comment(string owner)
        {
            GUID = System.Guid.NewGuid().ToString().Replace("-", "").ToUpper();
            Owner = owner;
        }
    }

}