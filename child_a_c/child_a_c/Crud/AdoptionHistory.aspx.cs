using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace YourNamespace
{
    public partial class AdoptionHistory : System.Web.UI.Page
    {
        // Field to store total records count
        public int TotalRecordCount { get; set; } = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int orphanageId = 0;
                // Assuming orphanage_id is passed as a query string
                if (Request.QueryString["orphanage_id"] != null)
                {
                    orphanageId = Convert.ToInt32(Request.QueryString["orphanage_id"]);
                }

                if (orphanageId > 0)
                {
                    FetchAdoptionRecords(orphanageId);
                }
                else
                {
                    lblOrphanageName.Text = "Invalid orphanage ID.";
                }
            }
        }

        private void FetchAdoptionRecords(int orphanageId)
        {
            // Fetch connection string from Web.config
            string connString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"SELECT adoption_id, adopter_id, child_id, 
                                        adoption_date, finalization_date, 
                                        adoption_status, legal_documents, notes 
                                 FROM AdoptionRecords 
                                 WHERE orphanage_id = @OrphanageId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@OrphanageId", orphanageId);

                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Set the total record count
                    TotalRecordCount = dt.Rows.Count;

                    // Bind the data to the Repeater
                    rptAdoptionRecords.DataSource = dt;
                    rptAdoptionRecords.DataBind();
                }
                catch (Exception ex)
                {
                    // Handle exceptions by showing error message
                    lblOrphanageName.Text = "Error fetching records: " + ex.Message;
                }
            }
        }
    }
}
