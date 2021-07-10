using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Ecliptae.Lib
{
    public class GuidClass
    {
        public string GUID { get; set; }
        public void NewGuid()
        {
            GUID = System.Guid.NewGuid().ToString().ToUpper();
        }
    }
    public class Order : GuidClass
    {
        public string Owner { get; set; }
        public ObservableCollection<OrderItem> Items { get; set; }
        public Order()
        {
            Items = new ObservableCollection<OrderItem> { };
        }
    }

    public class Item : GuidClass
    {
        public string Owner { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Storage { get; set; }
    }

    public class OrderItem
    {
        public Item Item { get; set; }
        public int Count { get; set; }

    }

    public class User : GuidClass
    {
        public string Name { get; set; }
        public string Hash { get; set; }
        public double Balance { get; set; }
        public int Level { get; set; }
    }

    public class LoginInfo
    {
        public string Account { get; set; }
        public string Hash { get; set; }
        public bool IsHashed { get; set; } = false;
        public void GetHash()
        {
            var hashString = APIHelper.SHA1Encrypt($"ECLIPTAE_ACCOUNT_HASH_{Account}_{Hash}");
            Hash = hashString;
            IsHashed = true;
        }
    }

    public class Comment : GuidClass
    {
        public string Owner { get; set; }
        public string Item { get; set; }
        public string Content { get; set; }
        public int Star { get; set; }
    }

    // SQLHelper
    public class SQLConfig
    {
        public string Database { get; set; }
        public string DataSource { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public string Charset { get; set; }
        public string Pooling { get; set; }

        public SQLConfig(string json)
        {
            var sqlconfig = JsonConvert.DeserializeObject<SQLConfig>(json);
            // Deserialize Object
            Database = sqlconfig.Database;
            DataSource = sqlconfig.DataSource;
            UserID = sqlconfig.UserID;
            Password = sqlconfig.Password;
            Charset = sqlconfig.Charset;
            Pooling = sqlconfig.Pooling;
        }

        public SQLConfig()
        {
            Database = "";
            DataSource = "";
            UserID = "";
            Password = "";
            Charset = "";
            Pooling = "";
        }
        public string Serialize() => JsonConvert.SerializeObject(this);

        public override string ToString()
        {
            var str = $"Database='{Database}';" +
                         $"Data Source='{DataSource}';" +
                         $"User Id='{UserID}';" +
                         $"Password='{Password}';" +
                         $"charset='{Charset}';" +
                         $"pooling={Pooling};";
            return str;
        }
    }
}