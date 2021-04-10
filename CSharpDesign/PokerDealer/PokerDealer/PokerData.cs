using System.IO;

namespace PokerDealer
{
    public class PokerData
    {
		private FileStream _fileStream;
		private string _path;
	
		public PokerData(FileStream fileStream, string path)
        {
			_fileStream = fileStream;
			_path = path;
			// ToDo : init filestream
        }
	}
}
