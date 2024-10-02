using System;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Web.UI.WebControls;

namespace child_a_c.Crud
{
    public partial class ApplicationRecords : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int orphanageId = Convert.ToInt32(Request.QueryString["orphanage_id"]);
                int childId = Convert.ToInt32(Request.QueryString["child_id"]);
                int adopterId = GetAdopterId(); // Fetch the adopter ID as needed

                // Load orphanage and child IDs
                lblOrphanageId.Text = orphanageId.ToString();
                lblChildId.Text = childId.ToString();
                txtApplicationDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                // Load adopter details
                LoadAdopterDetails(adopterId);
            }
        }

        private int GetAdopterId()
        {
            if (Session["AdopterID"] != null)
            {
                return Convert.ToInt32(Session["AdopterID"]);
            }
            else
            {
                Response.Redirect("Login.aspx");
                return 0;
            }
        }

        private void LoadAdopterDetails(int adopterId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT first_name, last_name, email, phone_number FROM Adopters WHERE adopter_id = @adopter_id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@adopter_id", adopterId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lblAdopterName.Text = $"{reader["first_name"]} {reader["last_name"]}";
                    lblAdopterEmail.Text = reader["email"].ToString();
                    lblAdopterPhone.Text = reader["phone_number"].ToString();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int orphanageId = Convert.ToInt32(lblOrphanageId.Text);
            int childId = Convert.ToInt32(lblChildId.Text);
            int adopterId = GetAdopterId();
            DateTime applicationDate = DateTime.Now;

            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Insert application record into the ApplicationRecords table
                string applicationQuery = "INSERT INTO ApplicationRecords (adopter_id, orphanage_id, child_id, application_date, status) " +
                                          "VALUES (@adopter_id, @orphanage_id, @child_id, @application_date, @status)";
                SqlCommand cmd = new SqlCommand(applicationQuery, conn);
                cmd.Parameters.AddWithValue("@adopter_id", adopterId);
                cmd.Parameters.AddWithValue("@orphanage_id", orphanageId);
                cmd.Parameters.AddWithValue("@child_id", childId);
                cmd.Parameters.AddWithValue("@application_date", applicationDate);
                cmd.Parameters.AddWithValue("@status", "Pending");

                conn.Open();
                cmd.ExecuteNonQuery();

                // Upload and store documents
                SaveDocument(fuPersonalImage, adopterId, "Personal Image", conn);
                SaveDocument(fuIdProof, adopterId, "ID Proof", conn);
                SaveDocument(fuBirthCertificate, adopterId, "Birth Certificate", conn);
                SaveDocument(fuIncomeCertificate, adopterId, "Income Certificate", conn);
                SaveDocument(fuCasteCertificate, adopterId, "Caste Certificate", conn);
            }

            lblSuccessMessage.Text = "Application and documents submitted successfully!";
            lblSuccessMessage.Visible = true;
        }

        private void SaveDocument(FileUpload fileUpload, int adopterId, string documentType, SqlConnection conn)
        {
            if (fileUpload.HasFile)
            {
                string folderPath = Server.MapPath("~/Document/");

                // Check if the directory exists; if not, create it
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Create the full path to save the uploaded file
                string fileName = Path.GetFileName(fileUpload.FileName);
                string uploadPath = Path.Combine(folderPath, fileName);

                // Save the file to the server
                fileUpload.SaveAs(uploadPath);
                // Insert document details into the AdopterDocuments table
                string documentQuery = "INSERT INTO AdopterDocuments (adopter_id, document_type, document_name, document_url, upload_date) " +
                                       "VALUES (@adopter_id, @document_type, @document_name, @document_url, @upload_date)";
                SqlCommand cmd = new SqlCommand(documentQuery, conn);
                cmd.Parameters.AddWithValue("@adopter_id", adopterId);
                cmd.Parameters.AddWithValue("@document_type", documentType);
                cmd.Parameters.AddWithValue("@document_name", fileName);
                cmd.Parameters.AddWithValue("@document_url", uploadPath);
                cmd.Parameters.AddWithValue("@upload_date", DateTime.Now);

                cmd.ExecuteNonQuery();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdopterCrud.aspx");
        }
    }
}
