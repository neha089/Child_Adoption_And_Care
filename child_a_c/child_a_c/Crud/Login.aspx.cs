using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                System.Diagnostics.Debug.WriteLine("Connection opened.");

                // Check if Admin
                if (email == "admin@example.com" && password == "admin123")
                {
                    System.Diagnostics.Debug.WriteLine("Admin login detected.");
                    FormsAuthentication.SetAuthCookie(email, false); // Set authentication cookie
                    Response.Redirect("admin_crud.aspx");
                    return;
                }
                else
                {
                    // Check Orphanage
                    string orphanageQuery = "SELECT orphanage_id FROM Orphanages WHERE email=@Email AND password=@Password";
                    using (SqlCommand cmd = new SqlCommand(orphanageQuery, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.NVarChar) { Value = email });
                        cmd.Parameters.Add(new SqlParameter("@Password", System.Data.SqlDbType.NVarChar) { Value = password });

                        System.Diagnostics.Debug.WriteLine("Executing query with Email: " + email + " and Password: " + password);
                        object orphanageId = cmd.ExecuteScalar();

                        if (orphanageId != null)
                        {
                            System.Diagnostics.Debug.WriteLine("Orphanage ID found: " + orphanageId.ToString());

                            // Set an authentication cookie
                            FormsAuthentication.SetAuthCookie(email, false);

                            // Store orphanage ID in session for future use
                            Session["OrphanageID"] = orphanageId.ToString();

                            // Redirect to Orphanage CRUD page
                            Response.Redirect("OrphanageCrud.aspx");
                            return;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("No orphanage found for the provided credentials.");
                            Response.Write("<script>alert('Invalid credentials');</script>");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Exception occurred: " + ex.Message);
            Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
        }

        System.Diagnostics.Debug.WriteLine("Invalid credentials. Login failed.");
        Response.Write("<script>alert('Invalid credentials');</script>");
    }
}
