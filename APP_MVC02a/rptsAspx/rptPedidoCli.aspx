<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptPedidoCli.aspx.cs" Inherits="APP_MVC02a.Views.rptsAspx.rptPedidoCli" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 257px">
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <CR:CrystalReportViewer ID="crvClientes" runat="server" AutoDataBind="true"/>
    
    </div>
    </form>
</body>
</html>
