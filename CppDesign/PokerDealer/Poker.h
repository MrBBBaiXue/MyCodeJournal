/****************************************************************
	P O K E R D E A L E R

		File Name: Poker.h

		   Author: Chenhao Wang (MrBBBaiXue@github.com)
				   Boyan Wang (JingNianNian@github.com)
				   Wenle Zhang (Skywb@github.com)
				   Sen Ma

			 Date: 2021-04-05

	  Description: Randomly arrange poker and display.

****************************************************************/

#pragma once

#include <iostream>
#include <string>

class Poker
{
public:
	int Point;
	PokerColor Color;
	std::string GetData();
	bool SetData();
};

enum PokerColor
{
	Spade = 0,
	Heart = 1,
	Blossom = 2,
	Cube = 3
};