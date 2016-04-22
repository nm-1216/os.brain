//-----------------------------------------------------------------------
// <copyright file="Swap.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>Algorithms swap 交替</discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Common
{
    /// <summary>
    /// Algorithms 算法集
    /// </summary>
    public partial class Algorithms
    {
        /// <summary>
        /// Swap 交替
        /// </summary>
        /// <param name="a">A 参数一</param>
        /// <param name="b">B 参数二</param>
        public static void Swap(ref int a, ref int b)
        {
            Swap(ref a, ref b, 0);
        }

        /// <summary>
        /// Swap 交替
        /// </summary>
        /// <param name="a">A 参数1</param>
        /// <param name="b">B 参数2</param>
        /// <param name="type">参数三 0:从小到大排序，非0:从大到小排序</param>
        public static void Swap(ref int a, ref int b, int type)
        {
            if (type == 0)
            {
                if (a > b)
                {
                    int temp = a;
                    a = b;
                    b = temp;
                }
            }
            else
            {
                if (a < b)
                {
                    int temp = a;
                    a = b;
                    b = temp;
                }
            }
        }

        /// <summary>
        /// Swap 交替
        /// </summary>
        /// <typeparam name="T">T 泛型参数</typeparam>
        /// <param name="a">A 参数1</param>
        /// <param name="b">B 参数2</param>
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}
