using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace child_a_c.Crud
{
    public partial class OrphanageCrud : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!User.Identity.IsAuthenticated)
                {
                    Response.Redirect("~/Crud/Login.aspx");
                }
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
            }
        }

        protected void btnSaveChild_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Insert child
                SqlCommand cmd = new SqlCommand("INSERT INTO Children (first_name, last_name, date_of_birth, gender, orphanage_id, medical_history, education_level, special_needs, profile_image) OUTPUT INSERTED.child_id VALUES (@FirstName, @LastName, @DateOfBirth, @Gender, @OrphanageID, @MedicalHistory, @EducationLevel, @SpecialNeeds, @ProfileImage)", conn);

                cmd.Parameters.AddWithValue("@FirstName", txtChildFirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtChildLastName.Text);
                cmd.Parameters.AddWithValue("@DateOfBirth", txtChildDateOfBirth.Text);
                cmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
                cmd.Parameters.AddWithValue("@OrphanageID", txtOrphanageID.Text);
                cmd.Parameters.AddWithValue("@MedicalHistory", txtMedicalHistory.Text);
                cmd.Parameters.AddWithValue("@EducationLevel", txtEducationLevel.Text);
                cmd.Parameters.AddWithValue("@SpecialNeeds", txtSpecialNeeds.Text);

                string profileImageUrl = string.Empty;
                if (fuProfileImage.HasFile)
                {
                    string profileImageName = Path.GetFileName(fuProfileImage.FileName);
                    profileImageUrl = "Images/" + profileImageName;
                    fuProfileImage.SaveAs(Server.MapPath("~/" + profileImageUrl));
                }
                cmd.Parameters.AddWithValue("@ProfileImage", profileImageUrl);

                conn.Open();
                int childId = (int)cmd.ExecuteScalar();

                // Insert document if available
                if (fuDocument.HasFile)
                {
                    string documentName = Path.GetFileName(fuDocument.FileName);
                    string documentUrl = "Documents/" + documentName;
                    fuDocument.SaveAs(Server.MapPath("~/" + documentUrl));

                    SqlCommand docCmd = new SqlCommand("INSERT INTO ChildDocuments (child_id, document_type, document_name, document_url, upload_date) VALUES (@ChildID, @DocumentType, @DocumentName, @DocumentUrl, @UploadDate)", conn);
                    docCmd.Parameters.AddWithValue("@ChildID", childId);
                    docCmd.Parameters.AddWithValue("@DocumentType", txtDocumentType.Text);
                    docCmd.Parameters.AddWithValue("@DocumentName", txtDocumentName.Text);
                    docCmd.Parameters.AddWithValue("@DocumentUrl", documentUrl);
                    docCmd.Parameters.AddWithValue("@UploadDate", DateTime.Now);
                    docCmd.ExecuteNonQuery();
                }

                lblMessage.Text = "Child added successfully!";
            }
        }
    }
}
