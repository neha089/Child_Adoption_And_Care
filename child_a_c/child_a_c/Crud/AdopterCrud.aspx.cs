using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;

public partial class AdopterCrud : System.Web.UI.Page
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

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Orphanages";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            rptOrphanages.DataSource = dt;
            rptOrphanages.DataBind();
            // Bind images for each orphanage
            foreach (RepeaterItem item in rptOrphanages.Items)
            {
                int orphanageId = Convert.ToInt32(((Button)item.FindControl("btnSelectOrphanage")).CommandArgument);
                LoadImagesForOrphanage(orphanageId, (Repeater)item.FindControl("rptImages"));
            }
        }
    }

    private void LoadImagesForOrphanage(int orphanageId, Repeater rptImages)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT image_url, description FROM Images WHERE related_orphanage_id = @orphanageId";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@orphanageId", orphanageId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            rptImages.DataSource = dt;
            rptImages.DataBind();
        }
    }

    protected void btnSelectOrphanage_Command(object sender, CommandEventArgs e)
    {
        int orphanageId = Convert.ToInt32(e.CommandArgument);

        // Redirect to ChildrenList.aspx with orphanage_id as a query parameter
        Response.Redirect($"ChildrenList.aspx?orphanage_id={orphanageId}");
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        // Clear session data and redirect to login
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }
}
