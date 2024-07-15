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
    public partial class TodaysDeal1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void createBut_Click(object sender, EventArgs e)
        {
            int i = 0;
            string date = dateTxt.Text;
            string errortxt = "";
            string time = timeTxt0.Text;
            string datetimeTxt = date + " " + time;
            string[] d = date.Split('-');
            string[] t = time.Split(':');
            if (d.Length != 3)
            {
                errortxt += "Date is not in the correct format. Date must be in this format: YYYY-MM-DD. \n";
                Response.Write(d[0]);
            }
            if (t.Length != 2)
            {
                errortxt += "Time is not in the correct format. Time must be in this format: HH:MM. \n";

            }
            if (amountTxt.Text == "")
            {
                errortxt += "Amount cannot be empty.\n";

            }
            if (productTxt.Text == "")
            {
                errortxt += " Product Id cannot be empty \n";

            }
            if (amountTxt.Text == "")
            {
                errortxt += "Amount cannot be empty \n";

            }
            else
            {
                Int32.TryParse((amountTxt.Text), out i);
            }

            if (errortxt == "")
            {
                string conSt = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
                SqlConnection c = new SqlConnection(conSt);
                SqlCommand getFromCart = new SqlCommand("Select count(*) from Product  where serial_no =" + productTxt.Text.ToString(), c);
                int pExist = 0;
                int cExist = 0;

                c.Open();
                Int32.TryParse((getFromCart.ExecuteScalar()).ToString(), out cExist);

                c.Close();

                if (cExist == 0)
                {
                    errorBox.Text = "Product :" + productTxt.Text + " doesn't exist.";
                    errorBox.ForeColor = System.Drawing.Color.Red;
                    errorBox.Visible = true;

                }
                else
                {

                    SqlCommand command = new SqlCommand("createTodaysDeal", c);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@admin_username", Session["username"]));
                    command.Parameters.Add(new SqlParameter("@deal_amount", i));
                    command.Parameters.Add(new SqlParameter("@expiry_date", datetimeTxt));
                    SqlCommand commandcheck = new SqlCommand("checkTodaysDealOnProduct", c);
                    commandcheck.CommandType = CommandType.StoredProcedure;
                    commandcheck.Parameters.Add(new SqlParameter("@serial_no", productTxt.Text));
                    SqlParameter active = commandcheck.Parameters.Add("@activeDeal", SqlDbType.Bit);
                    active.Direction = ParameterDirection.Output;
                    SqlCommand getid = new SqlCommand("Select MAX(deal_id) from Todays_Deals", c);

                    c.Open();
                    commandcheck.ExecuteNonQuery();

                    c.Close();
                    if (active.Value.ToString() == "True")
                    {
                        errorBox.Text = "Product :" + productTxt.Text + " already have an active Today's Deal";
                        errorBox.ForeColor = System.Drawing.Color.Red;
                        errorBox.Visible = true;
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("addTodaysDealOnProduct", c);
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.Add(new SqlParameter("@serial_no", productTxt.Text));
                        c.Open();
                        command.ExecuteNonQuery();
                        string dealId = (getid.ExecuteScalar()).ToString();
                        cmd.Parameters.Add(new SqlParameter("@deal_id", dealId));
                        cmd.ExecuteNonQuery();
                        c.Close();
                        errorBox.Text = "Success";
                        errorBox.ForeColor = System.Drawing.Color.LimeGreen;
                        errorBox.Visible = true;

                    }
                }
            }
            else
            {
                errorBox.Text = errortxt;
                errorBox.ForeColor = System.Drawing.Color.Red;
                errorBox.Visible = true;
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string errortxt = "";
            int id = 0;
            if (deleteTxt.Text == "")
            {
                errortxt += "Deal ID cannot be empty \n";

            }
            else
            {
                Int32.TryParse((deleteTxt.Text), out id);
            }

            if (errortxt == "")
            {
                string conSt = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
                SqlConnection c = new SqlConnection(conSt);
                SqlCommand command = new SqlCommand("removeExpiredDeal", c);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@deal_iD", id));


                SqlCommand getCount = new SqlCommand("Select count(deal_id) from Todays_Deals", c);
                SqlCommand getDeal = new SqlCommand("Select count(deal_id) from Todays_Deals where deal_id =" + id, c);
                int dealExist = 0;
                int countPrev = 0;
                int countAft = 0;
                c.Open();
                Int32.TryParse((getCount.ExecuteScalar()).ToString(), out countPrev);
                Int32.TryParse((getDeal.ExecuteScalar()).ToString(), out dealExist);

                c.Close();

                if (dealExist == 0)
                {
                    errorBox0.Text = "DEAL :" + deleteTxt.Text + " does not exist";
                    errorBox0.ForeColor = System.Drawing.Color.Red;
                    errorBox0.Visible = true;
                }
                else
                {

                    c.Open();
                    command.ExecuteNonQuery();
                    Int32.TryParse((getCount.ExecuteScalar()).ToString(), out countAft);

                    c.Close();

                    if (countAft == countPrev)
                    {
                        errorBox0.Text = "DEAL :" + deleteTxt.Text + "is not yet expired";
                        errorBox0.ForeColor = System.Drawing.Color.Red;
                        errorBox0.Visible = true;
                    }
                    else
                    {
                        errorBox0.Text = "Success";
                        errorBox0.ForeColor = System.Drawing.Color.LimeGreen;
                        errorBox0.Visible = true;

                    }

                }
            }
            else
            {
                errorBox0.Text = errortxt;
                errorBox0.ForeColor = System.Drawing.Color.Red;
                errorBox0.Visible = true;
            }
        }

    }
}