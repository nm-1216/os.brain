
namespace Os.Brain.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Base
    {
        [Required]
        public virtual DateTime AddTime { get; set; }

        //public virtual string AddUserId { get; set; }

        //public virtual string ModifyUserId { get; set; }


        [Required]
        [MaxLength(64)]
        public virtual string AddUser { get; set; }

        [Required]
        public virtual DateTime ModifyTime { get; set; }

        [Required]
        [MaxLength(64)]
        public virtual string ModifyUser { get; set; }

        public virtual void Update(string user, DateTime modifyTime)
        {
            this.AddUser = this.ModifyUser = user;
            this.AddTime = this.ModifyTime = modifyTime;
        }
    }
}
