
namespace Os.Brain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : User<string>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="User"/>.
        /// </summary>
        /// <remarks>
        /// The Id property is initialized to from a new GUID string value.
        /// </remarks>
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Initializes a new instance of <see cref="User"/>.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <remarks>
        /// The Id property is initialized to from a new GUID string value.
        /// </remarks>
        public User(string userName) : this()
        {
            UserName = userName;
        }
    }


    public class User<TKey> : IdentityUser<TKey> where TKey : IEquatable<TKey>
    {

        
        #region 用户帐号


        [Display(Name = "用户类型")]
        public virtual UserType UserType { get; set; }

        [Display(Name = "IP限制")]
        [MaxLength(128)]
        public string LockIp { get; set; }
        #endregion

        #region 用户资料
        [Display(Name = "图像")]
        public byte[] Photo { get; set; }

        [Display(Name = "中文名")]
        [MaxLength(64)]
        public string Cname { get; set; }

        [Display(Name = "英文名")]
        [MaxLength(64)]
        public string Ename { get; set; }

        [Display(Name = "身份证号码")]
        [MaxLength(64)]
        public string IDCard { get; set; }

        [Required]
        [Display(Name = "性别")]
        public virtual Sex Sex { get; set; }

        [Display(Name = "生日")]
        [MaxLength(16)]
        public string DOB { get; set; }

        [Display(Name = "固定电话")]
        [MaxLength(16)]
        public string Tel { get; set; }

        [Display(Name = "移动电话")]
        [MaxLength(16)]
        public string Mobile { get; set; }

        [Display(Name = "员工编号")]
        [MaxLength(32)]
        public string NO { get; set; }

        [Display(Name = "部门")]
        [MaxLength(128)]
        public string Group { get; set; }

        [Display(Name = "职务")]
        [MaxLength(128)]
        public string ProfessionalTitle { get; set; }

        [Display(Name = "分机号")]
        [MaxLength(10)]
        public string Ext { get; set; }

        [Display(Name = "入职日期")]
        public DateTime HireDate { get; set; }

        [Display(Name = "离职日期")]
        public DateTime ResignationDate { get; set; }

        #endregion

        #region 个人设置
        public virtual int PageSize { get; set; } = 10;

        #endregion

        #region 通用记录

        /// <summary>
        /// 建档时间
        /// </summary>
        [Required]
        public DateTime CreateDate
        {
            get;
            set;
        }

        /// <summary>
        /// 描述备注
        /// </summary>
        [Display(Name = "描述备注")]
        [MaxLength(128)]
        public string Description
        {
            get;
            set;
        }

        #endregion
        
        #region 
        public virtual ICollection<UserInGroup<TKey>> Groups { get; } = new List<UserInGroup<TKey>>();
        public virtual ICollection<PersonalizationPerUser<TKey>> Paths { get; } = new List<PersonalizationPerUser<TKey>>();
        public virtual ICollection<LoginLog<TKey>> LoginLogs { get; set; } //= new List<LoginLog<TKey>>();
        #endregion
    }

}
