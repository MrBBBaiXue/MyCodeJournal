using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Magician
{
    /// <summary>
    /// Utility类，内含输入输出所用函数
    /// </summary>
    class Utility
    {
        /// <summary>
        /// 游戏模式
        /// </summary>
        public static byte Mode { get; set; }
        /// <summary>
        /// 设定控制台参数
        /// </summary>
        public static void SetConsolePreferences()
        {
            Console.Title = "三位数魔法小游戏";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WindowHeight = 30;
            Console.WindowWidth = 84;
            Console.Clear();
        }
        /// <summary>
        /// 输出游戏规则
        /// </summary>
        public static void OutputRules()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------游戏规则--------------------------------------\n");
            Console.WriteLine("·玩家可以选择两个角色之一：旁观者 / 魔术师\n");
            Console.WriteLine("·当玩家选择旁观者时：");
            Console.WriteLine("  玩家在心中想一个数字，大小在100-999之间，例如ABC");
            Console.WriteLine("  可以直接输入ABC由程序计算相关信息，也可以自己计算出ACB+BAC+BCA+CAB+CBA的大小并输入");
            Console.WriteLine("  程序会根据相关信息计算出玩家所想数字并输出，此轮游戏结束\n");
            Console.WriteLine("·当玩家选择魔术师时：");
            Console.WriteLine("  程序会随机生成一个在100-999之间的数，计算ACB+BAC+BCA+CAB+CBA的大小并输出给玩家");
            Console.WriteLine("  玩家通过计算结果来猜测生成的三位数，并输入");
            Console.WriteLine("  输入后程序会判断玩家所计算的结果是否正确，并显示");
            Console.WriteLine("  ·若玩家想查看答案，可以按下A，程序会输出此轮答案，此轮游戏结束\n");
            Console.WriteLine("·一轮游戏结束后，玩家可自主选择<继续游戏>或者<退出>\n");
            Console.WriteLine("·注意：游戏开始前请将输入法调至英文！");
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine("  按下回车以继续");
            Console.ReadKey(false);
        }
        /// <summary>
        /// 获取旁观者输入的数字并返回
        /// </summary>
        /// <returns>输入的结果</returns>
        public static int ViewerInputNumber()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------输入----------------------------------------\n");
            Console.WriteLine("·请输入你心中所想的数字并回车");
            Console.WriteLine("·若输入和，请在数字最后加上“s”\n");
            Console.WriteLine("------------------------------------------------------------------------------------\n");
            Console.Write("  请输入：");
            var s = Console.ReadLine();
            if (s.Contains("s"))
            {
                Mode = 1;
                return Convert.ToInt32(s.Remove(s.Length - 1, 1));
            }
            else
            {
                return Convert.ToInt32(s);
            }
        }
        /// <summary>
        /// 基于玩家时旁观者时，输出程序对玩家心中所想数字的猜测结果
        /// </summary>
        /// <param name="result">程序计算结果</param>
        public static void ViewerOutputCalculate(int result)
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------结果----------------------------------------\n");
            if (result == -1)
            {
                Console.WriteLine("·魔术师：你输入的这个和没有相对应的解。\n");
            }
            else
            {
                Console.WriteLine($"·魔术师：我猜测你心中想的数字是：{result}\n");
            }
            Console.WriteLine("----------------------------------------结果----------------------------------------\n");
            Console.WriteLine("·按下任意键继续");
            Console.ReadKey(false);
        }
        /// <summary>
        /// 基于玩家是魔术师时，输出对玩家此轮输入数字的判定
        /// </summary>
        /// <param name="win">是否正确</param>
        /// <param name="v">Viewer类，用于获取答案</param>
        /// <returns>玩家是否继续猜测</returns>
        public static bool MagicianOutputResult(bool win, Viewer v)
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------结果----------------------------------------\n");
            if (win)
            {
                Console.WriteLine($"·答案是：{v.GetAnswer()}");
                Console.WriteLine("·恭喜你，你猜对了。\n");
                Console.WriteLine("----------------------------------------结果----------------------------------------\n");
                return false;
            }
            else
            {
                Console.WriteLine("·很遗憾，你猜错了。");
                Console.WriteLine("·继续猜测请按下Y键，获取答案请按下A\n");
                Console.WriteLine("----------------------------------------结果----------------------------------------\n");
                var k = Console.ReadKey(false);
                if (k.Key == ConsoleKey.Y)
                {
                    return true;
                }
                else if (k.Key == ConsoleKey.A)
                {
                    Console.Clear();
                    Console.WriteLine("----------------------------------------结果----------------------------------------\n");
                    Console.WriteLine($"·答案是：{v.GetAnswer()}\n");
                    Console.WriteLine("----------------------------------------结果----------------------------------------\n");
                    Console.WriteLine("·按下任意键继续");
                    Console.ReadKey(false);
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        /// <summary>
        /// 游戏结束时判断是否重新进行
        /// </summary>
        /// <returns>按下Y键则继续，按下其它退出</returns>
        public static bool ReStart()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------重新开始--------------------------------------\n");
            Console.WriteLine("·请问是否要重新开启一局新游戏？");
            Console.WriteLine("·重新开始请按下Y键，退出按下除Y之外的任意键。\n");
            Console.WriteLine("------------------------------------------------------------------------------------\n");
            var k = Console.ReadKey(false);
            if (k.Key == ConsoleKey.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 基于玩家是魔术师时，获取玩家的计算结果
        /// </summary>
        /// <param name="v"></param>
        /// <returns>玩家输入的计算结果</returns>
        public static int MagicianInputGuestNumber(int v)
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------请输入-------------------------------------\n");
            Console.WriteLine($"·该数字除去自身的和是{v}");
            Console.WriteLine("·请输入你的计算结果\n");
            Console.WriteLine("-------------------------------------请输入-------------------------------------\n");
            var guestNumber = Convert.ToInt32(Console.ReadLine());
            if (guestNumber > 1000 || guestNumber < 100)
            {
                throw new Exception();
            }
            return guestNumber;
        }
        /// <summary>
        /// 选择角色
        /// </summary>
        /// <returns>选择魔术师则为true，选择旁观者则为false</returns>
        public static bool CheckRole()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------角色选择--------------------------------------\n");
            Console.WriteLine("·选择魔术师请按下M键");
            Console.WriteLine("·选择旁观者请按下V键\n");
            Console.WriteLine("------------------------------------------------------------------------------------\n");
            Console.WriteLine("                              <M·魔术师>  <V·旁观者>                                  ");
            var k = Console.ReadKey(false).Key;
            if (k != ConsoleKey.M && k != ConsoleKey.V)
            {
                throw new Exception();
            }
            return k == ConsoleKey.M ? true : false;
        }
        /// <summary>
        /// 当输入有误输出错误信息
        /// </summary>
        public static void InputError()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------输入有误--------------------------------------\n");
            Console.WriteLine("·请稍后重新输入\n");
            Console.WriteLine("--------------------------------------输入有误--------------------------------------\n");
            Thread.Sleep(3000);
        }
    }
}
