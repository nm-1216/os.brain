//-----------------------------------------------------------------------
// <copyright file="IPFilterModule.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2012/02/25</datetime>
// <discription>IP地址过滤器</discription>
//-----------------------------------------------------------------------

namespace Os.Brain.HttpModules
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Web;

    using Os.Brain.Common;
    /// <summary>
    /// IP 地址过滤器
    /// </summary>
    public class IPFilterModule : IHttpModule
    {
        /// <summary>
        /// 初始化模块，并使其为处理请求做好准备。使用 Init 方法向特定事件注册事件处理方法。
        /// </summary>
        /// <param name="context">context 对象</param>
        public void Init(HttpApplication context)
        {
            context.AcquireRequestState += new EventHandler(this.context_AcquireRequestState);
        }

        private void context_AcquireRequestState(object sender, EventArgs e)
        {
            HttpContext context = (sender as HttpApplication).Context;

            if (null == context.Session)
                return;

            long ip = 0;

            if (null == context.Session["com.framework.filter_ip"])
            {
                context.Session["com.framework.filter_ip"] = ip = IP.ToInt(IP.GetIp());
            }
            else
            {
                ip = long.Parse(context.Session["com.framework.filter_ip"].ToString());
            }

            if (null == context.Cache["com.framework.filter_ip_list"])
            {
                ////工厂提供缓存
                context.Cache["com.framework.filter_ip_list"] = new List<IpRegion>();
            }

            IList<IpRegion> iplist = new List<IpRegion>();

            iplist.Add(new IpRegion("127.0.0.1"));
            context.Cache["com.framework.filter_ip_list"] = iplist;

            foreach (IpRegion i in context.Cache["com.framework.filter_ip_list"] as IList<IpRegion>)
            {
                if (i.contains(ip) == 0)
                {
                    context.Response.Write("ip地址访问限制");
                    context.Response.End();
                }
            }
        }

        /// <summary>
        /// 处置由实现 IHttpModule 的模块使用的资源（内存除外）。
        /// </summary>
        void IHttpModule.Dispose()
        {
        }

        /// <summary>
        /// IP 地址区间
        /// </summary>
        [Serializable]
        public class IpRegion
        {
            private long minValue = 0;
            private long maxValue = 0;

            public IpRegion(long minValue, long maxValue)
            {
                this.init(minValue, maxValue);
            }

            public IpRegion(string ips)
            {
                string[] temp = ips.Split('-');
                if (temp.Length == 2)
                    this.init(IP.ToInt(temp[0]), IP.ToInt(temp[1]));
                else
                    this.init(IP.ToInt(temp[0]), IP.ToInt(temp[0]));
            }

            public IpRegion()
            {
            }

            public long MinValue
            {
                get { return this.minValue; }
                set { this.minValue = value; }
            }

            public long MaxValue
            {
                get { return this.maxValue; }
                set { this.maxValue = value; }
            }

            public override bool Equals(object obj)
            {
                IpRegion _obj = obj as IpRegion;
                return this.maxValue == _obj.maxValue && this.minValue == _obj.minValue;
            }

            /// <summary>
            /// 判定 当前IP地址是否在区域内
            /// </summary>
            /// <param name="obj">IP 地址</param>
            /// <returns>-1 小于最小，0 在区域内，1大于最大</returns>
            public int contains(long obj)
            {
                if (obj < this.minValue)
                    return -1;
                else if (obj > this.maxValue)
                    return 1;
                else
                    return 0;
            }

            public int contains(string ips)
            {
                return this.contains(IP.ToInt(ips));
            }

            public override string ToString()
            {
                return string.Format("{0}-{1}", IP.ToString(this.minValue), IP.ToString(this.maxValue));
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            private void init(long minValue, long maxValue)
            {
                if (minValue < maxValue)
                {
                    this.minValue = minValue;
                    this.maxValue = maxValue;
                }
                else
                {
                    this.minValue = maxValue;
                    this.maxValue = minValue;
                }
            }
        }

    }
}
