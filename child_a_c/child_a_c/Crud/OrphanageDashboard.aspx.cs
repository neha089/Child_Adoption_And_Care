using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using System.IO;

namespace child_a_c.Crud
{
    public partial class OrphanageDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if session exists
                if (Session["OrphanageID"] == null)
                {
                    // Redirect to login page if session is null
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    string orphanageId = Session["OrphanageID"]?.ToString();

                    DisplayTotalDonations(orphanageId);
                    LoadOrphanageImages(orphanageId);

                    // Load application records
                    LoadApplicationRecords();
                }
            }
        }
        private void DisplayTotalDonations(string orphanageId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ISNULL(SUM(amount), 0) AS TotalDonations FROM Donations WHERE orphanage_id = @orphanageId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@orphanageId", orphanageId);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    decimal totalDonations = (result != null) ? Convert.ToDecimal(result) : 0;

                    // Use InnerText instead of Text for HtmlGenericControl
                    lblTotalDonations.Text = $"Total Donations: ${totalDonations}";
                }
                catch (Exception ex)
                {
                    lblTotalDonations.Text = "Error fetching total donations.";
                }
            }
        }
        private void LoadOrphanageImages(string orphanageId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT image_url, description FROM Images WHERE related_orphanage_id = @orphanageId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@orphanageId", orphanageId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                rptOrphanageImages.DataSource = dt;
                rptOrphanageImages.DataBind();
            }
        }
        private void LoadApplicationRecords()
        {
            string orphanageId = Session["OrphanageID"]?.ToString();
            if (string.IsNullOrEmpty(orphanageId))
            {
                lblErrorMessage.Text = "Orphanage ID not found.";
                lblErrorMessage.Visible = true;
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT ar.application_id, 
                                        a.first_name + ' ' + a.last_name AS adopter_name, 
                                        ar.child_id, 
                                        ar.application_date, 
                                        ar.status
                                 FROM ApplicationRecords ar
                                 JOIN Adopters a ON ar.adopter_id = a.adopter_id
                                 WHERE ar.orphanage_id = @orphanage_id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@orphanage_id", orphanageId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvApplicationRecords.DataSource = dt;
                gvApplicationRecords.DataBind();
            }
        }

        protected void btnViewChildren(object sender, EventArgs e)
        {
            string orphanageId = Session["OrphanageID"]?.ToString();
            // Redirect to ChildrenList.aspx with orphanage_id as a query parameter
            Response.Redirect($"ChildCrud.aspx?orphanage_id={orphanageId}");
        }

        protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument is null)
            {
                lblErrorMessage.Text = "Invalid command argument.";
                lblErrorMessage.Visible = true;
                return;
            }

            int applicationId;
            if (!int.TryParse(e.CommandArgument.ToString(), out applicationId))
            {
                lblErrorMessage.Text = "Invalid application ID.";
                lblErrorMessage.Visible = true;
                return;
            }

            switch (e.CommandName)
            {
                case "Accept":
                    UpdateApplicationStatus(applicationId, "Accepted");
                    break;

                case "Reject":
                    UpdateApplicationStatus(applicationId, "Rejected");
                    break;

                case "ViewDocuments":
                    // Redirect to a document viewing page
                    Response.Redirect($"ViewAdopterDocs.aspx?application_id={applicationId}");
                    break;

                case "HomeStudy":
                    // Redirect to a document viewing page
                    Response.Redirect($"HomeStudies.aspx?application_id={applicationId}");
                    break;

                default:
                    lblErrorMessage.Text = "Invalid command.";
                    lblErrorMessage.Visible = true;
                    break;
            }
        }
      
        private void UpdateApplicationStatus(int applicationId, string status)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE ApplicationRecords SET status = @status, review_date = @review_date WHERE application_id = @application_id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@review_date", DateTime.Now);
                cmd.Parameters.AddWithValue("@application_id", applicationId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            lblSuccessMessage.Text = $"Application {status} successfully!";
            lblSuccessMessage.Visible = true;

            // Refresh the GridView after updating
            LoadApplicationRecords();
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileUploadControl.HasFile)
            {
                string fileName = Path.GetFileName(fileUploadControl.FileName);
                string orphanageId = Session["OrphanageID"]?.ToString();

                // Save the uploaded file
                string uploadPath = Server.MapPath("~/Uploads/");
                string fullPath = Path.Combine(uploadPath, fileName);

                // Ensure the directory exists
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                // Save the file to the server
                fileUploadControl.SaveAs(fullPath);
                string description = txtDescription.Text;
                SaveImageToDatabase(orphanageId, fileName, description);

                lblUploadMessage.Text = "Image uploaded successfully!";
                lblUploadMessage.Visible = true;
                lblUploadError.Visible = false;
                LoadOrphanageImages(orphanageId);
            }
            else
            {
                lblUploadError.Text = "Please select a file to upload.";
                lblUploadError.Visible = true;
                lblUploadMessage.Visible = false;
            }
        }

        private void SaveImageToDatabase(string orphanageId, string fileName, string description)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Define the path to append
                string imagePath = "/Images/Orphanage/";

                // Modify the query to include the appended file name
                string query = "INSERT INTO Images (related_orphanage_id, image_url, description, uploaded_date) VALUES (@OrphanageId, @FileName, @Description, @UploadedDate)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Combine the path with the file name
                    string fullFileName = imagePath + fileName;

                    cmd.Parameters.AddWithValue("@OrphanageId", orphanageId);
                    cmd.Parameters.AddWithValue("@FileName", fullFileName); // Use the modified full file name
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@UploadedDate", DateTime.Now); // Set the current date and time

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }




        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear session data and redirect to login
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

    }
}
