<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchAndViewUI.aspx.cs" Inherits="StockManagementProjectApp.UI.SearchAndViewUI" %>

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
    <form id="form2" runat="server">
        <div>
            <center>
            <asp:Label ID="Label1" runat="server" Text="Search and View Item's Summary" Font-Bold="True" Font-Size="XX-Large" ForeColor="#3366FF" Height="38px" Width="511px" style="margin-bottom: 10px"></asp:Label>
            <br/>
            <br/>
            <br/>

        </center>

            <table align="center" class="auto-style1" style="background-color: #C0C0C0; height: 152px; margin-top: 0px; margin-bottom: 2px; margin-right: 0px;">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#9933FF" Text="Company"></asp:Label>
                    </td>
            <center>
                    <td class="auto-style3">
                        <asp:DropDownList ID="companyDropDownList" runat="server" Width="227px" style="margin-left: 29px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style4"></td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#9933FF" Text="Catagory"></asp:Label>
                    </td>
            <center>
                    <td class="auto-style3">
                        <asp:DropDownList ID="catagoryDropDownList" runat="server" Width="227px" style="margin-left: 29px">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style4"></td>
                </tr>
                
                <tr>
                    <td class="auto-style2">&nbsp;</td>
            <center>
                    <td class="auto-style3">
                        <asp:Button ID="searchButton" runat="server" BackColor="#006699" style="margin-left: 93px" Text="Search" Width="156px" Height="31px" Font-Bold="True" Font-Size="Medium" OnClick="searchButton_Click" />
                    </td>
                    <td class="auto-style4"></td>
                </tr>
            </table>
            <asp:Label ID="outputLabel" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" Height="30px" Width="264px" style="margin-left: 292px; margin-top: 0px"></asp:Label></td>

        </center>

        </center>

        </center>

        </center>

        </center>

        </center>

        </div>
        
        <br/>

        <div>
            <center>
            <asp:GridView ID="searchAndViewGridView" runat="server" AutoGenerateColumns="False" style="margin-left: 10px; margin-top: 25px;" Width="884px" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>
                    <asp:TemplateField HeaderText="SL">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Item">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("ItemName") %>'></asp:Label>                             
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Company">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("CompanyName") %>'></asp:Label> 
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("AvailableQuantity") %>'></asp:Label> 
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Reorder Lavel">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("ReorderLavel") %>'></asp:Label> 
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
                </center>
            <br/>
        </div>
    </form>
</body>
</html>
