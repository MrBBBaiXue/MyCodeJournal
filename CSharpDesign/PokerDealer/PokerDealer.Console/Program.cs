/****************************************************************
	                P O K E R D E A L E R

          Project: PokerDealer.Console

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
using System.Text;
using System.IO;
using Con = System.Console;
// 重定义Console，防止和项目命名空间冲突

// Publish Command : dotnet publish -c Release -r win7-x64 /p:PublishSingleFile=true /p:PublishTrimmed=true

namespace PokerDealer.Console
{
    class Program
    {
        // 牌堆，由四个PokerSet组成
        public static List<PokerSet> Pokers = new List<PokerSet> { };

        public static string DataPath = Path.Combine(Environment.CurrentDirectory, $"pokerData.dat");

        /// <summary>
        /// 程序的入口点
        /// </summary>
        /// <param name="args">参数</param>
        static void Main(string[] args)
        {
            // 初始化Console数据
            ConsoleOperation.ApplyConsoleSettings(20, 60);
            ConsoleOperation.OutputRule();
            // 获得用户想要进行的操作
            var operation = ConsoleOperation.InputOperation();
            switch (operation)
            {
                case 1:
                    DataPath = ConsoleOperation.InputDataPath();
                    var pokerData = new PokerData(DataPath);
                    Pokers = pokerData.Read();
                    break;

                case 2:
                    var pokerPool = PokerOperation.GeneratePokerPool();
                    for (var i = 1; i <= 4; i++)
                    {
                        Pokers.Add(PokerOperation.GeneratePokerSet(pokerPool, i, 13));
                    }
                    ConsoleOperation.OutputShufflePorksInf();
                    break;
                default:
                    return;
            }
            // 获得初始牌池
            while (true)
            {
                var checkIndex = ConsoleOperation.InputCheckPokerSets();
                if (checkIndex == 5)
                {
                    break;
                }
                ConsoleOperation.ApplyConsoleSettings(45, 145);
                ConsoleOperation.OutputPokersLine(Pokers[checkIndex - 1]);
            }
            Con.Clear();
            return;

        }
    }
}
