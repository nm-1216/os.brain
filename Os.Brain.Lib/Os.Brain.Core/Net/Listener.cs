//-----------------------------------------------------------------------
// <copyright file="Listener.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2012/02/25</datetime>
// <discription>TCP/IP Listener</discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Net
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    /// <summary>
    /// 抽象 TCP/IP Listener TCP/IP 通信程序 服务器端
    /// </summary>
    public abstract class Listener
    {
        /// <summary>
        /// 编码 格式，默认值 GBK
        /// </summary>
        private string msgEncoding = "GBK";

        /// <summary>
        /// 监听 端口
        /// </summary>
        private int port;

        /// <summary>
        /// 默认主机 默认值 0.0.0.0 表示当前主机所有IP地址
        /// </summary>
        private string host = "0.0.0.0";
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Listener" /> class.
        /// </summary>
        /// <param name="port">监听 端口</param>
        public Listener(int port)
        {
            this.port = port;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Listener" /> class.
        /// </summary>
        /// <param name="port">监听 端口</param>
        /// <param name="encoding">信息 编码格式</param>
        public Listener(int port, string encoding)
        {
            this.port = port;
            if (!string.IsNullOrEmpty(encoding))
            {
                this.msgEncoding = encoding;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Listener" /> class.
        /// </summary>
        /// <param name="port">监听 端口</param>
        /// <param name="host">监听 主机</param>
        /// <param name="encoding">信息 编码格式</param>
        public Listener(int port, string host, string encoding)
        {
            if (!string.IsNullOrEmpty(host))
            {
                this.host = host;
            }

            this.port = port;

            if (!string.IsNullOrEmpty(encoding))
            {
                this.msgEncoding = encoding;
            }
        }

        /// <summary>
        /// Gets 编码 格式，默认值 GBK
        /// </summary>
        public string MsgEncoding
        {
            get
            {
                return this.msgEncoding;
            }
        }

        /// <summary>
        /// 监听程序 启动函数
        /// </summary>
        public void run()
        {
            IPAddress ip = IPAddress.Parse(this.host);
            IPEndPoint ipe = new IPEndPoint(ip, this.port);

            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Bind(ipe);
            s.Listen(0);

            while (true)
            {
                try
                {
                    Socket temp = s.Accept();

                    byte[] strMsgText = new byte[2048];
                    int msgTextLength = temp.Receive(strMsgText, strMsgText.Length, 0);

                    ////返回给请求者的数据
                    string sendXml = string.Empty;
                    ////接收到的数据
                    string receivedXml;
                    ////字节转换成字符 
                    receivedXml = Encoding.GetEncoding(this.msgEncoding).GetString(strMsgText, 0, msgTextLength);

                    ////转发数据并接收应答数据
                    sendXml = this.callBack(receivedXml);

                    ////返回数据
                    temp.Send(Encoding.GetEncoding(this.msgEncoding).GetBytes(sendXml));
                    temp.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 回调 方法
        /// </summary>
        /// <param name="str">通讯 请求报文</param>
        /// <returns>通讯 响应报文</returns>
        public abstract string callBack(string str);
    }
}
