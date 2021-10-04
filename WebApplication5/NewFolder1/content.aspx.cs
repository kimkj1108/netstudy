using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//추가
using System.Data;
using System.Data.SqlClient;


//주석으로 '추정됨'이라고 쓴건 반드시
namespace WebApplication5.NewFolder1
{
    public partial class content : System.Web.UI.Page
    {
        //list페이지에서 넘어오는 seq값을 가지고 오기 위해서 만든 코드로 추정됨.
        private string seq = string.Empty;

        private string UpdateReadCount = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//앞에 느낌표가 빠지니까 아예 해당코드 실행이 안된다.
            {
                if (Request.Params["seq"] != null)
                    seq = Request.Params["seq"].ToString();

                if(Request.Cookies["Test"] != null)
                    UpdateReadCount = Request.Cookies["Test"]["UpdateReadCount"];

                if (seq == string.Empty)//list페이지에서 seq값을 안가지고 해당페이지로 넘어온다면 돌려보낸다.
                {
                    Response.Redirect("list.aspx");
                    Response.End();
                }
                getContent();
            }

        }

        private void getContent()
        {
            //선언,정의 된 변수가 이후에 쓰이지 않으면 경고 메시지가 뜬다??
            string ConnectStr = "server=(local); database=Test02; user id=sa; password=124578";

            SqlConnection Con = new SqlConnection(ConnectStr);
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;

            //using System.Data;가 없으면 CommandType에 에러표출
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@seq", SqlDbType.Int);
            Cmd.Parameters["@seq"].Value = seq;

            try
            {
                Con.Open();
                //조회수 증가
                if(UpdateReadCount == "0")
                {
                    Cmd.CommandText = "UPDATE_BOARD_READ_COUNT";
                    Cmd.ExecuteNonQuery();

                    //컨텐츠 페이지로 진입하며 조회수가 증가했고
                    //컨텐츠 페이지에서 쿠키에 UpdateReadCount = 1을 담아둔다. 그럼 새로고침을 해도 if 문이 실행되지 않고
                    //따라서 조회수는 증가하지 않는다.
                    Response.Cookies["Test"]["UpdateReadCount"] = "1";



                }
                
                //레코드를 읽어오는 프로시저로 지정.
                Cmd.CommandText = "SELECT_BOARDCONTENT";

                //이부분(여기서부터) 코드는 다시한번 살펴보기.(정확히 이해가 잘 가지 않으나 일단 넘어감)
                SqlDataReader reader =
                    Cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.Read())
                {
                    //아래는 강좌와 별개로 프로시저에서 내가 가저온 값들이다.
                    //seq, writer, email, title, ip, readcount, transdate, content
                    //ViewState["seq"] = reader[0].ToString();//생긴 모양이 배열객체에 담은다음에 배열 인덱스로 하나씩 가져오는거 같은데 맞나?
                    ViewState["seq"] = reader["seq"].ToString();

                    //<asp:Label ID="IdName" runat="server" />  의에 아이디값으로 사용자가 입력한 값을 읽어오는 걸로 추정됨.
                    //IdName.Text = reader[1].ToString();
                    IdName.Text = reader["writer"].ToString();

                    //IbDate.Text = reader[6].ToString();
                    IbDate.Text = reader["transdate"].ToString();

                    //IbRead.Text = reader[5].ToString();
                    IbRead.Text = reader["readcount"].ToString();

                    //IbTitle.Text = reader[3].ToString();
                    IbTitle.Text = reader["title"].ToString();

                    //IbContent.Text = reader[7].ToString();
                    IbContent.Text = reader["content"].ToString();

                    //html선택하는 칸 자체를 안만든걸로 기억하는데...
                    //bool mode = (bool)reader[8];//사용자의 HTML 사용여부를 지정 하는 칼럼
                    bool mode = (bool)reader["mode"];
                    if(mode)
                    {
                        //IbContent.Text = ReplaceBR(reader[7].ToString());
                        IbContent.Text = ReplaceBR(reader["content"].ToString());
                    }
                    else
                    {
                        //IbContent.Text = ReplaceBR(Server.HtmlEncode(reader[7].ToString()));
                        IbContent.Text = ReplaceBR(Server.HtmlEncode(reader["content"].ToString()));
                    }
                }
                else//해당 esle구문 전체를 삭제 할 수도...??
                {
                    string script;
                    script = "<script>alert('글이 존재하지 않습니다.); hisotory.back();</script>";
                    Page.RegisterClientScriptBlock("done", script);
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                IbError.Text = "ERROR : " + ex.Source + " - " + ex.Message;
                IbError.Visible = true;
            }
            if (Con.State == ConnectionState.Open)//if에 조건만 있고 바디가 없는데 이런형태가 자바에서 가능했는지 기억이 안난다
                Con.Close();
            Cmd = null;
            Con = null;
        }
        protected string ReplaceBR(string s)
        {
            return s.Replace("\n", "<br/>");//  \n : 줄바꿈.
        }

        protected void btnList_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
        private bool IsPasswordValid()
        {
            bool flag = false;

            string ConnectStr = "server=(local); database=Test02; user id=sa; password=124578";
            //SqlConnection : 서버 접속을 위한 클래스
            //서버 접속 방법이 담겨있는 connection String이 필요하다.
            SqlConnection Con = new SqlConnection(ConnectStr);

            //SqlCommand : 서버에 어떤 명령을 내리기 위해 사용하는 클래스이다.
            SqlCommand Cmd = new SqlCommand();

            Cmd.Connection = Con;

            Cmd.CommandText = "PASSWORD_VALID";
            Cmd.CommandType = CommandType.StoredProcedure;

            //입력받은 값을 db의 값이랑 비교하기 위한 코드로 추정.
            Cmd.Parameters.Add("@seq", SqlDbType.Int);
            Cmd.Parameters["@seq"].Value = ViewState["seq"].ToString();//Command 매개변수 중 seq 값을 지정하는 부분
            Cmd.Parameters.Add("@pwd", SqlDbType.VarChar, 20);
            Cmd.Parameters["@pwd"].Value = pwd.Text;

            //ViewState에 담고 있는 seq 와 pwd가 모두 일치하지 않는다면 반환되는 값이 없을 것이다.

            try
            {
                Con.Open();

                if (Cmd.ExecuteScalar() != null)
                    flag = true;
            }
            catch(Exception ex)
            {
                //에러 발생시 안보이던걸 보이게 하고 에러 메시지 띄우고
                IbError.Text = "ERROR : " + ex.Source + " - " + ex.Message;
                IbError.Visible = true;
            }
            if (Con.State == ConnectionState.Open) Con.Close();

            Cmd = null;
            Con = null;

            return flag;


        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            bool isValid = IsPasswordValid();

            if (isValid)//값이 있는 경우?
            {

                //테스트용 코드
                //IbError.Text = "비밀번호 일치!!";

                Delete();//만들어둔 로직 실행!
                Response.Redirect("list.aspx");
            }
            else
                IbError.Text = "비밀번호 불일치!!";

            IbError.Visible = true;
        }

        private void Delete()
        {
            string ConnectStr = "server=(local); database=Test02; user id=sa; password=124578";

            SqlConnection Con = new SqlConnection(ConnectStr);
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;

            Cmd.CommandText = "DELETE_CONTENT";
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@seq", SqlDbType.Int);
            Cmd.Parameters["@seq"].Value = ViewState["seq"].ToString();

            try
            {
                Con.Open();
                Cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                IbError.Text = "ERROR" + ex.Source + " - " + ex.Message;
                IbError.Visible = true;
            }

            if (Con.State == ConnectionState.Open) Con.Close();//열려있다면 닫아라

            //둘다 널값 넣어준다.
            Cmd = null;
            Con = null;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            bool isValid = IsPasswordValid();

            if (isValid)
            {
                Response.Redirect("Edit.aspx?seq=" + ViewState["seq"].ToString());
            }
            else
                IbError.Text = "비밀번호 불일치!!";

                IbError.Visible = true;
        }
    }
}










