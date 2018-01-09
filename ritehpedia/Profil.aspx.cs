using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Globalization;

public partial class Profil : System.Web.UI.Page
{
    UserSession sesija;
    protected string usernm;
    private string ime;
    private string prezime;
    private string adresa;
    private string grad;
    private string email;
    private string broj_tel;
    private int userID;
    protected void Page_Load(object sender, EventArgs e)
    {
        sesija = Session["User"] as UserSession;
        if (!IsPostBack)
        {
            if (sesija != null)
            {
                usernm = sesija.Username;
                success.Text = "";
                DataSet ds = new DataSet();
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand sqlCmd = new SqlCommand("SELECT ime, prezime, adresa, grad, email, broj_tel, Korisnicko_ime FROM Student where idStudent= " + sesija.UserID, conn);
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd.CommandText, conn);
                    sqlAdapter.Fill(ds, "korisnik");
                }
                foreach (DataRow myRow in ds.Tables["korisnik"].Rows)
                {
                    ime = myRow["ime"].ToString();
                    prezime = myRow["prezime"].ToString();
                    adresa = myRow["adresa"].ToString();
                    grad = myRow["grad"].ToString();
                    broj_tel = myRow["Broj_tel"].ToString();

                    txt1.Text = ime;
                    txt2.Text = prezime;
                    txt3.Text = adresa;
                    txt4.Text = grad;
                    txt5.Text = broj_tel;
                }
            }
        }
    }


    protected void IzmjeniPodatke(object sender, EventArgs e)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        {
            connection.Open();
            string queryString = "UPDATE Student SET Ime='" + txt1.Text + "', Prezime='" + txt2.Text + "', Adresa='" + txt3.Text + "', Grad='" + txt4.Text + "', broj_tel='" + txt5.Text + "' WHERE idStudent=" + sesija.UserID;
            SqlCommand sqlCmd = new SqlCommand(queryString, connection);
            string test = queryString;
            int x = sqlCmd.ExecuteNonQuery();
            if(x > 0)
            {
                success.Text = "Podaci uspješno ažurirani!";
            }
            else
            {
                success.Text = "Greška";
            }
        }
    }

}