using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Os.Brain.iBxg.Admin.Sys
{
    public partial class editPwd : System.Web.UI.Page
    {
        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (txtNewPwd.Text.Trim() != txtOkPwd.Text.Trim())
            {
                Os.Brain.Web.MsgBox.Alert(this, "两次密码输入不正确", "defer");
                return;
            }

            Os.Brain.iBxg.Core.Dal.Admin dal = new Core.Dal.Admin();
            dal.Action = Data.DataActions.select;

            var model = dal.GetItemByID(Page.User.Identity.Name);

            //com.temp.core.Admins _model = com.temp.core.Admins.get(Page.User.Identity.Name, com.temp.core.Admins.Types._ID);

            if (null == model)
                return;

            if (Os.Brain.Common.Encrypts.MD5.Encode(model.Admin_UserID + txtOldPwd.Text.Trim()) != model.Admin_Pwd)
            {
                Os.Brain.Web.MsgBox.Alert(this, "旧密码不正确", "defer");
                return;
            }

            model.Admin_Pwd = Os.Brain.Common.Encrypts.MD5.Encode(model.Admin_UserID + txtNewPwd.Text.Trim());

            if (int.Parse(model.Update().ToString())>0)
                Os.Brain.Web.MsgBox.Alert(this, "修改成功", "defer");
            else
                Os.Brain.Web.MsgBox.Alert(this, "修改失败", "defer");
        }
    }
}