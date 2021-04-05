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
	int Point { get; set; }; // ����
	int Color; // 0 ����
			   // 1 ����
	           // 2 ��÷
	           // 3 ��Ƭ
	std::string GetDataString();
	bool SetDataString(std::string str);

};