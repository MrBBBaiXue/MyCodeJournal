using System;
using System.Collections.ObjectModel;

namespace Manglietia.DLL
{
    public class Student
    {
        public ObservableCollection<Score> Scores { get; set; } = new ObservableCollection<Score> { };
        public string Name { get; set; }
        public bool Sex { get; set; }
        // 规定False为男性，True为女性。
        public string ID { get; set; }
        public string Phone { get; set; }

        public string GUID;

        public Student()
        {
            GUID = System.Guid.NewGuid().ToString();
        }
    }
}
