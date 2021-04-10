using System;
using System.Collections.Generic;
using System.IO;

namespace PokerDealer
{
    public class PokerData
    {
        private readonly string _path;
		public PokerData(string path)
        {
            _path = path;
        }

		public void Write(List<PokerSet> pokers)
        {
            using StreamWriter streamWriter = new StreamWriter(_path);
            foreach (var pokerSet in pokers)
            {
                streamWriter.WriteLine(pokerSet.Serialize());
            }
        }

        public List<PokerSet> Read()
        {
            var pokers = new List<PokerSet> { };
            string content;
            using StreamReader streamReader = new StreamReader(_path);
            while ((content = streamReader.ReadLine()) != null)
            {
                var pokerSet = new PokerSet { };
                pokerSet.Deserialize(content);
                pokers.Add(pokerSet);
            }
            return pokers;
        }
	}
}
