using System;
using System.Data.SqlClient;
using System.Configuration;

namespace child_a_c.Crud
{
    public partial class AdopterCrud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Your code here (if needed)
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // SQL command to insert data into the Adopters table
                string query = "INSERT INTO Adopters (first_name, last_name, date_of_birth, address, phone_number, email, marital_status, occupation, education_level) " +
                               "VALUES (@FirstName, @LastName, @DateOfBirth, @Address, @PhoneNumber, @Email, @MaritalStatus, @Occupation, @EducationLevel)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Adding parameters from text boxes
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@DateOfBirth", txtDateOfBirth.Text); // Ensure the date is in a valid format
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@MaritalStatus", txtMaritalStatus.Text);
                    cmd.Parameters.AddWithValue("@Occupation", txtOccupation.Text);
                    cmd.Parameters.AddWithValue("@EducationLevel", txtEducationLevel.Text);

                    conn.Open();

                    // Execute the command and store the number of affected rows
                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    // Check if rows were affected
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
