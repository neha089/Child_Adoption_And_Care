using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace Crud
{
    public partial class ApplicationRecords : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadApplicationRecords();
            }
        }

        private void LoadApplicationRecords()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Con1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM ApplicationRecords", conn);
                conn.Open();
                gvApplicationRecords.DataSource = cmd.ExecuteReader();
                gvApplicationRecords.DataBind();
            }
        }

        protected void gvApplicationRecords_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvApplicationRecords.SelectedRow;
            txtApplicationID.Text = row.Cells[0].Text;
            txtAdopterID.Text = row.Cells[1].Text;
            txtChildID.Text = row.Cells[2].Text;
            txtApplicationDate.Text = row.Cells[3].Text;
            txtStatus.Text = row.Cells[4].Text;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd;
                if (string.IsNullOrEmpty(txtApplicationID.Text))
                {
                    cmd = new SqlCommand("INSERT INTO ApplicationRecords (adopter_id, child_id, application_date, status) VALUES (@AdopterID, @ChildID, @ApplicationDate, @Status)", conn);
                }
                else
                {
                    cmd = new SqlCommand("UPDATE ApplicationRecords SET adopter_id = @AdopterID, child_id = @ChildID, application_date = @ApplicationDate, status = @Status WHERE application_id = @ApplicationID", conn);
                    cmd.Parameters.AddWithValue("@ApplicationID", txtApplicationID.Text);
                }

                cmd.Parameters.AddWithValue("@AdopterID", txtAdopterID.Text);
                cmd.Parameters.AddWithValue("@ChildID", txtChildID.Text);
                cmd.Parameters.AddWithValue("@ApplicationDate", txtApplicationDate.Text);
                cmd.Parameters.AddWithValue("@Status", txtStatus.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                LoadApplicationRecords();
            }
        }
    }
}
