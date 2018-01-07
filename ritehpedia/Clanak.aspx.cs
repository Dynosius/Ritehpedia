using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Clanak : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string idClanak = Request.QueryString["ID"];

        SqlConnection sqlConnection1 = new SqlConnection("ritehpediaConnectionString");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;

        cmd.CommandText = "SELECT * FROM Clanak WHERE (idClanak = @idClanak)";
        cmd.CommandType = CommandType.Text;
        cmd.Connection = sqlConnection1;

        sqlConnection1.Open();
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Naslov.InnerHtml = reader.GetString(3);
            Sadrzaj.InnerHtml = reader.GetString(4);
            BrPregleda.InnerHtml = "Broj pregleda: " + (reader.GetInt16(1)).ToString();
        }
        
        sqlConnection1.Close();

    }
}