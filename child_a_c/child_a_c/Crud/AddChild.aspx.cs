using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

            // Retrieve orphanageId from the session
            int orphanageId;
            if (Session["OrphanageID"] != null && int.TryParse(Session["OrphanageID"].ToString(), out orphanageId))
            {
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
                    cmdChild.Parameters.AddWithValue("@OrphanageID", orphanageId); // Use the value from session
                    cmdChild.Parameters.AddWithValue("@MedicalHistory", txtMedicalHistory.Text);
                    cmdChild.Parameters.AddWithValue("@EducationLevel", txtEducationLevel.Text);

                    string profileImageUrl = UploadProfileImage(fuProfileImage);
                    cmdChild.Parameters.AddWithValue("@ProfileImage", string.IsNullOrEmpty(profileImageUrl) ? (object)DBNull.Value : profileImageUrl);

                    int childId = (int)cmdChild.ExecuteScalar(); // Retrieve the generated child_id

                    // Insert document details
                    if (fuDocument.HasFile)
                    {
                        string documentUrl = UploadDocument(fuDocument);
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
            else
            {
                lblMessage.Text = "Orphanage ID is not available in session.";
            }
        }


        private string UploadProfileImage(FileUpload fileUpload)
        {
            if (fileUpload.HasFile)
            {
                string fileName = Path.GetFileName(fileUpload.FileName);
                string filePath = Server.MapPath("~/Images/Children_images/" + fileName); // Path for profile images
                fileUpload.SaveAs(filePath);
                return "~/Images/Children_images/" + fileName; // Store the URL in the database
            }
            return null; // No file uploaded
        }

        private string UploadDocument(FileUpload fileUpload)
        {
            if (fileUpload.HasFile)
            {
                string fileName = Path.GetFileName(fileUpload.FileName);
                string filePath = Server.MapPath("~/children_documents/" + fileName); // Path for documents
                fileUpload.SaveAs(filePath);
                return "~/children_documents/" + fileName; // Store the URL in the database
            }
            return null; // No file uploaded
        }
    }
}
