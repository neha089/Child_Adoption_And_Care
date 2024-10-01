﻿using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls; // Ensure this is included
using child_a_c.Crud;
using System.Web.Security;

namespace child_a_c.Crud
{
    public partial class ChildCrud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadChildrenRecords();
            }
        }

        private void LoadChildrenRecords()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Children", conn);
                conn.Open();
                gvChildren.DataSource = cmd.ExecuteReader();
                gvChildren.DataBind();
            }
        }

        protected void gvChildren_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvChildren.SelectedRow;
            txtChildID.Text = row.Cells[0].Text;
            txtFirstName.Text = row.Cells[1].Text;
            txtLastName.Text = row.Cells[2].Text;
            txtDateOfBirth.Text = row.Cells[3].Text;
            txtGender.Text = row.Cells[4].Text;
            txtOrphanageID.Text = row.Cells[5].Text;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd;
                if (string.IsNullOrEmpty(txtChildID.Text))
                {
                    cmd = new SqlCommand("INSERT INTO Children (first_name, last_name, date_of_birth, gender, orphanage_id) VALUES (@FirstName, @LastName, @DateOfBirth, @Gender, @OrphanageID)", conn);
                }
                else
                {
                    cmd = new SqlCommand("UPDATE Children SET first_name = @FirstName, last_name = @LastName, date_of_birth = @DateOfBirth, gender = @Gender, orphanage_id = @OrphanageID WHERE child_id = @ChildID", conn);
                    cmd.Parameters.AddWithValue("@ChildID", txtChildID.Text);
                }

                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@DateOfBirth", txtDateOfBirth.Text);
                cmd.Parameters.AddWithValue("@Gender", txtGender.Text);
                cmd.Parameters.AddWithValue("@OrphanageID", txtOrphanageID.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                LoadChildrenRecords();
            }
        }
        protected void handleLogout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Crud/Login.aspx");
        }
        public void CreateChild(string email, string username, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Children (email, name, password) VALUES (@Email, @Name, @Password)", conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Name", username);
                cmd.Parameters.AddWithValue("@Password", password);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
