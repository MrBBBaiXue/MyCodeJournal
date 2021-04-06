/****************************************************************
	P O K E R D E A L E R

		File Name: Classes/Poker.cs

		   Author: Chenhao Wang (MrBBBaiXue@github.com)
				   Boyan Wang (JingNianNian@github.com)
				   Wenle Zhang (Skywb@github.com)
				   Sen Ma

			 Date: 2021-04-05

	  Description: Randomly arrange poker and display.

****************************************************************/

using System.ComponentModel;
using System.Text.Json;

namespace PokerDealer
{
    /// <summary>
    /// 牌的类
    /// </summary>
    public class Poker
    {
        public int Point { get; set; }
        // 牌的点数
        public PokerType PokerType { get; set; }
        // 牌的花色，详见PokerType
        public string Serialize() => JsonSerializer.Serialize(this);
        // JSON序列化（这是唯一和C++有区别的地方，在C++中要手写实现）
        public bool Deserialize(string str)
        {
            try
            {
                var poker = JsonSerializer.Deserialize<Poker>(str);
                Point = poker.Point;
                PokerType = poker.PokerType;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    /// <summary>
    /// 初始牌堆，多一个是否被拿取的属性
    /// </summary>
    public class PokerInPool : Poker
    {
        public bool IsTaken { get; set; }
    }

    /// <summary>
    /// 牌的花色枚举
    /// </summary>
    public enum PokerType
    {
        [Description("♠ 黑桃")]
        Spade = 0,
        [Description("♥ 红心")]
        Heart = 1,
        [Description("♣ 梅花")]
        Blossom = 2,
        [Description("♦ 方片")]
        Cube = 3
    }
}
