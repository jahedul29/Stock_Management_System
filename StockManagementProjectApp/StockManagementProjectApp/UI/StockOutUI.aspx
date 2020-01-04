<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockOutUI.aspx.cs" Inherits="StockManagementProjectApp.UI.StockOutUI" %>
<%@ Import Namespace="System.ComponentModel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 63%;
            margin-left: 246px;
        }

        .auto-style2 {
            width: 246px;
            text-align: right;
        }

        .auto-style3 {
            width: 263px;
        }
        .auto-style4 {
            width: 187px;
        }
        .auto-style5 {
            height: 31px;
        }
        .auto-style6 {
            height: 31px;
            width: 128px;
        }
        .auto-style7 {
            height: 31px;
            width: 121px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
            <asp:Label ID="Label1" runat="server" Text="Stock In" Font-Bold="True" Font-Size="XX-Large" ForeColor="#3366FF" Height="38px" Width="300px" style="margin-bottom: 10px"></asp:Label>
            <br/>
            <br/>
            <br/>

        </center>

            <table align="center" class="auto-style1" style="background-color: #C0C0C0; height: 192px; margin-top: 0px; margin-bottom: 2px; margin-right: 0px;">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#9933FF" Text="Company"></asp:Label>
                    </td>
            <center>
                    <td class="auto-style3">
                        <asp:DropDownList ID="companyDropDownList" runat="server" Width="227px" style="margin-left: 29px" OnSelectedIndexChanged="companyDropDownList_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style4"></td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#9933FF" Text="Item"></asp:Label>
                    </td>
            <center>
                    <td class="auto-style3">
                        <asp:DropDownList ID="itemDropDownList" runat="server" Width="227px" style="margin-left: 29px" OnSelectedIndexChanged="itemDropDownList_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style4"></td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#9933FF" Text="Reorder Lavel"></asp:Label>
                    </td>
            <center>
                    <td class="auto-style3">
                        <asp:TextBox ID="reorderLavelTextBox" runat="server" Enabled="False" style="text-align: left; margin-left: 29px" Width="223px"></asp:TextBox>
                    </td>
                    <td class="auto-style4"></td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#9933FF" Text="Available Quantity"></asp:Label>
                    </td>
            <center>
                    <td class="auto-style3">
                        <asp:TextBox ID="availableQuantityTextBox" runat="server" Enabled="False" style="text-align: left; margin-left: 29px" Width="223px"></asp:TextBox>
                    </td>
                    <td class="auto-style4"></td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#9933FF" Text="Stock Out Quantity"></asp:Label>
                    </td>
            <center>
                    <td class="auto-style3">
                        <asp:TextBox ID="stockOutTextBox" runat="server" style="text-align: left; margin-left: 29px" Width="223px"></asp:TextBox>
                    </td>
                    <td class="auto-style4"></td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
            <center>
                    <td class="auto-style3">
                        <asp:Button ID="addButton" runat="server" BackColor="#006699" style="margin-left: 96px" Text="Add" Width="156px" Height="29px" Font-Bold="True" Font-Size="Medium" OnClick="addButton_Click" />
                    </td>
                    <td class="auto-style4"></td>
                </tr>
            </table>

        </center>

        </center>

        </center>

        </center>

        </center>

        </center>

        </div>
        
        <br/>

        <div>
            <asp:GridView ID="stockOutGridView" runat="server" AutoGenerateColumns="False" style="margin-left: 10px; margin-top: 25px;" Width="884px" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:TemplateField HeaderText="SL">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Item">
                        <ItemTemplate>
                            <asp:Label runat="server" Text="Item"></asp:Label>                             
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Company">
                        <ItemTemplate>
                            <asp:Label runat="server" Text="Company"></asp:Label> 
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Label runat="server" Text="Quality"></asp:Label> 
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>
            <br/>

            <table align="right" style="height: 54px; width: 900px; margin-right: 4px">
                <tr>
                    <td align="left" class="auto-style5">
                        <asp:Label ID="outputLabel" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Height="28px" Width="535px"></asp:Label></td>
                    <td class="auto-style6">
                        <asp:Button ID="sellButton" runat="server" Text="Sell" Height="30px" Width="94px" Font-Bold="True" Font-Size="Medium" ForeColor="#CC00FF" style="margin-left: 7px" /></td>
                    <td class="auto-style5"><asp:Button ID="damageButton" runat="server" Text="Damage" Height="30px" Width="104px" Font-Bold="True" Font-Size="Medium" ForeColor="#CC00FF" /></td>
                    <td class="auto-style7">&nbsp;&nbsp;&nbsp; <asp:Button ID="lostButton" runat="server" Text="Lost" Height="30px" Width="94px" style="margin-left: 0px" Font-Bold="True" Font-Size="Medium" ForeColor="#CC00FF" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
