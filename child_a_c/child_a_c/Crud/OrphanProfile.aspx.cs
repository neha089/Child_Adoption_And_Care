using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace child_a_c.Crud
{
    public partial class OrphanProfile : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!User.Identity.IsAuthenticated)
                {
                    Response.Redirect("~/Crud/Login.aspx");
                }

                LoadOrphanageProfile();
                LoadUploadedDocuments();
            }
        }

        private void LoadOrphanageProfile()
        {
            lblName.Text = Session["OrphanageName"]?.ToString() ?? "N/A";
            lblAddress.Text = Session["OrphanageAddress"]?.ToString() ?? "N/A";
            lblPhoneNumber.Text = Session["OrphanagePhone"]?.ToString() ?? "N/A";
            lblEmail.Text = Session["OrphanageEmail"]?.ToString() ?? "N/A";
            lblContactPerson.Text = Session["OrphanageContactPerson"]?.ToString() ?? "N/A";
            lblCapacity.Text = Session["OrphanageCapacity"]?.ToString() ?? "N/A";
            lblNumberOfChildren.Text = Session["OrphanageNumberOfChildren"]?.ToString() ?? "N/A";
            lblLicenseNumber.Text = Session["OrphanageLicenseNumber"]?.ToString() ?? "N/A";
        }

        private void LoadUploadedDocuments()
        {
            string orphanageId = Session["OrphanageID"]?.ToString();

            if (string.IsNullOrEmpty(orphanageId))
            {
                lblErrorMessage.Text = "Orphanage ID is not available.";
                lblErrorMessage.Visible = true;
                return;
            }

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database1"].ConnectionString))
            {
                string query = "SELECT document_id, document_name, document_url FROM OrphanageDocuments WHERE orphanage_id = @OrphanageId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrphanageId", orphanageId);
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Document> documents = new List<Document>();

                    while (reader.Read())
                    {
                        string documentUrl = reader["document_url"].ToString().Trim();

                        // Convert an absolute path to a relative path, if necessary
                        if (Path.IsPathRooted(documentUrl)) // Absolute path (like C:\...)
                        {
                            documentUrl = "/Documents/" + Path.GetFileName(documentUrl); // Adjust to relative path
                        }

                        // Ensure documentUrl starts with "~/" for MapPath to work correctly
                        if (!documentUrl.StartsWith("~/"))
                        {
                            documentUrl = "~" + documentUrl;
                        }

                        // Resolve the virtual path to a physical path
                        string documentPath = Server.MapPath(documentUrl);

                        // Check if the physical file exists
                        if (File.Exists(documentPath))
                        {
                            documents.Add(new Document
                            {
                                DocumentId = (int)reader["document_id"],
                                DocumentName = reader["document_name"].ToString(),
                                DocumentUrl = ResolveUrl(documentUrl) // Properly resolve URL for the link
                            });
                        }
                        else
                        {
                            // Handle case where the file does not exist
                            documents.Add(new Document
                            {
                                DocumentId = (int)reader["document_id"],
                                DocumentName = reader["document_name"].ToString() + " (File not found)",
                                DocumentUrl = "#" // No valid URL
                            });
                        }
                    }

                    rptDocuments.DataSource = documents;
                    rptDocuments.DataBind();
                }
            }
        }


        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fuDocumentUpload.HasFile)
            {
                string fileName = fuDocumentUpload.FileName;
                string filePath = Server.MapPath("~/Documents/") + fileName;
                fuDocumentUpload.SaveAs(filePath);

                string orphanageId = Session["OrphanageID"]?.ToString();
                string documentType = txtDocumentType.Text;
                string documentName = txtDocumentName.Text;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database1"].ConnectionString))
                {
                    string query = "INSERT INTO OrphanageDocuments (orphanage_id, document_type, document_name, document_url, upload_date) VALUES (@OrphanageId, @DocumentType, @DocumentName, @DocumentUrl, @UploadDate)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrphanageId", orphanageId);
                        cmd.Parameters.AddWithValue("@DocumentType", documentType);
                        cmd.Parameters.AddWithValue("@DocumentName", documentName);
                        cmd.Parameters.AddWithValue("@DocumentUrl", "~/Documents/" + fileName);
                        cmd.Parameters.AddWithValue("@UploadDate", DateTime.Now);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadUploadedDocuments();
            }
        }

        protected void btnRemove_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                int documentId = Convert.ToInt32(e.CommandArgument);
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database1"].ConnectionString))
                {
                    string query = "DELETE FROM OrphanageDocuments WHERE document_id = @DocumentId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DocumentId", documentId);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadUploadedDocuments();
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Orphanagedashboard.aspx");
        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrphanageEdit.aspx");
        }

        public class Document
        {
            public int DocumentId { get; set; }
            public string DocumentName { get; set; }
            public string DocumentUrl { get; set; }
            public string DocumentType { get; set; }
        }

    }
}
