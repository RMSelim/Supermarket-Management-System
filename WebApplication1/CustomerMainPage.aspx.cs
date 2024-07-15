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
    public partial class CustomerMainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       

        protected void goproducts(object sender, EventArgs e)
        {
            Response.Redirect("products.aspx");
        }

        protected void gowishlists(object sender, EventArgs e)
        {
            Response.Redirect("Wishlists.aspx");
        }

        protected void gocart(object sender, EventArgs e)
        {
            Response.Redirect("cart.aspx");
        }

        protected void addcredit(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

         
            SqlCommand cmd = new SqlCommand("AddcreditCard", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            string ccnum = TextBox1.Text;
            string cvc = TextBox2.Text;
            string expiry_date = TextBox3.Text;

            string[] d = expiry_date.Split('-');

            if (d.Length != 3)
            { 
                Response.Write("Date is not in the correct format. Date must be in this format: YYYY-MM-DD.");
            }


            cmd.Parameters.Add(new SqlParameter("@creditcardnumber", ccnum));
            cmd.Parameters.Add(new SqlParameter("@cvv", cvc));
            cmd.Parameters.Add(new SqlParameter("@expirydate", expiry_date));
            cmd.Parameters.Add(new SqlParameter("@customername", Session["username"]));


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("Credit Card added successfully");
            }
            catch 
            {
                Response.Write("This Credit Card is either already in the system or the information entered is not valid, please try again.");
            }
        }

        protected void createwishlist(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand cmd = new SqlCommand("createWishlist", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            string wishlist_name = TextBox5.Text;
            cmd.Parameters.Add(new SqlParameter("@customername", Session["username"]));
            cmd.Parameters.Add(new SqlParameter("@name", wishlist_name));

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("Wishlist Created");
            }
            catch
            {
                Response.Write("This user already has a wishlist with the entered name.");
            }


        }

        protected void Button3_Click(object sender, EventArgs e)
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

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}