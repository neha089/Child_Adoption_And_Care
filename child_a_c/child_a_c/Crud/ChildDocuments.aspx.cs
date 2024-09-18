using System;
using System.Data.SqlClient;
using System.Configuration;
using child_a_c.Crud;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class ChildDocuments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    https://localhost:44351/Crud/ChildDocuments.aspx.cs
        if (!IsPostBack)
        {
            LoadChildDocuments();
        }
    }

    private void LoadChildDocuments()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM ChildDocuments", conn);
            conn.Open();
            gvChildDocuments.DataSource = cmd.ExecuteReader();
            gvChildDocuments.DataBind();
        }
    }

    protected void gvChildDocuments_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvChildDocuments.SelectedRow;
        txtDocumentID.Text = row.Cells[0].Text;
        txtChildID.Text = row.Cells[1].Text;
        txtDocumentType.Text = row.Cells[2].Text;
        txtDocumentName.Text = row.Cells[3].Text;
        txtDocumentURL.Text = row.Cells[4].Text;
        txtUploadDate.Text = row.Cells[5].Text;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd;
            if (string.IsNullOrEmpty(txtDocumentID.Text))
            {
                cmd = new SqlCommand("INSERT INTO ChildDocuments (child_id, document_type, document_name, document_url, upload_date) VALUES (@ChildID, @DocumentType, @DocumentName, @DocumentURL, @UploadDate)", conn);
            }
            else
            {
                cmd = new SqlCommand("UPDATE ChildDocuments SET child_id = @ChildID, document_type = @DocumentType, document_name = @DocumentName, document_url = @DocumentURL, upload_date = @UploadDate WHERE document_id = @DocumentID", conn);
                cmd.Parameters.AddWithValue("@DocumentID", txtDocumentID.Text);
            }

            cmd.Parameters.AddWithValue("@ChildID", txtChildID.Text);
            cmd.Parameters.AddWithValue("@DocumentType", txtDocumentType.Text);
            cmd.Parameters.AddWithValue("@DocumentName", txtDocumentName.Text);
            cmd.Parameters.AddWithValue("@DocumentURL", txtDocumentURL.Text);
            cmd.Parameters.AddWithValue("@UploadDate", txtUploadDate.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            LoadChildDocuments();
        }
    }
}
