<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebServiceConfig.aspx.cs" Inherits="InterfaceMonitor.WebserviceApplication.WebServiceConfig" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>WebService配置页面</title>
</head>
<body>
    <form id="form1" runat="server">    
    <div style="width: 341px; margin-top:18px; margin-left: auto; margin-right: auto; margin-bottom: 0;">
        <asp:Label ID="Label1" runat="server" Text="服务器地址："></asp:Label>
        <asp:TextBox ID="tbxServerAddress" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Label ID="Label2" runat="server" Text="数据库名称："></asp:Label> 
        <asp:TextBox ID="tbxDatabaseName" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Label ID="Label3" runat="server" Text="数据库账号："></asp:Label>
        <asp:TextBox ID="tbxUser" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Label ID="Label4" runat="server" Text="数据库密码："></asp:Label>
        <asp:TextBox ID="tbxPwd" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="保存" OnClick="Button1_Click" Width="73px"  />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="Button2" runat="server" Text="取消" Width="73px" OnClick="Button2_Click" />
        <br />   
    </div>
    </form>
</body>
</html>
