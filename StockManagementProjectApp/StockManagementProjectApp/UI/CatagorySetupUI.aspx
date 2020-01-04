<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CatagorySetupUI.aspx.cs" Inherits="StockManagementProjectApp.UI.CatagorySetupUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 347px;
        }
        .auto-style2 {
            width: 347px;
            height: 59px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1 align="center" style="color: blue ">Setup Catagory</h1>
    <div>
        <table>
            <tr>
                <td class="auto-style1"><asp:TextBox ID="catagoryTextBox" runat="server" Width="300px" Height="25px" style="margin-bottom: 2px"></asp:TextBox></td>
            </tr>

            <tr>
                <td class="auto-style2"><asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" style="margin-bottom: 16px" Width="133px" /></td>
            </tr>
        </table>

        <asp:Label ID="outputLabel" runat="server"></asp:Label>
    </div>
        <br/>
        
        <asp:GridView ID="catagoryListGridView" runat="server" AutoGenerateColumns="False">    
            <Columns>
                <asp:TemplateField HeaderText="SL">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1 %>                                   <%--Auto generate serial number--%>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="CatagoryName">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("CatagoryName") %>'></asp:Label>
                        <asp:HiddenField ID="catagoryIdHiddenField" runat="server" Value='<%#Eval("Id") %>'/>    <%--Hidden CatagoryId--%>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="catagoryUpdateLinkButton" runat="server" OnClick="catagoryUpdateLinkButton_OnClick">Update</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>                
            </Columns>
        </asp:GridView>

        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp;<asp:HyperLink ID="BackToIndexLinkButton" runat="server" NavigateUrl="IndexUI.aspx" BorderStyle="Dashed" BorderColor="green" ForeColor="Black">Go to Main Page</asp:HyperLink>     <%--Link to go Index page--%>
    </form>
</body>
</html>
