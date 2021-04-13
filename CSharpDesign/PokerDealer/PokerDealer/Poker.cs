using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Text.Json;

namespace PokerDealer
{
    /// <summary>
    /// 牌的类
    /// </summary>
    public class Poker : NotificationObject
    {
        public int Point { get; set; }
        // 牌的点数

        // 牌的点数 (string)
        public string PointString
        {
            get
            {
                if (Point == 1)
                {
                    return "A";
                }
                if (Point == 11)
                {
                    return "J";
                }
                if (Point == 12)
                {
                    return "Q";
                }
                if (Point == 13)
                {
                    return "K";
                }
                return Point.ToString();
            }
        }
        public PokerType PokerType { get; set; }
        // 牌的花色，详见PokerType
        public bool IsRed => (PokerType == PokerType.Heart || PokerType == PokerType.Cube);
        public string PokerTypeString
        {
            get
            {
                return PokerType switch
                {
                    PokerType.Spade => "♠",
                    PokerType.Heart => "♥️",
                    PokerType.Blossom => "♣️",
                    PokerType.Cube => "♦️",
                    _ => "",
                };
            }
        }
        public string GetEnumDescription(Enum en)
        {
            Type type = en.GetType();   //获取类型  
            MemberInfo[] memberInfos = type.GetMember(en.ToString());   //获取成员  
            if (memberInfos != null && memberInfos.Length > 0)
            {
                //获取描述特性  
                if (memberInfos[0].GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attrs && attrs.Length > 0)
                {
                    return attrs[0].Description;    //返回当前描述
                }
            }
            return en.ToString();
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
    /// 牌组的类
    /// </summary>
    public class PokerSet : NotificationObject
    {
        public int Index { get; set; }
        // 当前牌组的序号
        public ObservableCollection<Poker> Pokers { get; set; }
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
            Pokers = new ObservableCollection<Poker> { };
        }
    }

    /// <summary>
    /// 牌的花色枚举
    /// </summary>
    public enum PokerType
    {
        [Description("♠♠")]
        Spade = 0,
        [Description("♥♥")]
        Heart = 1,
        [Description("♣♣")]
        Blossom = 2,
        [Description("♦♦")]
        Cube = 3
    }
}
