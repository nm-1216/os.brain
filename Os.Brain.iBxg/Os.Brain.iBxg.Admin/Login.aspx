<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Os.Brain.iBxg.Admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>
        <%= System.Configuration.ConfigurationManager.AppSettings.Get("App_Title")%>
    </title>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $("document").ready(function () {
            //防止在frame里面出现登录页面
            if (top.location !== self.location) {
                //alert(top.location);
                //alert(self.location);
                top.location.href = self.location.href;
            }
        });
    </script>
    <style type="text/css">
    body,form,html{margin:0;padding:0;border:0}
    html,body,.div_0{width:100%;height:100%}
    html{overflow:hidden}
    body{background:#01559F;}
    .div_1{border-bottom:4px solid #000;height:102px;background:url('image/BgLogin.png') bottom right no-repeat white; margin-top:-400px;text-align:right;padding-top:240px}
    input{cursor:pointer}
    .input_txt{width:115px;border:1px solid #5797BD;background:#F2EFF1;height:16px}
    .input_btn{width:58px;height:53px;background:url('image/BgLoginBtnOver.png') no-repeat;border:0}
    
    .div_btn{width:61px;height:56px;padding:2px 3px 0 0;float:right}
    .div_name{background:url('image/BgUserName.gif') 0 7px no-repeat;height:30px;padding-top:3px;*padding-top:2px}
    .div_pwd{background:url('image/BgPassWord.gif') 0 7px no-repeat;height:30px;padding-top:2px}
</style>
</head>
<body>
    <div class="div_0">
    </div>
    <div class="div_1">
        <div style="width: 250px; height: 90px; margin: 0 10px 0 auto">
            <form id="form1" runat="server">
            <div style="width: 180px; float: left">
                <div class="div_name">
                    <asp:TextBox CssClass="input_txt" MaxLength="10" ID="txtName" runat="server"></asp:TextBox></div>
                <div class="div_pwd">
                    <asp:TextBox CssClass="input_txt" MaxLength="10" ID="txtPwd" TextMode="Password"
                        runat="server"></asp:TextBox></div>
            </div>
            <div class="div_btn">
                <asp:Button ID="btnSubmit" onMouseOver="this.style.backgroundImage='url(image/BgLoginBtnOn.png)'"
                    onMouseOut="this.style.backgroundImage='url(image/BgLoginBtnOver.png)'" CssClass="input_btn"
                    runat="server" OnClick="btnOk_Click" Text=" 登 录 " /></div>
            </form>
        </div>
    </div>
</body>
</html>
