//-----------------------------------------------------------------------
// <copyright file="AuthCodeHttpHander.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2012/02/25</datetime>
// <discription>验证码产生器 高仿腾讯
// Version:1.0.1
// Example:
// <httpHandlers>
//      <add verb="*" path="*.hwx" type="Os.Brain.HttpHanders.AuthCodeHttpHander"/>
// </httpHandlers>
// </discription>
//-----------------------------------------------------------------------

namespace Os.Brain.HttpHanders
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Drawing.Text;
    using System.IO;
    using System.Web;
    using System.Web.SessionState;

    using Os.Brain.Common;

    /// <summary>
    /// 验证码产生器 高仿腾讯
    /// </summary>
    public class AuthCodeHttpHander : IHttpHandler, IRequiresSessionState
    {
        /// <summary>
        /// 产生图片 宽度：_WIDTH, 高度：_HEIGHT
        /// </summary>
        private static readonly int _WIDTH = 130, _HEIGHT = 53;

        ////字体集
        ////private static readonly string[] _FONT_FAMIly = { "Arial", "Arial Black", "Arial Italic", "Courier New", "Courier New Bold Italic", "Courier New Italic", "Courier New Italic", "Courier New Bold Italic" };
        ////private static readonly string[] _FONT_FAMIly = { "Arial", "Arial Black", "Arial Italic", "Courier New", "Courier New Bold Italic", "Courier New Italic", "Franklin Gothic Medium", "Franklin Gothic Medium Italic" };

        /// <summary>
        /// 字体 集
        /// </summary>
        private static readonly string[] _FONT_FAMIly = { "Stencil" };

        ////private static readonly int[] _FONT_SIZE = { 20, 25, 30 };

        /// <summary>
        /// 字体 大小集
        /// </summary>
        private static readonly int[] _FONT_SIZE = { 30 };

        /// <summary>
        /// 前景 颜色集
        /// </summary>
        private static readonly Color[] _COLOR_FACE = { Color.FromArgb(113, 153, 67), Color.FromArgb(30, 99, 140), Color.FromArgb(206, 60, 19), Color.FromArgb(227, 60, 0) };

        /// <summary>
        /// 背景 颜色集
        /// </summary>
        private static readonly Color[] _COLOR_BACKGROUND = { Color.FromArgb(247, 254, 236), Color.FromArgb(234, 248, 255), Color.FromArgb(244, 250, 246), Color.FromArgb(248, 248, 248) };

        /// <summary>
        /// 文本 左右旋转角度
        /// </summary>
        private static readonly int _ANGLE = 30;

        /// <summary>
        /// 验证码 SESSION 名称
        /// </summary>
        private static string VCODE_SESSION = "vcode";

        /// <summary>
        /// 验证码 类型
        /// </summary>
        private static Types VCODE_TYPE = Types.Number;

        /// <summary>
        /// 验证码 字符长度
        /// </summary>
        private static int VCODE_LENGTH = 4;

        /// <summary>
        /// 验证码 字符是否加密
        /// </summary>
        ////private static bool VCODE_IsEncrypt = true;

        /// <summary>
        /// 验证码 是否出分大小写
        /// </summary>
        private static bool VCODE_IsIgnore = false;

        /// <summary>
        /// 文本 布局信息
        /// </summary>
        private static StringFormat _DL_FORMAT = new StringFormat(StringFormatFlags.NoClip);
        
        /// <summary>
        /// 验证码 类型
        /// </summary>
        protected enum Types : int
        {
            /// <summary>
            /// Number 纯数字
            /// </summary>
            Number = 0,

            /// <summary>
            /// ABC 纯字母
            /// </summary>
            ABC = 1,

            /// <summary>
            /// 数字 和 字母
            /// </summary>
            Character = 2
        }

        /// <summary>
        /// Gets a value indicating whether the item is IsReusable.
        /// </summary>
        public bool IsReusable
        {
            get { return true; }
        }

        #region Methods

        /// <summary>
        /// Process Request
        /// </summary>
        /// <param name="context">Http Context</param>
        public void ProcessRequest(HttpContext context)
        {
            this.CreateImage(this.GetCheckCode(context), context);
        }

        /// <summary>
        /// 获取 验证码字符串
        /// </summary>
        /// <param name="context">Http Context</param>
        /// <returns>返回 字符串</returns>
        private string GetCheckCode(HttpContext context)
        {
            string _checkCode = string.Empty;

            if (VCODE_TYPE == Types.Number)
            {
                _checkCode = Rnd.RandomNum(VCODE_LENGTH);
            }
            else if (VCODE_TYPE == Types.ABC)
            {
                _checkCode = Rnd.RandomABC(VCODE_LENGTH);
            }
            else
            {
                _checkCode = Rnd.RandomCode(VCODE_LENGTH);
            }

            ////if (VCODE_IsEncrypt)
            ////    context.Session[VCODE_SESSION] = MD5.Encode(VCODE_IsIgnore ? _checkCode : _checkCode.ToLower());
            ////else
            ////    context.Session[VCODE_SESSION] = VCODE_IsIgnore ? _checkCode : _checkCode.ToLower();

            context.Session[VCODE_SESSION] = VCODE_IsIgnore ? _checkCode : _checkCode.ToLower();

            return _checkCode;
        }

        /// <summary>
        /// 生成 验证码图片
        /// </summary>
        /// <param name="code">验证码 字符串</param>
        /// <param name="context">Http Context</param>
        private void CreateImage(string code, HttpContext context)
        {
            _DL_FORMAT.Alignment = StringAlignment.Center;
            _DL_FORMAT.LineAlignment = StringAlignment.Center;

            long tick = DateTime.Now.Ticks;
            Random Rnd = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));

            using (Bitmap _img = new Bitmap(_WIDTH, _HEIGHT))
            {
                using (Graphics g = Graphics.FromImage(_img))
                {
                    g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                    Point dot = new Point(20, 20);

                    //// 定义一个无干扰线区间和一个起始位置
                    int nor = Rnd.Next(53), rsta = Rnd.Next(130);
                    //// 绘制干扰正弦曲线 M:曲线平折度, D:Y轴常量 V:X轴焦距
                    int M = Rnd.Next(15) + 5, D = Rnd.Next(20) + 15, V = Rnd.Next(5) + 1;

                    int ColorIndex = Rnd.Next(4);

                    float Px_x = 0.0F;
                    float Px_y = Convert.ToSingle((M * Math.Sin(((V * Px_x) * Math.PI) / 180)) + D);
                    float Py_x, Py_y;

                    ////填充背景
                    g.Clear(_COLOR_BACKGROUND[Rnd.Next(4)]);

                    ////前景刷子 //背景刷子
                    using (Brush _BrushFace = new SolidBrush(_COLOR_FACE[ColorIndex]))
                    {
                        #region 绘制正弦线
                        for (int i = 0; i < 131; i++)
                        {
                            ////初始化y点
                            Py_x = Px_x + 1;
                            Py_y = Convert.ToSingle((M * Math.Sin(((V * Py_x) * Math.PI) / 180)) + D);

                            ////确定线条颜色
                            if (rsta >= i || i > (rsta + nor))
                            {
                                ////初始化画笔
                                using (Pen _pen = new Pen(_BrushFace, Rnd.Next(2, 4) + 1.5F))
                                {
                                    ////绘制线条
                                    g.DrawLine(_pen, Px_x, Px_y, Py_x, Py_y);
                                }
                            }

                            ////交替x,y坐标点
                            Px_x = Py_x;
                            Px_y = Py_y;
                        }
                        #endregion

                        ////初始化光标的开始位置
                        g.TranslateTransform(14, 10);

                        #region 绘制校验码字符串
                        for (int i = 0; i < code.Length; i++)
                        {
                            ////随机旋转 角度
                            int angle = Rnd.Next(-_ANGLE, _ANGLE);
                            ////移动光标到指定位置
                            g.TranslateTransform(dot.X, dot.Y);
                            ////旋转
                            g.RotateTransform(angle);

                            ////初始化字体
                            ////using (Font _font = new Font(_FONT_FAMIly[Rnd.Next(0, 8)], _FONT_SIZE[Rnd.Next(0, 3)]))
                            using (Font _font = new Font(_FONT_FAMIly[0], _FONT_SIZE[0]))
                            {
                                ////绘制
                                g.DrawString(code[i].ToString(), _font, _BrushFace, 1, 1, _DL_FORMAT);
                            }
                            ////反转
                            g.RotateTransform(-angle);
                            ////重新定位光标位置
                            g.TranslateTransform(2, -dot.Y);
                        }
                        #endregion
                    }
                }

                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    context.Response.ContentType = "Image/PNG";
                    context.Response.Clear();
                    context.Response.BufferOutput = true;
                    _img.Save(ms, ImageFormat.Png);
                    ms.Flush();
                    context.Response.BinaryWrite(ms.GetBuffer());
                    context.Response.End();
                }
            }
        }

        #endregion
    }
}