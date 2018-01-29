using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class index : System.Web.UI.Page
{
    string idKategorije;
    string idKolegija;
    
    protected void Page_Load(object sender, EventArgs e)
    {
       

        idKategorije = this.Request.QueryString["idKategorije"];
        idKolegija = this.Request.QueryString["idKolegija"];

        if (idKategorije != null || idKolegija != null)
        {
            ClanakRepeater.DataSource = VratiClanke();
            ClanakRepeater.DataBind();
        }
        else
        {
            Napuni_Naslovnu();
        }
    }

    protected DataView VratiClanke()
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        {
            conn.Open();
            string query;
            query = "SELECT  StudClan.Korisnicko_ime as Korisnik ,StudClan.idClanak, naslov FROM Clanak INNER JOIN(SELECT idClanak, Korisnicko_ime FROM Student INNER JOIN Student_ureduje_clanak ON " +
                "Student.idStudent = Student_ureduje_clanak.idStudent) AS StudClan ON StudClan.idClanak = Clanak.idClanak WHERE idKolegij =" + idKolegija;
            /*
            if (idKategorije == null)
            {
                query = "SELECT idClanak, naslov FROM Clanak WHERE idKolegij=" + idKolegija + "ORDER BY brojPregleda DESC";
            }
                  // Placeholder, radilo je prije CSS-a i promjena u front-endu. Planirano je ponovno implementirati
            else
            {
                query = "SELECT idClanak, naslov FROM Clanak WHERE idKolegij=" + idKolegija + " AND idKategorija=" + idKategorije + "ORDER BY brojPregleda DESC";
            }
            */
            DataSet ds = new DataSet();
            SqlDataAdapter sqlData = new SqlDataAdapter(query, conn);
            sqlData.Fill(ds, "clanci");
            return ds.Tables["clanci"].DefaultView;
        }
    }
    public void Napuni_Naslovnu()
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        {
            conn.Open();
            string query;
            query = "SELECT StudClan.Korisnicko_ime as Korisnik ,StudClan.idClanak, naslov FROM Clanak INNER JOIN(SELECT idClanak, Korisnicko_ime FROM Student INNER JOIN Student_ureduje_clanak ON Student.idStudent = Student_ureduje_clanak.idStudent) AS StudClan ON StudClan.idClanak = Clanak.idClanak ORDER BY idClanak OFFSET 0 ROWS FETCH NEXT 8 ROWS ONLY";
            //query = "select idClanak, naslov from dbo.Clanak ORDER BY idClanak OFFSET 0 ROWS FETCH NEXT 8 ROWS ONLY";
            DataSet ds = new DataSet();
            SqlDataAdapter sqlData = new SqlDataAdapter(query, conn);
            sqlData.Fill(ds, "clanci");
            ClanakRepeater.DataSource = ds.Tables["clanci"].DefaultView;
            ClanakRepeater.DataBind();
        }
    }

    protected void prikazIncrement(string id) //ne radi increment broja prikaza
    {
        string query;
        int result;
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        {
            conn.Open();
            query = "SELECT brojPregleda FROM Clanak WHERE idClanak = " + id; //izmijenio
            SqlCommand com = new SqlCommand(query, conn);
            SqlDataReader read = com.ExecuteReader();
            if (read.IsDBNull(read.GetOrdinal("brojPregleda")))
            {
                result = 0;
            }
            else
            {
                result = read.GetInt16(0);
            }
            result++;

            query = "UPDATE Clanak SET brojPregleda= " + result + " WHERE idClanak= " + id;
            com = new SqlCommand(query, conn);
            com.ExecuteNonQuery();
        }

    }
}
    