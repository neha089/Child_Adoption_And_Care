using System;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace child_a_c.Crud
{
    public partial class AdopterDocument : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // No need to load documents, as we removed the GridView
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (fileUploadDocument.HasFile)
            {
                try
                {
                    // Define the folder where the document will be uploaded
                    string folderPath = Server.MapPath("~/Document/");

                    // Check if the directory exists; if not, create it
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    // Create the full path to save the uploaded file
                    string fileName = Path.GetFileName(fileUploadDocument.FileName);
                    string uploadPath = Path.Combine(folderPath, fileName);

                    // Save the file to the server
                    fileUploadDocument.SaveAs(uploadPath);

                    // Save document details to the database
                    string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO AdopterDocuments (adopter_id, document_type, document_name, document_url, upload_date) VALUES (@AdopterID, @DocumentType, @DocumentName, @DocumentURL, @UploadDate)", conn);

                        cmd.Parameters.AddWithValue("@AdopterID", txtAdopterID.Text);
                        cmd.Parameters.AddWithValue("@DocumentType", txtDocumentType.Text);
                        cmd.Parameters.AddWithValue("@DocumentName", fileName);
                        cmd.Parameters.AddWithValue("@DocumentURL", uploadPath);
                        cmd.Parameters.AddWithValue("@UploadDate", DateTime.Now);

                        cmd.ExecuteNonQuery();
                    }

                    // Display success message
                    lblMessage.Text = "Document uploaded successfully!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                catch (Exception ex)
                {
                    // Handle any errors that may have occurred
                    lblMessage.Text = "Error: " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMessage.Text = "Please select a document to upload.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
