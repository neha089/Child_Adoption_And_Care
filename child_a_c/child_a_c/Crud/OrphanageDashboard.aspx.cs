using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace child_a_c.Crud
{
    public partial class OrphanageDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void Logout()
        {
            Session.Clear(); 
            Session.Abandon(); 
            Response.Redirect("Login.aspx");
        }
    
}
}