using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace child_a_c.Crud
{
    public partial class OrphanageDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if session exists
                if (Session["OrphanageID"] == null)
                {
                    // Redirect to login page if session is null
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    // Load application records
                    LoadApplicationRecords();
                }
            }
        }

        private void LoadApplicationRecords()
        {
            // Ensure the OrphanageID is stored in the session
            string orphanageId = Session["OrphanageID"]?.ToString();
            if (string.IsNullOrEmpty(orphanageId))
            {
                // Handle case if orphanageId is not found
                lblErrorMessage.Text = "Orphanage ID not found.";
                lblErrorMessage.Visible = true;
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT ar.application_id, a.first_name + ' ' + a.last_name AS adopter_name, ar.child_id, ar.application_date, ar.status
                                 FROM ApplicationRecords ar
                                 JOIN Adopters a ON ar.adopter_id = a.adopter_id
                                 WHERE ar.orphanage_id = @orphanage_id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@orphanage_id", orphanageId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvApplicationRecords.DataSource = dt;
                gvApplicationRecords.DataBind();
            }
        }

        protected void OnRowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int applicationId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Accept")
            {
                UpdateApplicationStatus(applicationId, "Accepted");
            }
            else if (e.CommandName == "Reject")
            {
                UpdateApplicationStatus(applicationId, "Rejected");
            }
            else if (e.CommandName == "ViewDocuments")
            {
                // Redirect to a document viewing page
                Response.Redirect($"OrphanageDocument.aspx?application_id={applicationId}");
            }
        }

        private void UpdateApplicationStatus(int applicationId, string status)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE ApplicationRecords SET status = @status, review_date = @review_date WHERE application_id = @application_id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@review_date", DateTime.Now);
                cmd.Parameters.AddWithValue("@application_id", applicationId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            lblSuccessMessage.Text = $"Application {status} successfully!";
            lblSuccessMessage.Visible = true;

            // Refresh the GridView after updating
            LoadApplicationRecords();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear session data and redirect to login
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}
