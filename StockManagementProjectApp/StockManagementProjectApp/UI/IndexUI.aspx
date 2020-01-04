<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexUI.aspx.cs" Inherits="StockManagementProjectApp.UI.IndexUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <H1 align="center" style="color: blueviolet">Stock Management System</H1>
        <br/>
    <div align="center">
        <asp:HyperLink ID="catagorySetupLinkButton" runat="server" NavigateUrl="CatagorySetupUI.aspx" Font-Bold="True" Font-Size="25px">Catagory Setup</asp:HyperLink>
        <br/>
        <asp:HyperLink ID="companySetupLinkButton" runat="server" NavigateUrl="CompanySetupUI.aspx" Font-Bold="True" Font-Size="25px">Company Setup</asp:HyperLink>
        <br/>
    </div>
    </form>
</body>
</html>
