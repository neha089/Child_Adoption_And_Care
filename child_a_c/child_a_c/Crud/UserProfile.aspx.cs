using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace child_a_c.Crud
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserProfile();
            }
        }

        private void LoadUserProfile()
        {
            // Assuming you have a way to get the logged-in adopter's ID (e.g., from session)
            int adopterId = GetLoggedAdopterId();

            // Fetch user details from the database
            string connectionString = WebConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Adopters WHERE adopter_id = @adopterId", con);
                cmd.Parameters.AddWithValue("@adopterId", adopterId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtFirstName.Text = reader["first_name"].ToString();
                    txtLastName.Text = reader["last_name"].ToString();
                    txtEmail.Text = reader["email"].ToString();
                    txtPhoneNumber.Text = reader["phone_number"].ToString();
                    txtAddress.Text = reader["address"].ToString();
                    txtDOB.Text = Convert.ToDateTime(reader["date_of_birth"]).ToString("yyyy-MM-dd");
                }
            }
        }

        protected void UpdateProfile(object sender, EventArgs e)
        {
            int adopterId = GetLoggedAdopterId();

            string connectionString = WebConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Adopters SET first_name = @firstName, last_name = @lastName, email = @email, phone_number = @phone, address = @address, date_of_birth = @dob WHERE adopter_id = @adopterId", con);
                cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@lastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhoneNumber.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@dob", txtDOB.Text);
                cmd.Parameters.AddWithValue("@adopterId", adopterId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            // Optionally, redirect back or show a success message
        }

        private int GetLoggedAdopterId()
        {
            // Example: Retrieve adopter ID from session or some other method
            return Convert.ToInt32(Session["AdopterId"]);
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            // Redirect to the previous page or a specific page
            Response.Redirect("AdopterCrud.aspx"); // Replace "PreviousPage.aspx" with the actual page name
        }
    }
}
