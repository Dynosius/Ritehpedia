using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;
using System.Data.SqlClient;

public partial class Create_account : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Email_TextChanged(object sender, EventArgs e)
    {

    }

    protected void sendButton_Click(object sender, EventArgs e)
    {
        string Uname = Username.Text;
        string emailcheck = Email.Text;
        string name = Name.Text;
        string lastname = Surname.Text;
        string city = City.Text;
        string pass = Password.Text;
        string passAgain = Confirmpass.Text;
        string address = adress.Text;
        string phone = tel.Text;
        string date = year.Text.Trim() + "-" + month.Text.Trim() + "-" + day.Text.Trim();
        int studijID = kolegijLista.SelectedIndex + 1;
        if (CheckCredentials(Uname, emailcheck) == false)
        {
            InsertData(Uname, pass, name, lastname, city, address, emailcheck, phone, date, studijID);
            Response.Redirect("RegSuccess.aspx");
        }
        else
        {
            ErrorMessage.Text = "Greška, koristili ste postojeći Email ili username";
        }
    }

    private void InsertData(string Uname, string pass, string name, string lastname, string city, string adress, string email, string phone, string date, int studijID)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        {
            connection.Open();
            String query = "INSERT INTO dbo.Student (Korisnicko_ime, Lozinka, Ime, Prezime, Adresa, Grad, Datum_rod, Email, broj_tel, idStudij) VALUES (@Uname, @pass, @name, @lastname, @adress, @city, @date, @email, @phone, @studijID)";
            SqlCommand sqlCmd = new SqlCommand(query, connection);
            sqlCmd.Parameters.AddWithValue("@Uname", Uname.Trim());
            sqlCmd.Parameters.AddWithValue("@pass", pass.Trim());
            sqlCmd.Parameters.AddWithValue("@name", name.Trim());
            sqlCmd.Parameters.AddWithValue("@lastname", lastname.Trim());
            sqlCmd.Parameters.AddWithValue("@city", city.Trim());
            sqlCmd.Parameters.AddWithValue("@adress", adress.Trim());
            sqlCmd.Parameters.AddWithValue("@phone", phone.Trim());
            sqlCmd.Parameters.AddWithValue("@date", date.Trim());
            sqlCmd.Parameters.AddWithValue("@email", email.Trim());
            sqlCmd.Parameters.AddWithValue("@studijID", studijID);
            sqlCmd.ExecuteNonQuery();
        }
    }

    private Boolean CheckCredentials(String username, String email)   // Metoda provjerava ima li u bazi podataka već zabilježen username ili email (T: Ima; F: nema)
    {
        Boolean imaLi = false;
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        {
            connection.Open();
            String query1 = "SELECT count(*) FROM Student WHERE Korisnicko_ime=@username";
            String query2 = "SELECT count(*) FROM Student WHERE Email=@email";
            SqlCommand sqlCmd = new SqlCommand(query1, connection);
            sqlCmd.Parameters.AddWithValue("@username", username.Trim());
            Int32 count = (Int32)sqlCmd.ExecuteScalar();
            if (count > 0)
            {
                imaLi = true;
            }
            else
            {
                sqlCmd = new SqlCommand(query2, connection);
                sqlCmd.Parameters.AddWithValue("@email", email.Trim());
                count = (Int32)sqlCmd.ExecuteScalar();

                if (count > 0)
                {
                    imaLi = true;
                }
            }
        }
        return imaLi;
    }

    protected void Username_TextChanged(object sender, EventArgs e) //dinamički provjerava je li ime dostupno
    {
        //string Uname = Username.Text;
        Int32 count = 0;
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        {
            connection.Open();
            String query = "SELECT count(*) FROM Student WHERE Korisnicko_ime = '" + Username.Text.Trim()+ "'";
            SqlCommand sqlCmd = new SqlCommand(query, connection);
            count = (Int32)sqlCmd.ExecuteScalar();
        }

        if (count > 0) { LabelUsernamePostoji.Visible = true; }
        else { LabelUsernamePostoji.Visible = false; }
    }
}