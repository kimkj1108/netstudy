using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5.NewFolder1
{
    public partial class Edit : System.Web.UI.Page
    {
        private string seq = string.Empty;
        private SqlConnection Con;
        private SqlCommand Cmd;
        private const string CONNECTSTR = "server=(local); database=Test02; user id=sa; password=124578";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {   //Request.Params컬렉션으로 seq값을 받아온다
                if (Request.Params["seq"] != null)//값이 널이 아니라면?
                    seq = Request.Params["seq"].ToString();//seq변수에 seq값을 넣겠다.

                if(seq == string.Empty)//값이 빈값이랑 일치 없으면.
                {
                    Response.Redirect("list.aspx");//리스트로 이동하겠다.
                    Response.End();
                }
                else
                {
                    ViewState["seq"] = seq;
                }

                getContent();
            }
            else
            {
                seq = ViewState["seq"].ToString();
            }
        }

        private void getContent()
        {

            Con = new SqlConnection(CONNECTSTR);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;

            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add("@seq", SqlDbType.Int);
            Cmd.Parameters["@seq"].Value = seq;

            try
            {
                Con.Open();

                //레코드를 읽어오는 프로시저로 지정...프로시저로??

                //Cmd.CommandText = "SELECT_BOARDLIST";//프로시저를 잘못가져왔으니 당연히 원하는 값이 안뜨지.
                Cmd.CommandText = "SELECT_BOARDCONTENT";//해당하는 프로시저
                SqlDataReader reader = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.Read())
                {
                    //seq, writer, email, title, ip, readcount, transdate, content  //content페이지와 동일한 것들을 불러 올 것이다.
                    name.Text = reader["writer"].ToString();
                    mail.Text = reader["email"].ToString();
                    title.Text = reader["title"].ToString();

                    bool mode = (bool)reader["mode"];
                    if (mode) UseHTML.Checked = true;

                    content.Text = reader["content"].ToString();
                }
                else
                {
                    //글이 존제하지 않는다는 alert
                    string script = "<script>alert('글이 존재하지 않습니다'); history.back();</script>";
                    Page.RegisterClientScriptBlock("done", script);
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                IbError.Text = "ERROR : " + ex.Source + " - " + ex.Message;
                IbError.Visible = true;

            }
            if (Con.State == ConnectionState.Open)
                Con.Close();

            Cmd = null;
            Con = null;

        }

        protected void PostButton_Click(object sender, EventArgs e)
        {
            Con = new SqlConnection(CONNECTSTR);
            Cmd = new SqlCommand("UPDATE_TEST", Con);//
            Cmd.CommandType = CommandType.StoredProcedure;

            //파라미터의 타입 및 값 입력.
            Cmd.Parameters.Add("@seq", SqlDbType.Int);
            Cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100);
            Cmd.Parameters.Add("@Title", SqlDbType.VarChar, 100);
            Cmd.Parameters.Add("@Mode", SqlDbType.Bit);
            Cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 15);
            Cmd.Parameters.Add("@Content", SqlDbType.Text);

            Cmd.Parameters["@seq"].Value = seq;//화면에서 입력받은걸 프로시저의 아규먼트에 전달하겠다?
            Cmd.Parameters["@Email"].Value = mail.Text;
            Cmd.Parameters["@Title"].Value = title.Text;
            Cmd.Parameters["@Mode"].Value = (UseHTML.Checked == true ? 1 : 0);//???
            Cmd.Parameters["@Ip"].Value = Request.UserHostAddress;
            Cmd.Parameters["@Content"].Value = content.Text;

            string script;

            try
            {
                Con.Open();//db연결
                Cmd.ExecuteNonQuery();//결과를 반환받는다.
                Con.Close();//db연결 종료

                script = "<script>alert('변경되었습니다');location.href='Content.aspx?seq={0}';</script>";
                script = string.Format(script, seq);

            }
            catch (Exception ex)
            {
                IbError.Text = "ERROR : " + ex.Source + " - " + ex.Message;
                IbError.Visible = true;
            }
            if (Con.State == ConnectionState.Open)
                Con.Close();
            Cmd = null;
            Con = null;
            Response.Redirect("list.aspx");
        }
    }
       
            
}