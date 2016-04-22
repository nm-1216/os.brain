//-----------------------------------------------------------------------
// <copyright file="TSQL.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>通用TSQL语句</discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Data.MsSQL
{
    using System;

    /// <summary>
    /// common TSQL
    /// </summary>
    public partial class TSQL
    {
        #region const

        #region INSERT

        /// <summary>
        /// 插入记录 INSERT INTO {0} ({1}) VALUES ({2})
        /// </summary>
        public const string INSERT_VALUE = "INSERT INTO {0} ({1}) VALUES ({2})";

        /// <summary>
        /// 插入记录并返回标示值 INSERT INTO {0} ({1}) VALUES ({2});SELECT @@IDENTITY
        /// </summary>
        public const string INSERT_VALUE_IDENTITY = "INSERT INTO {0} ({1}) VALUES ({2}); SELECT SCOPE_IDENTITY();";

        /// <summary>
        /// 插入记录 INSERT INTO {0} ({1}) SELECT {2} FROM {3} WHERE {4}
        /// </summary>
        public const string INSERT_SELECT = "INSERT INTO {0} ({1}) SELECT {2} FROM {3} WHERE {4}";

        #endregion

        #region UPDATE

        /// <summary>
        /// 修改记录 修改记录集 UPDATE {0} SET {1} WHERE {2}
        /// </summary>
        public const string UPDATE = "UPDATE {0} SET {1} WHERE {2}";

        /// <summary>
        /// 修改记录 修改一个字段 UPDATE {0} SET {1}={2} WHERE {3}
        /// </summary>
        public const string UPDATE_ONE_FIELD = "UPDATE {0} SET {1}={2} WHERE {3}";

        /// <summary>
        /// 修改记录 修改多个字段 UPDATE {0} SET {1} WHERE {2} = @{2}
        /// </summary>
        public const string UPDATE_MORE_FIELD = "UPDATE {0} SET {1} WHERE {2} = @{2}";

        /// <summary>
        /// 修改记录 修改多个字段 并返查询值 UPDATE {0} SET {1} WHERE {2} = @{2}; SELECT @{2}
        /// </summary>
        public const string UPDATE_MORE_FIELD_IDENTITY = "UPDATE {0} SET {1} WHERE {2} = @{2}; SELECT @{2}";

        #endregion

        #region SELECT

        /// <summary>
        /// 根据主键获取 数据
        /// </summary>
        public const string SELECT_ITEM = "SELECT TOP 1 * FROM {0} WITH(NOLOCK) WHERE {1} = {2}";

        /// <summary>
        /// 获取 插入语句返回的 最后一个标识值SELECT @@IDENTITY
        /// </summary>
        public const string SELECT_IDENTITY = "SELECT @@IDENTITY";

        #endregion

        #region DELETE

        /// <summary>
        /// 删除记录 DELETE FROM {0} WHERE {1}={2}
        /// </summary>
        public const string DELETE_ITEM = "DELETE FROM {0} WHERE {1}={2}";

        /// <summary>
        /// 删除记录 DELETE FROM {0} WHERE {1} IN {2}
        /// </summary>
        public const string DELETE_LIST = "DELETE FROM {0} WHERE CHARINDEX(','+LTRIM(STR({1}))+',',{2})>0";

        /// <summary> 
        /// 清空记录 TRUNCATE TABLE {0}
        /// </summary>
        public const string TRUNCATE_TABLE = "TRUNCATE TABLE {0}";

        #endregion

        #region BACKUP

        /// <summary>
        /// 备份数据库【完整备份】BACKUP DATABASE {0} TO DISK={1}
        /// </summary>
        public const string BACKUP_DATABASE = "BACKUP DATABASE {0} TO DISK={1}";

        /// <summary>
        /// 备份数据库【差异备份】BACKUP DATABASE {0} TO DISK={1} WITH DIFFERENTIAL
        /// </summary>
        public const string BACKUP_DATABASE_WITH_DIFFERENTIAL = "BACKUP DATABASE {0} TO DISK={1} WITH DIFFERENTIAL";

        /// <summary>
        /// 备份日志【默认截断日志】BACKUP LOG {0} TO DISK={1}
        /// </summary>
        public const string BACKUP_LOG = "BACKUP LOG {0} TO DISK={1}";

        /// <summary>
        /// 备份日志【不截断日志】BACKUP LOG {0} TO DISK={1} WITH NO_TRUNCATE
        /// </summary>
        public const string BACKUP_LOG_WITH_NO_TRUNCATE = "BACKUP LOG {0} TO DISK={1} WITH NO_TRUNCATE";

        /// <summary>
        /// 备份日志【截断日志不保留】BACKUP LOG {0} TO DISK={1} WITH NO_LOG
        /// </summary>
        public const string BACKUP_LOG_WITH_NO_LOG = "BACKUP LOG {0} TO DISK={1} WITH NO_LOG";

        /// <summary>
        /// 备份日志【截断日志不保留】BACKUP LOG {0} TO DISK={1} WITH TRUNCATE_ONLY
        /// </summary>
        public const string BACKUP_LOG_WITH_TRUNCATE_ONLY = "BACKUP LOG {0} TO DISK={1} WITH TRUNCATE_ONLY";

        #endregion

        #region RESTORE

        /// <summary>
        /// 恢复数据库RESTORE DATABASE {0} FROM DISK='{1}'
        /// </summary>
        public const string RESTORE_DATABASE = "RESTORE DATABASE {0} FROM DISK='{1}'";

        #endregion

        #region DEBUG
        
        /// <summary>
        /// DEBUG_START_LINE
        /// </summary>
        public const string DEBUG_START_LINE = "\r\n\r\n\r\n\r\n\r\n====={0}====================================================================================================================================\r\n";
        
        /// <summary>
        /// DEBUG_END_LINE
        /// </summary>
        public const string DEBUG_END_LINE = "\r\n====={0}======================================================================================================================================\r\n\r\n\r\n\r\n\r\n";

        #endregion

        #endregion

        #region mothed

        /// <summary>
        /// Check TSQL
        /// </summary>
        /// <param name="value">TSQL string</param>
        /// <param name="simple">is simple</param>
        /// <returns>return is effective TSQL</returns>
        public static bool CheckSqlChar(string value, bool simple)
        {
            string[] allInjections = new string[] { "net", "xp_cmdshell", "add", "exec", "select", "count", "asc", "char", "mid", "and", "or", "'", ":", "\"", "insert", "update", "delete", "drop", "truncate", "from", "%", "@" };

            string[] simpleInjections = new string[] { "net user", "xp_cmdshell", "/add", "exec master.dbo.xp_cmdshell" };

            string[] injections;

            if (simple)
            {
                injections = simpleInjections;
            }
            else
            {
                injections = allInjections;
            }

            foreach (string s in injections)
            {
                if (value.IndexOf(s) > 0)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}
