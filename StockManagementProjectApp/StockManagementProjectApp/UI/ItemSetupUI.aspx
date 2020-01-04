<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemSetupUI.aspx.cs" Inherits="StockManagementProjectApp.UI.ItemSetupUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 196px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <fieldset>
            <legend>Set Item Name</legend>
            <table>
                <tr>
                    <td><asp:Label ID="Label1" runat="server" Text="Catagory"></asp:Label></td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="catagoryDropDownList" runat="server" Height="18px" Width="195px">
                        </asp:DropDownList></td>
                </tr>
            
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Company"></asp:Label></td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="companyDropDownList" runat="server" Width="195px" Height="17px">
                        </asp:DropDownList></td>
                </tr>
            
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Item Name"></asp:Label></td>
                    <td class="auto-style1">
                        <asp:TextBox ID="itemNameTextBox" runat="server" Width="190px"></asp:TextBox></td>
                </tr>
            
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Reorder Label"></asp:Label></td>
                    <td class="auto-style1">
                        <asp:TextBox ID="reorderLabelTextbox" runat="server" Width="190px" ></asp:TextBox></td>
               
                </tr>
            
                <tr>
                    <td></td>
                    <td class="auto-style1" align="right">
                        <asp:Button ID="saveButton" runat="server" Text="Save" Width="103px" OnClick="saveButton_Click" /></td>
                </tr>
            </table>
        </fieldset>
        
        <asp:Label ID="outputLabel" runat="server" AssociatedControlID="reorderLabelTextbox"></asp:Label>
       <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                        runat="server" 
                                        ControlToValidate="reorderLabelTextbox"
                                        ErrorMessage="Only Numbers Allowed"
                                        ValidationExpression="^[0-9]+$">
        </asp:RegularExpressionValidator>--%>
    </div>
    </form>
</body>
</html>
