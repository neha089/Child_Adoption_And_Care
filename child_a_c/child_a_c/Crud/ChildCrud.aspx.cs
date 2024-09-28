using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace Crud
{
    public partial class Children : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadChildren();
            }
        }

        private void LoadChildren()
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
            txtAdopterID.Text = row.Cells[6].Text;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database1"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd;
                if (string.IsNullOrEmpty(txtChildID.Text))
                {
                    cmd = new SqlCommand("INSERT INTO Children (first_name, last_name, date_of_birth, gender, orphanage_id, adopter_id) VALUES (@FirstName, @LastName, @DateOfBirth, @Gender, @OrphanageID, @AdopterID)", conn);
                }
                else
                {
                    cmd = new SqlCommand("UPDATE Children SET first_name = @FirstName, last_name = @LastName, date_of_birth = @DateOfBirth, gender = @Gender, orphanage_id = @OrphanageID, adopter_id = @AdopterID WHERE child_id = @ChildID", conn);
                    cmd.Parameters.AddWithValue("@ChildID", txtChildID.Text);
                }

                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@DateOfBirth", txtDateOfBirth.Text);
                cmd.Parameters.AddWithValue("@Gender", txtGender.Text);
                cmd.Parameters.AddWithValue("@OrphanageID", txtOrphanageID.Text);
                cmd.Parameters.AddWithValue("@AdopterID", txtAdopterID.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                LoadChildren();
            }
        }
    }
}
