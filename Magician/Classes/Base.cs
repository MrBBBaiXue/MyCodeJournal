/****************************************************************
	                    M A G I C I A N

		File Name: Base.cs

		   Author: Chenhao Wang (MrBBBaiXue@github.com)
				   Boyan Wang (JingNianNian@github.com)
				   Wenle Zhang (Skywb@github.com)

	         Date: 2021-04-05

	  Description: Base Class, contains base definitions.

****************************************************************/

using System;

namespace Magician
{

    /// <summary> 
    /// 将观众角色抽象为对象，继承Number类
    /// </summary>
    class Viewer : Number
    {
        /// <summary>
        /// 基于玩家是魔术师时，获取答案以判断玩家猜测是否正确
        /// </summary>
        /// <returns>答案</returns>
        public int GetAnswer()
            => InputNumber;
        public int GetRemoveSelfSum()
            => RemoveSelfSum;
        /// <summary>
        /// 类的构造函数
        /// </summary>
        /// <param name="input">观众输入心中所想的数字，其除自身以外的和的结果由程序计算</param>
        public Viewer(int input) : base(input)
        {
            if (input > 1000 || input < 100)
            {
                throw new Exception("超出范围");
            }
        }
        /// <summary>
        /// 重载构造函数，允许观众输入数字除自身以外的和
        /// </summary>
        /// <param name="input">观众输入数字除自身以外的和</param>
        /// <param name="b">用于区分构造函数重载</param>
        public Viewer(int input, byte b) : base(input, b)
        {
            if (input > 4995 || input < 122)
            {
                throw new Exception("超出范围");
            }
        }
    }
    /// <summary>
    /// 将魔术师角色抽象为对象
    /// </summary>
    class Magician
    {
        /// <summary>
        /// 基于电脑时魔术师时，通过玩家给定信息计算玩家所想的数字
        /// </summary>
        /// <param name="removeSelfSum">玩家传入的数字之和</param>
        /// <returns>玩家所想数字</returns>
        public int CalculateAnswer(int removeSelfSum)
        {
            int nCon = removeSelfSum / 222;
            int nOne, nTen, nHund;
            int nNum;
            do
            {
                nNum = 222 * nCon - removeSelfSum;
                if (nNum < 100)
                {
                    nCon++;
                }
                else if (nNum > 1000)
                {
                    return -1;
                }
                else if (nNum >= 100 && nNum <= 1000)
                {
                    nOne = nNum % 10;
                    nTen = nNum / 10 % 10;
                    nHund = nNum / 100;
                    if (nOne + nTen + nHund == nCon)
                    {
                        return nNum;
                    }
                    else
                    {
                        nCon++;
                        continue;
                    }
                }
                else
                {
                    throw new Exception();
                }
            } while (true);
        }
        /// <summary>
        /// 基于玩家是魔术师时，判断玩家猜测是否正确
        /// </summary>
        /// <param name="guestNumber">玩家猜测的数</param>
        /// <param name="v">Viewer对象，用于调用获取答案的方法</param>
        /// <returns></returns>
        public bool IsCorrectAnswer(int guestNumber, Viewer v)
            => guestNumber == v.GetAnswer();
    }

    /// <summary>
    /// 将数字抽象为对象，其中属性的访问级别均为protected，不可被除继承此类的其它类型访问
    /// </summary>
    class Number
    {
        private static Random Random = new Random();
        protected int InputNumber { get; }
        protected int OnePosition { get; }
        // 个位
        protected int TensPosition { get; }
        // 十分位
        protected int HundredsPosition { get; }
        // 百分位
        protected int[] FullPermutation { get; }
        // 全排列
        protected int RemoveSelfSum { get; }
        // 删除自身的数
        /// <summary>
        /// 类的构造函数，通过玩家输入所想的数来确定其它信息
        /// </summary>
        /// <param name="inputNumber">观众输入所想数字</param>
        public Number(int inputNumber)
        {
            InputNumber = inputNumber;
            FullPermutation = new int[6];
            OnePosition = InputNumber % 10;
            TensPosition = (InputNumber / 10) % 10;
            HundredsPosition = InputNumber / 100;
            FullPermutation[0] = InputNumber;
            FullPermutation[1] = HundredsPosition * 100 + OnePosition * 10 + TensPosition;
            FullPermutation[2] = TensPosition * 100 + OnePosition * 10 + HundredsPosition;
            FullPermutation[3] = TensPosition * 100 + HundredsPosition * 10 + OnePosition;
            FullPermutation[4] = OnePosition * 100 + HundredsPosition * 10 + TensPosition;
            FullPermutation[5] = OnePosition * 100 + TensPosition * 10 + HundredsPosition;
            int f()
            {
                int sum = 0;
                for (int i = 1; i <= 5; i++)
                {
                    sum += FullPermutation[i];
                }
                return sum;
            }
            RemoveSelfSum = f();
        }
        /// <summary>
        /// 重载构造函数，允许观众直接输入数字
        /// </summary>
        /// <param name="inputSum"></param>
        /// <param name="b"></param>
        public Number(int inputSum, byte b)
        {
            RemoveSelfSum = inputSum;
        }
        /// <summary>
        /// 当玩家选择魔术师时，生成100-999的随机数来对Viewer进行初始化
        /// </summary>
        /// <returns>一个100-999的随机数</returns>
        public static int GetRandomNumber()
        {
            return Random.Next(100,1000);
        }
    }
}
