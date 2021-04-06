/****************************************************************
	P O K E R D E A L E R

		File Name: Classes/PokerData.cs

		   Author: Chenhao Wang (MrBBBaiXue@github.com)
				   Boyan Wang (JingNianNian@github.com)
				   Wenle Zhang (Skywb@github.com)
				   Sen Ma

			 Date: 2021-04-06

	  Description: Randomly arrange poker and display.

****************************************************************/

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
