<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockIn.aspx.cs" Inherits="StockManagementProjectApp.UI.StockIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <fieldset>
            <legend>Stock Items</legend>
            <table>
            
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Company"></asp:Label></td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="companyDropDownList" runat="server" Width="195px" Height="17px" OnSelectedIndexChanged="companyDropDownList_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                        
                    </td>
                </tr>
                
                <tr>
                    <td><asp:Label ID="Label1" runat="server" Text="Item"></asp:Label></td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="itemDropDownList" runat="server" Height="18px" Width="195px" OnSelectedIndexChanged="itemDropDownList_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
            
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Available Quantity"></asp:Label></td>
                    <td class="auto-style1">
                        <asp:TextBox ID="availableQuantityTextBox" runat="server" Text="view" Enabled="False"></asp:TextBox>
                        
                    </td>
                        
                </tr>
                
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Reorder Lavel"></asp:Label></td>
                    <td class="auto-style1">
                        <asp:TextBox ID="reorderLavelTextBox" runat="server" Text="view" Enabled="False"></asp:TextBox>
                        <asp:HiddenField ID="availableQuantityHiddenField" runat="server" Value=""/>
                    </td>
                </tr>
            
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Stock In"></asp:Label></td>
                    <td class="auto-style1">
                        <asp:TextBox ID="stockInTextbox" runat="server" Width="190px" ></asp:TextBox></td>
               
                </tr>
            
                <tr>
                    <td></td>
                    <td class="auto-style1" align="right">
                        <asp:Button ID="saveButton" runat="server" Text="Save" Width="103px" OnClick="saveButton_Click" /></td>
                </tr>
            </table>
        </fieldset>
        
        <asp:Label ID="outputLabel" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
