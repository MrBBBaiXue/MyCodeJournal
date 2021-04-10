using System.Collections.Generic;
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
    }

    /// <summary>
    /// 初始牌堆，多一个是否被拿取的属性
    /// </summary>
    public class PokerInPool : Poker
    {
        public bool IsTaken { get; set; }
    }

    /// <summary>
    /// 牌组的类
    /// </summary>
    public class PokerSet
    {
        public int Index { get; set; }
        // 当前牌组的序号
        public List<Poker> Pokers { get; set; }
        // 存放牌组信息
        public string Serialize() => JsonSerializer.Serialize(this);
        // JSON序列化，详见 System.Text.Json
        public bool Deserialize(string str)
        {
            // JSON反序列化
            try
            {
                var pokerSet = JsonSerializer.Deserialize<PokerSet>(str);
                Pokers = pokerSet.Pokers;
                Index = pokerSet.Index;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// PokerSet类的构造器
        /// </summary>
        public PokerSet()
        {
            Pokers = new List<Poker> { };
        }
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
