using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Clanak : System.Web.UI.Page
{
    string idClanka;
    protected void Page_Load(object sender, EventArgs e)
    {
        idClanka = this.Request.QueryString["idClanak"];
        if (idClanka != null)
        {
            clanakLabel.Text = whatQueryReturns();
        }

    }

    protected string whatQueryReturns()
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        {
            conn.Open();
            string query, result = "";
            query = "SELECT sadrzaj FROM Clanak WHERE idClanak =" + idClanka;
            SqlCommand sqlCmd = new SqlCommand(query, conn);
            SqlDataReader sqlRead = sqlCmd.ExecuteReader();
            if (sqlRead.HasRows)
            {
                while (sqlRead.Read())
                {
                    result = sqlRead.GetString(0);
                }
            }
            sqlRead.Close();
            return result;
        }
    }
}