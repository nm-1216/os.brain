<%@ Page Title="" Language="C#" MasterPageFile="~/right.master" AutoEventWireup="true" CodeBehind="addadmins.aspx.cs" Inherits="Os.Brain.iBxg.Admin.Sys.addadmins" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
	<script type="text/javascript">
	    function _do() {
	        if ($.trim($('[name*=txtRealName]').val()) == '') {
	            alert('用户名称不能是空')
	            return false;
	        }

	        if ($.trim($('[name*=txtUsers]').val()) == '') {
	            alert('登录名不能是空')
	            return false;
	        }

	        if ($.trim($('[name*=txtNewPwd]').val()) == '') {
	            alert('密码不能是空！')
	            return false;
	        }

	        if ($.trim($('[name*=txtOkPwd]').val()) == '') {
	            alert('确认密码不能是空！')
	            return false;
	        }

	        if ($.trim($('[name*=txtOkPwd]').val()) != $.trim($('[name*=txtNewPwd]').val())) {
	            alert('两次密码输入不一致')
	            return false;
	        }


	        return confirm("确认添加吗？")
	    }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Title" Runat="Server">系统管理员</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Content" Runat="Server">
<div class="Menubox">
    <ul>
        <li id="three1" onclick="Tab('three',1,3)"  class="hover">列表</li>
        <li id="three2" onclick="Tab('three',2,3)" >搜索</li>
        <li id="three3" onclick="Tab('three',3,3)">添加管理员</li>
    </ul>
</div>
<div class="Contentbox">
    <div id="con_three_1" >
        <table class="tabList" cellspacing="1" cellpadding="0">
            <tr>
                <th style="width:34px"></th>
                <th style="width:80px">编号</th>
                <th style="width:160px">姓名</th>
                <th style="width:120px">登录名</th>
                <th style="width:200px">添加时间</th>
                <th style="width:120px">添加人</th>
                <th style="width:120px"></th>
                <th></th>
            </tr>
            <asp:Repeater ID="rptList" runat="server"><ItemTemplate>
            <tr>
                <td><input name="idList" type="checkbox" title="<%#Eval("Admin_ID") %>" value="<%#Eval("Admin_ID") %>"/></td>
                <td class="tc"><%#Eval("Admin_ID") %></td>
                <td class="tc"><%#Eval("Admin_Name")%></td>
                <td class="tc"><%#Eval("Admin_UserID")%></td>
                <td class="tc"><%#Eval("Admin_AddTime","{0:yyyy-MM-dd HH:mm:ss}")%></td>
                <td class="tc"><%#Eval("Admin_AddUser")%></td>                
                <td class="tc">                    
                    <asp:LinkButton ID="lbtnDel" CommandName="cmdDel" CommandArgument='<%#Eval("Admin_ID") %>' oncommand="lbtnDel_Command" OnClientClick="return confirm('数据将永久删除，不可恢复，确认删除吗？')" runat="server"> 删  除 </asp:LinkButton></td>
                <td></td>
            </tr>
            </ItemTemplate></asp:Repeater>
        </table>
    </div>
    <div id="con_three_2" style="display:none">
        <table class="tab" cellspacing="1" cellpadding="0">
            <tr>
                <td class="l">姓　名：</td>
                <td style="width:135px"><asp:TextBox ID="txtName" MaxLength="10" Width="120" runat="server"></asp:TextBox></td>
                <td rowspan="3"><asp:Button ID="btnSearch" runat="server" Width="70" Height="70" Text=" 搜索 " onclick="btnSearch_Click" /></td></tr>
            <tr>
                <td class="l">编　号：</td>
                <td style="width:135px"><asp:TextBox ID="txtIDs" MaxLength="15" Width="120" runat="server"></asp:TextBox></td></tr>
            <tr>
                <td class="l">登录名：</td>
                <td style="width:135px"><asp:TextBox ID="txtUserID" MaxLength="15" Width="120" runat="server"></asp:TextBox></td></tr>
            
        </table>
    </div>
    <div id="con_three_3" style="display:none">
        <table class="tab" cellspacing="1" cellpadding="0">
            <tr>
                <td class="l">姓　名：</td>
                <td style="width:135px"><asp:TextBox TabIndex="1" ID="txtRealName" MaxLength="10" Width="120" runat="server"></asp:TextBox></td>
                <td rowspan="5"><asp:Button ID="btnOk" TabIndex="5" runat="server" Width="70" Height="70" Text=" 添 加 " onclick="btnOk_Click" OnClientClick="return _do()" /></td></tr>
            <tr>
                <td class="l">登录名：</td>
                <td style="width:135px"><asp:TextBox TabIndex="2" ID="txtUsers" MaxLength="15" Width="120" runat="server"></asp:TextBox></td></tr>
            <tr>
                <td class="l">新密码：</td>
                <td style="width:135px"><asp:TextBox TabIndex="3" ID="txtNewPwd" MaxLength="10" Width="120" TextMode="Password" runat="server"></asp:TextBox></td></tr>
            <tr>
                <td class="l">确认密码：</td>
                <td style="width:135px"><asp:TextBox TabIndex="4" ID="txtOkPwd" MaxLength="10" Width="120" TextMode="Password" runat="server"></asp:TextBox></td></tr> 
            <tr>
                <td class="l">角　色：</td>
                <td style="width:135px">
                    <asp:DropDownList ID="ddlRoles" runat="server">
                        <asp:ListItem Text="超级管理员" Value="ADMIN1"></asp:ListItem>
                        <asp:ListItem Text="管 理 员" Value="ADMIN2"></asp:ListItem>
                        <asp:ListItem Text="新闻管理" Value="ADMIN3"></asp:ListItem>
                        <asp:ListItem Text="用户管理" Value="ADMIN4"></asp:ListItem>
                        <asp:ListItem Text="财务管理" Value="ADMIN5"></asp:ListItem>
                        <asp:ListItem Text="游戏管理" Value="ADMIN6"></asp:ListItem>
                    </asp:DropDownList>
                </td></tr>      
        </table>
    </div>
</div> 
    

</asp:Content>
