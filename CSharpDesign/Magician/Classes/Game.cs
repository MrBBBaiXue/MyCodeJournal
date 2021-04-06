/****************************************************************
	                    M A G I C I A N

		File Name: Game.cs

		   Author: Chenhao Wang (MrBBBaiXue@github.com)
				   Boyan Wang (JingNianNian@github.com)
				   Wenle Zhang (Skywb@github.com)

	         Date: 2021-04-05

	  Description: Basic Game class, contains game process.

****************************************************************/

using System;

namespace Magician
{
    /// <summary>
    /// 将一局游戏抽象为对象，通过玩家选择来决定进行的游戏
    /// </summary>
    public class Game
    {
        /// <summary>
        /// 进行一场旁观者游戏
        /// </summary>
        /// <returns>是否继续</returns>
        public static bool ViewerGame()
        {
            Viewer v;
            Magician m = new Magician();
            // 初始化对象（Viewer的初始化需要确定玩家输入的方法，稍后初始化）
            int viewerNum;
            while (true)
            {
                int input;
                input = Utility.ViewerInputNumber();
                // 玩家输入数据
                if (Utility.Mode == 0)
                {
                    // 电脑帮忙
                    v = new Viewer(input);
                    break;
                }
                else if (Utility.Mode == 1)
                {
                    // 如果玩家选择自己计算和并输入，那么就是模式1
                    v = new Viewer(input, Utility.Mode);
                    break;
                }
                else
                {
                    Utility.InputError();
                    continue;
                }
            }
            viewerNum = m.CalculateAnswer(v.GetRemoveSelfSum());
            // 旁观者的结果
            Utility.ViewerOutputCalculate(viewerNum);
            return Utility.ReStart();
        }
        /// <summary>
        /// 进行一场魔术师游戏
        /// </summary>
        /// <returns>是否继续</returns>
        public static bool MagicianGame()
        {
            Viewer v = new Viewer(Number.GetRandomNumber());
            Magician m = new Magician();
            int guestNumber;
            bool continueGuest;
            bool win;
            while (true)
            {
                try
                {
                    guestNumber = Utility.MagicianInputGuestNumber(v.GetRemoveSelfSum());
                    win = m.IsCorrectAnswer(guestNumber, v);
                    continueGuest = Utility.MagicianOutputResult(win, v);
                    if (continueGuest)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    Utility.InputError();
                    continue;
                }
            }
            return Utility.ReStart();
        }
        /// <summary>
        /// 退出游戏
        /// </summary>
        public static void ExitGame()
            => Environment.Exit(0);
    }

}