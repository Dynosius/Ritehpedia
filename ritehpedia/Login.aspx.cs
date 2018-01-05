using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        string usernm = ((TextBox)LoginControl.FindControl("UserName")).Text.ToLower();
        string passwd = ((TextBox)LoginControl.FindControl("Password")).Text;
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        {
            conn.Open();
            string query = "SELECT COUNT(1) FROM Student WHERE Korisnicko_ime=@username AND Lozinka=@password";
            SqlCommand sqlCmd = new SqlCommand(query, conn);
            sqlCmd.Parameters.AddWithValue("@username", usernm.Trim());
            sqlCmd.Parameters.AddWithValue("@password", passwd.Trim());

            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());

            if (count == 1)
            {
                Session["username"] = usernm.Trim();
                Response.Redirect("Home.aspx");
            }
            else
            {
                //Response.Redirect("Login.aspx");
            }
        }
    }

}