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
    public partial class orderpayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void payfororder(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd2 = new SqlCommand("getorderid", conn);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add(new SqlParameter("@customername", Session["username"]));
            SqlParameter orderid = cmd2.Parameters.Add("@orderid", SqlDbType.Int);
            orderid.Direction = ParameterDirection.Output;
            int id;


            SqlCommand cmd = new SqlCommand("SpecifyAmount", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            int x;
            string money = TextBox1.Text;
            Int32.TryParse(money, out x);

            cmd.Parameters.Add(new SqlParameter("@customername", Session["username"]));



            if (cashcheck.Checked)
            {
                cmd.Parameters.AddWithValue("@cash", x);
                cmd.Parameters.AddWithValue("@credit", 0);


            }
            else if (creditcheck.Checked)
            {
                cmd.Parameters.AddWithValue("@credit", x);
                cmd.Parameters.AddWithValue("@cash", 0);


            }
            try
            {

                conn.Open();
                cmd2.ExecuteNonQuery();
                Int32.TryParse(orderid.Value.ToString(), out id);
                cmd.Parameters.Add(new SqlParameter("@orderid", id));
                cmd.ExecuteNonQuery();
                conn.Close();

                Response.Redirect("myorders.aspx");
            }
            catch
            {
                Response.Write("The order is either empty or a field(s) was left empty, please specify payment detals again.");
            }


        }

    }
}