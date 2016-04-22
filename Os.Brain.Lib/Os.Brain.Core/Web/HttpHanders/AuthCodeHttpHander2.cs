/**
 * 
 * Summary:验证码产生器
 * Coder:Hwx
 * DateTime:2010/11/26 16:10:46
 * 
 * Version:1.0.1
 * 
 * Example:
 *  <httpHandlers>
 *      <add verb="*" path="*.hwx" type="Os.Brain.HttpHanders.AuthCodeHttpHander2"/>
 *  </httpHandlers>
 
 */





namespace Os.Brain.HttpHanders
{
    using System;
    using System.Web;
    using System.Web.SessionState;
    using System.IO;
    using System.Drawing;
    using Os.Brain.Common;

    public class AuthCodeHttpHander2 : IHttpHandler, IRequiresSessionState
    {
        protected static string VCODE_SESSION = "vcode";

        protected static Types VCODE_TYPE = Types.Character;

        protected static int VCODE_LENGTH = 5;

        protected static bool VCODE_IsEncrypt = true;

        protected static bool VCODE_IsIgnore = true;

        protected static Color[] VCODE_COLOR = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };

        protected static string[] VCODE_FONT = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };

        private string GetCheckCode(HttpContext context)
        {
            string _checkCode = string.Empty;

            if (VCODE_TYPE == Types.Number)
                _checkCode = Rnd.RandomNum(VCODE_LENGTH);
            else
                _checkCode = Rnd.RandomCode(VCODE_LENGTH);

            if (VCODE_IsEncrypt)
                context.Session[VCODE_SESSION] = Os.Brain.Common.Encrypts.MD5.Encode(VCODE_IsIgnore ? _checkCode : _checkCode.ToLower());
            else
                context.Session[VCODE_SESSION] = VCODE_IsIgnore ? _checkCode : _checkCode.ToLower();

            return _checkCode;
        }

        private void CreateImage(string code, HttpContext context)
        {
            Bitmap image = new Bitmap((int)Math.Ceiling(code.Length * 14.0), 20);
            Graphics g = Graphics.FromImage(image);

            g.Clear(Color.White);

            MemoryStream ms = null;

            Random Rnd = new Random();
            g.Clear(Color.White);

            //画图片的背景噪音线
            for (int i = 0; i < 25; i++)
            {
                int x1 = Rnd.Next(image.Width);
                int x2 = Rnd.Next(image.Width);
                int y1 = Rnd.Next(image.Height);
                int y2 = Rnd.Next(image.Height);
                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }



            for (int i = 0; i < code.Length; i++)
            {
                int cindex = Rnd.Next(7);
                //int findex = Rnd.Next(5);

                //Font f = new System.Drawing.Font(font[findex], 12, System.Drawing.FontStyle.Bold);
                Font f = new System.Drawing.Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));

                Brush b = new System.Drawing.SolidBrush(VCODE_COLOR[cindex]);

                g.DrawString(code.Substring(i, 1), f, b, 3 + (i * 12), 1);
            }




            //画图片的前景噪音点
            for (int i = 0; i < 100; i++)
            {
                int x = Rnd.Next(image.Width);
                int y = Rnd.Next(image.Height);
                image.SetPixel(x, y, Color.FromArgb(Rnd.Next()));
            }





            g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
            g.Save();



            ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            context.Response.ClearContent();
            context.Response.ContentType = "image/Gif";
            context.Response.BinaryWrite(ms.ToArray());

            image.Dispose();
            g.Dispose();
            ms.Close();
            ms.Dispose();
            context.Response.End();
        }

        protected enum Types
        {
            Number,
            Character
        }



        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            CreateImage(GetCheckCode(context), context);
        }
    }
}

