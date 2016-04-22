//-----------------------------------------------------------------------
// <copyright file="Rnd.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>Common Regular Expression
// </discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Rnd 正态分布的随机数发生器
    /// </summary>
    public class Rnd
    {
        /// <summary>
        /// 数字 字符列表
        /// </summary>
        private static readonly char[] NUMARRAY = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        /// <summary>
        /// 字母 字符列表
        /// </summary>
        private static readonly char[] ABCARRAY = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        /// <summary>
        /// iset 变量
        /// </summary>
        private int iset;

        /// <summary>
        /// gset 变量
        /// </summary>
        private double gset;

        /// <summary>
        /// 两个 随机变量
        /// </summary>
        private System.Random r1, r2;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rnd"/> class. 随机数产生器
        /// </summary>
        public Rnd()
        {
            this.r1 = new Random(unchecked((int)DateTime.Now.Ticks));

            this.r2 = new Random(~unchecked((int)DateTime.Now.Ticks));

            this.iset = 0;
        }

        /// <summary>
        /// RandomABC 构造随机字符串
        /// </summary>
        /// <param name="strLen">strLen 随机字符串长度</param>
        /// <returns>returns 指定长度的随机字符串</returns>
        public static string RandomABC(int strLen)
        {
            StringBuilder temp = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < strLen; i++)
            {
                temp.Append(ABCARRAY[random.Next(ABCARRAY.Length)]);
            }

            return temp.ToString();
        }

        /// <summary>
        /// RandomCode 构造随机字符串
        /// </summary>
        /// <param name="strLen">strLen 随机字符串长度</param>
        /// <returns>returns 指定长度的随机字符串</returns>
        public static string RandomCode(int strLen)
        {
            StringBuilder temp = new StringBuilder();
            Random random = new Random();
            List<char> ls = new List<char>(ABCARRAY);
            ls.AddRange(NUMARRAY);
            char[] arr = ls.ToArray();

            for (int i = 0; i < strLen; i++)
            {
                temp.Append(arr[random.Next(arr.Length)]);
            }

            return temp.ToString();
        }

        /// <summary>
        /// RandomNum 构造随机数
        /// </summary>
        /// <param name="strLen">strLen 随机数长度</param>
        /// <returns>returns 指定长度的随机数</returns>
        public static string RandomNum(int strLen)
        {
            StringBuilder temp = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < strLen; i++)
            {
                temp.Append(NUMARRAY[random.Next(NUMARRAY.Length)]);
            }

            return temp.ToString();
        }

        /// <summary>
        /// NextDouble 产生下一个随机数
        /// </summary>
        /// <returns>return 随机数</returns>
        public double NextDouble()
        {
            double fac, rsq, v1, v2;

            if (this.iset == 0)
            {
                do
                {
                    v1 = (2.0 * this.r1.NextDouble()) - 1.0;
                    v2 = (2.0 * this.r2.NextDouble()) - 1.0;
                    rsq = (v1 * v1) + (v2 * v2);
                }
                while (rsq >= 1.0 || rsq == 0.0);

                fac = Math.Sqrt(-2.0 * Math.Log(rsq) / rsq);
                this.gset = v1 * fac;
                this.iset = 1;

                return Math.Abs(v2 * fac);
            }
            else
            {
                this.iset = 0;
                return Math.Abs(this.gset);
            }
        }

        /// <summary>
        /// Next 产生下一个随机数
        /// </summary>
        /// <returns>return 随机数</returns>
        public int Next()
        {
            return (int)Math.Round(this.NextDouble() * int.MaxValue, 0);
        }

        /// <summary>
        /// Next 产生下一个随机数
        /// </summary>
        /// <param name="maxValue">maxValue 随机数的最大值</param>
        /// <returns>return 随机数</returns>
        public int Next(int maxValue)
        {
            return (int)Math.Round(this.NextDouble() * maxValue, 0);
        }

        /// <summary>
        /// Next 产生下一个随机数
        /// </summary>
        /// <param name="minValue">minValue 随机数的最小值</param>
        /// <param name="maxValue">maxValue 随机数的最大值</param>
        /// <returns>return 随机数</returns>
        public int Next(int minValue, int maxValue)
        {
            return (int)Math.Round(minValue + (this.NextDouble() * (maxValue - minValue)), 0);
        }
    }
}