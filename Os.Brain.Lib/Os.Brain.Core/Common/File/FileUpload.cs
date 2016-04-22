//-----------------------------------------------------------------------
// <copyright file="FileUpload.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>Common Regular Expression
// </discription>
//-----------------------------------------------------------------------

/*

using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.Drawing.Drawing2D;

namespace org.framework.common.file
{
    public class FileUpload
    {
        #region 字段

        private ArrayList _fileTypes;                           //可以上传的文件类型

        private int _maxSize;                                   //最大可以上传的文件字节

        private string _destinationDirectory;                   //要保存到的目的路径

        private HttpPostedFile _httpPostedFile;                 //上传的文件

        private string _extension;                              //文件名扩展部份

        private string _fileName;                               //文件名

        private Bitmap Image;                                   //图片

        private ArrayList _defaultFileTypes;                    //默认可以上传的文件类型

        private string _mimeType;                               //文件MIME类型

        private bool _isImage;                                  //是否为图片

        private bool _overwrite;                                //是否覆盖原来的文件

        #endregion
        
        #region 属性

        //要保存到的目的路径
        public string DestinationDirectory                          
        {
            get { return _destinationDirectory; }
        }

        //新的文件名
        public string FileName                                      
        {
            get { return _fileName; }
        }

        //完整路径
        public string FullFileName                                  
        {
            get { return string.Format("{0}\\{1}", DestinationDirectory, FileName); }
        }

        //扩展名部份
        public string Extension                                     
        {
            get{return _extension;}
        }

        //URL地址
        public string Url
        {
            get { return FullFileName.Replace(HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath), "/").Replace("\\", "/"); }
        }

        //可以上传的文件类型
        public System.Collections.ArrayList FileTypes
        {
            get
            {
                if (_fileTypes == null)
                    _fileTypes = new ArrayList();
                return _fileTypes;
            }
        }

        //上传的文件
        public System.Web.HttpPostedFile HttpPostedFile
        {
            get { return _httpPostedFile; }
        }


        //最大可以上传的文件大小（K）
        public int MaxSize
        {
            get
            {
                if (_maxSize == 0) _maxSize = 200;
                return _maxSize;
            }
            set
            {
                _maxSize = value;
            }
        }

        //默认可以上传的文件类型
        public System.Collections.ArrayList DefaultFileTypes
        {
            get
            {
                if (_defaultFileTypes == null)
                    _defaultFileTypes = FileType.ImageFileTypes;
                return _defaultFileTypes;
            }
        }

        //文件MIME类型
        public string MimeType
        {
            get { return _mimeType; }
        }

        //是否是图片
        public bool IsImage
        {
            get
            {
                foreach (FileType imageFileType in FileType.ImageFileTypes)
                {
                    if (imageFileType.MimeType == HttpPostedFile.ContentType)
                    {
                        _isImage = true;
                        break;
                    }
                }
                return _isImage;
            }
        }

        //是否覆盖原来的文件
        public bool Overwrite
        {
            get { return _overwrite; }
            set { _overwrite = value; }
        }

        #endregion

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="httpPostedFile"></param>
        /// <param name="destinationDirectory"></param>
        public FileUpload(HttpPostedFile httpPostedFile, string destinationDirectory)
            : this(httpPostedFile, false, false, destinationDirectory)
        {
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="httpPostedFile"></param>
        /// <param name="rename"></param>
        /// <param name="destinationDirectory"></param>
        public FileUpload(HttpPostedFile httpPostedFile, bool rename, string destinationDirectory)
            : this(httpPostedFile, rename, false, destinationDirectory)
        {
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="httpPostedFile"></param>
        public FileUpload(HttpPostedFile httpPostedFile, bool rename, bool overlay, string destinationDirectory)
        {
            this._overwrite = overlay;
            _httpPostedFile = httpPostedFile;
            if (destinationDirectory.EndsWith("\\")) destinationDirectory = destinationDirectory.Substring(0, destinationDirectory.Length - 1);
            _destinationDirectory = destinationDirectory;

            _mimeType = httpPostedFile.ContentType;

            _fileName = httpPostedFile.FileName.Substring(httpPostedFile.FileName.LastIndexOf(@"\") + 1);
            _extension = _fileName.Substring(_fileName.LastIndexOf(".") + 1);
            if (rename)
            {

                _fileName = string.Format("{0}-{1}.{2}", DateTime.Now.ToString("yyyyMMddHHmmfffffff"), GetRandomString(4), _extension);
            }




            //如果目的目录存在，并且不覆盖，则检查是否重名，如果重名，则在文件名加上（x）
            if (Directory.Exists(DestinationDirectory) && !this.Overwrite)
            {
                int i = 1;
                string filename = _fileName;
                while (System.IO.File.Exists(string.Format("{0}\\{1}", _destinationDirectory, filename)))
                {
                    filename = string.Format("{0}({1}).{2}", _fileName.Substring(0, _fileName.LastIndexOf(".")), i.ToString(), _extension);
                    i++;
                }
                _fileName = filename;
            }
        }

        /// <summary>
        /// 加入水印
        /// </summary>
        /// <param name="wateFileName"></param>
        /// <param name="alpha"></param>
        public void AppendWatermark(string wateFileName, float alpha)
        {
            if (!IsImage)
                throw new System.Exception("不是有效的图形文件");
            Image = new Bitmap(_httpPostedFile.InputStream);
            FileUpload.AppendWatermark(Image, wateFileName, alpha);
        }


        public void AppendWatermark(string text, System.Drawing.Font font, Color color, System.Drawing.Size size, float alpha)
        {
            if (!IsImage)
                throw new System.Exception("不是有效的图形文件");
            Image = new Bitmap(_httpPostedFile.InputStream);
            FileUpload.AppendWatermark(Image, text, font, color, alpha);
        }

        #region 验证上传的文件
        public void ValidFile()
        {
            if (string.IsNullOrEmpty(HttpPostedFile.FileName))
                throw new System.Exception("没有上传的文件");
            if (HttpPostedFile.ContentLength == 0)
                throw new System.Exception("0字节文件");
            if (!CheckFileType())
            {
                ArrayList fileTypes;
                if (_fileTypes != null)
                    fileTypes = _fileTypes;
                else
                    fileTypes = DefaultFileTypes;
                string extStr = string.Empty;
                foreach (FileType fileType in fileTypes)
                {
                    extStr += "，" + fileType.Extension;
                }
                throw new System.Exception(string.Format("文件类型错误，可以上传的文件类型有：{0}", extStr.Substring(1)));
            }
            if (!CheckSize())
                throw new System.Exception(string.Format("文件太大，最大可以上传：{0}K", MaxSize));
        }
        #endregion

        #region 保存文件方法
        /// <summary>
        /// 保存文件
        /// </summary>
        public void Save()
        {

            ValidFile();

            if (!Directory.Exists(DestinationDirectory))
                Directory.CreateDirectory(DestinationDirectory);

            string fullFileName = string.Format(@"{0}\{1}", _destinationDirectory, FileName);

            //如果覆盖原有的文件，则先将原有的文件删除
            if (this.Overwrite && System.IO.File.Exists(fullFileName))
            {
                System.IO.File.Delete(fullFileName);
            }

            if (Image == null)
                _httpPostedFile.SaveAs(fullFileName);
            else
                Image.Save(fullFileName);

        }

        /// <summary>
        /// 保存缩略图，如果文件不是图片，会抛出异常
        /// </summary>
        public void SaveThumbnailImage(System.Drawing.Size size)
        {
            string thumdir = string.Format("{0}\\s", _destinationDirectory);
            if (!Directory.Exists(thumdir))
                Directory.CreateDirectory(thumdir);
            SaveThumbnailImage(size, string.Format("{0}\\{1}", thumdir, FileName));
        }

        /// <summary>
        /// 保存缩略图，如果文件不是图片，会抛出异常（重载方法2）
        /// </summary>
        public void SaveThumbnailImage(System.Drawing.Size size, string fileName)
        {
            if (!IsImage)
                throw new System.Exception("不是有效的图形文件");
            string thumdir = fileName.Substring(0, fileName.LastIndexOf("\\"));
            if (!Directory.Exists(thumdir))
                Directory.CreateDirectory(thumdir);
            Bitmap thumBitmap;
            if (Image == null)
                thumBitmap = FileUpload.CreateThumbnailImage(HttpPostedFile.InputStream, size);
            else
            {
                System.IO.MemoryStream memStream = new MemoryStream();
                Image.Save(memStream, Image.RawFormat);
                thumBitmap = FileUpload.CreateThumbnailImage(memStream, size);
            }

            SaveThumbnailImage(thumBitmap, fileName);
        }
        #endregion

        #region 检测文件是否合法的方法
        /// <summary>
        /// 检测是否为可以上传的文件类型
        /// </summary>
        private bool CheckFileType()
        {            
            ArrayList fileTypes;
            if (_fileTypes != null)
                fileTypes = _fileTypes;
            else
                fileTypes = DefaultFileTypes;

            bool isValid = false;
            foreach (FileType fileType in fileTypes)
            {
                if (fileType.Extension == _extension.ToLower() && fileType.MimeType == _mimeType)
                {
                    isValid = true;
                    break;
                }
            }
            return isValid;
        }

        /// <summary>
        /// 检测文件是否为图片文件
        /// </summary>
        private bool IsImageType()
        {
            if (HttpPostedFile.ContentType == FileMimes.Gif) return true;
            if (HttpPostedFile.ContentType == FileMimes.Jpeg) return true;
            if (HttpPostedFile.ContentType == FileMimes.Png) return true;
            return false;
        }

        /// <summary>
        /// 检测文件大小
        /// </summary>
        private bool CheckSize()
        {
            if (HttpPostedFile.ContentLength / 1024 > MaxSize) return false;
            return true;
        }

        #endregion

        #region 静态属性
        public static string GetRandomString(int length)
        {
            byte[] random = new Byte[length / 2];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(random);

            StringBuilder sb = new StringBuilder(length);
            int i;
            for (i = 0; i < random.Length; i++)
            {
                sb.Append(String.Format("{0:X2}", random[i]));
            }
            return sb.ToString();
        }
        #endregion

        #region 静态方法

        /// <summary>
        /// 生成缩略图
        /// </summary>
        public static Bitmap CreateThumbnailImage(Bitmap sourceBitmap, Size desiredSize)
        {
            int width = desiredSize.Width;
            int height = desiredSize.Height;

            double w = (double)width / sourceBitmap.Width;
            double h = (double)height / sourceBitmap.Height;
            double wh = w * sourceBitmap.Height;
            double hw = h * sourceBitmap.Width;

            if (wh <= height && width <= sourceBitmap.Width) height = (int)wh;
            if (hw <= width && height <= sourceBitmap.Height) width = (int)hw;

            Bitmap bitmap2 = new Bitmap(width, height);
            Graphics graphics1 = Graphics.FromImage(bitmap2);
            graphics1.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics1.SmoothingMode = SmoothingMode.HighQuality;
            graphics1.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
            graphics1.Clear(Color.Transparent);
            graphics1.DrawImage(sourceBitmap, 0, 0, width, height);

            return bitmap2;
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        public static Bitmap CreateThumbnailImage(System.IO.Stream sourceStream, Size desiredSize)
        {
            Bitmap sourceBitmap = new Bitmap(sourceStream);
            Bitmap desiredBitmap = FileUpload.CreateThumbnailImage(sourceBitmap, desiredSize);
            return desiredBitmap;
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="sourceStream"></param>
        /// <param name="desiredSize"></param>
        /// <param name="destFileName"></param>
        public static void CreateThumbnailImage(System.IO.Stream sourceStream, Size desiredSize, string destFileName)
        {
            Bitmap desiredBitmap = FileUpload.CreateThumbnailImage(sourceStream, desiredSize);
            SaveThumbnailImage(desiredBitmap, destFileName);
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="sourceStream"></param>
        /// <param name="desiredSize"></param>
        /// <param name="destFileName"></param>
        public static void CreateThumbnailImage(string sourceFileName, Size desiredSize, string destFileName)
        {
            Bitmap sourceBitmap = new Bitmap(sourceFileName);
            Bitmap desiredBitmap = FileUpload.CreateThumbnailImage(sourceBitmap, desiredSize);
            SaveThumbnailImage(desiredBitmap, destFileName);
        }

        /// <summary>
        /// 保存缩略图
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="format"></param>
        /// <param name="fileName"></param>
        public static void SaveThumbnailImage(Bitmap bitmap, string fileName)
        {
            if (fileName.ToLower().EndsWith(".jpg"))
            {
                ImageCodecInfo imageCodecInfo = GetEncoderInfo("image/jpeg");
                EncoderParameters encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)100);

                bitmap.Save(fileName, imageCodecInfo, encoderParameters);
            }
            else
            {
                bitmap.Save(fileName);
            }
        }

        /// <summary>
        /// 加入图片水印
        /// </summary>
        /// <param name="wateFileName"></param>
        /// <param name="alpha"></param>
        public static void AppendWatermark(Bitmap bitmap, string wateFileName, float alpha)
        {
            System.Drawing.Bitmap wateBitmap = new Bitmap(wateFileName);
            AppendWatermark(bitmap, wateBitmap, alpha);
        }

        /// <summary>
        /// 加入图片水印
        /// </summary>
        /// <param name="wateFileName"></param>
        /// <param name="alpha"></param>
        public static void AppendWatermark(Bitmap bitmap, Bitmap wateBitmap, float alpha)
        {
            float[][] matrixItems = {
                new float[]{1,0,0,0,0},
                new float[]{0,1,0,0,0},
                new float[]{0,0,1,0,0},
                new float[]{0,0,0,alpha,0},
                new float[]{0,0,0,0,1}
            };

            ColorMatrix colorMatrix = new ColorMatrix(matrixItems);

            ImageAttributes attr = new ImageAttributes();
            attr.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            System.Drawing.Graphics grap = Graphics.FromImage(bitmap);
            grap.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;

            int width = wateBitmap.Width;
            int height = wateBitmap.Height;
            int x = (bitmap.Width - width) / 2;
            int y = (bitmap.Height - height) / 2;
            grap.DrawImage(wateBitmap, new Rectangle(x, y, width, height), 0, 0, width, height, GraphicsUnit.Pixel, attr);
            grap.Flush();
            grap.Save();
            grap.Dispose();
        }

        /// <summary>
        /// 加入文字水印
        /// </summary>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="size"></param>
        /// <param name="?"></param>
        /// <param name="alpha"></param>
        public static void AppendWatermark(Bitmap bitmap, string text, System.Drawing.Font font, Color color, float alpha)
        {
            AppendWatermark(bitmap, text, font, color, alpha, 20.0F, 20.0F);
        }

        public static void AppendWatermark(Bitmap bitmap, string text, System.Drawing.Font font, Color color, float alpha, float x, float y)
        {
            System.Drawing.Graphics grap = Graphics.FromImage(bitmap);
            SolidBrush drawBrush = new SolidBrush(color);
            grap.DrawString(text, font, drawBrush, x, y);
            grap.Flush();
            grap.Save();
            grap.Dispose();
        }

        public static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            if (mimeType == "image/pjpeg") mimeType = "image/jpeg";
            ImageCodecInfo[] infoArray1 = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo info1 in infoArray1)
            {
                if (info1.MimeType == mimeType)
                {
                    return info1;
                }
            }
            return null;
        }
        
        #endregion
    }
}


 */