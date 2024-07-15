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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void loginbutton(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("userLogin", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            string username = TextBox1.Text;
            string password = TextBox2.Text;

            cmd.Parameters.Add(new SqlParameter("@username", username));
            cmd.Parameters.Add(new SqlParameter("@password", password));

            SqlParameter success = cmd.Parameters.Add("@success", SqlDbType.Int);
            success.Direction = ParameterDirection.Output;
            SqlParameter type = cmd.Parameters.Add("@type", SqlDbType.Int);
            type.Direction = ParameterDirection.Output;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

       

            if ((int)success.Value == 1)
                {
                Session["username"] = username;
                if (type.Value.ToString().Equals("0"))
                {
                    Response.Redirect("CustomerMainPage.aspx");
                }
                else if (type.Value.ToString().Equals("1"))
                {
                    Response.Redirect("VendorMainPage.aspx");
                }
                else if (type.Value.ToString().Equals("2"))
                {
                    Response.Redirect("AdminMainPage.aspx");
                }
                else if (type.Value.ToString().Equals("3"))
                {
                    Response.Redirect("DeliveryMainPage.aspx");
                }
            }
            else
            {
                Response.Write("Username or Password is incorrect");
            }


        }
    }
}