/****************************************************************
	                    M A G I C I A N

		File Name: Program.cs

		   Author: Chenhao Wang (MrBBBaiXue@github.com)
				   Boyan Wang (JingNianNian@github.com)
				   Wenle Zhang (Skywb@github.com)

	         Date: 2021-04-05

	  Description: Guess Number using the sum of it.

****************************************************************/


//Publish Command : dotnet publish -c Release -r win7-x64 /p:PublishSingleFile=true /p:PublishTrimmed=true

namespace Magician
{
    /// <summary>
    /// Process类，内定义程序入口
    /// </summary>
    class Process
    {
        /// <summary>
        /// 程序从此开始运行
        /// </summary>
        static void Main()
        {
            Utility.SetConsolePreferences();
            // 设置控制台窗口信息
            bool role;
            // 玩家角色 如果true，为魔术师
            //         如果false，为旁观者
            bool canContinue = true;
            // 是否可以继续游戏（取决于玩家是否按Y）

            Utility.OutputRules();
            // 输出游戏规则
            while (canContinue)
            {
                try
                {
                    role = Utility.CheckRole();
                    // 要求玩家选择自己的角色
                    canContinue = (role) ? Game.MagicianGame() : Game.ViewerGame();
                    // 三目
                }
                catch
                {
                    Utility.InputError();
                    // 输出错误信息
                    continue;
                }
            }
        }
    }
}

