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
    public partial class cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void AddProduct(object sender, EventArgs e)
        {
            string errortxt = "";
            int id = 0;
            if (TextBox3.Text == "")
            {
                errortxt += "Product ID cannot be empty \n";

            }
            else
            {
                Int32.TryParse((TextBox3.Text), out id);
            }

            if (errortxt == "")
            {
                string conSt = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
                SqlConnection c = new SqlConnection(conSt);
                SqlCommand command = new SqlCommand("addToCart", c);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@customername", Session["username"]));
                command.Parameters.Add(new SqlParameter("@serial", id));


                SqlCommand getFromCart = new SqlCommand("Select count(*) from CustomerAddstoCartProduct  where serial_no =" + id, c);
                SqlCommand getFromProd = new SqlCommand("Select count(*) from Product where serial_no =" + id, c);
                int pExist = 0;
                int cExist = 0;

                c.Open();
                Int32.TryParse((getFromCart.ExecuteScalar()).ToString(), out cExist);
                Int32.TryParse((getFromProd.ExecuteScalar()).ToString(), out pExist);

                c.Close();

                if (pExist == 0)
                {
                    errorBox.Text = "Product :" + TextBox3.Text + " does not exist";
                    errorBox.ForeColor = System.Drawing.Color.Red;
                    errorBox.Visible = true;
                }
                else if (cExist == 1)
                {

                    errorBox.Text = "Product :" + TextBox3.Text + " already exists in your cart.";
                    errorBox.ForeColor = System.Drawing.Color.Red;
                    errorBox.Visible = true;

                }
                else
                {

                    c.Open();
                    command.ExecuteNonQuery();

                    c.Close();



                    errorBox.Text = "Success";
                    Response.Redirect("cart.aspx");
                    errorBox.ForeColor = System.Drawing.Color.LimeGreen;
                    errorBox.Visible = true;



                }
            }
            else
            {
                errorBox.Text = errortxt;
                errorBox.ForeColor = System.Drawing.Color.Red;
                errorBox.Visible = true;
            }
        }

        protected void RemoveProduct(object sender, EventArgs e)
        {
            string errortxt = "";
            int id = 0;
            if (TextBox2.Text == "")
            {
                errortxt += "Product ID cannot be empty \n";

            }
            else
            {
                Int32.TryParse((TextBox2.Text), out id);
            }

            if (errortxt == "")
            {
                string conSt = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
                SqlConnection c = new SqlConnection(conSt);
                SqlCommand command = new SqlCommand("removefromCart", c);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@customername", Session["username"]));
                command.Parameters.Add(new SqlParameter("@serial", id));


                SqlCommand getFromCart = new SqlCommand("Select count(*) from CustomerAddstoCartProduct where serial_no =" + id, c);
                SqlCommand getFromProd = new SqlCommand("Select count(*) from Product where serial_no =" + id, c);
                int pExist = 0;
                int cExist = 0;

                c.Open();
                Int32.TryParse((getFromCart.ExecuteScalar()).ToString(), out cExist);
                Int32.TryParse((getFromProd.ExecuteScalar()).ToString(), out pExist);

                c.Close();

                if (pExist == 0)
                {
                    errorBox0.Text = "Product :" + TextBox2.Text + " does not exist";
                    errorBox0.ForeColor = System.Drawing.Color.Red;
                    errorBox0.Visible = true;
                }
                else if (cExist == 0)
                {

                    errorBox0.Text = "Product :" + TextBox2.Text + " is not in your cart.";
                    errorBox0.ForeColor = System.Drawing.Color.Red;
                    errorBox0.Visible = true;

                }
                else
                {

                    c.Open();
                    command.ExecuteNonQuery();

                    c.Close();



                    errorBox0.Text = "Success";
                    Response.Redirect("cart.aspx");
                    errorBox0.ForeColor = System.Drawing.Color.LimeGreen;
                    errorBox0.Visible = true;



                }
            }
            else
            {
                errorBox0.Text = errortxt;
                errorBox0.ForeColor = System.Drawing.Color.Red;
                errorBox0.Visible = true;
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewcart.aspx");
        }
    }
}