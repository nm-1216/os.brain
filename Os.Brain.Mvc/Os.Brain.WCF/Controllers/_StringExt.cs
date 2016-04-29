using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Os.Brain.WCF.Controllers
{
    public static class _StringExt
    {
        #region Help
        public static string Limit(this string s, int length)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;

            return s.Substring(0, Math.Min(length, s.Length)).Trim();
        }
        #endregion

    }
}
