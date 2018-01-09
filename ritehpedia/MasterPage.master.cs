using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    private int idKolegijaIzURL;
    UserSession sesija;
    protected void Page_Load(object sender, EventArgs e)
    {
        idKolegijaIzURL = Convert.ToInt32(this.Request.QueryString["idKolegija"]);
        sesija = Session["User"] as UserSession;

        List<MeniItem> meni = new List<MeniItem>();
        meni.Add(new MeniItem("Naslovna", "index.aspx"));
        meni.Add(new MeniItem("About", "about.aspx", true));

        if (sesija == null)
        {
            meni.Add(new MeniItem("Login", "login.aspx"));
        }
        meni.Add(new MeniItem("Vijesti", "vijesti.aspx"));
        meni.Add(new MeniItem("Kontakti", "kontakt.aspx"));
        MenuRepeter.DataSource = meni;
        MenuRepeter.DataBind();

        if (sesija != null)
        {
            imeStudija.Text = sesija.StudijIme + " - " + sesija.Username;

            string tableName = "imeKolegija";
            DataSet ds = LoadDataFromDB("SELECT KO.idKolegij, imeKolegija, Semestar FROM Kolegij KO INNER JOIN Studij_Kolegij SK ON SK.idKolegij = KO.idKolegij " +
                "where SK.idStudij = " + sesija.StudijID + " ORDER BY Semestar, KO.idKolegij", tableName);
            dbContent.DataSource = ds.Tables[tableName].DefaultView;
            dbContent.DataBind();

            ProfileBtn.Visible = true;
            NoviClanakBtn.Visible = true;
        }

    }

    public DataSet LoadDataFromDB(string query, string tablename)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, tablename);
            return ds;
        }
    }

    protected void dbContent_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView row = (DataRowView)e.Item.DataItem;
            int idKolegijIzRetka = Convert.ToInt32(row.Row.ItemArray[0]);
            if (idKolegijIzRetka == idKolegijaIzURL)
            {
                Repeater kategorijaRepeater = e.Item.FindControl("KategorijaRepeater") as Repeater;
                if (kategorijaRepeater != null)
                {
                    string tableName = "imeKategorije";
                    DataSet ds = LoadDataFromDB("SELECT idKategorija, imeKategorije, " + idKolegijaIzURL + " AS idKolegija FROM Kategorija ORDER BY idKategorija", tableName);
                    DataView kategorije = ds.Tables[tableName].DefaultView;
                    kategorijaRepeater.DataSource = kategorije;
                    kategorijaRepeater.DataBind();
                }
            }
        }
    }

    protected void profilClicked(object sender, EventArgs e)
    {
        Response.Redirect("profil.aspx");
    }

    protected void NoviClanakBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("NoviClanak.aspx");
    }
}
