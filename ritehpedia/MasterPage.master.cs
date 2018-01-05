using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
public partial class MasterPage : System.Web.UI.MasterPage
{
    public List<MeniItem> Meni { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        Meni = new List<MeniItem>();
        Meni.Add(new MeniItem("Naslovna", "index.aspx"));
        Meni.Add(new MeniItem("About", "about.aspx", true));
        Meni.Add(new MeniItem("Login", "login.aspx"));

        MenuRepeter.DataSource = Meni;
        MenuRepeter.DataBind();
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString);
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT imeKategorije FROM Kategorija", conn);
        DataSet ds = new DataSet();
        adapter.Fill(ds, "imeKategorije");
        dbContent.DataSource = ds.Tables["imeKategorije"].DefaultView;
        dbContent.DataBind();
    }
}
