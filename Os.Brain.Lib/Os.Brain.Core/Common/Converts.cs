//-----------------------------------------------------------------------
// <copyright file="Converts.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>类型转换</discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Common
{
    using System;
    using System.Data;

    /// <summary>
    /// Converts 转换
    /// </summary>
    public class Converts
    {
        #region Int Array/String Array

        /// <summary>
        /// 数组转换， Int 型数组转换成 String 型数组 
        /// </summary>
        /// <param name="array">Int 型数组</param>
        /// <returns>String 型数组</returns>
        public static string[] ToStringArray(int[] array)
        {
            string[] strArray = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                strArray[i] = array[i].ToString();
            }

            return strArray;
        }

        /// <summary>
        /// ToStringArray 字符串转换成数组
        /// </summary>
        /// <param name="str">str 搜索字符串</param>
        /// <param name="separator">separator 分隔符</param>
        /// <returns>returns 子字符串集</returns>
        public static string[] ToStringArray(string str, params char[] separator)
        {
            return str.Split(separator);
        }

        #endregion

        #region Type/DbType/TypeCode

        /// <summary>
        /// ToType 数据类型转换
        /// </summary>
        /// <param name="dbt">dbType 数据库类型</param>
        /// <returns>returns system.types</returns>
        public static Type ToType(DbType dbt)
        {
            switch (dbt)
            {
                case DbType.Boolean:
                    return typeof(bool);

                case DbType.DateTime:
                    return typeof(DateTime);

                case DbType.Decimal:
                    return typeof(decimal);

                case DbType.Double:
                    return typeof(double);

                case DbType.Guid:
                    return typeof(Guid);

                case DbType.Int16:
                    return typeof(short);

                case DbType.Int32:
                    return typeof(int);

                case DbType.Int64:
                    return typeof(long);

                case DbType.Single:
                    return typeof(float);

                case DbType.String:
                    return typeof(string);
            }

            return typeof(object);
        }

        /// <summary>
        /// ToDbType 数据类型转换
        /// </summary>
        /// <param name="type">type system.types</param>
        /// <returns>returns 数据库类型</returns>
        public static DbType ToDbType(Type type)
        {
            switch (type.ToString())
            {
                case "System.Int16":
                    return DbType.Int16;

                case "System.Int32":
                    return DbType.Int32;

                case "System.Int64":
                    return DbType.Int64;

                case "System.Single":
                    return DbType.Single;

                case "System.Double":
                    return DbType.Double;

                case "System.Decimal":
                    return DbType.Decimal;

                case "System.DateTime":
                    return DbType.DateTime;

                case "System.String":
                case "System.Char":
                    return DbType.String;

                case "System.Boolean":
                    return DbType.Boolean;

                case "System.Guid":
                    return DbType.Guid;
            }

            return DbType.Object;
        }

        /// <summary>
        /// ToDbType 数据类型转换
        /// </summary>
        /// <param name="typeCode">typeCode system.types</param>
        /// <returns>returns 数据库类型</returns>
        public static DbType ToDbType(TypeCode typeCode)
        {
            switch (typeCode)
            {
                case TypeCode.Empty:
                case TypeCode.DBNull:
                    return DbType.Object;

                case TypeCode.Boolean:
                    return DbType.Boolean;

                case TypeCode.Char:
                    return DbType.StringFixedLength;

                case TypeCode.SByte:
                    return DbType.SByte;

                case TypeCode.Byte:
                    return DbType.Byte;

                case TypeCode.Int16:
                    return DbType.Int16;

                case TypeCode.UInt16:
                    return DbType.UInt16;

                case TypeCode.Int32:
                    return DbType.Int32;

                case TypeCode.UInt32:
                    return DbType.UInt32;

                case TypeCode.Int64:
                    return DbType.Int64;

                case TypeCode.UInt64:
                    return DbType.UInt64;

                case TypeCode.Single:
                    return DbType.Single;

                case TypeCode.Double:
                    return DbType.Double;

                case TypeCode.Decimal:
                    return DbType.Decimal;

                case TypeCode.DateTime:
                    return DbType.DateTime;

                case TypeCode.String:
                    return DbType.String;
            }

            return DbType.Object;        
        }

        /// <summary>
        /// ToTypeCode 数据类型转换
        /// </summary>
        /// <param name="dbt">dbType 数据库类型</param>
        /// <returns>returns system.types</returns>
        public static TypeCode ToTypeCode(DbType dbt)
        {
            switch (dbt)
            {
                case DbType.Byte:
                    return TypeCode.Byte;

                case DbType.Boolean:
                    return TypeCode.Boolean;

                case DbType.DateTime:
                    return TypeCode.DateTime;

                case DbType.Decimal:
                    return TypeCode.Decimal;

                case DbType.Double:
                    return TypeCode.Double;

                case DbType.Int16:
                    return TypeCode.Int16;

                case DbType.Int32:
                    return TypeCode.Int32;

                case DbType.Int64:
                    return TypeCode.Int64;

                case DbType.SByte:
                    return TypeCode.SByte;

                case DbType.Single:
                    return TypeCode.Single;

                case DbType.String:
                    return TypeCode.String;

                case DbType.UInt16:
                    return TypeCode.UInt16;

                case DbType.UInt32:
                    return TypeCode.UInt32;

                case DbType.UInt64:
                    return TypeCode.UInt64;

                case DbType.StringFixedLength:
                    return TypeCode.Char;
            }

            return TypeCode.Object;
        }

        #endregion

        #region 全角/半角

        /// <summary>
        /// ToSBC 半角转全角(SBC case) 
        /// </summary>
        /// <param name="input">input 待转码字符串</param>
        /// <returns>returns 转码后字符串</returns>
        public static string ToSBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }

                if (c[i] < 127)
                {
                    c[i] = (char)(c[i] + 65248);
                }
            }

            return new string(c);
        }

        /// <summary>
        /// ToDBC 全角转半角(SBC case) 
        /// </summary>
        /// <param name="input">input 待转码</param>
        /// <returns>returns 转码后字符串</returns>
        public static string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }

                if (c[i] > 65280 && c[i] < 65375)
                {
                    c[i] = (char)(c[i] - 65248);
                }
            }

            return new string(c);
        }

        #endregion
        
        #region 字符串/ASCII

        /// <summary>
        /// ToAsc 字符串转换为 ASCII
        /// </summary>
        /// <param name="character">character 字符码</param>
        /// <returns>returns ASCII数值</returns>
        public static int ToAsc(string character)
        {
            if (character.Length == 1)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                int intAsciiCode = (int)asciiEncoding.GetBytes(character)[0];

                return intAsciiCode;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// ASCII 转化为字符串
        /// </summary>
        /// <param name="asciiCode">asciiCode ASCII数值</param>
        /// <returns>returns 对应字符</returns>
        public static string ToChr(int asciiCode)
        {
            if (asciiCode >= 0 && asciiCode <= 255)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                byte[] byteArray = new byte[] { (byte)asciiCode };
                string strCharacter = asciiEncoding.GetString(byteArray);

                return strCharacter;
            }
            else
            {
                return string.Empty;
            }
        }
        
        #endregion
    }
}
