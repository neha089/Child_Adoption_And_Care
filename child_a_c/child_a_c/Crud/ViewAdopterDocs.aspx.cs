using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

namespace child_a_c.Crud
{
    public partial class ViewAdopterDocs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get the application_id from the query string
                int applicationId = Convert.ToInt32(Request.QueryString["application_id"]);

                if (applicationId > 0)
                {
                    // Fetch and display documents for the adopter
                    LoadAdopterDocuments(applicationId);
                }
                else
                {
                    lblErrorMessage.Text = "Invalid application ID.";
                    lblErrorMessage.Visible = true;
                }
            }
        }

        private void LoadAdopterDocuments(int applicationId)
        {
            // Your database connection string
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT doc.document_name 
                         FROM AdopterDocuments doc
                         JOIN ApplicationRecords ar ON ar.adopter_id = doc.adopter_id
                         WHERE ar.application_id = @application_id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@application_id", applicationId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                // Clear previous content
                ltrDocuments.InnerHtml = string.Empty;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string documentName = reader["document_name"].ToString();
                        string documentUrl = $"/Document/{documentName}"; // Construct the URL correctly

                        // Check if the file exists on the server
                        string documentPath = Server.MapPath(documentUrl);
                        if (File.Exists(documentPath))
                        {
                            // Create a link to open the document
                            ltrDocuments.InnerHtml += $"<li class='document-item'><span>{documentName}</span>" +
                                                       $"<a class='btn-view' href='{documentUrl}' target='_blank'>View</a></li>";
                        }
                        else
                        {
                            // Handle missing document files
                            ltrDocuments.InnerHtml += $"<li class='document-item'><span>{documentName} (File not found)</span></li>";
                        }
                    }
                }
                else
                {
                    ltrNoDocs.Text = "<div class='no-docs'>No documents found for this adopter.</div>";
                    ltrNoDocs.Visible = true;
                }
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Orphanagedashboard.aspx");
        }
    }
}
