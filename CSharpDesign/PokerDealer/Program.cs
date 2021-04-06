/****************************************************************
	                P O K E R D E A L E R

		File Name: Program.cs

		   Author: Chenhao Wang (MrBBBaiXue@github.com)
				   Boyan Wang (JingNianNian@github.com)
				   Wenle Zhang (Skywb@github.com)
				   Sen Ma

			 Date: 2021-04-06

	  Description: Randomly arrange poker and display.

****************************************************************/

using System;
using System.Collections.Generic;

//Publish Command : dotnet publish -c Release -r win7-x64 /p:PublishSingleFile=true /p:PublishTrimmed=true

namespace PokerDealer
{
    class Program
    {
        public static List<PokerSet> Pokers = new List<PokerSet> { };

        /// <summary>
        /// 程序的入口点
        /// </summary>
        /// <param name="args">参数</param>
        static void Main(string[] args)
        {
            var pokerPool = PokerOperation.GeneratePokerPool();
            // 获得初始牌池

            for (var i = 1; i <= 4; i++)
            {
                Pokers.Add(PokerOperation.GeneratePokerSet(pokerPool,i,13));
            }
            // 输出全部4个牌组的序列化数据
            foreach(var pokerSet in Pokers)
            {
                Console.WriteLine(pokerSet.Serialize() + "\n");
            }
            return;
        } 
    }
}
