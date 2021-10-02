<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="WebApplication5.NewFolder1.Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         
        <table border ="0">
            <tr>
                <td></td>
            </tr>
            <tr>
                <td></td>
            </tr>
        </table>
        <table border="0">
            <tr>
                <td>&nbsp;&nbsp;글 수정하기</td>
            </tr>
        </table>
        <table border="0">
            <tr class="txt01"><td></td></tr>
            <tr class="txt01"><td></td></tr>
            <tr class="txt01"><td></td></tr>
        </table>
        <table border="0">
            <tr class="txt01">
                <td>이름</td>
                <td>
                    <asp:Label runat="server" ID="name" />
                </td>
            </tr>
            <tr height="1">
                <td colspan="2"></td>
            </tr>
            <%--비밀번호는 수정시 필요없으므로 삭제 --%>
            <tr height="1">
                <td colspan="2"></td>
            </tr>
            <tr class="txt01">
                <td>메일</td>
                <td>
                    <asp:TextBox Runat="server" CssClass="input" ID="mail" Width="300px">
                    </asp:TextBox>
                  </td>
            </tr>
            <tr height="1">
                <td colspan="2" background="images/dotline.gif"></td>
            </tr>
            <tr class="txt01">
                <td>제목</td>
                <td>
                    <asp:TextBox runat="server" CssClass="input" ID="title" Width="300px">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ErrorMessage="제목" Display="None" ControlToValidate="title">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr height="1">
                <td colspan="2"></td>
            </tr>
                <%-- 여기만 내용이 뭔가 다른데..왜지? --%>
            <tr class="txt01">
                <td colspan="2">내용
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                        ErrorMessage="본문 내용" Display="None" ControlToValidate="content">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox runat="server" CssClass="input" ID="content" Rows="7"
                        TextMode="MultiLine" Wrap="true" Columns="80">
                    </asp:TextBox>
                </td>
            </tr>

            <%-- height 속성 : 에러표출하나 크롬에서 동작함. --%>
            <tr height="1">
                <td colspan="2"></td>
            </tr>
             <tr class="txt01">
                <td>HTML 사용여부</td>
                <td>
                    <asp:CheckBox ID="UseHTML" Runat="server" CssClass="Options">
                    </asp:CheckBox>
                    <label for="UseHTML" class="txt01">사용합니다</label></td>
            </tr>
            <tr height="1">
                <td colspan="2"></td>
            </tr>
            <tr>
                <%-- aligin 속성 : 에러는 뜨지만 크롬에서 동작함. --%>
                <td colspan="2" align="right">
                    <asp:Button ID="PostButton" runat="server" Text="저장하기" OnClick="PostButton_Click" />
                </td>
            </tr>
        </table>
        <asp:Label ID="IbError" runat="server" ForeColor="Red" BorderWidth="1px" BorderStyle="Solid" BorderColor="Red" Width="520px"
                Visible="false"></asp:Label>

    </form>
</body>
</html>
