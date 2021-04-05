/****************************************************************
	P O K E R D E A L E R

		File Name: Poker.cpp

		   Author: Chenhao Wang (MrBBBaiXue@github.com)
				   Boyan Wang (JingNianNian@github.com)
				   Wenle Zhang (Skywb@github.com)
				   Sen Ma

			 Date: 2021-04-05

	  Description: Randomly arrange poker and display.

****************************************************************/

#include "Poker.h"

std::string Poker::GetDataString()
{
	return std::string{std::to_string(Point) + "," + std::to_string(Color)};
}

bool Poker::SetDataString(std::string str)
{
	// 通过获得的string设置该Poker的Data
	return false;
}
