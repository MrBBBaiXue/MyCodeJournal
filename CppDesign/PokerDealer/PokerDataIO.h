/****************************************************************
	P O K E R D E A L E R

		File Name: PokerDataIO.h

		   Author: Chenhao Wang (MrBBBaiXue@github.com)
				   Boyan Wang (JingNianNian@github.com)
				   Wenle Zhang (Skywb@github.com)
				   Sen Ma

			 Date: 2021-04-05

	  Description: Randomly arrange poker and display.

****************************************************************/

#pragma once

#include <iostream>
#include <fstream>

class PokerDataIO
{
public:
	std::string DataPath;
	Poker* Pokers[];
	void Write();
	void Read();
};