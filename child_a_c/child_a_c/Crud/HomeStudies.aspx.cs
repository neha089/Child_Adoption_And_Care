using System;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Crud
{
    public partial class HomeStudies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get the application_id from the query string
                int applicationId;
                if (int.TryParse(Request.QueryString["application_id"], out applicationId))
                {
                    LoadApplicationData(applicationId);
                }
                else
                {
                    lblMessage.Text = "Invalid application ID.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Visible = true;
                }
            }
        }

        private void LoadApplicationData(int applicationId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT ar.adopter_id, ar.child_id, ar.orphanage_id 
                                 FROM ApplicationRecords ar 
                                 WHERE ar.application_id = @application_id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@application_id", applicationId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Retrieve values from ApplicationRecords
                    string adopterId = reader["adopter_id"].ToString();
                    string childId = reader["child_id"].ToString();
                    string orphanageId = reader["orphanage_id"].ToString();

                    // Check if there is an existing entry in HomeStudies
                    CheckExistingHomeStudy(adopterId, childId, orphanageId);
                }
                else
                {
                    lblMessage.Text = "No data found for this application ID.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Visible = true;
                }
            }
        }

        private void CheckExistingHomeStudy(string adopterId, string childId, string orphanageId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM HomeStudies 
                                 WHERE adopter_id = @adopter_id AND child_id = @child_id AND orphanage_id = @orphanage_id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@adopter_id", adopterId);
                cmd.Parameters.AddWithValue("@child_id", childId);
                cmd.Parameters.AddWithValue("@orphanage_id", orphanageId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Fill the form with existing details
                    txtAdopterID.Text = reader["adopter_id"].ToString();
                    txtChildID.Text = reader["child_id"].ToString();
                    txtOrphanageID.Text = reader["orphanage_id"].ToString();
                    DateTime dateOfStudy = Convert.ToDateTime(reader["date_of_study"]);
                    txtDateOfStudy.Text = dateOfStudy.ToString("yyyy-MM-dd");
                    txtStatus.Text = reader["status"].ToString();
                    txtSocialWorkerName.Text = reader["social_worker_name"].ToString();
                    txtComment.Text = reader["comments"].ToString();
                  
                    // Make fields read-only
                    txtAdopterID.ReadOnly = true;
                    txtChildID.ReadOnly = true;
                    txtOrphanageID.ReadOnly = true;
                    txtDateOfStudy.ReadOnly = true;
                    txtStatus.ReadOnly = true;
                    txtSocialWorkerName.ReadOnly = true;
                    txtComment.ReadOnly = true;

                    // Hide save button and file upload button
                    btnSave.Visible = false;
                    fuHomeStudyReport.Visible = false;

                    // Show view button with the document link
                    string fileUrl = reader["home_study_report_url"].ToString();
                    string fileName = Path.GetFileName(fileUrl);

                    // Construct the full path to the document in the Documents folder
                    string documentPath = ResolveUrl("/Document/" + fileName);

                    // Show view button with the document link
                    btnView.Visible = true;
                    btnView.Attributes["onclick"] = $"window.open('{documentPath}', '_blank'); return false;";
                }
                else
                {
                    txtAdopterID.Text = adopterId;
                    txtChildID.Text = childId;
                    txtOrphanageID.Text = orphanageId;
                    // If no existing entry, keep the form editable
                   
                    txtDateOfStudy.ReadOnly = false;
                    txtStatus.ReadOnly = false;
                    txtSocialWorkerName.ReadOnly = false;
                    txtComment.ReadOnly = false;

                    // Ensure the view button is hidden if no record found
                    btnView.Visible = false;

                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure the Documents directory exists
                string directoryPath = Server.MapPath("~/Documents/");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Save the uploaded file
                string fileName = Path.GetFileName(fuHomeStudyReport.FileName);
                string filePath = Path.Combine(directoryPath, fileName); // Combine directory path and file name
                fuHomeStudyReport.SaveAs(filePath);

                // Parse the date
                DateTime dateOfStudy;
                if (!DateTime.TryParse(txtDateOfStudy.Text, out dateOfStudy))
                {
                    // Handle invalid date format
                    lblMessage.Text = "Error: Invalid date format. Please enter a valid date.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Visible = true;
                    return; // Exit the method to prevent further execution
                }

                string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); // Open the connection here

                    // Insert the details into the HomeStudies table
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO HomeStudies (adopter_id, child_id, date_of_study, home_study_report_url, status, social_worker_name, comments, orphanage_id) VALUES (@adopter_id, @child_id, @date_of_study, @home_study_report_url, @status, @social_worker_name, @comments, @orphanageId)", conn))
                    {
                        cmd.Parameters.AddWithValue("@adopter_id", txtAdopterID.Text);
                        cmd.Parameters.AddWithValue("@child_id", txtChildID.Text);
                        cmd.Parameters.AddWithValue("@date_of_study", dateOfStudy); // Use the parsed date
                        cmd.Parameters.AddWithValue("@home_study_report_url", "~/Documents/" + fileName); // Corrected path
                        cmd.Parameters.AddWithValue("@status", txtStatus.Text);
                        cmd.Parameters.AddWithValue("@social_worker_name", txtSocialWorkerName.Text);
                        cmd.Parameters.AddWithValue("@comments", txtComment.Text);
                        cmd.Parameters.AddWithValue("@orphanageId", txtOrphanageID.Text);

                        // Execute the command
                        cmd.ExecuteNonQuery();
                    }
                    // Update the ApplicationRecords table based on the status
                    string notes = "Home Study Pending"; // Default value
                    if (txtStatus.Text.Equals("Approved", StringComparison.OrdinalIgnoreCase))
                    {
                        notes = "Home Study Approve";
                    }
                    else if (txtStatus.Text.Equals("Rejected", StringComparison.OrdinalIgnoreCase))
                    {
                        notes = "Home Study Rejected";
                    }

                    // Update the notes in ApplicationRecords where child_id matches
                    using (SqlCommand cmdUpdate = new SqlCommand("UPDATE ApplicationRecords SET notes = @notes WHERE child_id = @child_id", conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@notes", notes);
                        cmdUpdate.Parameters.AddWithValue("@child_id", txtChildID.Text); // Match the child_id

                        // Execute the update command
                        cmdUpdate.ExecuteNonQuery();
                    }
                }

                // Show success message
                lblMessage.Text = "Home study details saved successfully.";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Visible = true;
            }
            catch (Exception ex)
            {
                // Handle exceptions and show error message
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Orphanagedashboard.aspx");
        }
    }
}
