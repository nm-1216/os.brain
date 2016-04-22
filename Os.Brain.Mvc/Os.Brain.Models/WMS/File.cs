namespace Os.Brain.Models.WMS
{
    /// <summary>
    /// 文件类
    /// </summary>
    public class File:Base
    {
        public virtual int FileId { get; set; }
        public virtual string FileName { get; set; }
        public virtual string FileType { get; set; }
        public virtual string FileExtensions { get; set; }
        public virtual byte[] Content { get; set; }
        public virtual string Url { get; set; }
        public virtual byte[] Thumbnail { get; set; }
        public virtual string ThumbnailUrl { get; set; }

    }
}
