using System.Collections.ObjectModel;
using System.IO;

namespace Manglietia.DLL
{
    public class ClassesData
    {
        private readonly string _path;

        public ClassesData(string path)
        { 
            _path = path;
        }

        public void Write(ObservableCollection<DLL.Class> classesData)
        {
            using StreamWriter streamWriter = new StreamWriter(_path);
            foreach (var classData in classesData)
            {
                streamWriter.WriteLine(classData.Serialize());
            }
        }

        public ObservableCollection<DLL.Class> Read()
        {
            var classesData = new ObservableCollection<DLL.Class> { };
            string content;
            using StreamReader streamReader = new StreamReader(_path);
            while ((content = streamReader.ReadLine()) != null)
            {
                var classData = new Class { };
                classData.Deserialize(content);
                // add to classesData
                classesData.Add(classData);
            }
            return classesData;
        }
    }
}
