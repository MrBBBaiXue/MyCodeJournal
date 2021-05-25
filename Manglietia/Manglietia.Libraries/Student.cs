using System.Collections.ObjectModel;
using System.Text;

namespace Manglietia.DLL
{
    public class Student : NotificationObject
    {
        public bool IsSelected { get; set; } = false;
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

        public string ScoreText
        {
            get
            {
                var stringBuilder = new StringBuilder();
                foreach (var score in Scores)
                {
                    stringBuilder.Append($"{score.Subject}: {score.Point}; ");
                }
                return stringBuilder.ToString();
            }
        }
    }
}
