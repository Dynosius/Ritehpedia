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
    string idKolegija;
    UserSession sesija;
    bool checkIfOwner = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        sesija = Session["User"] as UserSession;
        idClanka = this.Request.QueryString["idClanak"];
        if (idClanka != null)
        {
            clanakLabel.Text = WhatQueryReturns();
        }
        idKolegija = this.Request.QueryString["idKolegija"];
        if (idKolegija == null)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
            {
                conn.Open();
                string queryStr = "SELECT idStudent FROM Student_ureduje_clanak WHERE idClanak=@clanak";
                SqlCommand sqlCmd = new SqlCommand(queryStr, conn);
                sqlCmd.Parameters.AddWithValue("@clanak", idClanka);
                SqlDataReader read = sqlCmd.ExecuteReader();
                while (read.Read())
                {
                    if (read.GetInt32(0) == sesija.UserID)
                    {
                        DeleteButton.Visible = true;
                    }
                }
            }
        }
        else
        {
            DeleteButton.Visible = false;
        }
    }

    protected string WhatQueryReturns()
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

    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        {
            conn.Open();
            string deleteFromSUC = "DELETE FROM Student_ureduje_clanak WHERE idClanak=@idClanak; DELETE FROM Clanak WHERE idClanak=@idClanak";
            SqlCommand sqlCmd = new SqlCommand(deleteFromSUC, conn);
            sqlCmd.Parameters.AddWithValue("@idClanak", idClanka);
            int x = sqlCmd.ExecuteNonQuery();
            if (x > 0)
            {
                clanakLabel.Text = "Uspješno izbrisano!";
            }
        }
    }
}