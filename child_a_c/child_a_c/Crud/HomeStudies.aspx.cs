using System;
using System.Data.SqlClient;
using System.Configuration;
using child_a_c.Crud;
using System.Web.UI.WebControls;

public partial class HomeStudies : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadHomeStudies();
        }
    }

    private void LoadHomeStudies()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM HomeStudies", conn);
            conn.Open();
            gvHomeStudies.DataSource = cmd.ExecuteReader();
            gvHomeStudies.DataBind();
        }
    }

    protected void gvHomeStudies_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvHomeStudies.SelectedRow;
        txtHomeStudyID.Text = row.Cells[0].Text;
        txtAdopterID.Text = row.Cells[1].Text;
        txtChildID.Text = row.Cells[2].Text;
        txtDateOfStudy.Text = row.Cells[3].Text;
        txtHomeStudyReportURL.Text = row.Cells[4].Text;
        txtStatus.Text = row.Cells[5].Text;
        txtSocialWorkerName.Text = row.Cells[6].Text;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd;
            if (string.IsNullOrEmpty(txtHomeStudyID.Text))
            {
                cmd = new SqlCommand("INSERT INTO HomeStudies (adopter_id, child_id, date_of_study, home_study_report_url, status, social_worker_name) VALUES (@AdopterID, @ChildID, @DateOfStudy, @HomeStudyReportURL, @Status, @SocialWorkerName)", conn);
            }
            else
            {
                cmd = new SqlCommand("UPDATE HomeStudies SET adopter_id = @AdopterID, child_id = @ChildID, date_of_study = @DateOfStudy, home_study_report_url = @HomeStudyReportURL, status = @Status, social_worker_name = @SocialWorkerName WHERE home_study_id = @HomeStudyID", conn);
                cmd.Parameters.AddWithValue("@HomeStudyID", txtHomeStudyID.Text);
            }

            cmd.Parameters.AddWithValue("@AdopterID", txtAdopterID.Text);
            cmd.Parameters.AddWithValue("@ChildID", txtChildID.Text);
            cmd.Parameters.AddWithValue("@DateOfStudy", txtDateOfStudy.Text);
            cmd.Parameters.AddWithValue("@HomeStudyReportURL", txtHomeStudyReportURL.Text);
            cmd.Parameters.AddWithValue("@Status", txtStatus.Text);
            cmd.Parameters.AddWithValue("@SocialWorkerName", txtSocialWorkerName.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            LoadHomeStudies();
        }
    }
}
