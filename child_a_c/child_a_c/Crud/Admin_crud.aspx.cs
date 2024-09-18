using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace CAC.Crud
{
    public partial class admin_crud : System.Web.UI.Page
    {
        SqlConnection con;
        DataSet ds;
        DataTable dt;
        SqlDataAdapter da;
        SqlCommandBuilder builder;

        void init()
        {
            con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["Con_Db1"].ConnectionString;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Text = "Enter id";
                retrieve();
            }
        }

        void retrieve()
        {
            try
            {
                init();
                using (con)
                {
                    string command = "Select * from Admins";
                    SqlCommand cmd = new SqlCommand(command, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();
                    rdr.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error in fetching: " + ex.Message);
            }
        }

        void retrieveById()
        {
            try
            {
                init();
                using (con)
                {
                    string command = "Select * from Admins where admin_id = ISNULL(@Id,1)";
                    SqlCommand cmd = new SqlCommand(command, con);
                    if (string.IsNullOrEmpty(TextBox1.Text))
                    {
                        cmd.Parameters.AddWithValue("@Id", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Id", TextBox1.Text);
                    }
                    con.Open();
                    ds = new DataSet();
                    da = new SqlDataAdapter(cmd);
                    builder = new SqlCommandBuilder(da);
                    da.Fill(ds, "Admins");
                    dt = ds.Tables["Admins"];
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error in fetching by id: " + ex.Message);
            }
        }

        void getById()
        {
            retrieveById();
            if (dt != null && dt.Rows.Count > 0)
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
            else
            {
                Response.Write("No data found for the given id.");
            }
        }

        void UpdateById(object sender, EventArgs e)
        {
            try
            {
                init();
                using (con)
                {
                    retrieveById();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        row["username"] = TextBox2.Text;


                        if (da != null && ds != null)
                        {
                            da.Update(ds, "Admins");
                        }

                        GridView3.DataSource = dt;
                        GridView3.DataBind();
                    }
                    else
                    {
                        Response.Write("Row not found for updation");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error in updation: " + ex.Message);
            }
        }

        void DeleteById(object sender, EventArgs e)
        {
            try
            {
                init();
                using (con)
                {
                    retrieveById();
                    int id = 0;
                    if (string.IsNullOrEmpty(TextBox1.Text))
                    {
                        Response.Write("Please enter id which you want to delete");
                    }
                    else
                    {
                        id = int.Parse(TextBox1.Text);
                    }

                    if (dt != null)
                    {
                        DataRow row = dt.AsEnumerable().FirstOrDefault(r => r.Field<int>("admin_id") == id);
                        if (row != null)
                        {
                            row.Delete();
                            Label2.Text = "Deleted successfully";
                            if (da != null && ds != null)
                            {
                                da.Update(ds, "Admins");
                            }
                        }
                        else
                        {
                            Label2.Text = "Row not found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error in deletion: " + ex.Message);
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DeleteById(sender, e);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            UpdateById(sender, e);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            getById();
        }
    }
}
