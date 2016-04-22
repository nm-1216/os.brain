<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reg.aspx.cs" Inherits="Os.Brain.iBxg.UCenter.Reg" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    用户帐号：
                </td>
                <td>
                    <asp:TextBox ID="LetterId" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    密码：
                </td>
                <td>
                    <asp:TextBox ID="Password" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    确认密码：
                </td>
                <td>
                    <asp:TextBox ID="PasswordOk" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    验证码：
                </td>
                <td>
                    <asp:TextBox ID="Code" runat="server"></asp:TextBox>
                    <img src="vcode.aspx" style="vertical-align:middle;cursor:pointer" alt="点击更换" onclick="this.src='vcode.aspx?'+Math.random()">
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
