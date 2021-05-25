using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace Manglietia.DLL
{
    public class Class
    {
        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student> { };
        public string Description { get; set; }

        public string GUID;

        public Class()
        {
            GUID = System.Guid.NewGuid().ToString();
        }

        // JSON序列化
        public string Serialize() => JsonConvert.SerializeObject(this);
        public void Deserialize(string json)
        {
            var seralizedClass = JsonConvert.DeserializeObject<Class>(json);
            // JSON反序列化
            Students = seralizedClass.Students;
            Description = seralizedClass.Description;
            GUID = seralizedClass.GUID;
        }

    }
}
