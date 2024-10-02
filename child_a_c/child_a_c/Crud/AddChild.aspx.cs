using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;

namespace child_a_c.Crud
{
    public partial class AddChild : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Crud/Login.aspx");
            }
        }

        protected void btnAddChild_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
            int orphanageId = Convert.ToInt32(Request.QueryString["orphanageId"]); // Fetch the orphanage ID from the query string

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Insert child details
                string childQuery = "INSERT INTO Children (first_name, last_name, date_of_birth, gender, orphanage_id, medical_history, education_level, profile_image) " +
                                    "OUTPUT INSERTED.child_id VALUES (@FirstName, @LastName, @DateOfBirth, @Gender, @OrphanageID, @MedicalHistory, @EducationLevel, @ProfileImage)";

                SqlCommand cmdChild = new SqlCommand(childQuery, conn);
                cmdChild.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmdChild.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmdChild.Parameters.AddWithValue("@DateOfBirth", txtDateOfBirth.Text);
                cmdChild.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
                cmdChild.Parameters.AddWithValue("@OrphanageID", orphanageId);
                cmdChild.Parameters.AddWithValue("@MedicalHistory", txtMedicalHistory.Text);
                cmdChild.Parameters.AddWithValue("@EducationLevel", txtEducationLevel.Text);

                string profileImageUrl = UploadFile(fuProfileImage);
                cmdChild.Parameters.AddWithValue("@ProfileImage", profileImageUrl ?? DBNull.Value);

                int childId = (int)cmdChild.ExecuteScalar(); // Retrieve the generated child_id

                // Insert document details
                if (fuDocument.HasFile)
                {
                    string documentUrl = UploadFile(fuDocument);
                    if (!string.IsNullOrEmpty(documentUrl))
                    {
                        string documentQuery = "INSERT INTO ChildDocuments (child_id, document_type, document_name, document_url, upload_date) " +
                                               "VALUES (@ChildID, @DocumentType, @DocumentName, @DocumentUrl, @UploadDate)";

                        SqlCommand cmdDocument = new SqlCommand(documentQuery, conn);
                        cmdDocument.Parameters.AddWithValue("@ChildID", childId);
                        cmdDocument.Parameters.AddWithValue("@DocumentType", txtDocumentType.Text);
                        cmdDocument.Parameters.AddWithValue("@DocumentName", txtDocumentName.Text);
                        cmdDocument.Parameters.AddWithValue("@DocumentUrl", documentUrl);
                        cmdDocument.Parameters.AddWithValue("@UploadDate", DateTime.Now);
                        cmdDocument.ExecuteNonQuery();
                    }
                }

                lblMessage.Text = "Child added successfully!";
                conn.Close();
            }
        }

        private string UploadFile(FileUpload fileUpload)
        {
            if (fileUpload.HasFile)
            {
                string fileName = Path.GetFileName(fileUpload.FileName);
                string filePath = Server.MapPath("~/Uploads/" + fileName); // Change this to your desired path
                fileUpload.SaveAs(filePath);
                return "~/Uploads/" + fileName; // Store the URL in the database
            }
            return null; // No file uploaded
        }
    }
}
