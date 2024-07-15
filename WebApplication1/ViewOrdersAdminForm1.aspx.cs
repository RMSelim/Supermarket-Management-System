using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1
{
    public partial class ViewOrdersAdminForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void update_Click(object sender, EventArgs e)
        {
            string conSt = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection c = new SqlConnection(conSt);
            string orderId = idTxtBox.Text;
            SqlCommand command = new SqlCommand("updateOrderStatusInProcess", c);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@order_no", orderId));
            string sqlcmdstatus = "Select order_status From Orders where order_no =" + "'" + orderId + "'";
            SqlCommand statCmd = new SqlCommand(sqlcmdstatus, c);
            try
            {
                c.Open();
                string stat = (statCmd.ExecuteScalar()).ToString();
                c.Close();
                switch (stat)
                {
                    case "in process":
                        errorBox.Text = "Order is already in process.";
                        errorBox.Visible = true;
                        break;
                    case "delivered":
                        errorBox.Text = "Cannot change status. Order is already delivered.";
                        errorBox.Visible = true;
                        break;
                    case "not processed":
                        c.Open();
                        command.ExecuteNonQuery();
                        c.Close();
                        Response.Redirect("ViewOrdersAdminForm1.aspx", true);
                        break;
                    case "Out for Delivery":
                        errorBox.Text = "Cannot change status. Order is already out for delievery.";
                        errorBox.Visible = true;
                        break;
                    default:
                        errorBox.Text = "Order Does not exist.";
                        errorBox.Visible = true;
                        break;

                }
            }
            catch (Exception ex)
            {
                errorBox.Text = "Order Does not exist.";
                errorBox.Visible = true;
            }



        }
    }
}