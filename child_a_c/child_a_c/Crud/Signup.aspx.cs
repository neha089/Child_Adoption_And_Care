using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;

public partial class Signup : System.Web.UI.Page
{
    private int orphanageId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlUserType.Items.Insert(0, new ListItem("Select", ""));
            ShowHideForms();
        }
    }

    protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        adopterForm.Visible = false;
        orphanageForm.Visible = false;
        donorForm.Visible = false;
        ShowHideForms();
    }

    private void ShowHideForms()
    {
        string userType = ddlUserType.SelectedValue;

        // Show or hide forms based on the selected user type
        if (userType == "Adopter")
        {
            adopterForm.Visible = true;
            orphanageForm.Visible = false;
        }
        else if (userType == "Orphanage")
        {
            adopterForm.Visible = false;
            orphanageForm.Visible = true;
        }
        else if (userType == "Donor")
        {
            adopterForm.Visible = false;
            donorForm.Visible = true;
        }
        else
        {
            adopterForm.Visible = false;
            orphanageForm.Visible = false;
        }
    }

    protected void btnSignUp_Click(object sender, EventArgs e)
    {
        string userType = ddlUserType.SelectedValue;
        string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            if (userType == "Adopter")
            {
                DateTime dob;
                string dateFormat = "yyyy-MM-dd"; // Set the expected date format

                // Try to parse the date of birth
                if (!DateTime.TryParseExact(txtDateOfBirth.Text, dateFormat,
                                             System.Globalization.CultureInfo.InvariantCulture,
                                             System.Globalization.DateTimeStyles.None, out dob))
                {
                    // Handle the error, e.g., display a message to the user
                    throw new Exception("Invalid date format. Please enter a valid date in the format YYYY-MM-DD.");
                }

                string query = @"INSERT INTO Adopters (first_name, last_name, password, date_of_birth, address, phone_number, email, marital_status, occupation, education_level) 
                     VALUES (@FirstName, @LastName, @Password, @DOB, @Address, @Phone, @Email, @MaritalStatus, @Occupation, @EducationLevel)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@DOB", dob); // Use the parsed DateTime object
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhoneNumber.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@MaritalStatus", txtMaritalStatus.Text);
                    cmd.Parameters.AddWithValue("@Occupation", txtOccupation.Text);
                    cmd.Parameters.AddWithValue("@EducationLevel", txtEducationLevel.Text);
                    cmd.ExecuteNonQuery();
                }
            }


            else if (userType == "Orphanage")
            {
                // Insert orphanage information into the database
                string query = @"INSERT INTO Orphanages (name, address, phone_number, email, contact_person, capacity, number_of_children, license_number, password) 
                 OUTPUT INSERTED.orphanage_id VALUES (@Name, @Address, @Phone, @Email, @ContactPerson, @Capacity, @NumChildren, @LicenseNumber, @Password)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", txtOrphanageName.Text);
                    cmd.Parameters.AddWithValue("@Address", txtOrphanageAddress.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtOrphanagePhoneNumber.Text);
                    cmd.Parameters.AddWithValue("@Email", txtOrphanageEmail.Text);
                    cmd.Parameters.AddWithValue("@ContactPerson", txtContactPerson.Text);
                    cmd.Parameters.AddWithValue("@Capacity", txtCapacity.Text);
                    cmd.Parameters.AddWithValue("@NumChildren", txtNumChildren.Text);
                    cmd.Parameters.AddWithValue("@LicenseNumber", txtLicenseNumber.Text);
                    cmd.Parameters.AddWithValue("@Password", txtOrphanagePassword.Text);

                    // Execute the command and retrieve the inserted orphanage ID
                    orphanageId = (int)cmd.ExecuteScalar(); // Get the new orphanage ID
                }

                // Save uploaded documents
                SaveDocument(fuLicence, orphanageId, "License", conn);
                SaveDocument(fuIdProof, orphanageId, "ID Proof", conn);
            }
            else if (userType == "Donor")
            {
                string query = @"INSERT INTO Donors (donor_name, phone_number, email, password) 
                                 VALUES (@DonorName, @Phone, @Email, @Password)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DonorName", txtDonorName.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtDonorPhone.Text);
                    cmd.Parameters.AddWithValue("@Email", txtDonorEmail.Text);
                    cmd.Parameters.AddWithValue("@Password", txtDonorPassword.Text);
                    cmd.ExecuteNonQuery();
                }

            }
        }
    
        // Redirect to Login
        Response.Redirect("Login.aspx");
    }
    private void SaveDocument(FileUpload fileUpload, int orphanageId, string documentType, SqlConnection conn)
    {
        if (fileUpload.HasFile)
        {
            string folderPath = Server.MapPath("~/Documents/"); // Ensure this folder exists

            // Check if the directory exists; if not, create it
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Create the full path to save the uploaded file
            string fileName = Path.GetFileName(fileUpload.FileName);
            string uploadPath = Path.Combine(folderPath, fileName);

            // Save the file to the server
            fileUpload.SaveAs(uploadPath);

            // Insert document details into the OrphanageDocuments table
            string documentQuery = "INSERT INTO OrphanageDocuments (orphanage_id, document_type, document_name, document_url, upload_date) " +
                                   "VALUES (@orphanage_id, @document_type, @document_name, @document_url, @upload_date)";
            using (SqlCommand cmd = new SqlCommand(documentQuery, conn))
            {
                cmd.Parameters.AddWithValue("@orphanage_id", orphanageId);
                cmd.Parameters.AddWithValue("@document_type", documentType);
                cmd.Parameters.AddWithValue("@document_name", fileName);
                cmd.Parameters.AddWithValue("@document_url", uploadPath);
                cmd.Parameters.AddWithValue("@upload_date", DateTime.Now);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
