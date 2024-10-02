using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

public partial class ChildrenList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int orphanageId = Convert.ToInt32(Request.QueryString["orphanage_id"]);
            int adopterId = GetAdopterId(); // Fetch the adopter ID as needed
            LoadChildren(orphanageId,adopterId);
        }
    }
    private int GetAdopterId()
    {
        if (Session["AdopterID"] != null)
        {
            return Convert.ToInt32(Session["AdopterID"]);
        }
        else
        {
            Response.Redirect("Login.aspx");
            return 0;
        }
    }

    private void LoadChildren(int orphanageId, int adopterId)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = @"
            SELECT c.child_id, c.first_name, c.last_name, c.date_of_birth, c.gender, 
                ar.status, ar.notes, c.orphanage_id  -- Ensure orphanage_id is included
            FROM Children c
            LEFT JOIN ApplicationRecords ar ON c.child_id = ar.child_id AND ar.adopter_id = @adopter_id  
            WHERE c.orphanage_id = @orphanageId";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@adopter_id", adopterId);
            cmd.Parameters.AddWithValue("@orphanageId", orphanageId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Check if there are no children
            if (dt.Rows.Count == 0)
            {
                lblMessage.Text = "No children found in this orphanage.";
                lblMessage.Visible = true; // Show the message label
                rptChildren.Visible = false; // Hide the repeater
            }
            else
            {
                rptChildren.DataSource = dt;
                rptChildren.DataBind();
                lblMessage.Visible = false; // Hide the message label if children are found
                rptChildren.Visible = true; // Show the repeater
            }
        }
    }



    protected void btnAdopt_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandArgument != null)
        {
            string commandArgument = e.CommandArgument.ToString();
            // Log or display the command argument for debugging
            System.Diagnostics.Debug.WriteLine("CommandArgument: " + commandArgument); // Debugging output

            string[] args = commandArgument.Split(';');

            // Ensure that the array has exactly 2 elements
            if (args.Length == 2)
            {
                int childId, orphanageId;

                // Attempt to parse childId and orphanageId
                if (int.TryParse(args[0], out childId) && int.TryParse(args[1], out orphanageId))
                {
                    // Redirect to ApplicationRecords.aspx with orphanage_id and child_id as query parameters
                    Response.Redirect($"ApplicationRecords.aspx?orphanage_id={orphanageId}&child_id={childId}");
                }
                else
                {
                    // Handle the error if parsing fails
                    lblMessage.Text = "Invalid child or orphanage ID.";
                    lblMessage.Visible = true;
                }
            }
            else
            {
                // Handle the error if the array does not have exactly 2 elements
                lblMessage.Text = "Invalid command arguments.";
                lblMessage.Visible = true;
            }
        }
        else
        {
            // Handle the error if CommandArgument is null
            lblMessage.Text = "Command argument is missing.";
            lblMessage.Visible = true;
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdopterCrud.aspx");
    }
}
