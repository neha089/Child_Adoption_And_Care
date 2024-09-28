using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace child_a_c.Crud
{
    public partial class AdopterCrud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAdopters();
            }
        }

        private void LoadAdopters()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Adopters", conn);
                conn.Open();
                gvAdopters.DataSource = cmd.ExecuteReader();
                gvAdopters.DataBind();
            }
        }

        protected void gvAdopters_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvAdopters.SelectedRow;
            txtAdopterID.Text = row.Cells[0].Text;
            txtFirstName.Text = row.Cells[1].Text;
            txtLastName.Text = row.Cells[2].Text;
            txtDateOfBirth.Text = Convert.ToDateTime(row.Cells[3].Text).ToString("yyyy-MM-dd");
            txtAddress.Text = row.Cells[4].Text;
            txtPhoneNumber.Text = row.Cells[5].Text;
            txtEmail.Text = row.Cells[6].Text;
            txtMaritalStatus.Text = row.Cells[7].Text;
            txtOccupation.Text = row.Cells[8].Text;
            txtEducationLevel.Text = row.Cells[9].Text;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd;
                if (string.IsNullOrEmpty(txtAdopterID.Text))
                {
                    cmd = new SqlCommand("INSERT INTO Adopters (first_name, last_name, date_of_birth, address, phone_number, email, marital_status, occupation, education_level) VALUES (@FirstName, @LastName, @DateOfBirth, @Address, @PhoneNumber, @Email, @MaritalStatus, @Occupation, @EducationLevel)", conn);
                }
                else
                {
                    cmd = new SqlCommand("UPDATE Adopters SET first_name = @FirstName, last_name = @LastName, date_of_birth = @DateOfBirth, address = @Address, phone_number = @PhoneNumber, email = @Email, marital_status = @MaritalStatus, occupation = @Occupation, education_level = @EducationLevel WHERE adopter_id = @AdopterID", conn);
                    cmd.Parameters.AddWithValue("@AdopterID", txtAdopterID.Text);
                }

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
                LoadAdopters();
            }
        }
    }
}
