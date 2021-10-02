<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="WebApplication5.NewFolder1.list" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>list</title>
</head>
<body>
    <form id="list" method="post" runat="server">
        <table>
            <tr>
                <td>글목록</td>
                <td><button type="button" onclick="location.href='Insert.aspx'">글작성</button></td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:DataGrid id="DataGrid1" runat="server" CssClass="txt01" AutoGenerateColumns="False">
                        <SelectedItemStyle Font-Bold="True">
                        </SelectedItemStyle>
                        <ItemStyle ForeColor="#000066" />
                        <HeaderStyle Font-Bold="True" />
                        <%-- <FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle> 바닥글속성?--%>
                        <Columns>
                            <asp:HyperLinkColumn DataNavigateUrlField="seq"  DataTextField="Title" 
                             DataNavigateUrlFormatString="Content.aspx?seq={0}" HeaderText="제목">
                                <HeaderStyle HorizontalAlign="Center" Width="430px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:HyperLinkColumn>
                            <asp:BoundColumn DataField="writer" HeaderText="작성자">
                                <HeaderStyle HorizontalAlign="Center" Width="70px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="transdate" HeaderText="작성일"
                                DataFormatString="{0:yyyy-MM-dd}">
                                <HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="readcount" HeaderText="읽음">
                                <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                        </Columns>
                    </asp:DataGrid>
                </td>
            </tr>
        </table>
        
    </form>
</body>
</html>
