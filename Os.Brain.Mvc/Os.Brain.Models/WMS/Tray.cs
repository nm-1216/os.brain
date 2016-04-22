using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Os.Brain.Models.WMS
{
    public class Tray : Base
    {
        public virtual string TrayId { get; set; }
        public virtual string TrayTypeId { get; set; }
        public virtual bool IsFull { get; set; }
        public virtual ICollection<TrayInBinLocation> BinLocations { get; set; } 
    }
}
