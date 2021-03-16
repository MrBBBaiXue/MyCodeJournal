//maker:zwl
//game rule
//Big 1 time
//Small 1 time
//Leopard 5 time
#include<stdio.h>
#include<stdlib.h>
#include<time.h>
#include<iostream>


class Dice
{
private:
	int _point;

	//声明方法
public:
	int Result = 0;//骰子相加结果是大、小、豹子

	void Throw(int range)
	{
		_point = rand() % range + 1;
		srand((unsigned)time(NULL));
		return;
	}

	int Get()
	{
		return _point;
	}
	//构造器
	Dice()
	{
		_point = 0;
		Throw(6);
	}
};

class User
{
public:
	int UserScore = 20;//玩家积分

	int Choice = 0;//玩家猜测类型

	int BetScore = 0;//玩家下注筹码

	char IfContinue;//是否继续

	//玩家输入猜测大小【判断有效输入】
	void InterChoice()
	{
		while (1)
		{
			printf("请输入你猜测【猜小输入1，猜大输入2，猜豹子输入3】: ");
			scanf_s("%d", &Choice);
			if (Choice == 1 || Choice == 2 || Choice == 3)
			{
				break;
			}
			printf("请输入正确的格式\n\n");
		}
	}

	//玩家输入筹码 【判断筹码效果】
	void InterBetScore()
	{
		while (1)
		{
			printf("请输入你要下注的筹码：");
			scanf_s("%d", &BetScore);
			if (BetScore > UserScore)
			{
				printf("请不要输入超过你积分的筹码，你没那么多钱！\n\n");
				continue;
			}
			break;
		}
	}

	//玩家输入是否继续
	void InterIfContinue()
	{
		printf("是否继续？继续游戏输入：Y/y，结束游戏输入：N/n\n\n");
		scanf_s("%c", &IfContinue);
		getchar();
		if (IfContinue == 'n' || IfContinue == 'N')
		{
			printf("感谢游玩 再见！\n");
		}
	}
};

class Computer
{
public:
	int ComputerScore = 100;//电脑积分

	int Times = 0;//输赢倍数

	//电脑判断输赢积分，计算倍数
	void Judge_Result()
	{

	}

	//计算积分：电脑和玩家加减积分_结算积分结果
	void Calculation_Store()
	{

	}

	//判断两者积分是否小于0
	void Judge_Store()
	{

	}
};


int main()
{
	Dice dice1, dice2, dice3;
	//dice1.Throw(6);
	std::cout << dice1.Get() << dice2.Get() << dice3.Get() << std::endl;

	void ThrowDice(int dice[]);//声明关于摇骰子的函数

	int ComputerScore = 100;//电脑积分

	int UserScore = 20;//玩家积分

	int Choice = 0;//玩家猜测类型

	int BetScore = 0;//玩家下注筹码

	int Times = 0;//输赢倍数

	int Dice[3] = { 0, 0, 0 };//3个骰子

	char IfContinue;//是否继续

	int Result = 0;//骰子相加结果是大、小、豹子

	//1.掷骰子，电脑生成得到各个骰子的数，给予Dice的数组中
	//2.玩家输入猜测大小【判断有效输入】
	//4.输入筹码【判断筹码效果】
	//4.电脑判断输赢积分
	//5.计算积分：电脑和玩家加减积分
	//6.判断玩家和电脑的积分是否可以继续下一次【询问是否下一次】
	while (1)
	{
		//介绍基础积分
		printf("玩家积分：%d\n电脑积分：%d\n\n", UserScore, ComputerScore);

		//1.掷骰子，电脑生成得到各个骰子的数，给予Dice的数组中
		ThrowDice(Dice);

		//2.玩家输入猜测大小【判断有效输入】
		while (1)
		{
			printf("请输入你猜测【猜小输入1，猜大输入2，猜豹子输入3】: ");
			scanf_s("%d", &Choice);
			if (Choice == 1 || Choice == 2 || Choice == 3)
			{
				break;
			}
			printf("请输入正确的格式\n\n");
		}

		//4.输入筹码【判断筹码效果】
		while (1)
		{
			printf("请输入你要下注的筹码：");
			scanf_s("%d", &BetScore);
			if (BetScore > UserScore)
			{
				printf("请不要输入超过你积分的筹码，你没那么多钱！\n\n");
				continue;
			}
			break;
		}

		//4.电脑判断输赢积分，计算倍数

		if ((Dice[0] + Dice[1] + Dice[2]) <= 10 && (Dice[0] != Dice[1] || Dice[0] != Dice[2] || Dice[1] != Dice[2]))
		{
			Result = 1;//小，sumDice <= 10 且3个不同
			Times = (Result == Choice) ? 1 : -1;
		}
		if ((Dice[0] + Dice[1] + Dice[2]) > 10 && (Dice[0] != Dice[1] || Dice[0] != Dice[2] || Dice[1] != Dice[2]))
		{
			Result = 2;//大，sumDice > 10 且3个不同
			Times = (Result == Choice) ? 1 : -1;
		}
		if ((Dice[0] == Dice[1]) && (Dice[0] == Dice[2]) && (Dice[1] == Dice[2]))//豹子 三个骰子一样
		{
			Result = 3;//豹子,三个相同
			Times = (Result == Choice) ? 3 : -3;
		}
		//展现骰子结果
		printf("骰子展现的数字分别为 %d %d %d\n\n", Dice[0], Dice[1], Dice[2]);
		//4.计算积分：电脑和玩家加减积分
		ComputerScore -= Times * BetScore;//计算电脑积分

		UserScore += Times * BetScore;//计算玩家积分

		//结局1--玩家or电脑积分<=0
		if (UserScore <= 0 || ComputerScore <= 0)
		{
			UserScore > ComputerScore ? printf("玩家胜利\n") : printf("电脑胜利\n");
			printf("玩家剩余积分：%d  电脑剩余积分：%d\n", UserScore, ComputerScore);
			printf("游戏结束\n");
			break;
		}

		//结算这次猜骰子的积分结果
		printf("玩家剩余积分：%d  电脑剩余积分：%d\n\n", UserScore, ComputerScore);

		//结局2--玩家主动结束游戏
		printf("是否继续？继续游戏输入：Y/y，结束游戏输入：N/n\n\n");
		scanf_s("%c", &IfContinue);
		getchar();
		if (IfContinue == 'n' || IfContinue == 'N')
		{
			printf("感谢游玩 再见！\n");
			break;
		}
	}
}

void ThrowDice(int dice[])
{
	int range = 6;
	srand((int)time(0));
	for (int i = 0; i <= 2; i++)
	{
		dice[i] = rand() % range + 1;
	}
}
