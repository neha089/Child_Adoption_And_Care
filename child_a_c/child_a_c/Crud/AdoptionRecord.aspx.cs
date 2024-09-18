using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

public partial class AdoptionRecords : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadAdoptionRecords();
        }
    }

    private void LoadAdoptionRecords()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM AdoptionRecords", conn);
            conn.Open();
            gvAdoptionRecords.DataSource = cmd.ExecuteReader();
            gvAdoptionRecords.DataBind();
        }
    }

    protected void gvAdoptionRecords_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvAdoptionRecords.SelectedRow;
        txtAdoptionID.Text = row.Cells[0].Text;
        txtAdopterID.Text = row.Cells[1].Text;
        txtChildID.Text = row.Cells[2].Text;
        txtAdoptionDate.Text = row.Cells[3].Text;
        txtStatus.Text = row.Cells[4].Text;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd;
            if (string.IsNullOrEmpty(txtAdoptionID.Text))
            {
                cmd = new SqlCommand("INSERT INTO AdoptionRecords (adopter_id, child_id, adoption_date, status) VALUES (@AdopterID, @ChildID, @AdoptionDate, @Status)", conn);
            }
            else
            {
                cmd = new SqlCommand("UPDATE AdoptionRecords SET adopter_id = @AdopterID, child_id = @ChildID, adoption_date = @AdoptionDate, status = @Status WHERE adoption_id = @AdoptionID", conn);
                cmd.Parameters.AddWithValue("@AdoptionID", txtAdoptionID.Text);
            }

            cmd.Parameters.AddWithValue("@AdopterID", txtAdopterID.Text);
            cmd.Parameters.AddWithValue("@ChildID", txtChildID.Text);
            cmd.Parameters.AddWithValue("@AdoptionDate", txtAdoptionDate.Text);
            cmd.Parameters.AddWithValue("@Status", txtStatus.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            LoadAdoptionRecords();
        }
    }
}
