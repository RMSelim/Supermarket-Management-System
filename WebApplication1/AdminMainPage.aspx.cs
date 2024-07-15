using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace WebApplication1
{
    public partial class AdminMainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewOrdersAdminForm1.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ActivateVendorForm1.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("TodaysDeal1.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand cmd = new SqlCommand("addMobile", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            string mobilenum = TextBox6.Text;
            cmd.Parameters.Add(new SqlParameter("@username", Session["username"]));
            cmd.Parameters.Add(new SqlParameter("@mobile_number", mobilenum));

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("Mobile Number added");
            }
            catch
            {
                Response.Write("This number is invalid or is already in the system.");
            }

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}