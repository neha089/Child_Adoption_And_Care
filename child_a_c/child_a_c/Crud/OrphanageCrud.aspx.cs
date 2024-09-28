using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace child_a_c.Crud
{
    public partial class OrphanageCrud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOrphanages();
            }
        }

        private void LoadOrphanages()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Orphanages", conn);
                conn.Open();
                gvOrphanages.DataSource = cmd.ExecuteReader();
                gvOrphanages.DataBind();
            }
        }

        protected void gvOrphanages_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvOrphanages.SelectedRow;
            txtOrphanageID.Text = row.Cells[0].Text;
            txtName.Text = row.Cells[1].Text;
            txtAddress.Text = row.Cells[2].Text;
            txtPhoneNumber.Text = row.Cells[3].Text;
            txtEmail.Text = row.Cells[4].Text;
            txtContactPerson.Text = row.Cells[5].Text;
            txtCapacity.Text = row.Cells[6].Text;
            txtNumberOfChildren.Text = row.Cells[7].Text;
            txtLicenseNumber.Text = row.Cells[8].Text;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd;
                if (string.IsNullOrEmpty(txtOrphanageID.Text))
                {
                    cmd = new SqlCommand("INSERT INTO Orphanages (name, address, phone_number, email, contact_person, capacity, number_of_children, license_number) VALUES (@Name, @Address, @PhoneNumber, @Email, @ContactPerson, @Capacity, @NumberOfChildren, @LicenseNumber)", conn);
                }
                else
                {
                    cmd = new SqlCommand("UPDATE Orphanages SET name = @Name, address = @Address, phone_number = @PhoneNumber, email = @Email, contact_person = @ContactPerson, capacity = @Capacity, number_of_children = @NumberOfChildren, license_number = @LicenseNumber WHERE orphanage_id = @OrphanageID", conn);
                    cmd.Parameters.AddWithValue("@OrphanageID", txtOrphanageID.Text);
                }

                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@ContactPerson", txtContactPerson.Text);
                cmd.Parameters.AddWithValue("@Capacity", txtCapacity.Text);
                cmd.Parameters.AddWithValue("@NumberOfChildren", txtNumberOfChildren.Text);
                cmd.Parameters.AddWithValue("@LicenseNumber", txtLicenseNumber.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                LoadOrphanages();
            }
        }
    }
}
