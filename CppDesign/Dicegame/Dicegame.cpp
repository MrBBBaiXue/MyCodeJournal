/****************************************************************
	D I C E G A M E

	File Name:     Dicegame.cpp

	Author:        Chenhao Wang (MrBBBaiXue@github.com)
				   Boyan Wang (JingNianNian@github.com)
				   Wenle Zhang (Skywb@github.com)

	Version:       1.2

	Date:          2021-03-23

	Description:   Dicegame with OOP design used.

	Classes:       Dice
				   Computer
				   Player
				   Main
				   BetType

****************************************************************/
#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include "windows.h"
#include <iostream>

#define NUM_OF_DICES 3
#define DIVIDE_NUM (NUM_OF_DICES * 6) / 2 + 1
#define INIT_SCORE 2000

/// <summary>
/// 骰子类，抽象骰子对象
/// </summary>
class Dice
{
private:
	int _point; // 骰子点数
				// 私有Set，公有Get，防止外部对骰子值进行随意更改

public:
	/// <summary>
	/// 随机扔一次骰子
	/// </summary>
	/// <param name="range">骰子点数的最大范围</param>
	void Throw(int range = 6)
	{
		_point = rand() % range + 1;
		return;
	}

	/// <summary>
	/// 获得骰子点数
	/// </summary>
	/// <returns>当前骰子点数</returns>
	int Get()
	{
		return _point;
	}

	/// <summary>
	/// 类的构造函数
	/// </summary>
	Dice()
	{
		_point = 0;
		Throw(6);
	}
};

/// <summary>
/// 下注类型
/// 1 = 大,
/// 2 = 小,
/// 3 = 豹子。
/// </summary>
enum class BetType
{
	Larger = 1,
	Smaller = 2,
	Leopard = 3
};

/// <summary>
/// 电脑类，抽象庄家对象
/// </summary>
class Computer
{
public:
	int Score = INIT_SCORE;		  // 积分
	Dice Dices[NUM_OF_DICES]; // 骰子对象

	/// <summary>
	/// 重新扔一次骰子
	/// </summary>
	void ThrowDice()
	{
		for (auto i = 0; i <= NUM_OF_DICES - 1; i++)
		{
			Dices[i].Throw(6);
		}
		return;
	}

	/// <summary>
	/// 获得骰子当前的总点数
	/// </summary>
	/// <returns>骰子的总点数</returns>
	int GetDiceTotalPoints()
	{
		auto totalPoints = 0;
		for (auto i = 0; i <= NUM_OF_DICES - 1; i++)
		{
			totalPoints += Dices[i].Get();
		}
		return totalPoints;
	}

	/// <summary>
	/// 返回骰子是否是豹子
	/// </summary>
	/// <returns>骰子是否是豹子</returns>
	bool IsLeopard()
	{
		int point = Dices[0].Get();
		for (auto i = 1; i <= NUM_OF_DICES - 1; i++)
		{
			if (Dices[i].Get() != point)
			{
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// 返回可否继续游戏（积分够不够）
	/// </summary>
	/// <returns>可否继续进行游戏</returns>
	bool CanContinue()
	{
		return (Score > 0) ? true : false;
	}
};

/// <summary>
/// 玩家类，抽象玩家对象
/// </summary>
class Player
{
public:
	int Score = INIT_SCORE;		 // 积分
	BetType PlayerBetType = BetType::Larger;   // 猜测类型
	int BetScore = 1;		 // 玩家下注筹码

	/// <summary>
	/// 返回可否继续游戏（积分够不够）
	/// </summary>
	/// <returns>可否继续进行游戏</returns>
	bool CanContinue()
	{
		return (Score > 0) ? true : false;
	}
};

/// <summary>
/// 静态输出类，输出信息
/// </summary>
class Output
{
public:
	/// <summary>
	/// 输出规则
	/// </summary>
	static void Rules()
	{
		system("cls"); // 清屏
		std::cout << "-骰子游戏-----------------------------------------------------------" << std::endl;
		std::cout << std::endl;
		std::cout << " 【规则】" << std::endl;
		std::cout << std::endl;
		std::cout << " 1.游戏开始时，庄家和玩家将会各获得 " << INIT_SCORE << " 积分。" << std::endl;
		std::cout << std::endl;
		std::cout << " 2.玩家猜测骰子分数大小；有三种情况：大，小，豹子。" << std::endl;
		std::cout << std::endl;
		std::cout << "   1) 如果骰子总点数大于：" << DIVIDE_NUM << " 是 大；" << std::endl;
		std::cout << std::endl;
		std::cout << "   2) 如果骰子总点数小于：" << DIVIDE_NUM << " 是 小；" << std::endl;
		std::cout << std::endl;
		std::cout << "   3) 如果 " << NUM_OF_DICES << " 个骰子点数一样是 豹子。" << std::endl;
		std::cout << std::endl;
		std::cout << " 3.玩家输入下注分值；猜测大小为下注 1 倍分值，猜测豹子为 5 倍。" << std::endl;
		std::cout << std::endl;
		std::cout << " 4.系统按照猜测分数进行加减分并进行下一轮，直到一方分数小于零为止。" << std::endl;
		std::cout << std::endl;
		std::cout << "-按回车键开始-------------------------------------------------------" << std::endl;
		std::cout << std::endl;
		system("pause>nul"); // 等待玩家回车
		return;
	}

	/// <summary>
	/// 游戏：输入下注类型阶段
	/// </summary>
	/// <param name="pComputer">电脑指针</param>
	/// <param name="pPlayer">玩家指针</param>
	/// <param name="round">当前回合数</param>
	static void GameInputBetType(Computer* pComputer, Player* pPlayer, int round)
	{
		system("cls"); // 清屏
		std::cout << "-骰子游戏-----------------------------------------------------------" << std::endl;
		std::cout << std::endl;
		std::cout << " 第【" << round << "】回合" << std::endl;
		std::cout << std::endl;
		std::cout << " 玩家分数：【" << pPlayer->Score << "】 庄家分数：【" << pComputer->Score << "】" << std::endl;
		std::cout << std::endl;
		std::cout << " -猜测阶段--------------------------------------------------------- " << std::endl;
		std::cout << std::endl;
		std::cout << " 骰子已经摇好，请输入你的猜测：" << std::endl;
		std::cout << std::endl;
		std::cout << "   1) 如果骰子总点数大于等于：" << DIVIDE_NUM << " 是 大；" << std::endl;
		std::cout << std::endl;
		std::cout << "   2) 如果骰子总点数小于：" << DIVIDE_NUM << " 是 小；" << std::endl;
		std::cout << std::endl;
		std::cout << "   3) 如果 " << NUM_OF_DICES << " 个骰子点数一样是 豹子。" << std::endl;
		std::cout << std::endl;
		std::cout << " 输入1，猜测大；输入2，猜测小；输入3，猜测豹子。" << std::endl;
		std::cout << std::endl;
		std::cout << "-输入你的猜测-------------------------------------------------------" << std::endl;
		std::cout << std::endl;
	}

	/// <summary>
	/// 游戏：输入下注分值阶段
	/// </summary>
	/// <param name="pComputer">电脑指针</param>
	/// <param name="pPlayer">玩家指针</param>
	/// <param name="round">当前回合数</param>
	/// <param name="maxBetScore">最大下注分数</param>
	static void GameInputBetScore(Computer* pComputer, Player* pPlayer, int round, int maxBetScore)
	{
		system("cls"); // 清屏
		std::cout << "-骰子游戏-----------------------------------------------------------" << std::endl;
		std::cout << std::endl;
		std::cout << " 第【" << round << "】回合" << std::endl;
		std::cout << std::endl;
		std::cout << " 玩家分数：【" << pPlayer->Score << "】 庄家分数：【" << pComputer->Score << "】" << std::endl;
		std::cout << std::endl;
		std::cout << " -下注阶段--------------------------------------------------------- " << std::endl;
		std::cout << std::endl;
		if (pPlayer->PlayerBetType == BetType::Larger)
		{
			std::cout << " 您猜测的是 大，下注总分数为 1 倍分值。" << std::endl;
		}
		if (pPlayer->PlayerBetType == BetType::Smaller)
		{
			std::cout << " 您猜测的是 小，下注总分数为 1 倍分值。" << std::endl;
		}		
		if (pPlayer->PlayerBetType == BetType::Leopard)
		{
			std::cout << " 您猜测的是 豹子，下注总分数为 5 倍分值。" << std::endl;
		}
		std::cout << std::endl;
		std::cout << " 请输入您的下注分值，您现在还可以下注 【" << maxBetScore << "】 分。" << std::endl;
		std::cout << std::endl;
		std::cout << "-输入你的下注分值---------------------------------------------------" << std::endl;
		std::cout << std::endl;
	}

	/// <summary>
	/// 游戏：结算
	/// </summary>
	/// <param name="pComputer">电脑指针</param>
	/// <param name="pPlayer">玩家指针</param>
	/// <param name="round">当前回合数</param>
	/// <param name="wins">当前是否获胜</param>
	/// <param name="canContinue">可否继续</param>
	static void GameRoundEnd(Computer* pComputer, Player* pPlayer, int round, bool wins, bool canContinue)
	{
		system("cls"); // 清屏
		std::cout << "-骰子游戏-----------------------------------------------------------" << std::endl;
		std::cout << std::endl;
		std::cout << " 第【" << round << "】回合结束" << std::endl;
		std::cout << std::endl;
		std::cout << " 玩家分数：【" << pPlayer->Score << "】 庄家分数：【" << pComputer->Score << "】" << std::endl;
		std::cout << std::endl;
		std::cout << " -本局结果--------------------------------------------------------- " << std::endl;
		std::cout << std::endl;
		std::cout << "骰子点数是： " << pComputer->Dices[0].Get() << " "
			<< pComputer->Dices[1].Get() << " "
			<< pComputer->Dices[2].Get() << std::endl;
		std::cout << std::endl;
		if (wins)
		{
			std::cout << " 【您赢了本局！】" << std::endl;
		}
		else
		{
			std::cout << " 【您输了本局...】" << std::endl;
		}
		std::cout << std::endl;
		if (canContinue)
		{
			std::cout << " 还要继续玩吗？输入Y/y继续，输入N/n退出。" << std::endl;
			std::cout << std::endl;
			std::cout << "-输入你的选项-------------------------------------------------------" << std::endl;
		}
		else
		{
			std::cout << " 分数不足，无法继续；感谢您的游玩！" << std::endl;
			std::cout << std::endl;
			std::cout << "-按回车键退出-------------------------------------------------------" << std::endl;
		}
		std::cout << std::endl;
	}

	/// <summary>
	/// 输出错误输入
	/// </summary>
	static void ErrorWrongInput()
	{
		system("cls"); // 清屏
		std::cout << "-【错误】-----------------------------------------------------------" << std::endl;
		std::cout << std::endl;
		std::cout << " 输入有误，请重新确认您的输入！" << std::endl;
		std::cout << std::endl;
		std::cout << "--------------------------------------------------------------------" << std::endl;
		std::cout << std::endl;
		Sleep(3000); // 来自Windows.h 休眠三秒
	}

	/// <summary>
	/// 输出错误输入
	/// </summary>
	static void ErrorWrongNoEnoughScore()
	{
		system("cls"); // 清屏
		std::cout << "-【错误】-----------------------------------------------------------" << std::endl;
		std::cout << std::endl;
		std::cout << " 输入有误，您没有足够的下注积分！" << std::endl;
		std::cout << std::endl;
		std::cout << "--------------------------------------------------------------------" << std::endl;
		std::cout << std::endl;
		Sleep(3000); // 来自Windows.h 休眠三秒
	}
};

/// <summary>
/// 定义程序的入口点
/// </summary>
/// <returns>如果程序出错，返回%ERRORLEVEL% = -1</returns>
int main(int argc, char* argv[])
{
	try
	{
		srand((unsigned)time(NULL)); // 重置随机数种子
		system("color f0"); // 命令行窗口设置
		system("title 骰子游戏"); 
		system("mode con cols=68 lines=22");
		Output::Rules(); // 输出规则

		Computer computer, * pComputer = &computer;
		Player player, * pPlayer = &player;
		int round = 1; // 回合数

		while (true)
		{

			int maxBetScore = 0;
			// 重扔骰子
			pComputer->ThrowDice();

			// 1.输入猜测类别
			while (true)
			{
				Output::GameInputBetType(pComputer, pPlayer, round);
				auto input = 0;
				std::cin >> input;
				if (input == 1)
				{
					pPlayer->PlayerBetType = BetType::Larger;
					maxBetScore = pPlayer->Score;
					break;
				}
				if (input == 2)
				{
					pPlayer->PlayerBetType = BetType::Smaller;
					maxBetScore = pPlayer->Score;
					break;
				}
				if (input == 3)
				{
					// 检查还有没有5分
					if (pPlayer->Score < 5)
					{
						Output::ErrorWrongNoEnoughScore();
						continue;
					}
					pPlayer->PlayerBetType = BetType::Leopard;
					maxBetScore = pPlayer->Score / 5;
					break;
				}
				Output::ErrorWrongInput();
			}

			// 2.输入下注分值			
			while (true)
			{
				Output::GameInputBetScore(pComputer, pPlayer, round, maxBetScore);
				auto input = 0;
				std::cin >> input;
				if (input > maxBetScore)
				{
					Output::ErrorWrongNoEnoughScore();
					continue;
				}
				pPlayer->BetScore = input;
				break;
			}

			// 3.判断输赢积分，计算倍数
			auto wins = false;
			auto point = 0;
			switch (pPlayer->PlayerBetType)
			{
			case BetType::Larger:
				wins = (pComputer->GetDiceTotalPoints() >= DIVIDE_NUM) ? true : false;
				point = pPlayer->BetScore * 1;
				break;
			case BetType::Smaller:
				wins = (pComputer->GetDiceTotalPoints() < DIVIDE_NUM) ? true : false;
				point = pPlayer->BetScore * 1;
				break;
			case BetType::Leopard:
				wins = (pComputer->IsLeopard()) ? true : false;
				point = pPlayer->BetScore * 5;
				break;
			}
			
			// 4. 加减积分
			pPlayer->Score = (wins) ? pPlayer->Score + point : pPlayer->Score - point;
			pComputer->Score = (wins) ? pComputer->Score - point : pComputer->Score + point;
			auto canContinue = (pPlayer->CanContinue() && pComputer->CanContinue()) ? true : false;

			// 5.输入是否继续			
			while (true)
			{
				Output::GameRoundEnd(pComputer, pPlayer, round, wins, canContinue);
				if (canContinue)
				{
					char input = 'Y';
					std::cin >> input;
					if ((input == 'Y' || input == 'y') && canContinue)
					{
						round++;
						break;
					}
					if (input == 'N' || input == 'n')
					{
						return 0;
					}
					Output::ErrorWrongInput();
				}
				else
				{
					system("pause>nul");
					return 0;
				}
			}
		}
	}
	catch (std::exception e)
	{
		// 错误处理（虽然好像不会出什么错）
		std::cerr << e.what() << std::endl;
		return -1;
	}
	return 0;
}