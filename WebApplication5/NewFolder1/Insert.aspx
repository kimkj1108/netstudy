<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Insert.aspx.cs" Inherits="WebApplication5.NewFolder1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>insert</title>
</head>
<body><%-- 디자인 탭에서 드레그엔 드롭으로 요소들을 생성 가능--%>
    <%-- 태그들을 컨트롤 이라고 부르는 것으로 보임 --%>
    <form id="insert" method ="post" runat="server">
        
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
                <td>&nbsp;&nbsp;글 작성하기</td>
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
                    <asp:TextBox runat="server" CssClass="input" ID="name" Width="100px">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="이름" Display="None" ControlToValidate="name">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr height="1">
                <td colspan="2"></td>
            </tr>
            <tr class="txt01">
                <td>비밀번호</td>
                <td>
                    <asp:TextBox runat="server" CssClass="input" ID="pwd" 
                        Width="100px" TextMode="Password">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ErrorMessage="비밀번호" Display="None" ControlToValidate="pwd">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
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
        <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true"
            runat="server" ShowSummary="false" HeaderText="다음 항목들을 제대로 기입해주세요<" />
    </form>
</body>
</html>














