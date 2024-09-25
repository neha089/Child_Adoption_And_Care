using System;
using System.Data.SqlClient;
using System.Configuration;
using child_a_c.Crud;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Crud
{
    public partial class ChildDocuments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            conn.Open();
            cmd.ExecuteNonQuery();
            LoadChildDocuments();
        }
    }
}
