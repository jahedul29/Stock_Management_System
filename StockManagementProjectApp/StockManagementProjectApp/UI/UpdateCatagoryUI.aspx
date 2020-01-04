<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateCatagoryUI.aspx.cs" Inherits="StockManagementProjectApp.UI.UpdateCatagoryUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1 align="center" style="color: blue ">Update Catagory</h1>

    <div>
        <table>
        <tr>
            <td class="auto-style1"><asp:TextBox ID="catagoryTextBox" runat="server" Width="300px" Height="25px" style="margin-bottom: 2px"></asp:TextBox></td>
            <asp:HiddenField ID="idHiddenField" runat="server" />
        </tr>

        <tr>
            <td class="auto-style2"><asp:Button ID="updateButton" runat="server" Text="Update" style="margin-bottom: 16px" Width="133px" OnClick="updateButton_Click" /></td>
        </tr>
        </table>

        <asp:Label ID="outputLabel" runat="server"></asp:Label>
    </div>

        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp;<asp:HyperLink ID="BackToIndexLinkButton" runat="server" NavigateUrl="IndexUI.aspx" BorderStyle="Dashed" BorderColor="green" ForeColor="Black">Go to Main Page</asp:HyperLink>    <%--Link to go Index page--%>
    </form>
</body>
</html>
