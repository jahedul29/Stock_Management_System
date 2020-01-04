<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanySetupUI.aspx.cs" Inherits="StockManagementProjectApp.UI.CompanySetupUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 41px;
        }
        .auto-style2 {
            height: 13px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
    <H1 align="center" style="color: blue ">Setup Company</H1>

    <div>
        <table>
            <tr>
                <td class="auto-style2"><asp:TextBox ID="companyTextBox" runat="server" Width="300px" Height="25px" style="margin-bottom: 9px"></asp:TextBox></td>
            </tr>

            <tr>
                <td class="auto-style1"><asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" Height="26px" style="margin-top: 0px" Width="133px" /></td>
            </tr>
        </table>

        <asp:Label ID="outputLabel" runat="server"></asp:Label>
    </div>
        <br/>

        <asp:GridView ID="companyListGridView" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="SL">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1 %>                     <%--Auto generate serial number--%>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="CompanyName">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%#Eval("CompanyName") %>'></asp:Label>    
                        <asp:HiddenField ID="companyIdHiddenField" runat="server" Value='<%#Eval("Id") %>' />   <%-- Hidden CompanytId--%>
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
