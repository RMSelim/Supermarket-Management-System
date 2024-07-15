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
    public partial class ActivateVendorForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            string vendorUser = vendoruser.Text;
            string conSt = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            SqlConnection c = new SqlConnection(conSt);
            SqlCommand command = new SqlCommand("activateVendors", c);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@admin_username", Session["username"]));
            command.Parameters.Add(new SqlParameter("@vendor_username", vendorUser));

            string sqlcmdV = "Select username From Vendor where username =" + "'" + vendorUser + "'";
            string sqlcmdA = "Select admin_username From Vendor where username =" + "'" + vendorUser + "'";

            SqlCommand vCmd = new SqlCommand(sqlcmdV, c);
            SqlCommand aCmd = new SqlCommand(sqlcmdA, c);
            if (vendorUser == "")
            {
                errorBox.Text = "Vendor Username cannot be empty ";
                errorBox.ForeColor = System.Drawing.Color.Red;
                errorBox.Visible = true;
            }
            else
            {
                try
                {
                    c.Open();
                    string ven = (vCmd.ExecuteScalar()).ToString();
                    string Adm = (aCmd.ExecuteScalar()).ToString();
                    c.Close();

                    if (!(Adm == ""))
                    {
                        
                        errorBox.Text = "Vendor is already activated by " + Adm;
                        errorBox.ForeColor = System.Drawing.Color.Red;

                        errorBox.Visible = true;
                    }
                    else
                    {
                        c.Open();
                        command.ExecuteNonQuery();
                        c.Close();
                        errorBox.Text = "Success";
                        errorBox.ForeColor = System.Drawing.Color.Lime;

                        errorBox.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    errorBox.Text = "Vendor does not exist.";
                    errorBox.ForeColor = System.Drawing.Color.Red;

                    errorBox.Visible = true;
                }
            }
        }
    }
}