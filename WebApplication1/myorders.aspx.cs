using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Configuration;

namespace WebApplication1
{
    public partial class myorders : System.Web.UI.Page
    {
        protected void cancelorder(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("cancelOrder", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            int id;
            Int32.TryParse(TextBox1.Text, out id);
            cmd.Parameters.Add(new SqlParameter("@orderid", id));

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("myorders.aspx");



        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerMainPage.aspx");
        }
    }
}