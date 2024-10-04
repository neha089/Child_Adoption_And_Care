using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace child_a_c.Crud
{
    public partial class OrphanageList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOrphanages();
            }
        }

        private void LoadOrphanages()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
            string query = "SELECT orphanage_id, name, address, phone_number, email, contact_person, capacity, number_of_children FROM Orphanages";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        RepeaterOrphanages.DataSource = dt;
                        RepeaterOrphanages.DataBind();
                    }
                }
            }
        }

        protected void btnDonate_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string orphanageId = btn.CommandArgument; // Get orphanage ID from CommandArgument

            // Redirect to the donation page with the orphanage ID
            Response.Redirect($"Donate.aspx?orphanageId={orphanageId}");
        }


    }
}
