using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Con = System.Console;

namespace PokerDealer.Console
{
    public static class ConsoleOperation
    {
        /// <summary>
        /// 输出规则
        /// </summary>
        public static void OutputRule()
        {
            Con.Clear();
            Con.WriteLine("发牌游戏规则：\n");
            Con.WriteLine("> 程序开始后洗牌，并发牌（洗牌结果存储到文件中）。");
            Con.WriteLine("> 牌组有四副，玩家可任意选择查看其中一副牌。");
            Con.WriteLine("> 直到玩家选择退出，程序关闭。\n");
            Con.WriteLine("  按任意键继续...");
            Con.ReadKey(false);
        }
        /// <summary>
        /// 输出洗牌信息
        /// </summary>
        public static void OutputShufflePorksInf()
        {
            Con.Clear();
            Con.WriteLine("> 洗牌已完成");
            System.Threading.Thread.Sleep(1000);
            Con.Clear();
        }

        /// <summary>
        /// 输出成功信息
        /// </summary>
        public static void OutputIOCompleted(string content)
        {
            Con.Clear();
            Con.WriteLine($"> {content}");
            System.Threading.Thread.Sleep(1000);
            Con.Clear();
        }

        /// <summary>
        /// 输出某个牌组的信息
        /// </summary>
        /// <param name="pokers">传入的牌组信息</param>
        public static void OutputPokersLine(PokerSet pokers)
        {
            Con.WriteLine($"> 第{pokers.Index}组牌组：");
            List<StringBuilder> lines = new List<StringBuilder>();
            for (int i = 0; i < 8; i++)
            {
                lines.Add(new StringBuilder());
            }
            foreach (var poker in pokers.Pokers)
            {
                string f()
                {
                    if (poker.Point == 1)
                    {
                        return "A";
                    }
                    else if (poker.Point == 11)
                    {
                        return "J";
                    }
                    else if (poker.Point == 12)
                    {
                        return "Q";
                    }
                    else if (poker.Point == 13)
                    {
                        return "K";
                    }
                    else
                    {
                        return poker.Point.ToString();
                    }
                }
                string point = f();
                lines[0].Append("┌---------┐");
                lines[1].Append($"│ {point}{(point == "10" ? "" : " ")}      │");
                lines[2].Append($"│   {poker.GetEnumDescription(poker.PokerType)}  │");
                lines[3].Append("│         │");
                lines[4].Append("│         │");
                lines[5].Append($"│   {poker.GetEnumDescription(poker.PokerType)}  │");
                lines[6].Append($"│       {(point == "10" ? "" : " ")}{point}│");
                lines[7].Append("└---------┘");
            }
            foreach (var line in lines)
            {
                Con.WriteLine(line);
            }
        }
        /// <summary>
        /// 输入想查看的牌组
        /// </summary>
        /// <returns>返回用户想查看的牌组的索引</returns>
        public static int InputCheckPokerSets()
        {
            while (true)
            {
                try
                {
                    Con.WriteLine("> 请选择你想查看的牌组：\n");
                    Con.WriteLine("  请按下 1-4 查看序号对应的牌组, 按 5 退出, 按 6 保存牌组到文件。\n");
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
                    else if (k.Key == ConsoleKey.D5)
                    {
                        return 5;
                    }
                    else if (k.Key == ConsoleKey.D6)
                    {
                        return 6;
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
        /// <summary>
        /// 获得用户的操作
        /// </summary>
        /// <returns>Read = 1, New = 2</returns>
        public static int InputOperation()
        {
            while (true)
            {
                try
                {
                    Con.Clear();
                    Con.WriteLine("> 请选择你的操作：\n");
                    Con.WriteLine("  R 读取指定文件中的牌组");
                    Con.WriteLine("  N 新建牌组");
                    var k = Con.ReadKey(false);
                    if (k.Key == ConsoleKey.R)
                    {
                        return 1;                        
                    }
                    else if (k.Key == ConsoleKey.N)
                    {
                        return 2;
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
        /// <summary>
        /// 获得用户输入的数据文件路径
        /// </summary>
        /// <param name="isCheckNeeded">是否需要检查文件存在</param>
        /// <returns>PokerData的路径</returns>
        public static string InputDataPath(bool isCheckNeeded)
        {
            while (true)
            {
                try
                {
                    Con.Clear();
                    Con.WriteLine("> 请输入数据文件路径：\n");
                    var path = Con.ReadLine();
                    if (isCheckNeeded)
                    {
                        if (!System.IO.File.Exists(path))
                        {
                            throw new Exception();
                        }
                        else
                        {
                            return path;
                        }
                    }
                    else
                    {
                        return path;
                    }
                }
                catch
                {
                    Con.Clear();
                    Con.WriteLine("路径错误，请重新输入!");
                    System.Threading.Thread.Sleep(3000);
                    continue;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="h"></param>
        /// <param name="w"></param>
        public static void ApplyConsoleSettings(int height, int width)
        {
            Con.OutputEncoding = Encoding.UTF8;
            Con.BackgroundColor = ConsoleColor.White;
            Con.ForegroundColor = ConsoleColor.Black;
            Con.Title = "发牌手 PokerDealer";
            Con.WindowHeight = height;
            Con.WindowWidth = width;
            Con.BufferHeight = height;
            Con.BufferWidth = width;
            Con.Clear();
        }
    }
}
