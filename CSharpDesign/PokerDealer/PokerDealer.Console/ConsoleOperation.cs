using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Con = System.Console;

namespace PokerDealer.Console
{
    public static class ConsoleOperation
    {
        // ToDo : 使用StringBuilder
        public static void OutputRule()
        {
            Con.Clear();
            Con.WriteLine("发牌游戏规则：");
            Con.WriteLine("·程序开始后洗牌，并发牌（洗牌结果存储到文件中）。");
            Con.WriteLine("·牌组有四副，玩家可任意选择查看其中一副牌。");
            Con.WriteLine("·直到玩家选择退出，程序关闭。\n");
            Con.WriteLine("·按任意键继续");
            Con.ReadKey(false);
        }
        public static void OutputShufflePorksInf()
        {
            Con.Clear();
            Con.WriteLine("洗牌已完成！");
            System.Threading.Thread.Sleep(3000);
        }
        public static int CheckPorks()
        {
            while (true)
            {
                try
                {
                    Con.Clear();
                    Con.Write("请按下你想查看的牌组(按下1/2/3/4)");
                    var k = Con.ReadKey(false);
                    if (k.Key == ConsoleKey.D1)
                    {
                        return 1;
                    }
                    else if (k.Key == ConsoleKey.D2)
                    {
                        return 2;
                    }
                    else if (k.Key == ConsoleKey.D3)
                    {
                        return 3;
                    }
                    else if (k.Key == ConsoleKey.D4)
                    {
                        return 4;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Con.Clear();
                    Con.WriteLine("按下了错误的键，请稍后重新选择！");
                    System.Threading.Thread.Sleep(3000);
                    continue;
                }
            }
        }
        public static void OutputPokers(PokerSet pokers)
        {
            Con.Clear();
            Con.WriteLine($"第{pokers.Index}组牌组如下：");
            foreach (var poker in pokers.Pokers)
            {
                Con.WriteLine("┌----------┐");
                Con.WriteLine($"|{poker.Point}         |");
                Con.WriteLine($"|   {poker.GetEnumDescription(poker.PokerType)}   |");
                Con.WriteLine("|          |");
                Con.WriteLine("|          |");
                Con.WriteLine($"|   {poker.GetEnumDescription(poker.PokerType)}   |");
                Con.WriteLine($"|         {poker.Point}|");
                Con.WriteLine("└----------┘");
            }
            Con.WriteLine("按下任意键继续");
            Con.ReadKey(false);
        }
        public static void ApplyConsoleSettings(int h, int w)
        {
            Con.BackgroundColor = ConsoleColor.White;
            Con.ForegroundColor = ConsoleColor.Black;
            Con.Title = "发牌小游戏";
            Con.WindowHeight = h;
            Con.WindowWidth = w;
            Con.Clear();
        }
    }
}
