using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Crud
{
    public partial class AdoptionRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            // Sample DataTable - replace this with actual data source
            DataTable dt = new DataTable();
            dt.Columns.Add("adoption_id");
            dt.Columns.Add("adopter_id");
            dt.Columns.Add("child_id");
            dt.Columns.Add("adoption_date");
            dt.Columns.Add("status");

            // Sample data - replace with actual data retrieval logic
            dt.Rows.Add("1", "A101", "C101", "2024-01-01", "Completed");
            dt.Rows.Add("2", "A102", "C102", "2024-01-02", "Pending");

            gvAdoptionRecords.DataSource = dt;
            gvAdoptionRecords.DataBind();
        }

        protected void gvAdoptionRecords_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected row
            GridViewRow row = gvAdoptionRecords.SelectedRow;
            txtAdoptionID.Text = row.Cells[1].Text; // Assuming the first cell is index 1 for Adoption ID
            txtAdopterID.Text = row.Cells[2].Text; // Adopter ID
            txtChildID.Text = row.Cells[3].Text; // Child ID
            txtAdoptionDate.Text = row.Cells[4].Text; // Adoption Date
            txtStatus.Text = row.Cells[5].Text; // Status
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Implement save logic (Insert/Update) here
            // This will depend on your data access layer and business logic

            // Example: Clear the fields after saving
            txtAdoptionID.Text = string.Empty;
            txtAdopterID.Text = string.Empty;
            txtChildID.Text = string.Empty;
            txtAdoptionDate.Text = string.Empty;
            txtStatus.Text = string.Empty;

            // Rebind the Grid to show updated data
            BindGrid();
        }
    }
}
