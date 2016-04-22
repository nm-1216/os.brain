//-----------------------------------------------------------------------
// <copyright file="Transpond.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2012/02/25</datetime>
// <discription>TCP/IP Transpond</discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Net
{
    using System;

    /// <summary>
    /// Transpond 中间传递程序
    /// </summary>
    public class Transpond : Listener
    {
        /// <summary>
        /// 目标服务器 端口
        /// </summary>
        private int tPort;

        /// <summary>
        /// 目标服务器 地址
        /// </summary>
        private string tHost;

        /// <summary>
        /// Initializes a new instance of the <see cref="Transpond" /> class. TCP/IP 中转程序
        /// </summary>
        /// <param name="port">监听服务器 端口</param>
        /// <param name="host">监听服务器 地址</param>
        /// <param name="encoding">传输信息 编码格式</param>
        /// <param name="toPort">目标服务器 端口</param>
        /// <param name="toHost">目标服务器 地址</param>
        public Transpond(int port, string host, string encoding, int toPort, string toHost)
            : base(port, host, encoding)
        {
            this.tPort = toPort;
            this.tHost = toHost;
        }

        /// <summary>
        /// 回调 函数
        /// </summary>
        /// <param name="str">传输 内容</param>
        /// <returns>目标服务器 应答内容</returns>
        public override string callBack(string str)
        {
            return Client.SendMsg(this.tHost, this.tPort, str, this.MsgEncoding);
        }
    }
}
