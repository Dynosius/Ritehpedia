using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Admin_AdminPage : System.Web.UI.Page
{
    private string KI_old;
    //DataSet dsRoles, dsUsers;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserSession.IsAdmin(Session))
        {
            if (!IsPostBack)
            {
                DisplayRolesInGrid();
                DisplayUsersTable();
            }
            
        }
        else
        {
            Response.Redirect("index.aspx");
        }
    }


    protected void CreateRoleButton_Click1(object sender, EventArgs e)
    {
        string newRoleName = RoleName.Text.Trim();

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        {
            conn.Open();
            string query = "INSERT INTO Uloge (uloga) VALUES ('" + newRoleName.Trim() + "')";
            SqlCommand sqlCmd = new SqlCommand(query, conn);
            int x = sqlCmd.ExecuteNonQuery();
            if (x > 0)
            {
                StatusLabel.Text = "Uspješno dodali ulogu '" + newRoleName + "'";
            }
            else
            {
                StatusLabel.Text = "Greška u dodavanju uloge";
            }
        }
        DisplayRolesInGrid();
        DisplayUsersTable();
    }

    private void DisplayRolesInGrid()
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        {
            conn.Open();
            string query = "SELECT uloga FROM Uloge ORDER BY ulogaID OFFSET 1 ROWS";
            SqlCommand sqlCmd = new SqlCommand(query, conn);
            DataSet dsRoles = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
            adapter.Fill(dsRoles, "roles");
            RoleList.DataSource = dsRoles;
            RoleList.DataBind();
            ViewState["dsRoles"] = dsRoles;
        }
    }
    private void DisplayUsersTable()
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        {
            conn.Open();
            string query = "SELECT Korisnicko_ime, UlogaID, Email, Ime, Prezime, idStudij, Adresa, Grad, Datum_rod FROM Student";
            SqlCommand sqlCmd = new SqlCommand(query, conn);
            DataSet dsUsers = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
            adapter.Fill(dsUsers, "roles");
            UserListGridView.DataSource = dsUsers;
            UserListGridView.DataBind();
            ViewState["dsUsers"] = dsUsers;
        }
        //RoleList.HeaderRow.Cells[0].Text = "Uloge";
    }
    protected void RoleList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label RoleNameLabel = RoleList.Rows[e.RowIndex].FindControl("RoleNameLabel") as Label;
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        {
            conn.Open();
            string query = "DELETE FROM Uloge WHERE uloga='" + RoleNameLabel.Text.Trim() + "'";
            SqlCommand sqlCmd = new SqlCommand(query, conn);
            sqlCmd.ExecuteNonQuery();
            DisplayRolesInGrid();
        }
    }

    protected void UserListGridView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.UserListGridView.EditIndex = e.NewEditIndex;
        this.UserListGridView.DataSource = ViewState["dsUsers"];
        this.UserListGridView.DataBind();
        DisplayUsersTable();
        DisplayRolesInGrid();
    }
   
    protected void UserListGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var oldValues = ViewState["dsUsers"];
        var oldUsername = ((DataSet)oldValues).Tables[0].Rows[0].ItemArray[0].ToString();
        var newValues = e.NewValues;
        //var a = newValues[0];
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString))
        {
            conn.Open();
            string query = "UPDATE Student SET Korisnicko_ime=@KI, UlogaID=@ulogaid, Email=@email, Ime=@ime, Prezime=@prezime, idStudij=@idstudij, Adresa=@adresa, Grad=@grad WHERE Korisnicko_ime = @KI_old";
            //string query = "UPDATE Student SET Korisnicko_ime=@KI WHERE Korisnicko_ime = @KI_old";
            SqlCommand sqlCmd = new SqlCommand(query, conn);
            //sqlCmd.Parameters.Add("@KI", SqlDbType.NVarChar);
            //sqlCmd.Parameters["@KI"].Value = newValues[0];
            sqlCmd.Parameters.AddWithValue("@KI", newValues[0]);
            sqlCmd.Parameters.Add("@ulogaid", SqlDbType.TinyInt);
            sqlCmd.Parameters["@ulogaid"].Value = Convert.ToByte(newValues[1]);
            sqlCmd.Parameters.AddWithValue("@email", newValues[2]);
            sqlCmd.Parameters.AddWithValue("@ime", newValues[3]);
            sqlCmd.Parameters.AddWithValue("@prezime", newValues[4]);
            sqlCmd.Parameters.AddWithValue("@idstudij", Convert.ToInt16(newValues[5]));
            sqlCmd.Parameters.AddWithValue("@adresa", newValues[6]);
            sqlCmd.Parameters.AddWithValue("@grad", newValues[7]);
            sqlCmd.Parameters.AddWithValue("@datum", newValues[8]);
            sqlCmd.Parameters.AddWithValue("@KI_old", oldUsername);
            //sqlCmd.Parameters.Add("@KI_old", SqlDbType.NVarChar);
            //sqlCmd.Parameters["@KI_old"].Value = oldUsername;
            int x = sqlCmd.ExecuteNonQuery();
            if (x > 0)
            {
                
            }
        }
        this.UserListGridView.EditIndex = -1;
        this.DataBind();
        DisplayUsersTable();
        DisplayRolesInGrid();
    }

    protected void UserListGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        this.UserListGridView.EditIndex = -1;
        this.UserListGridView.DataSource = ViewState["dsUsers"];
        this.DataBind();
        DisplayUsersTable();
        DisplayRolesInGrid();
    }

}