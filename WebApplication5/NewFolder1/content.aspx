<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="content.aspx.cs" Inherits="WebApplication5.NewFolder1.content" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Content</title>
</head>
<body>
    <form id="Content" method="post" runat="server">
        <table>
            <tr>
                <td>글 내용보기</td>
            </tr>
        </table>
        <table>
            <tr>
                <td>이름</td>
                <td>
                    <asp:Label ID="IdName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>작성일</td>
                <td><asp:Label ID="IbDate" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>읽음수</td>
                <td><asp:Label ID="IbRead" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>제목</td>
                <td><asp:Label ID="IbTitle" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>내용</td>
                <td><asp:Label ID="IbContent" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <%--" CausesValidation="false"속성에 의해 유효성검사를 무시한다. --%>
                    <%-- 여기서 목록으로 버튼만 유효성 검사를 피하기 위한 위의 속성이 존제한다.--%>
                    <asp:Button ID="btnList" runat="server" Text="  목록으로  " CausesValidation="false" OnClick="btnList_Click" />
                    <asp:TextBox runat="server" ID="pwd" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID ="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="비밀번호를 입력해 주세요" ControlToValidate="pwd" Display="None"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Button ID="btnEdit" runat="server" Text="  수정하기  " OnClick="btnEdit_Click" />
                    <asp:Button ID="btnDelete" runat="server" Text="  삭제하기  " OnClick="btnDelete_Click" />
                </td>
            </tr>
        </table>
        <asp:Label ID="IbError" runat="server" ForeColor="Red" BorderWidth="1px" BorderStyle="Solid" BorderColor="Red" Width="520px"
         Visible="false"></asp:Label><br/><%--br태그는 jsp와 동일하게 쓰는 듯 하다 --%>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
            ShowMessageBox="true" ShowSummary="false" DisplayMode="List" />
    </form>
</body>
</html>















