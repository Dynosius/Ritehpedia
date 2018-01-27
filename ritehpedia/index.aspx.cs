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
    }

    protected DataView VratiClanke()
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        {
            conn.Open();
            string query;
            if (idKategorije == null)
            {
                query = "SELECT idClanak, naslov FROM Clanak WHERE idKolegij=" + idKolegija;
            }
            else
            {
                query = "SELECT idClanak, naslov FROM Clanak WHERE idKolegij=" + idKolegija + " AND idKategorija=" + idKategorije;
            }

            DataSet ds = new DataSet();
            SqlDataAdapter sqlData = new SqlDataAdapter(query, conn);
            sqlData.Fill(ds, "clanci");
            return ds.Tables["clanci"].DefaultView;
        }
    }

    protected void prikazIncrement(string id) //ne radi increment broja prikaza
    {
        string query;
        int result;
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        {
            query = "SELECT brojPregleda FROM Clanak WHERE idClanak = " + id; //izmijenio
            SqlCommand com = new SqlCommand(query,conn);
            SqlDataReader read = com.ExecuteReader();
            if (read.IsDBNull(read.GetOrdinal("brojPregleda")))
            {
                result = 0;
            }
            else
            {
                result = read.GetInt16(0);
            }
            result ++;

            query = "UPDATE Clanak SET brojPregleda= " + result + " WHERE idClanak= " +id;
            com = new SqlCommand(query, conn);
            com.ExecuteNonQuery();
        }
    }
}