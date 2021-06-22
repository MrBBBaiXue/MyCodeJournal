using System.Collections.ObjectModel;

namespace Ecliptae.Lib
{
    public class GuidClass
    {
        public string GUID { get; set; }
        public void NewGUID()
        {
            GUID = System.Guid.NewGuid().ToString().Replace("-", "").ToUpper();
        }
    }
    public class Order : GuidClass
    {
        public string Owner { get; set; }
        private ObservableCollection<Item> Items { get; set; }
    }

    public class Item : GuidClass
    {
        public string Owner { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Storage { get; set; }
    }

    public class User : GuidClass
    {
        public string Name { get; set; }
        private string Hash { get; set; }
        private float Balance { get; set; }
        public int Level { get; set; }
    }

    public class Comment : GuidClass
    {
        public string Owner { get; set; }
        public string Item { get; set; }
        public string Content { get; set; }
        public int Star { get; set; }
    }

}