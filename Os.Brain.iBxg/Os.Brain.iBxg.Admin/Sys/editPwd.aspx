<%@ Page Title="" Language="C#" MasterPageFile="~/right.Master" AutoEventWireup="true" CodeBehind="editPwd.aspx.cs" Inherits="Os.Brain.iBxg.Admin.Sys.editPwd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .tab{border:0px solid #436888;background:#CFD7E1;width:100%;table-layout: fixed}
        .tab td{background:#fff;height:26px;text-align:left;width:auto;padding-left:5px;}
        .tab td.l{width:120px;text-align:right;padding-right:5px} 
        .tab .btn{padding:0 20px}       
    </style>
    
	<script type="text/javascript">
	    function _do() {
	        if ($.trim($('[name*=txtOldPwd]').val()) == '') {
	            alert('原始密码不能是空！')
	            return false;
	        }

	        if ($.trim($('[name*=txtNewPwd]').val()) == '') {
	            alert('新密码不能是空！')
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

	        if ($.trim($('[name*=txtNewPwd]').val()) == $.trim($('[name*=txtOldPwd]').val()))
	            return false;

	        return confirm("确认修改吗？")
	    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Title" Runat="Server">修改密码</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Content" Runat="Server">
    <table class="tab" cellspacing="1" cellpadding="0">
        <tr>
            <td class="l">旧密码：</td>
            <td style="width:135px"><asp:TextBox ID="txtOldPwd" TabIndex="1" MaxLength="10" Width="120" TextMode="Password" runat="server"></asp:TextBox></td>
            <td rowspan="3"><asp:Button ID="btnOk" runat="server" TabIndex="2" Width="70" Height="70" Text=" 修 改 " onclick="btnOk_Click" OnClientClick="return _do()" /></td>
            </tr>
        <tr>
            <td class="l">新密码：</td>
            <td style="width:135px"><asp:TextBox ID="txtNewPwd" TabIndex="1" MaxLength="10" Width="120" TextMode="Password" runat="server"></asp:TextBox></td></tr>
        <tr>
            <td class="l">确认密码：</td>
            <td style="width:135px"><asp:TextBox ID="txtOkPwd" TabIndex="1" MaxLength="10" Width="120" TextMode="Password" runat="server"></asp:TextBox></td></tr>       
    </table>
    
</asp:Content>

