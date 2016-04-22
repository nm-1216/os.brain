namespace Os.Brain.Models.WMS
{
    public class Attribute : ClassBase
    {
        public virtual int AttributeID { get; set; }

        public virtual string Name { get; set; }

        public virtual AttribType Type { get; set; }

        public virtual string Discription { get; set; }
    }
}
