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
        LinkButton1.Visible = false;
        //prikaz clanka
        if (idClanka != null)
        {
            naslovLabel.Text = WhatQueryReturns("naslov");
            clanakLabel.Text = WhatQueryReturns("sadrzaj");
            brPregledaLabel.Text = "Broj pregleda: " + VratiBrojPregleda();
            downloadLabel.Text = AttachmentName(); //prikaz attachment
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

    protected string WhatQueryReturns(string what)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        {
            conn.Open();
            string query, result = "";
            query = "SELECT " + what + " FROM Clanak WHERE idClanak =" + idClanka;
            SqlCommand sqlCmd = new SqlCommand(query, conn);
            SqlDataReader sqlRead = sqlCmd.ExecuteReader();
            if (sqlRead.HasRows)
            {
                while (sqlRead.Read())
                {
                    if (sqlRead.IsDBNull(sqlRead.GetOrdinal(what))) { return ""; }
                    result = sqlRead.GetString(0);
                }
            }
            sqlRead.Close();
            return result;
        }
    }

    protected string AttachmentName()
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        {
            conn.Open();
            string query, result = "";
            query = "SELECT fileName FROM Clanak WHERE idClanak =" + idClanka;
            SqlCommand sqlCmd = new SqlCommand(query, conn);
            SqlDataReader sqlRead = sqlCmd.ExecuteReader();
            if (sqlRead == null) { return ""; }
            if (sqlRead.HasRows)
            {
                while (sqlRead.Read())
                {
                    if (sqlRead.IsDBNull(sqlRead.GetOrdinal("fileName"))) { return ""; }
                    result = sqlRead.GetString(0);
                }
            }
            sqlRead.Close();
            //prikaz download
            if (result != "") { LinkButton1.Visible = true; }
            return result;
        }
    }

    protected string VratiBrojPregleda()
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        {
            conn.Open();
            string query;
            int result = 0;
            query = "SELECT brojPregleda FROM Clanak WHERE idClanak =" + idClanka;
            SqlCommand sqlCmd = new SqlCommand(query, conn);
            SqlDataReader sqlRead = sqlCmd.ExecuteReader();
            if (sqlRead == null) { return ""; }
            if (sqlRead.HasRows)
            {
                while (sqlRead.Read())
                {
                    if (sqlRead.IsDBNull(sqlRead.GetOrdinal("brojPregleda"))) { return "0"; }
                    result = sqlRead.GetInt16(0);
                }
            }
            sqlRead.Close();
            return result.ToString();
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

    protected void DownloadFile(object sender, EventArgs e)
    {
        byte[] bytes;
        string fileName, contentType;
        string constr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select fileName, attachment, contentType from Clanak where idClanak=@idClanak";
                cmd.Parameters.AddWithValue("@idClanak", idClanka);
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    bytes = (byte[])sdr["attachment"];
                    contentType = sdr["contentType"].ToString();
                    fileName = sdr["fileName"].ToString();
                }
                con.Close();
            }
        }
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = contentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();
    }
}