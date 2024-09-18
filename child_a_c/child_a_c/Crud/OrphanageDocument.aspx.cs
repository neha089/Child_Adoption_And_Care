using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class OrphanageDocuments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadOrphanageDocuments();
        }
    }

    private void LoadOrphanageDocuments()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM OrphanageDocuments", conn);
            conn.Open();
            gvOrphanageDocuments.DataSource = cmd.ExecuteReader();
            gvOrphanageDocuments.DataBind();
        }
    }

    protected void gvOrphanageDocuments_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvOrphanageDocuments.SelectedRow;
        txtDocumentID.Text = row.Cells[0].Text;
        txtOrphanageID.Text = row.Cells[1].Text;
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
                cmd = new SqlCommand("INSERT INTO OrphanageDocuments (orphanage_id, document_type, document_name, document_url, upload_date) VALUES (@OrphanageID, @DocumentType, @DocumentName, @DocumentURL, @UploadDate)", conn);
            }
            else
            {
                cmd = new SqlCommand("UPDATE OrphanageDocuments SET orphanage_id = @OrphanageID, document_type = @DocumentType, document_name = @DocumentName, document_url = @DocumentURL, upload_date = @UploadDate WHERE document_id = @DocumentID", conn);
                cmd.Parameters.AddWithValue("@DocumentID", txtDocumentID.Text);
            }

            cmd.Parameters.AddWithValue("@OrphanageID", txtOrphanageID.Text);
            cmd.Parameters.AddWithValue("@DocumentType", txtDocumentType.Text);
            cmd.Parameters.AddWithValue("@DocumentName", txtDocumentName.Text);
            cmd.Parameters.AddWithValue("@DocumentURL", txtDocumentURL.Text);
            cmd.Parameters.AddWithValue("@UploadDate", txtUploadDate.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            LoadOrphanageDocuments();
        }
    }
}
