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
	int Point { get; set; }; // 点数
	int Color; // 0 黑桃
			   // 1 红心
	           // 2 黑梅
	           // 3 方片
	std::string GetDataString();
	bool SetDataString(std::string str);

};