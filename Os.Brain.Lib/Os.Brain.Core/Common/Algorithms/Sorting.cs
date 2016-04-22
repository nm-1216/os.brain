//-----------------------------------------------------------------------
// <copyright file="Sorting.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>Algorithms Sorting 排序</discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Common
{
    /// <summary>
    /// Algorithms 算法集
    /// </summary>
    public partial class Algorithms
    {
        #region 快速排序
        /// <summary>
        /// QuickSort (快速排序)
        /// </summary>
        /// <param name="arry">arry 排序数组</param>
        /// <returns>返回 排序后数组</returns>
        public static int[] QSort(int[] arry)
        {
            return QSort(arry, 0, arry.Length - 1);
        }

        /// <summary>
        /// QuickSort (快速排序)
        /// </summary>
        /// <param name="arry">arry 数组</param>
        /// <param name="left">left 左端点</param>
        /// <param name="right">right 右端点</param>
        /// <returns>返回 排序后数组</returns>
        public static int[] QSort(int[] arry, int left, int right)
        {
            int i, j;
            int middle;
            Swap(ref left, ref right);
            i = left;
            j = right;
            middle = arry[(left + right) / 2];
            do
            {
                while ((arry[i] < middle) && (i < right))
                {
                    i++;
                }

                while ((arry[j] > middle) && (j > left))
                {
                    j--;
                }

                if (i <= j)
                {
                    Swap(ref arry[i], ref arry[j]);
                    i++;
                    j--;
                }
            }
            while (i <= j);

            if (left < j)
            {
                QSort(arry, left, j);
            }

            if (right > i)
            {
                QSort(arry, i, right);
            }

            return arry;
        }
        #endregion

        #region 冒泡排序
        /// <summary>
        /// BubbleSort (冒泡排序)
        /// </summary>
        /// <param name="arry">arry 排序数组</param>
        /// <returns>返回 排序后数组</returns>
        public static int[] BSort(int[] arry)
        {
            return BSort(arry, 0);
        }

        /// <summary>
        /// BubbleSort (冒泡排序)
        /// </summary>
        /// <param name="arry">arry 排序数组</param>
        /// <param name="type">排序方式 0:从小到大，1:从大到小</param>
        /// <returns>排序后 数组</returns>
        public static int[] BSort(int[] arry, int type)
        {
            int i, j;
            for (i = 0; i < arry.Length - 1; i++)
            {
                for (j = 0; j < arry.Length - 1 - i; j++)
                {
                    Swap(ref arry[j], ref arry[j + 1], type);
                }
            }

            return arry;
        }
        #endregion

        #region 鸡尾酒排序
        /// <summary>
        /// CocktailSort (鸡尾酒排序)
        /// </summary>
        /// <param name="arry">arry 排序数组</param>
        /// <returns>返回 排序后数组</returns>
        public static int[] CSort(int[] arry)
        {
            int left = 0, right = arry.Length - 1;
            bool swaped = true;
            while (swaped == true)
            {
                swaped = false;
                for (int i = left; i < right; i++)
                {
                    Swap(ref arry[i], ref arry[i + 1]);
                    swaped = true;
                }

                right--;
                for (int i = right; i > left; i--)
                {
                    Swap(ref arry[i], ref arry[i - 1]);
                    swaped = true;
                }

                left++;
            }

            return arry;
        }
        #endregion

        #region 二分法查找
        /// <summary>
        /// BinarySearch (二分法查找)
        /// </summary>
        /// <param name="arry">arry 待检索数组</param>
        /// <param name="search">search 检索字符串</param>
        /// <param name="left">left 左端点</param>
        /// <param name="right">right 右端点</param>
        /// <returns>返回 字符串所在位置</returns>
        public static int BinarySearch(int[] arry, int search, int left, int right)
        {
            Swap(ref left, ref right);

            if (arry[left] > search)
            {
                return left == 0 ? 0 : ++left;
            }

            if (arry[left] == search)
            {
                return ++left;
            }

            if (arry[right] <= search)
            {
                return right + 1;
            }

            int middle = (left + right) / 2;
            if (left + 1 >= right)
            {
                return left + 1;
            }
            else
            {
                if (arry[middle] < search)
                {
                    return BinarySearch(arry, search, middle, right);
                }
                else if (arry[middle] == search)
                {
                    return ++middle;
                }
                else
                {
                    return BinarySearch(arry, search, left, middle);
                }
            }
        }

        /// <summary>
        /// BinarySearch (二分法查找)
        /// </summary>
        /// <param name="arry">arry 待检索数组</param>
        /// <param name="search">search 检索字符串</param>
        /// <returns>返回 字符串所在位置</returns>
        public static int BinarySearch(int[] arry, int search)
        {
            return BinarySearch(arry, search, 0, arry.Length - 1);
        }

        /// <summary>
        /// BinarySearch (二分法查找)
        /// </summary>
        /// <param name="arry">arry 待检索数组</param>
        /// <param name="search">search 检索字符串</param>
        /// <returns>返回 字符串所在位置</returns>
        public static int BinarySearch1(int[] arry, int search)
        {
            int left = 0, right = arry.Length - 1;
            while (left <= right)
            {
                int middle = (left + right) / 2;
                if (search == arry[middle])
                {
                    return middle;
                }

                if (search > arry[middle])
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            return left;
        }
        #endregion
    }
}
