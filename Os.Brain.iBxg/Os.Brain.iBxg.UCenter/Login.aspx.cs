using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Os.Brain.iBxg.UCenter
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(User.Identity.Name))
                    Response.Redirect("index.aspx");
            }
        }


        protected void btnOk_Click(object sender, EventArgs e)
        {

            if (Os.Brain.Common.RegExp.IsBlank(txtName.Text) || Os.Brain.Common.RegExp.IsBlank(txtPwd.Text))
            {
                Os.Brain.Web.MsgBox.Alert(this, "用户名和密码输入格式不正确，请重新输入", "defer");
                return;
            }

            Os.Brain.iBxg.Core.Dal.Admin dal = new Core.Dal.Admin();
            dal.Action = Data.DataActions.select;

            var _admin = dal.GetItemByUserID(txtName.Text.Trim());

            if (null == _admin || _admin.Admin_Pwd != Os.Brain.Common.Encrypts.MD5.Encode(txtName.Text + txtPwd.Text))
            {
                Os.Brain.Web.MsgBox.Alert(this, "用户名和密码输入不正确，请重新输入", "defer");
                return;
            }

            Os.Brain.Web.Auth.WriteTicket(1, _admin.Admin_ID, 30, true, "Roles:{" + _admin.Admin_Roles + "}");


            Response.Redirect("index.aspx");
        }
    }
}