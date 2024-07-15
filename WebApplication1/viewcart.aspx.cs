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
    public partial class viewcart : System.Web.UI.Page
    {
        protected void lastorder(object sender, EventArgs e)
        {
            Response.Redirect("orderpayment.aspx");
        }

        protected void makeorder(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("makeorder", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@customername", Session["username"]));

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();




            Response.Redirect("orderpayment.aspx");

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

 
    }
}