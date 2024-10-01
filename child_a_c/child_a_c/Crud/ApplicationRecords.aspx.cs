using System;
using System.Data.SqlClient;
using System.Configuration;

namespace child_a_c.Crud
{
    public partial class ApplicationRecords : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // No need to load records on page load as GridView has been removed
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd;
                if (string.IsNullOrEmpty(txtAdopterID.Text))
                {
                    lblMessage.Text = "Please provide an Adopter ID.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                cmd = new SqlCommand("INSERT INTO ApplicationRecords (adopter_id, orphanage_id, child_id, application_date, status) VALUES (@AdopterID, @OrphanageID, @ChildID, @ApplicationDate, @Status)", conn);

                cmd.Parameters.AddWithValue("@AdopterID", txtAdopterID.Text);
                cmd.Parameters.AddWithValue("@OrphanageID", txtOrphanageID.Text);
                cmd.Parameters.AddWithValue("@ChildID", txtChildID.Text);
                cmd.Parameters.AddWithValue("@ApplicationDate", DateTime.Parse(txtApplicationDate.Text));
                cmd.Parameters.AddWithValue("@Status", txtStatus.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                lblMessage.Text = "Application record saved successfully!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
        }
    }
}
