//-----------------------------------------------------------------------
// <copyright file="SerializationHelper.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>序列化帮助类</discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Common.Xml
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// SerializationHelper 序列化帮助类
    /// </summary>
    public class SerializationHelper
    {
        /// <summary>
        /// _dict 私有变量
        /// </summary>
        private static Dictionary<int, XmlSerializer> _dict = new Dictionary<int, XmlSerializer>();

        /// <summary>
        /// GetSerializer 序列化
        /// </summary>
        /// <param name="t">T 目标类型</param>
        /// <returns>返回 序列化</returns>
        public static XmlSerializer GetSerializer(Type t)
        {
            int type_hash = t.GetHashCode();

            if (!_dict.ContainsKey(type_hash))
            {
                _dict.Add(type_hash, new XmlSerializer(t));
            }

            return _dict[type_hash];
        }

        /// <summary>
        /// Load 反序列化
        /// </summary>
        /// <param name="type">type 对象类型</param>
        /// <param name="fileName">文件 路径</param>
        /// <returns>返回 装载类型</returns>
        public static object Load(Type type, string fileName)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(type);
                return serializer.Deserialize(fs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        /// <summary>
        /// Save 序列化
        /// </summary>
        /// <param name="obj">obj 对象</param>
        /// <param name="fileName">fileName 文件路径</param>
        /// <returns>returns 是否保存成功</returns>
        public static bool Save(object obj, string fileName)
        {
            bool success = false;

            FileStream fs = null;

            try
            {
                fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(fs, obj);
                success = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }

            return success;
        }

        /// <summary>
        /// Serialize 序列化成字符串
        /// </summary>
        /// <param name="obj">obj 对象</param>
        /// <returns>returns xml字符串</returns>
        public static string Serialize(object obj)
        {
            string returnStr = string.Empty;

            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            MemoryStream ms = new MemoryStream();
            XmlTextWriter xtw = null;
            StreamReader sr = null;
            try
            {
                xtw = new XmlTextWriter(ms, Encoding.UTF8);
                xtw.Formatting = Formatting.Indented;
                serializer.Serialize(xtw, obj);
                ms.Seek(0, SeekOrigin.Begin);
                sr = new StreamReader(ms);
                returnStr = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (xtw != null)
                {
                    xtw.Close();
                }

                if (sr != null)
                {
                    sr.Close();
                }

                ms.Close();
            }

            return returnStr;
        }

        /// <summary>
        /// DeSerialize 字符串反序列化成对象
        /// </summary>
        /// <param name="type">type 对象类型</param>
        /// <param name="str">str 字符串</param>
        /// <returns>returns 对象</returns>
        public static object DeSerialize(Type type, string str)
        {
            byte[] b = System.Text.Encoding.UTF8.GetBytes(str);
            try
            {
                XmlSerializer serializer = GetSerializer(type);
                return serializer.Deserialize(new MemoryStream(b));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
