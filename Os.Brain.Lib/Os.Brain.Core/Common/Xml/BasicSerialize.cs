//-----------------------------------------------------------------------
// <copyright file="BasicSerialize.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>序列化基类</discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Common.Xml
{
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    /// <summary>
    /// BasicSerialize 序列化基类
    /// </summary>
    /// <typeparam name="T">T 目标类型</typeparam>
    public abstract class BasicSerialize<T> where T : class
    {
        /// <summary>
        /// LoadXml 反序列化
        /// </summary>
        /// <param name="xml">xml 字符串行</param>
        /// <returns>返回 目标类型实例</returns>
        public static T LoadXml(string xml)
        {
            using (MemoryStream ms = new MemoryStream(Encoding.Default.GetBytes(xml)))
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                return (T)xs.Deserialize(ms);
            }
        }
        
        /// <summary>
        /// ToXml 序列化
        /// </summary>
        /// <returns>返回 xml 字符串</returns>
        public string ToXml()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                xs.Serialize(ms, this);
                return Encoding.Default.GetString(ms.ToArray());
            }
        }
    }
}
