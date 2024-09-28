﻿using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace child_a_c.Crud
{
    public partial class AdopterDocument : System.Web.UI.Page
    {

    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAdopterDocuments();
            }
        }

        private void LoadAdopterDocuments()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM AdopterDocuments", conn);
                conn.Open();
                gvAdopterDocuments.DataSource = cmd.ExecuteReader();
                gvAdopterDocuments.DataBind();
            }
        }

        protected void gvAdopterDocuments_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvAdopterDocuments.SelectedRow;
            txtDocumentID.Text = row.Cells[0].Text;
            txtAdopterID.Text = row.Cells[1].Text;
            txtDocumentType.Text = row.Cells[2].Text;
            txtDocumentName.Text = row.Cells[3].Text;
            txtDocumentURL.Text = row.Cells[4].Text;
            txtUploadDate.Text = row.Cells[5].Text;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd;
                if (string.IsNullOrEmpty(txtDocumentID.Text))
                {
                    cmd = new SqlCommand("INSERT INTO AdopterDocuments (adopter_id, document_type, document_name, document_url, upload_date) VALUES (@AdopterID, @DocumentType, @DocumentName, @DocumentURL, @UploadDate)", conn);
                }
                else
                {
                    cmd = new SqlCommand("UPDATE AdopterDocuments SET adopter_id = @AdopterID, document_type = @DocumentType, document_name = @DocumentName, document_url = @DocumentURL, upload_date = @UploadDate WHERE document_id = @DocumentID", conn);
                    cmd.Parameters.AddWithValue("@DocumentID", txtDocumentID.Text);
                }

                cmd.Parameters.AddWithValue("@AdopterID", txtAdopterID.Text);
                cmd.Parameters.AddWithValue("@DocumentType", txtDocumentType.Text);
                cmd.Parameters.AddWithValue("@DocumentName", txtDocumentName.Text);
                cmd.Parameters.AddWithValue("@DocumentURL", txtDocumentURL.Text);
                cmd.Parameters.AddWithValue("@UploadDate", txtUploadDate.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                LoadAdopterDocuments();
            }
        }
    }
}