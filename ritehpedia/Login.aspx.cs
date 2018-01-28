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
    private bool isUserValidated = false;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        string usernm = ((TextBox)LoginControl.FindControl("UserName")).Text;
        string passwd = ((TextBox)LoginControl.FindControl("Password")).Text.Trim();
        string encryptedPass = FormsAuthentication.HashPasswordForStoringInConfigFile(passwd.Trim(), "SHA1");
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        {
            conn.Open();
            string query = "SELECT idStudent FROM Student WHERE Korisnicko_ime=@username AND Lozinka=@password";
            SqlCommand sqlCmd = new SqlCommand(query, conn);
            sqlCmd.Parameters.AddWithValue("@username", usernm.Trim());
            sqlCmd.Parameters.AddWithValue("@password", encryptedPass);
            int ID = Convert.ToInt32(sqlCmd.ExecuteScalar());

            if (ID != 0)
            {
                SqlCommand sqlCmd2 = new SqlCommand("SELECT Student.idStudij, imeStudija, Student.UlogaID as UlogaID FROM Studij INNER JOIN Student ON Studij.idStudij = Student.idStudij WHERE Student.idStudent =" + ID, conn);
                SqlDataReader reader = sqlCmd2.ExecuteReader();
                if (reader.Read())
                {
                    isUserValidated = true;
                    int idst = Convert.ToInt32(reader["idStudij"]);
                    string imeStd = reader["imeStudija"].ToString();
                    int uloga = Convert.ToInt32(reader["UlogaID"]);
                    UserSession sesija = new UserSession(usernm, ID, idst, imeStd, uloga);
                    Session["User"] = sesija;
                    Response.Redirect("index.aspx");
                }
            }
        }

        if (isUserValidated)
        {

        }
    }
}