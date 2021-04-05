/****************************************************************
	P O K E R D E A L E R

		File Name: Program.cs

		   Author: Chenhao Wang (MrBBBaiXue@github.com)
				   Boyan Wang (JingNianNian@github.com)
				   Wenle Zhang (Skywb@github.com)
				   Sen Ma

			 Date: 2021-04-05

	  Description: Randomly arrange poker and display.

****************************************************************/

using System;
using System.Collections.Generic;

//Publish Command : dotnet publish -c Release -r win7-x64 /p:PublishSingleFile=true /p:PublishTrimmed=true

namespace PokerDealer
{
    class Program
    {
        public static List<Poker> OriginPokers = new List<Poker> { };

        public static List<List<Poker>> PokerPool = new List<List<Poker>> { };

        /// <summary>
        /// 程序的入口点
        /// </summary>
        /// <param name="args">参数</param>
        static void Main(string[] args)
        {
            // init 
            for(var type = 0; type <= 3; type++)
            {
                for (var point = 1; point <= 13; point++)
                {
                    // add poker to pokers
                    var poker = new Poker
                    { 
                        Point = point,
                        PokerType = (PokerType)type
                    };
                    OriginPokers.Add(poker);
                }
            }
            foreach(var poker in OriginPokers)
            {
                Console.WriteLine(poker.Serialize());
            }
            Console.WriteLine(OriginPokers.Count);
            // randomize
            Random random = new Random();

            
            foreach(var poker in OriginPokers)
            {
                var num = random.Next(1,52);
                Console.WriteLine(num);
            }
            return;
        }
    }
}
