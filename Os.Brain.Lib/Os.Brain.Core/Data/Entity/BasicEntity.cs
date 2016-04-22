//-----------------------------------------------------------------------
// <copyright file="BasicEntity.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>抽象实体基类
// * Discription:
// *      Entity层：
// *          继承关系：所有类继承自BasicEntity, 其中BasicEntity实现 java.io.Serializable接口
// *          命名规则：类名称 = Object + 类后缀，其中类后缀为 Bean，如：ObjectBean
// </discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Data.Entity
{
    using System;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// Basic Entity
    /// </summary>
    [Serializable]
    public abstract class BasicEntity
    {
        /// <summary>
        /// Rewrite ToString method
        /// </summary>
        /// <returns>Return all property value</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append(" [\n");
            System.Reflection.PropertyInfo[] properties = this.GetType().GetProperties(BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo property in properties)
            {
                sb.Append(string.Format("{0} : {1}\n", property.ToString(), property.GetValue(this, null)));
            }

            sb.Append("]");
            return sb.ToString();
        }

        /// <summary>
        /// Rewrite Equals Method
        /// </summary>
        /// <param name="obj">another object</param>
        /// <returns>Return Equal value</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Rewrite GetHashCode method
        /// </summary>
        /// <returns>Return GetHashCode value</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// abstract insert
        /// </summary>
        /// <returns>Return object</returns>
        public abstract object Insert();

        /// <summary>
        /// abstract update
        /// </summary>
        /// <returns>Return object</returns>
        public abstract object Update();

        /// <summary>
        /// abstract delete
        /// </summary>
        /// <returns>Return number</returns>
        public abstract int Delete();
    }
}
