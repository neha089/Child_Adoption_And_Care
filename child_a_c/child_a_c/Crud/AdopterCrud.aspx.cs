    using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace CAC.Crud
{
    public partial class adopters_crud : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Con_Db1"].ConnectionString;

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
                GridViewAdopters.DataSource = dt;
                GridViewAdopters.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Adopters (first_name, last_name, date_of_birth, address, phone_number, email, marital_status, occupation, education_level) VALUES (@FirstName, @LastName, @DOB, @Address, @PhoneNumber, @Email, @MaritalStatus, @Occupation, @EducationLevel)", con);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@DOB", txtDOB.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@MaritalStatus", txtMaritalStatus.Text);
                cmd.Parameters.AddWithValue("@Occupation", txtOccupation.Text);
                cmd.Parameters.AddWithValue("@EducationLevel", txtEducationLevel.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                BindGrid();
            }
        }

        protected void GridViewAdopters_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            GridViewAdopters.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridViewAdopters_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GridViewAdopters.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = GridViewAdopters.Rows[e.RowIndex];

            // Use FindControl to get the TextBox from the TemplateField
            TextBox txtFirstName = (TextBox)row.FindControl("txtFirstName");
            TextBox txtLastName = (TextBox)row.FindControl("txtLastName");

            if (txtFirstName != null && txtLastName != null)
            {
                string firstName = txtFirstName.Text;
                string lastName = txtLastName.Text;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Adopters SET first_name=@FirstName, last_name=@LastName WHERE adopter_id=@Id", con);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    GridViewAdopters.EditIndex = -1;
                    BindGrid();
                }
            }
        }


        protected void GridViewAdopters_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridViewAdopters.DataKeys[e.RowIndex].Value.ToString());
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Adopters WHERE adopter_id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
            }
        }

        protected void GridViewAdopters_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            GridViewAdopters.EditIndex = -1;
            BindGrid();
        }
    }
}
