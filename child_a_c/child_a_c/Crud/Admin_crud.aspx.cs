using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class admin_crud : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Check if deleteId is present in the query string
            if (Request.QueryString["deleteId"] != null)
            {
                int orphanageId = Convert.ToInt32(Request.QueryString["deleteId"]);
                DeleteOrphanage(orphanageId);
            }

            // Load orphanages after deletion or on initial load
            LoadOrphanages();
        }
    }

    private void LoadOrphanages()
    {
        string query = @"
            SELECT o.*, 
                (SELECT STRING_AGG(document_name, ', ') 
                 FROM OrphanageDocuments 
                 WHERE orphanage_id = o.orphanage_id) AS OrphanageDocuments,
                (SELECT STRING_AGG(CONCAT('Child ID: ', child_id, ', Date: ', adoption_date, ', Status: ', adoption_status), '; ') 
                 FROM AdoptionRecords 
                 WHERE orphanage_id = o.orphanage_id) AS AdoptionRecords,
                (SELECT STRING_AGG(CONCAT('Child ID: ', child_id, ', Study Date: ', date_of_study), '; ') 
                 FROM HomeStudies 
                 WHERE orphanage_id = o.orphanage_id) AS HomeStudies
            FROM Orphanages o";

        DataTable dt = GetData(query);
        OrphanageRepeater.DataSource = dt;
        OrphanageRepeater.DataBind();
    }
    private void DeleteOrphanage(int orphanageId)
    {
        string query = "DELETE FROM Orphanages WHERE orphanage_id = @orphanage_id";

        string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@orphanage_id", orphanageId);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        // Cascade deletes should automatically remove related child records (AdoptionRecords, HomeStudies, etc.)
    }

    private DataTable GetData(string query)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                }
            }
        }
    }
    

    protected string FormatDocuments(object orphanageId)
    {
        int id = Convert.ToInt32(orphanageId);
        string query = $"SELECT document_name, document_url FROM OrphanageDocuments WHERE orphanage_id = {id}";
        DataTable dt = GetData(query);
        string result = string.Empty;
        foreach (DataRow row in dt.Rows)
        {
            result += $"<li><a href=\"{row["document_url"]}\">{row["document_name"]}</a></li>";
        }
        return result;
    }

   

    protected string FormatAdoptionRecords(object orphanageId)
    {
        // Assuming you are linking records via child_id or adopter_id
        string query = $"SELECT child_id, adoption_date, adoption_status FROM AdoptionRecords WHERE adopter_id IN (SELECT adopter_id FROM HomeStudies WHERE orphanage_id = {orphanageId})";
        DataTable dt = GetData(query);
        string result = string.Empty;
        foreach (DataRow row in dt.Rows)
        {
            result += $"<li>Child ID: {row["child_id"]}, Date: {Convert.ToDateTime(row["adoption_date"]).ToShortDateString()}, Status: {row["adoption_status"]}</li>";
        }
        return result;
    }

    protected string FormatHomeStudies(object orphanageId)
    {
        string query = $"SELECT * FROM HomeStudies WHERE adopter_id IN (SELECT adopter_id FROM AdoptionRecords WHERE orphanage_id = {orphanageId})";
        DataTable dt = GetData(query);
        string result = string.Empty;
        foreach (DataRow row in dt.Rows)
        {
            result += $"<li>Report: <a href=\"{row["home_study_report_url"]}\">{Convert.ToDateTime(row["date_of_study"]).ToShortDateString()}</a></li>";
        }
        return result;
    }

}
