using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//추가 코드
using System.Data.SqlClient;
using System.Data;

namespace WebApplication5.NewFolder1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //<asp:TextBox>태그의 ID속성값인듯 하다.
        protected System.Web.UI.WebControls.TextBox name;
        protected System.Web.UI.WebControls.TextBox pwd;
        protected System.Web.UI.WebControls.TextBox title;
        protected System.Web.UI.WebControls.TextBox content;

        //<asp:RequiredFieldValidator>태그의 ID속성값 인가...
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;

        //<asp:ValidationSummary>태그 ID
        protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;

        protected SqlConnection Con;
        protected SqlCommand Cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void PostButton_Click(object sender, EventArgs e)
        {
            Con = new SqlConnection();//db연결부 : ConnectionString을 가진다. 그리고 여기엔 db연결 정보가 들어간다.
            //server()안에 그냥 local로 두면 되나?->팀장님이 그냥 두면 된다고 하심.
            Con.ConnectionString = "server=(local); database=Test02; user id=sa; password=124578";

            Cmd = new SqlCommand("INSERT_BOARD",Con);
            Cmd.CommandType = CommandType.StoredProcedure;

            //using System.Data;가 없어서 에러 났었음.
            //db프로시저와 타입 길이를 맞춰줌
            //~.Add를 통해 db 프로시저에서 인자로 받을 값에 대해 이곳에서 다시한번 정의 해 준다.
            Cmd.Parameters.Add("@Writer", SqlDbType.VarChar, 20);
            Cmd.Parameters.Add("@Pwd", SqlDbType.VarChar, 20);
            Cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100);
            Cmd.Parameters.Add("@Title", SqlDbType.VarChar, 100);
            Cmd.Parameters.Add("@Mode", SqlDbType.Bit);
            Cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 15);
            Cmd.Parameters.Add("@Content", SqlDbType.Text);

            //여기서는 정의한 인자에 값을 대입 한다. 
            Cmd.Parameters["@Writer"].Value = name.Text;
            Cmd.Parameters["@Pwd"].Value = pwd.Text;
            Cmd.Parameters["@Email"].Value = mail.Text;
            Cmd.Parameters["@Title"].Value = title.Text;
            Cmd.Parameters["@Mode"].Value = (UseHTML.Checked == true ? 1 : 0);
            Cmd.Parameters["@Ip"].Value = Request.UserHostAddress;
            Cmd.Parameters["@Content"].Value = content.Text;

            Con.Open();
            int i = Cmd.ExecuteNonQuery();//쿼리를 db에 전달하고 결과를 받는다.//전달은 했으나 받을건 없다. 그래서 받고 끝!     

            Con.Close();

            Cmd = null;
            Con = null;

            //글 입력 후 자동으로 다음 페이지로 이동한다.
            Response.Redirect("list.aspx");
            
            
            //아래 코드는 동작하지 않음. 이유 확인예정.
            //string script = "<script>alert('저장되었습니다.');</script>";
            //script = string.Format(script);




        }
    }
}