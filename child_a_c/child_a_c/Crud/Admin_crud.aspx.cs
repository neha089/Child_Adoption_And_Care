using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace child_a_c.Crud
{
    public partial class Adopters : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAdmins();
            }
        }

        private void LoadAdmins()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Admins", conn);
                conn.Open();
                gvAdmins.DataSource = cmd.ExecuteReader();
                gvAdmins.DataBind();
            }
        }

        protected void gvAdmins_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvAdmins.SelectedRow;
            txtAdminID.Text = row.Cells[0].Text;
            txtUsername.Text = row.Cells[1].Text;
            txtEmail.Text = row.Cells[2].Text;
            txtRole.Text = row.Cells[3].Text;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Admins (username, password, first_name, last_name, email, phone_number, role, status) VALUES (@Username, @Password, @FirstName, @LastName, @Email, @PhoneNumber, @Role, @Status)", conn);

                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                cmd.Parameters.AddWithValue("@Role", txtRole.Text);
                cmd.Parameters.AddWithValue("@Status", txtStatus.Text);

                conn.Open();
                cmd.ExecuteNonQuery(); // Save data
                LoadAdmins(); // Reload admin list
            }
        }


    }
}
