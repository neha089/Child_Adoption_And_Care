using System;
using System.Configuration;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string email = txtEmail.Text;
        string password = txtPassword.Text;
        string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            // Check if Admin
            if (email == "admin@example.com" && password == "admin123")
            {
                Response.Redirect("AdminPage.aspx");
                return;
            }

            // Check Orphanage
            string orphanageQuery = "SELECT orphanage_id FROM Orphanages WHERE email=@Email AND password=@Password";
            using (SqlCommand cmd = new SqlCommand(orphanageQuery, conn))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                object orphanageId = cmd.ExecuteScalar();
                if (orphanageId != null)
                {
                    Response.Redirect("OrphanagePage.aspx");
                    return;
                }
            }

            // Check Adopter
            string adopterQuery = "SELECT adopter_id FROM Adopters WHERE email=@Email AND password=@Password";
            using (SqlCommand cmd = new SqlCommand(adopterQuery, conn))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                object adopterId = cmd.ExecuteScalar();
                if (adopterId != null)
                {
                    Response.Redirect("AdopterPage.aspx");
                    return;
                }
            }
        }

        // Invalid login
        Response.Write("<script>alert('Invalid credentials');</script>");
    }
}
