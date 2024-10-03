using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls; // Ensure this is included
using child_a_c.Crud;
using System.Web.Security;
using System.Data;

namespace child_a_c.Crud
{
    public partial class ChildCrud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int orphanageId = Convert.ToInt32(Request.QueryString["orphanage_id"]);
                LoadChildren(orphanageId); 
            }
        }

        private void LoadChildren(int orphanageId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT c.child_id, c.first_name, c.last_name, c.date_of_birth, c.gender, c.profile_image, c.orphanage_id 
            FROM Children c
            WHERE c.orphanage_id = @orphanageId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@orphanageId", orphanageId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    lblMessage.Text = "No children found in this orphanage.";
                    lblMessage.Visible = true;
                    rptChildren.Visible = false;
                }
                else
                {
                    rptChildren.DataSource = dt;
                    rptChildren.DataBind();
                    lblMessage.Visible = false;
                    rptChildren.Visible = true;
                }
            }
        }

        protected void btnEdit_Command(object sender, CommandEventArgs e)
        {
            int childId = Convert.ToInt32(e.CommandArgument);

            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT first_name, last_name, date_of_birth, gender FROM Children WHERE child_id = @childId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@childId", childId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Populate the edit form with the selected child's data
                    hfChildId.Value = childId.ToString();
                    txtFirstName.Text = reader["first_name"].ToString();
                    txtLastName.Text = reader["last_name"].ToString();
                    txtDateOfBirth.Text = Convert.ToDateTime(reader["date_of_birth"]).ToString("yyyy-MM-dd");
                    ddlGender.SelectedValue = reader["gender"].ToString();

                    // Show the edit form
                    editForm.Style["display"] = "block";
                }

                reader.Close();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int childId = Convert.ToInt32(hfChildId.Value);

            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                UPDATE Children 
                SET first_name = @firstName, last_name = @lastName, date_of_birth = @dateOfBirth, gender = @gender
                WHERE child_id = @childId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@firstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@lastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@dateOfBirth", Convert.ToDateTime(txtDateOfBirth.Text));
                cmd.Parameters.AddWithValue("@gender", ddlGender.SelectedValue);
                cmd.Parameters.AddWithValue("@childId", childId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            // Hide the edit form and reload the children list
            editForm.Style["display"] = "none";
            int orphanageId = Convert.ToInt32(Request.QueryString["orphanage_id"]);
            LoadChildren(orphanageId);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Hide the edit form without saving changes
            editForm.Style["display"] = "none";
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrphanageDashboard.aspx");
        }
    }
}
