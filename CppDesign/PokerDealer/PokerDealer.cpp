/****************************************************************
	P O K E R D E A L E R

		File Name: PokerDealer.cpp

		   Author: Chenhao Wang (MrBBBaiXue@github.com)
				   Boyan Wang (JingNianNian@github.com)
				   Wenle Zhang (Skywb@github.com)
				   Sen Ma

			 Date: 2021-04-05

	  Description: Randomly arrange poker and display.

****************************************************************/

#include <iostream>
#include <time.h>

// 程序自身的头文件
#include "PokerDataIO.h"
#include "Poker.h"

/// <summary>
/// 程序的入口点
/// </summary>
/// <returns>%ERRORLEVEL%</returns>
int main()
{
	auto pok = new Poker();
	pok->Point = 12;
	pok->Color = 0;
	std::cout << pok->GetDataString() << std::endl;
	// PokerDataIO Class
	PokerDataIO pokerDataIO = new PokerDataIO {
		DataPath = "C:\\pokerData.dat"
	}
	return 0;
}