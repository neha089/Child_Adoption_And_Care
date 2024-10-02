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

                // Check Orphanage
                string orphanageQuery = "SELECT orphanage_id, name, address, phone_number, email, contact_person, capacity, number_of_children, license_number FROM Orphanages WHERE email=@Email AND password=@Password";
                using (SqlCommand cmd = new SqlCommand(orphanageQuery, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.NVarChar) { Value = email });
                    cmd.Parameters.Add(new SqlParameter("@Password", System.Data.SqlDbType.NVarChar) { Value = password });

                    System.Diagnostics.Debug.WriteLine("Executing query for Orphanage with Email: " + email);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        System.Diagnostics.Debug.WriteLine("Orphanage ID found: " + reader["orphanage_id"].ToString());
                        FormsAuthentication.SetAuthCookie(email, false);
                        Session["OrphanageID"] = reader["orphanage_id"].ToString();
                        Session["OrphanageName"] = reader["name"].ToString();
                        Session["OrphanageAddress"] = reader["address"].ToString();
                        Session["OrphanagePhone"] = reader["phone_number"].ToString();
                        Session["OrphanageEmail"] = reader["email"].ToString();
                        Session["OrphanageContactPerson"] = reader["contact_person"].ToString();
                        Session["OrphanageCapacity"] = reader["capacity"].ToString();
                        Session["OrphanageNumberOfChildren"] = reader["number_of_children"].ToString();
                        Session["OrphanageLicenseNumber"] = reader["license_number"].ToString();

                        Response.Redirect("OrphanageDashboard.aspx");
                        return;
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("No orphanage found for the provided credentials.");
                    }
                }

                // Check Adopter
                string adopterQuery = "SELECT adopter_id FROM Adopters WHERE email=@Email AND password=@Password";
                using (SqlCommand cmd = new SqlCommand(adopterQuery, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.NVarChar) { Value = email });
                    cmd.Parameters.Add(new SqlParameter("@Password", System.Data.SqlDbType.NVarChar) { Value = password });

                    System.Diagnostics.Debug.WriteLine("Executing query for Adopter with Email: " + email);
                    object adopterId = cmd.ExecuteScalar();

                    if (adopterId != null)
                    {
                        System.Diagnostics.Debug.WriteLine("Adopter ID found: " + adopterId.ToString());
                        FormsAuthentication.SetAuthCookie(email, false);
                        Session["AdopterID"] = adopterId.ToString(); // Store Adopter ID in session
                        Response.Redirect("AdopterCrud.aspx");
                        return;
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("No adopter found for the provided credentials.");
                    }
                }

                // If no valid credentials were found
                Response.Write("<script>alert('Invalid credentials');</script>");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Exception occurred: " + ex.Message);
            Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
        }

        System.Diagnostics.Debug.WriteLine("Invalid credentials. Login failed.");
    }
}
