using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Os.Brain.Models.WMS
{
    public class TrayType : Base
    {
        public virtual string TrayTypeId { get; set; }

        public virtual string Name { get; set; }

        public virtual string Discription { get; set; }

        public virtual string Size { get; set; }

        public virtual byte[] Image { get; set; }

        public virtual ICollection<Tray> Trays { get; set; }

    }
}
