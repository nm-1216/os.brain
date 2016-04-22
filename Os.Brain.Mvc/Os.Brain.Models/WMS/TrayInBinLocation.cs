using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Os.Brain.Models.WMS
{
    public class TrayInBinLocation : Base
    {
        public virtual string TrayId { get; set; }

        public virtual int BinLocationId { get; set; }
    }
}
