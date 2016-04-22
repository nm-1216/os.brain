//-----------------------------------------------------------------------
// <copyright file="FileType.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>Common Regular Expression
// </discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Common.File
{
    using System;
    using System.Collections;
    
    /// <summary>
    /// FileType 文件类型
    /// </summary>
    public class FileType
    {
        /// <summary>
        /// 图片文件 类型
        /// </summary>
        private static ArrayList _imageFileTypes;
                
        /// <summary>
        /// 文件 扩展名
        /// </summary>
        private string _extension;
        
        /// <summary>
        /// 文件 类型
        /// </summary>
        private string _mimeType;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileType"/> class.
        /// </summary>
        /// <param name="extension">extension 后缀</param>
        /// <param name="mimeType">mimeType 文件格式</param>
        public FileType(string extension, string mimeType)
        {
            this._extension = extension;
            this._mimeType = mimeType;
        }

        /// <summary>
        /// Gets ImageFileTypes
        /// </summary>
        public static ArrayList ImageFileTypes
        {
            get
            {
                if (FileType._imageFileTypes == null)
                {
                    FileType._imageFileTypes = new ArrayList();
                    FileType._imageFileTypes.Add(new FileType("gif", Mimes.FileMimes.Gif));
                    FileType._imageFileTypes.Add(new FileType("jpg", Mimes.FileMimes.Jpeg));
                    FileType._imageFileTypes.Add(new FileType("jpg", Mimes.FileMimes.Jpeg2));
                    FileType._imageFileTypes.Add(new FileType("png", Mimes.FileMimes.Png));
                    FileType._imageFileTypes.Add(new FileType("png", Mimes.FileMimes.Png2));
                }

                return (ArrayList)FileType._imageFileTypes.Clone();
            }
        }

        /// <summary>
        /// Gets Extension
        /// </summary>
        public string Extension
        {
            get
            {
                return this._extension;
            }
        }

        /// <summary>
        /// Gets MimeType
        /// </summary>
        public string MimeType
        {
            get
            {
                return this._mimeType;
            }
        }
    }
}
