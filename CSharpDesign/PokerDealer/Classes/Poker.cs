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
    public class Poker
    {
        public int Point { get; set; }
        public PokerType PokerType { get; set; }
        public string Serialize() => JsonSerializer.Serialize(this);
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
