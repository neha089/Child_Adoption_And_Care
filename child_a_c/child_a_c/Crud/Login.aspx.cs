using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace child_a_c.Crud
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            string UserType = userType.SelectedValue;  
            string UserEmail = email.Text.Trim();
            string UserPassword = password.Text.Trim();

            if (ValidateLogin(UserType, UserEmail, UserPassword))
            {
                FormsAuthentication.SetAuthCookie(UserEmail, true);
                switch (UserType)
                {
                    case "Orphanage":
                        Response.Redirect("OrphanageCrud.aspx");
                        break;
                    case "Admin":
                        Response.Redirect("AdminCrud.aspx");
                        break;
                    case "Adopter":
                        Response.Redirect("AdopterCrud.aspx");
                        break;
                }
            }
            else
            {
                loginMessage.Text = "Invalid email or password.";
            }
        }

        private bool ValidateLogin(string userType, string email, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
            string query = "";

            switch (userType)
            {
                case "Orphanage":
                    query = "SELECT COUNT(*) FROM Orphanages WHERE email = @Email AND password = @Password";
                    break;
                case "Admin":
                    query = "SELECT COUNT(*) FROM Admins WHERE email = @Email AND password = @Password";
                    break;
                case "Adopter":
                    query = "SELECT COUNT(*) FROM Adopters WHERE email = @Email AND password = @Password";
                    break;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                conn.Open();
                int result = (int)cmd.ExecuteScalar(); // Return the first column of the first row

                return result > 0; 
            }
        }
    }
}