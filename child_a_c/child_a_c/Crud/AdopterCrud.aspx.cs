using System;
using System.Data.SqlClient;
using System.Configuration;

namespace child_a_c.Crud
{
    public partial class AdopterCrud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Your code here
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Example SQL command
                string query = "INSERT INTO Adopters (first_name, last_name, date_Of_birth, address, phone_number, email, marital_status, occupation, education_level) VALUES (@FirstName, @LastName, @DateOfBirth, @Address, @PhoneNumber, @Email, @MaritalStatus, @Occupation, @EducationLevel)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@DateOfBirth", txtDateOfBirth.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@MaritalStatus", txtMaritalStatus.Text);
                    cmd.Parameters.AddWithValue("@Occupation", txtOccupation.Text);
                    cmd.Parameters.AddWithValue("@EducationLevel", txtEducationLevel.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        lblMessage.Text = "Successfully submitted!";
                    }
                    else
                    {
                        lblMessage.Text = "Submission failed. Please try again.";
                    }
                }
            }
        }
    }
}
