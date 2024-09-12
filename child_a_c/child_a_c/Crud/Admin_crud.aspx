using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace YourNamespace
{
    public partial class Adopters : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Adopters (first_name, last_name, date_of_birth, address, phone_number, email, marital_status, occupation, education_level) VALUES (@FirstName, @LastName, @DOB, @Address, @Phone, @Email, @MaritalStatus, @Occupation, @Education)", con);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(txtDateOfBirth.Text));
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhoneNumber.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@MaritalStatus", txtMaritalStatus.Text);
                cmd.Parameters.AddWithValue("@Occupation", txtOccupation.Text);
                cmd.Parameters.AddWithValue("@Education", txtEducationLevel.Text);

                cmd.ExecuteNonQuery();
                BindGridView();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Adopters SET first_name=@FirstName, last_name=@LastName, date_of_birth=@DOB, address=@Address, phone_number=@Phone, email=@Email, marital_status=@MaritalStatus, occupation=@Occupation, education_level=@Education WHERE adopter_id=@AdopterID", con);
                cmd.Parameters.AddWithValue("@AdopterID", Convert.ToInt32(txtAdopterId.Text));
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(txtDateOfBirth.Text));
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhoneNumber.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@MaritalStatus", txtMaritalStatus.Text);
                cmd.Parameters.AddWithValue("@Occupation", txtOccupation.Text);
                cmd.Parameters.AddWithValue("@Education", txtEducationLevel.Text);

                cmd.ExecuteNonQuery();
                BindGridView();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Adopters WHERE adopter_id=@AdopterID", con);
                cmd.Parameters.AddWithValue("@AdopterID", Convert.ToInt32(txtAdopterId.Text));
                cmd.ExecuteNonQuery();
                BindGridView();
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
        }

        private void BindGridView()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Adopters", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                gvAdopters.DataSource = dt;
                gvAdopters.DataBind();
            }
        }

        protected void gvAdopters_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvAdopters.SelectedRow;
            txtAdopterId.Text = row.Cells[1].Text;
            txtFirstName.Text = row.Cells[2].Text;
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
