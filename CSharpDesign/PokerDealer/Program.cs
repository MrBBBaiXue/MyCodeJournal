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
        public static List<List<Poker>> Pokers = new List<List<Poker>> { };

        /// <summary>
        /// 程序的入口点
        /// </summary>
        /// <param name="args">参数</param>
        static void Main(string[] args)
        {
            var pokerPool = GeneratePokerPool();
            // 获得初始牌池
            Random random = new Random();
            // 获得随机数
            for (var i = 1; i <= 4; i++)
            {
                // 大小List嵌套，一共4个牌组，一个牌组13张牌
                var pokerSet = new List<Poker> { };
                for (var n = 1; n <= 13; n++)
                {
                    int index;
                    do
                    {
                        index = random.Next(0, 52);                      
                    }
                    while (pokerPool[index].IsTaken == true);
                    // 如果没有被拿走，那么就把这个扑克增加到扑克堆中
                    var poker = new Poker
                    {
                        Point = pokerPool[index].Point,
                        PokerType = pokerPool[index].PokerType
                    };
                    pokerPool[index].IsTaken = true;
                    pokerSet.Add(poker);
                }
                Pokers.Add(pokerSet);
            }
            // 输出全部4个牌组的序列化数据
            for(var i = 0; i <= 3; i++)
            {
                Console.WriteLine($"pokerSet {i}:");
                foreach(var poker in Pokers[i])
                {
                    Console.WriteLine(poker.Serialize());
                }
            }
            return;
        }

        /// <summary>
        /// 获得初始牌池
        /// </summary>
        /// <returns>初始牌池的List</returns>
        private static List<PokerInPool> GeneratePokerPool()
        {
            var pokerPool = new List<PokerInPool> { };
            for (var type = 0; type <= 3; type++)
            {
                for (var point = 1; point <= 13; point++)
                {
                    // 往初始牌池中放入按顺序的牌
                    var poker = new PokerInPool
                    {
                        Point = point,
                        PokerType = (PokerType)type,
                        IsTaken = false
                    };
                    pokerPool.Add(poker);
                }
            }
            // 返回生成好的初始牌池
            return pokerPool;
        }
    }
}
