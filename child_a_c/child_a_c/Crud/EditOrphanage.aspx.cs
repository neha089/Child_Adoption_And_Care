using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace child_a_c.Crud
{
    public partial class EditOrphanage : Page
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOrphanageDetails();
            }
        }

        private void LoadOrphanageDetails()
        {
            // Retrieve orphanage details from Session
            lblEmail.Text = Session["OrphanageEmail"]?.ToString() ?? "N/A";
            txtName.Text = Session["OrphanageName"]?.ToString() ?? string.Empty;
            txtAddress.Text = Session["OrphanageAddress"]?.ToString() ?? string.Empty;
            txtPhoneNumber.Text = Session["OrphanagePhone"]?.ToString() ?? string.Empty;
            txtContactPerson.Text = Session["OrphanageContactPerson"]?.ToString() ?? string.Empty;
            txtCapacity.Text = Session["OrphanageCapacity"]?.ToString() ?? string.Empty;
            txtNumberOfChildren.Text = Session["OrphanageNumberOfChildren"]?.ToString() ?? string.Empty;
            txtLicenseNumber.Text = Session["OrphanageLicenseNumber"]?.ToString() ?? string.Empty;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var email = Session["OrphanageEmail"]?.ToString();
            if (string.IsNullOrEmpty(email))
            {
                return; // You may want to show an error message here
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Orphanages SET name = @Name, address = @Address, phone_number = @PhoneNumber, contact_person = @ContactPerson, capacity = @Capacity, number_of_children = @NumberOfChildren, license_number = @LicenseNumber WHERE email = @Email", conn);

                    // Add parameters
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                    cmd.Parameters.AddWithValue("@ContactPerson", txtContactPerson.Text);
                    cmd.Parameters.AddWithValue("@Capacity", int.Parse(txtCapacity.Text)); // Ensure proper type conversion
                    cmd.Parameters.AddWithValue("@NumberOfChildren", int.Parse(txtNumberOfChildren.Text)); // Ensure proper type conversion
                    cmd.Parameters.AddWithValue("@LicenseNumber", txtLicenseNumber.Text);

                    // Execute the update
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Update session variables with the new values
                        Session["OrphanageName"] = txtName.Text;
                        Session["OrphanageAddress"] = txtAddress.Text;
                        Session["OrphanagePhone"] = txtPhoneNumber.Text;
                        Session["OrphanageContactPerson"] = txtContactPerson.Text;
                        Session["OrphanageCapacity"] = txtCapacity.Text;
                        Session["OrphanageNumberOfChildren"] = txtNumberOfChildren.Text;
                        Session["OrphanageLicenseNumber"] = txtLicenseNumber.Text;

                        Response.Redirect("OrphanProfile.aspx");
                    }
                    else
                    {
                        // Optionally inform the user that no rows were updated
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log error, show message)
            }
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrphanProfile.aspx"); // Redirect back to the profile page
        }
    }
}
