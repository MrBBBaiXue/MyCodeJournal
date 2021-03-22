/****************************************************************
	D I C E G A M E

	File Name:     Dicegame.cpp

	Author:        Chenhao Wang (MrBBBaiXue@github.com)
				   Boyan Wang (JingNianNian@github.com)
				   Wenle Zhang (Skywb@github.com)

	Version:       1.1

	Date:          2021-03-22

	Description:   Dicegame with OOP design used.

	Classes:       Dice
				   Computer
				   Player
				   Main

****************************************************************/
#include<stdio.h>
#include<stdlib.h>
#include<time.h>
#include<iostream>
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
enum BetType
{
	Larger,
	Smaller,
	Leopard
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
		return (Score >= 0) ? true : false;
	}
};

/// <summary>
/// 玩家类，抽象玩家对象
/// </summary>
class Player
{
public:
	int Score = INIT_SCORE;		 // 积分
	BetType PlayerBetType;   // 猜测类型
	int BetScore = 1;		 // 玩家下注筹码

	////玩家输入猜测大小【判断有效输入】
	//void InterChoice()
	//{
	//	while (1)
	//	{
	//		printf("请输入你猜测【猜小输入1，猜大输入2，猜豹子输入3】: ");
	//		scanf_s("%d", &Choice);
	//		if (Choice == 1 || Choice == 2 || Choice == 3)
	//		{
	//			break;
	//		}
	//		printf("请输入正确的格式\n\n");
	//	}
	//}

	////玩家输入筹码 【判断筹码效果】
	//void InterBetScore()
	//{
	//	while (1)
	//	{
	//		printf("请输入你要下注的筹码：");
	//		scanf_s("%d", &BetScore);
	//		if (BetScore > UserScore)
	//		{
	//			printf("请不要输入超过你积分的筹码，你没那么多钱！\n\n");
	//			continue;
	//		}
	//		break;
	//	}
	//}

	////玩家输入是否继续
	//void EnterIfContinue()
	//{
	//	printf("是否继续？继续游戏输入：Y/y，结束游戏输入：N/n\n\n");
	//	scanf_s("%c", &IfContinue);
	//	getchar();
	//	if (IfContinue == 'n' || IfContinue == 'N')
	//	{
	//		printf("感谢游玩 再见！\n");
	//	}
	//}

	/// <summary>
	/// 返回可否继续游戏（积分够不够）
	/// </summary>
	/// <returns>可否继续进行游戏</returns>
	bool CanContinue()
	{
		return (Score >= 0) ? true : false;
	}
};

/// <summary>
/// 输出类，输出信息
/// </summary>
class Output
{
private:
	Computer* _computer; // Computer 的类指针
	Player* _player;	 // Player 的类指针

public:
	static void OutputRules()
	{
		system("cls"); // 清屏
		std::cout << "-骰子游戏----------------------------------------------------------" << std::endl;
		std::cout << std::endl;
		std::cout << " 规则：" << std::endl;
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
		std::cout << "-按回车键继续-------------------------------------------------------" << std::endl;
		system("pause>nul"); // 等待玩家回车
		return;
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
		Output::OutputRules(); // 输出规则

		int round = 1;
		Computer computer, * pComputer = computer;
		//1.掷骰子，电脑生成得到各个骰子的数，给予Dice的数组中
		//2.玩家输入猜测大小【判断有效输入】
		//4.输入筹码【判断筹码效果】
		//4.电脑判断输赢积分
		//5.计算积分：电脑和玩家加减积分
		//6.判断玩家和电脑的积分是否可以继续下一次【询问是否下一次】
		//while (1)
		//{
		//	// 基本积分
		//	printf("玩家积分：%d\n电脑积分：%d\n\n", UserScore, ComputerScore);

		//	//1.掷骰子，电脑生成得到各个骰子的数，给予Dice的数组中
		//	ThrowDice(Dice);

		//	//2.玩家输入猜测大小【判断有效输入】
		//	while (1)
		//	{
		//		printf("请输入你猜测【猜小输入1，猜大输入2，猜豹子输入3】: ");
		//		scanf_s("%d", &Choice);
		//		if (Choice == 1 || Choice == 2 || Choice == 3)
		//		{
		//			break;
		//		}
		//		printf("请输入正确的格式\n\n");
		//	}

		//	//4.输入筹码【判断筹码效果】
		//	while (1)
		//	{
		//		printf("请输入你要下注的筹码：");
		//		scanf_s("%d", &BetScore);
		//		if (BetScore > UserScore)
		//		{
		//			printf("请不要输入超过你积分的筹码，你没那么多钱！\n\n");
		//			continue;
		//		}
		//		break;
		//	}

		//	//4.电脑判断输赢积分，计算倍数

		//	if ((Dice[0] + Dice[1] + Dice[2]) <= 10 && (Dice[0] != Dice[1] || Dice[0] != Dice[2] || Dice[1] != Dice[2]))
		//	{
		//		Result = 1;//小，sumDice <= 10 且3个不同
		//		Times = (Result == Choice) ? 1 : -1;
		//	}
		//	if ((Dice[0] + Dice[1] + Dice[2]) > 10 && (Dice[0] != Dice[1] || Dice[0] != Dice[2] || Dice[1] != Dice[2]))
		//	{
		//		Result = 2;//大，sumDice > 10 且3个不同
		//		Times = (Result == Choice) ? 1 : -1;
		//	}
		//	if ((Dice[0] == Dice[1]) && (Dice[0] == Dice[2]) && (Dice[1] == Dice[2]))//豹子 三个骰子一样
		//	{
		//		Result = 3;//豹子,三个相同
		//		Times = (Result == Choice) ? 3 : -3;
		//	}
		//	//展现骰子结果
		//	printf("骰子的数字分别为 %d %d %d\n\n", Dice[0], Dice[1], Dice[2]);
		//	//4.计算积分：电脑和玩家加减积分
		//	ComputerScore -= Times * BetScore;//计算电脑积分

		//	UserScore += Times * BetScore;//计算玩家积分

		//	//结局1--玩家or电脑积分<=0
		//	if (UserScore <= 0 || ComputerScore <= 0)
		//	{
		//		UserScore > ComputerScore ? printf("玩家胜利\n") : printf("电脑胜利\n");
		//		printf("玩家剩余积分：%d  电脑剩余积分：%d\n", UserScore, ComputerScore);
		//		printf("游戏结束\n");
		//		break;
		//	}

		//	//结算这次猜骰子的积分结果
		//	printf("玩家剩余积分：%d  电脑剩余积分：%d\n\n", UserScore, ComputerScore);

		//	//结局2--玩家主动结束游戏
		//	printf("是否继续？继续游戏输入：Y/y，结束游戏输入：N/n\n\n");
		//	scanf_s("%c", &IfContinue);
		//	getchar();
		//	if (IfContinue == 'n' || IfContinue == 'N')
		//	{
		//		printf("感谢游玩 再见！\n");
		//		break;
		//	}
		//}
	}
	catch (std::exception e)
	{
		// 错误处理（虽然好像不会出什么错）
		std::cerr << e.what() << std::endl;
		return -1;
	}
	return 0;
}