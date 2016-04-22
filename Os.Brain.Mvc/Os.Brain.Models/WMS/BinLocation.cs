using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Os.Brain.Models.WMS
{
    public class BinLocation : Base
    {

        public virtual int BinLocationId { get; set; }
        //四号定位
        public virtual string R { get; set; }
        public virtual int X { get; set; }
        public virtual int Y { get; set; }
        public virtual int Z { get; set; }

        /// <summary>
        /// 别名
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public virtual string Type { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Discription { get; set; }


        public virtual ICollection<TrayInBinLocation> Trays { get; set; }


    }
}
