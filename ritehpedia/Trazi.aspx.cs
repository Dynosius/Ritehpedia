using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Trazi : System.Web.UI.Page
{
    string trazi;
    string[] separators = { ",", ".", "!", "?", ";", ":", " ", "+", "-" };
    string[] result;
    protected void Page_Load(object sender, EventArgs e)
    {
        trazi = this.Request.QueryString["tag"];
        result = trazi.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        if (trazi != null)
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
            DataSet ds = new DataSet();
            SqlDataAdapter sqlData;

            for(int i=0; i<result.Length; i++)
            {
                string query = "SELECT idClanak, naslov FROM Clanak WHERE tags LIKE '" + result[i] + "' ORDER BY brojPregleda DESC";
                sqlData = new SqlDataAdapter(query, conn);
                sqlData.Fill(ds, "clanci");
            } 
            return ds.Tables["clanci"].DefaultView;
        }
    }
}