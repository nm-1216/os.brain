namespace Os.Brain.Models
{
    public enum UserType : int
    {
        /// <summary>
        /// 普通员工
        /// </summary>
        Ordinary = 0,

        /// <summary>
        /// 管理员
        /// </summary>
        Administrator = 1,
        
        /// <summary>
        /// 超级管理员
        /// </summary>
        SuperAdministrator = 2
    }

    public enum IsLock : int
    {
        No = 0,
        Yes = 1
    }

    public enum Sex : int
    {
        /// <summary>
        /// Unknown 未知的性别
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Man 男性
        /// </summary>
        Man = 1,

        /// <summary>
        /// Woman 女性
        /// </summary>
        Woman = 2,

        /// <summary>
        /// WomanToMan 女性改（变）为男性
        /// </summary>
        WomanToMan = 5,

        /// <summary>
        /// ManToWoman 男性改（变）为女性
        /// </summary>
        ManToWoman = 6,

        /// <summary>
        /// NoDiscription 未说明的性别
        /// </summary>
        NoDiscription = 9
    }

}
