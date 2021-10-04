using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;

namespace WebApplication5.NewFolder1
{
    //프로젝트 속성의 web에서 첫페이지로 설정했다.
    public partial class list : System.Web.UI.Page
    {
        protected SqlConnection Con;
        protected SqlCommand Cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)//목록으로 올때 해당 페이지는 초기화되면 db의 값을 이용 할 것이다. (false일때 조건)
            {
                Listing();
            }
            Response.Cookies["Test"]["UpdateReadCount"] = "0";
        }

        private void Listing()
        {
            Con = new SqlConnection();//해당 코드가 있어야 되는가...
            Con.ConnectionString = "server=(local); database=Test02; user id=sa; password=124578";

            Cmd = new SqlCommand();  //("SELECT_BOARDLIST", Con);
            Cmd.Connection = Con;
            //해당 프로시저 ASC정렬->최신글이 아래옴.
            Cmd.CommandText = "SELECT_BOARDLIST";
            Cmd.CommandType = CommandType.StoredProcedure;//using System.Data;가 없어서 CommandType에 에러가 났음.

            SqlDataAdapter adp = new SqlDataAdapter(Cmd);
            DataSet ds = new DataSet();

            adp.Fill(ds, "Test");

            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();//해당 코드가 없으니 빈화면 출력.



            //SqlConnection Con = new SqlConnection(ConnectStr);
        }
    }
}