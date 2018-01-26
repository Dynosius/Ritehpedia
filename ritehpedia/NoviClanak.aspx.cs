using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

public partial class NoviClanak : System.Web.UI.Page
{
    UserSession sesija;
    protected void Page_Load(object sender, EventArgs e)
    {
        sesija = Session["User"] as UserSession;
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        {
            if (!IsPostBack)
            {
                conn.Open();
                NapuniKolegije(conn);
                NapuniKategorije(conn);
            }
        }
    }
    private void NapuniKolegije(SqlConnection conn)
    {
        string query = "SELECT KO.idKolegij, imeKolegija FROM Kolegij KO INNER JOIN Studij_Kolegij SK ON KO.idKolegij=SK.idKolegij WHERE SK.idStudij=" + sesija.StudijID;
        DataSet ds = new DataSet();
        SqlCommand sqlCmd = new SqlCommand(query, conn);
        SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd);
        sqlAdapter.Fill(ds, "kolegiji");

        KolegijiDropDown.DataTextField = ds.Tables[0].Columns["imeKolegija"].ToString();
        KolegijiDropDown.DataValueField = ds.Tables[0].Columns["idKolegij"].ToString();
        KolegijiDropDown.DataSource = ds.Tables[0];
        KolegijiDropDown.DataBind();
    }

    private void NapuniKategorije(SqlConnection conn)
    {
        string query = "SELECT idKategorija, imeKategorije FROM Kategorija";
        DataSet ds = new DataSet();
        SqlCommand sqlCmd = new SqlCommand(query, conn);
        SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd);
        sqlAdapter.Fill(ds, "kategorije");

        KategorijeDropDown.DataTextField = ds.Tables[0].Columns["imeKategorije"].ToString();
        KategorijeDropDown.DataValueField = ds.Tables[0].Columns["idKategorija"].ToString();
        KategorijeDropDown.DataSource = ds.Tables[0];
        KategorijeDropDown.DataBind();
    }

    protected void ObjaviClanakClick(object sender, EventArgs e)
    {
        //kod vezan za upload fileova
        string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
        string contentType = FileUpload1.PostedFile.ContentType;
        Stream fs = FileUpload1.PostedFile.InputStream;
        BinaryReader br = new BinaryReader(fs);
        byte[] bytes = br.ReadBytes((Int32)fs.Length);

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        {
            conn.Open();
            string queryStr = "INSERT INTO Clanak (idKolegij, idKategorija, naslov, sadrzaj, attachment, fileName, contentType) VALUES (@idKolegija, @idKategorija, @naslov, @sadrzaj, @attachment, @fileName, @contentType)";
            
            SqlCommand sqlCmd = new SqlCommand(queryStr, conn);
            string kolegij = KolegijiDropDown.SelectedValue;
            string kategorija = KategorijeDropDown.SelectedValue;
            string naslov = naslovClanka.Text.Trim();
            sqlCmd.Parameters.AddWithValue("@idKolegija", kolegij);
            sqlCmd.Parameters.AddWithValue("@idKategorija", kategorija);
            sqlCmd.Parameters.AddWithValue("@naslov", naslov);
            sqlCmd.Parameters.AddWithValue("@sadrzaj", textareaNoviClanak.InnerText);
            sqlCmd.Parameters.AddWithValue("@attachment", bytes);
            sqlCmd.Parameters.AddWithValue("@fileName", filename);
            sqlCmd.Parameters.AddWithValue("@contentType", contentType);
            
            int x = sqlCmd.ExecuteNonQuery();
            if (x > 0)
            {
                
                AddToOtherTable(naslov, kategorija, kolegij, conn);
            }
            else
            {
                infoLabel.Text = "Neuspjeo pokušaj";
            }

        }
    }

    protected void AddToOtherTable(String naslov, String kategorija, String kolegij,  SqlConnection conn)
    {
        string queryString = "SELECT idClanak FROM Clanak WHERE naslov=@naslov AND idKategorija=@idKategorija AND idKolegij=@idKolegij";
        string queryStr2 = "INSERT INTO Student_ureduje_clanak (idClanak, idStudent, datumIzmjene) VALUES (@idClanak, @idStudent, @datum)";
        SqlCommand sqlCmd = new SqlCommand(queryString, conn);
        sqlCmd.Parameters.AddWithValue("@naslov", naslov);
        sqlCmd.Parameters.AddWithValue("@idKategorija", kategorija);
        sqlCmd.Parameters.AddWithValue("@idKolegij", kolegij);
        int IDClanka = Convert.ToInt32(sqlCmd.ExecuteScalar());

        SqlCommand sqlCmd2 = new SqlCommand(queryStr2, conn);
        sqlCmd2.Parameters.AddWithValue("@idClanak", IDClanka);
        sqlCmd2.Parameters.AddWithValue("@idStudent", sesija.UserID);
        DateTime vrijeme = DateTime.Now;
        vrijeme.Date.ToString("s");
        sqlCmd2.Parameters.AddWithValue("@datum", vrijeme);
        int status = sqlCmd2.ExecuteNonQuery();
        if (status > 0)
        {
            infoLabel.Text = "Članak uspješno dodan!";
        }
        else
        {
            infoLabel.Text = "Neuspjeo pokušaj";
        }
    }
}