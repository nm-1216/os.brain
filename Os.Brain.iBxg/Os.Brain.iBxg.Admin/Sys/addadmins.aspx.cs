using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Os.Brain.iBxg.Admin.Sys
{
    public partial class addadmins : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                bind();
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (!check())
                return;


            Os.Brain.iBxg.Core.Entity.Admin model = new Core.Entity.Admin()
            {
                Admin_AddTime = DateTime.Now,
                Admin_AddUser = Page.User.Identity.Name,
                Admin_Name = txtRealName.Text.Trim(),
                Admin_Pwd = Os.Brain.Common.Encrypts.MD5.Encode(txtUsers.Text.Trim() + txtNewPwd.Text.Trim(), Common.Digit.L32),
                Admin_Roles = ddlRoles.SelectedValue,
                Admin_UserID = txtUsers.Text.Trim()
            };


            if (int.Parse(model.Insert().ToString()) > 0)
                Os.Brain.Web.MsgBox.Alert(this, "操作成功", "defer");
            else
                Os.Brain.Web.MsgBox.Alert(this, "操作失败", "defer");

            bind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bind();
        }


        protected void lbtnDel_Command(object sender, CommandEventArgs e)
        {
            //if (e.CommandName == "cmdDel")
            //    if (com.temp.core.Admins.del(e.CommandArgument.ToString()))
            //        Os.Brain.Web.MsgBox.Alert(this, "操作成功", "defer");
            //    else
            //        Os.Brain.Web.MsgBox.Alert(this, "操作失败", "defer");
            //bind();
        }

        private bool check()
        {
            if (Os.Brain.Common.RegExp.IsBlank(txtRealName.Text))
            {
                Os.Brain.Web.MsgBox.Alert(this, "真是姓名不能是空", "defer");
                return false;
            }

            if (Os.Brain.Common.RegExp.IsBlank(txtUsers.Text))
            {
                Os.Brain.Web.MsgBox.Alert(this, "登录名不能是空", "defer");
                return false;
            }

            if (Os.Brain.Common.RegExp.IsBlank(txtNewPwd.Text))
            {
                Os.Brain.Web.MsgBox.Alert(this, "登录密码不能是空", "defer");
                return false;
            }

            if (txtNewPwd.Text != txtOkPwd.Text)
            {
                Os.Brain.Web.MsgBox.Alert(this, "两次输入密码不一致", "defer");
                return false;
            }

            return true;
        }

        private void bind()
        {
            SqlParameter[] _dataParam = new SqlParameter[]{
                new SqlParameter("@Admin_ID",txtIDs.Text.Trim()),
                new SqlParameter("@Admin_Name",txtName.Text.Trim()),
                new SqlParameter("@Admin_UserID",txtUserID.Text.Trim())
            };

            Os.Brain.iBxg.Core.Dal.Admin dal = new Core.Dal.Admin();
            dal.Action = Data.DataActions.select;


            rptList.DataSource = dal.GetList(_dataParam);
            rptList.DataBind();
        }
    }
}