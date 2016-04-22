using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Os.Brain.iBxg.UCenter
{
    public partial class Reg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        private void Submit()
        {
            Os.Brain.iBxg.Core.Entity.Users model = new Core.Entity.Users();
        
      
        }


        private bool check()
        {


            ///6-10位
            if (!Regex.IsMatch(LetterId.Text.Trim(), "^[a-zA-Z][a-zA-Z0-9]{5,9}$"))
            {
                Os.Brain.Web.MsgBox.Alert(this, "用户帐号不符合规则，用户帐号是以字母开头的6~10位字母数字组成的字符串。", "defer");
                return false;
            }

            if (Password.Text.Trim().Length < 6)
            {
                Os.Brain.Web.MsgBox.Alert(this, "用户密码不符合规则，用户密码长度不能小于6位不为空的字符。", "defer");
                return false;
            }

            if (Password.Text.Trim() != PasswordOk.Text.Trim())
            {
                Os.Brain.Web.MsgBox.Alert(this, "两次密码输入不一致，请重新输入。", "defer");
                return false;
            }

            
            Os.Brain.iBxg.Core.Dal.Users dal = new Core.Dal.Users();
            dal.Action = Data.DataActions.select;

            var model = dal.GetItemByLetterId(LetterId.Text.Trim());

            return true;

        }
    }
}