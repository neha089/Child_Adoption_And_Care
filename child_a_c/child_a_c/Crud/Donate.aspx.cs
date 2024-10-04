using System;
using System.Configuration;
using System.Data.SqlClient;

namespace child_a_c.Crud
{
    public partial class Donate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get orphanage ID from query string
                string orphanageId = Request.QueryString["orphanageId"];
                if (!string.IsNullOrEmpty(orphanageId))
                {
                    // Optionally, you can load orphanage details like name here using the orphanageId
                    LoadOrphanageDetails(orphanageId);
                }
            }
        }

        private void LoadOrphanageDetails(string orphanageId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
            string query = "SELECT name FROM Orphanages WHERE orphanage_id = @OrphanageID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrphanageID", orphanageId);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtOrphanageName.Text = reader["name"].ToString();
                        ViewState["OrphanageID"] = orphanageId; // Store the orphanage ID for later use (e.g., submission)
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string donorName = txtDonorName.Text.Trim();
            string orphanageId = ViewState["OrphanageID"].ToString();
            string donationAmount = txtAmount.Text.Trim();
            string donationType = ddlDonationType.SelectedValue;
            string donationDate = txtDate.Text.Trim();
            string purpose = txtPurpose.Text.Trim();
            string receiptUrl = txtReceiptUrl.Text.Trim();

            // Save the donation details to the database, including the new fields
            SaveDonation(donorName, orphanageId, donationAmount, donationType, donationDate, purpose, receiptUrl);

            Response.Redirect("DonationConfirmation.aspx");
        }

        private void SaveDonation(string donorName, string orphanageId, string donationAmount, string donationType, string donationDate, string purpose, string receiptUrl)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
            string query = "INSERT INTO Donations (donor_name, orphanage_id, amount, donation_type, date, purpose, receipt_url) " +
                           "VALUES (@DonorName, @OrphanageID, @Amount, @DonationType, @DonationDate, @Purpose, @ReceiptUrl)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DonorName", donorName);
                    cmd.Parameters.AddWithValue("@OrphanageID", orphanageId);
                    cmd.Parameters.AddWithValue("@Amount", donationAmount);
                    cmd.Parameters.AddWithValue("@DonationType", donationType);
                    cmd.Parameters.AddWithValue("@DonationDate", donationDate);
                    cmd.Parameters.AddWithValue("@Purpose", purpose);
                    cmd.Parameters.AddWithValue("@ReceiptUrl", receiptUrl);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
