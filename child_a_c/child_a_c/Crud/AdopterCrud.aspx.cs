using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace Crud
{
    public partial class Adopters_crud : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Con1"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Adopters", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                gvChildren.DataSource = dt;
                gvChildren.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Adopters (first_name, last_name, date_of_birth, address, phone_number, email, marital_status, occupation, education_level) VALUES (@FirstName, @LastName, @DOB, @Address, @PhoneNumber, @Email, @MaritalStatus, @Occupation, @EducationLevel)", con);
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@DOB", txtDateOfBirth.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@MaritalStatus", txtMaritalStatus.Text);
                    cmd.Parameters.AddWithValue("@Occupation", txtOccupation.Text);
                    cmd.Parameters.AddWithValue("@EducationLevel", txtEducationLevel.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                ClearFields();
                BindGrid();
            }
            catch (SqlException ex)
            {
                lblError.Text = "An error occurred while saving the adopter: " + ex.Message;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Adopters SET first_name = @FirstName, last_name = @LastName, date_of_birth = @DOB, address = @Address, phone_number = @PhoneNumber, email = @Email, marital_status = @MaritalStatus, occupation = @Occupation, education_level = @EducationLevel WHERE adopter_id = @AdopterId", con);
                    cmd.Parameters.AddWithValue("@AdopterId", txtAdopterId.Text);
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@DOB", txtDateOfBirth.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@MaritalStatus", txtMaritalStatus.Text);
                    cmd.Parameters.AddWithValue("@Occupation", txtOccupation.Text);
                    cmd.Parameters.AddWithValue("@EducationLevel", txtEducationLevel.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                ClearFields();
                BindGrid();
            }
            catch (SqlException ex)
            {
                lblError.Text = "An error occurred while updating the adopter: " + ex.Message;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Adopters WHERE adopter_id = @AdopterId", con);
                    cmd.Parameters.AddWithValue("@AdopterId", txtAdopterId.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                ClearFields();
                BindGrid();
            }
            catch (SqlException ex)
            {
                lblError.Text = "An error occurred while deleting the adopter: " + ex.Message;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtAdopterId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtDateOfBirth.Text = "";
            txtAddress.Text = "";
            txtPhoneNumber.Text = "";
            txtEmail.Text = "";
            txtMaritalStatus.Text = "";
            txtOccupation.Text = "";
            txtEducationLevel.Text = "";
            lblError.Text = "";
        }

        protected void gvAdopters_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvChildren.SelectedRow;
            txtAdopterId.Text = row.Cells[1].Text; // Assuming AdopterId is in the first column
            txtFirstName.Text = row.Cells[2].Text; // Adjust column indices as necessary
            txtLastName.Text = row.Cells[3].Text;
            txtDateOfBirth.Text = row.Cells[4].Text;
            txtAddress.Text = row.Cells[5].Text;
            txtPhoneNumber.Text = row.Cells[6].Text;
            txtEmail.Text = row.Cells[7].Text;
            txtMaritalStatus.Text = row.Cells[8].Text;
            txtOccupation.Text = row.Cells[9].Text;
            txtEducationLevel.Text = row.Cells[10].Text;
        }
    }
}
