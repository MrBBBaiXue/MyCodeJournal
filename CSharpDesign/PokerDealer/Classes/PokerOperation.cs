using System;
using System.Collections.Generic;
using System.Text;

namespace PokerDealer
{
    public static class PokerOperation
    {
        /// <summary>
        /// 获得初始牌池
        /// </summary>
        /// <returns>初始化的牌池</returns>
        public static List<PokerInPool> GeneratePokerPool()
        {
            var pokerPool = new List<PokerInPool> { };
            for (var type = 0; type <= 3; type++)
            {
                for (var point = 1; point <= 13; point++)
                {
                    // 往初始牌池中放入按顺序的牌
                    var poker = new PokerInPool
                    {
                        Point = point,
                        PokerType = (PokerType)type,
                        IsTaken = false
                    };
                    pokerPool.Add(poker);
                }
            }
            // 返回生成好的初始牌池
            return pokerPool;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pokerPool"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static PokerSet GeneratePokerSet(List<PokerInPool> pokerPool,
                                                int index,
                                                int count) 
        {
            Random random = new Random();
            var pokerSet = new PokerSet
            {
                Index = index
            };
            for (var n = 1; n <= count; n++)
            {
                int poolIndex;
                do
                {
                    poolIndex = random.Next(0, 52);
                }
                while (pokerPool[poolIndex].IsTaken == true);
                // 如果没有被拿走，那么就把这个扑克增加到扑克堆中
                var poker = new Poker
                {
                    Point = pokerPool[poolIndex].Point,
                    PokerType = pokerPool[poolIndex].PokerType
                };
                pokerPool[poolIndex].IsTaken = true;
                pokerSet.Pokers.Add(poker);
            }
            return pokerSet;
        }
    }
}
