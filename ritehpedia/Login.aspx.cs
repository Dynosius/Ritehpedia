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
            string query = "SELECT idStudent FROM Student WHERE Korisnicko_ime=@username AND Lozinka=@password";
            SqlCommand sqlCmd = new SqlCommand(query, conn);
            sqlCmd.Parameters.AddWithValue("@username", usernm.Trim());
            sqlCmd.Parameters.AddWithValue("@password", passwd.Trim());
            int ID = Convert.ToInt32(sqlCmd.ExecuteScalar());

            if (ID != 0)
            {

                SqlCommand sqlCmd2 = new SqlCommand("SELECT Student.idStudij, imeStudija FROM Studij INNER JOIN Student ON Studij.idStudij = Student.idStudij WHERE Student.idStudent =" + ID, conn);
                SqlDataReader reader = sqlCmd2.ExecuteReader();
                if (reader.Read())
                {
                    int idst = Convert.ToInt32(reader["idStudij"]);
                    string imeStd = reader["imeStudija"].ToString();
                    UserSession sesija = new UserSession(usernm, ID, idst, imeStd);
                    Session["User"] = sesija;
                    Response.Redirect("index.aspx", true);
                }

            }
        }
    }
}