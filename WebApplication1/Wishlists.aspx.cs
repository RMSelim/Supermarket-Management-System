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
    public partial class Wishlists : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddProduct(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("AddtoWishlist", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            string name = TextBox1.Text;
            int x;
            Int32.TryParse(addTxt.Text, out x);

            cmd.Parameters.Add(new SqlParameter("@customername", Session["username"]));
            cmd.Parameters.Add(new SqlParameter("@serial", x));
            cmd.Parameters.Add(new SqlParameter("@wishlistname", name));

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                Response.Write("Either the product doesn't exist or the wishlist entered has not been created.");
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("mywishlists.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("removefromWishlist", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            string name = TextBox3.Text;
            int x;
            Int32.TryParse(TextBox2.Text, out x);

            cmd.Parameters.Add(new SqlParameter("@customername", Session["username"]));
            cmd.Parameters.Add(new SqlParameter("@serial", x));
            cmd.Parameters.Add(new SqlParameter("@wishlistname", name));

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                Response.Write("Either the product doesn't exist or the wishlist entered has not been created.");

            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerMainPage.aspx");
        }
    }
}