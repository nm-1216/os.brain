//-----------------------------------------------------------------------
// <copyright file="Client.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2012/02/25</datetime>
// <discription>TCP/IP Client</discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Net
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    /// <summary>
    /// TCP/IP 通信程序 客户端
    /// </summary>
    public class Client
    {
        /// <summary>
        /// 客户端 向服务器端发送信息
        /// </summary>
        /// <param name="host">服务器端 地址</param>
        /// <param name="port">服务器端 端口</param>
        /// <param name="msg">发送给服务器端 内容</param>
        /// <param name="encoding">内容 编码格式 默认编码格式是GBK</param>
        /// <returns>返回 服务器端应答内容</returns>
        public static string SendMsg(string host, int port, string msg, string encoding)
        {
            if (string.IsNullOrEmpty(encoding))
            {
                encoding = "GBK";
            }

            TcpClient tc = null;

            try
            {
                tc = new TcpClient(host, port);
                tc.ReceiveTimeout = 1000;
                tc.SendTimeout = 1000;

                NetworkStream ns = tc.GetStream();

                byte[] tempMsg = Encoding.GetEncoding(encoding).GetBytes(msg);
                ns.Write(tempMsg, 0, tempMsg.Length);

                byte[] temp = new byte[2048];
                int index = ns.Read(temp, 0, temp.Length);

                return Encoding.GetEncoding(encoding).GetString(tempMsg, 0, index);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (null != tc && tc.Connected)
                {
                    tc.Close();
                }
            }
        }
    }
}
