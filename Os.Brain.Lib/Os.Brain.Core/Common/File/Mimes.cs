//-----------------------------------------------------------------------
// <copyright file="Mimes.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>Common Regular Expression
// </discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Common.File
{
    using System;

    /// <summary>
    /// Mimes 空类
    /// </summary>
    public class Mimes
    {
        /// <summary>
        /// 文件 FileMimes
        /// </summary>
        public class FileMimes
        {
            /// <summary>
            /// Gets Doc application/msword
            /// </summary>
            public static string Doc
            {
                get { return "application/msword"; }
            }

            /// <summary>
            /// Gets Xls application/vnd.ms-excel
            /// </summary>
            public static string Xls
            {
                get { return "application/vnd.ms-excel"; }
            }

            /// <summary>
            /// Gets Zip application/x-zip-compressed
            /// </summary>
            public static string Zip
            {
                get { return "application/x-zip-compressed"; }
            }

            /// <summary>
            /// Gets Txt text/plain
            /// </summary>
            public static string Txt
            {
                get { return "text/plain"; }
            }

            /// <summary>
            /// Gets Rar application/octet-stream
            /// </summary>
            public static string Rar
            {
                get { return "application/octet-stream"; }
            }

            /// <summary>
            /// Gets Swf application/x-shockwave-flash
            /// </summary>
            public static string Swf
            {
                get { return "application/x-shockwave-flash"; }
            }

            /// <summary>
            /// Gets Gif image/gif
            /// </summary>
            public static string Gif
            {
                get { return "image/gif"; }
            }

            /// <summary>
            /// Gets Jpeg image/jpeg
            /// </summary>
            public static string Jpeg
            {
                get { return "image/jpeg"; }
            }

            /// <summary>
            /// Gets Jpeg2 image/pjpeg
            /// </summary>
            public static string Jpeg2
            {
                get { return "image/pjpeg"; }
            }

            /// <summary>
            /// Gets Png image/png
            /// </summary>
            public static string Png
            {
                get { return "image/png"; }
            }

            /// <summary>
            /// Gets Png2 image/x-png
            /// </summary>
            public static string Png2
            {
                get { return "image/x-png"; }
            }

            /// <summary>
            /// Gets Xml image/xml
            /// </summary>
            public static string Xml
            {
                get { return "text/xml"; }
            }
        }

        /// <summary>
        /// ImageMimes 图片
        /// </summary>
        public class ImageMimes
        {
            /// <summary>
            /// Gets Gif image/gif
            /// </summary>
            public static string Gif
            {
                get { return "image/gif"; }
            }

            /// <summary>
            /// Gets Jpeg image/jpeg
            /// </summary>
            public static string Jpeg
            {
                get { return "image/jpeg"; }
            }

            /// <summary>
            /// Gets Jpeg2 image/pjpeg
            /// </summary>
            public static string Jpeg2
            {
                get { return "image/pjpeg"; }
            }

            /// <summary>
            /// Gets Png image/png
            /// </summary>
            public static string Png
            {
                get { return "image/png"; }
            }

            /// <summary>
            /// Gets Png2 image/x-png
            /// </summary>
            public static string Png2
            {
                get { return "image/x-png"; }
            }
        }
    }
}
