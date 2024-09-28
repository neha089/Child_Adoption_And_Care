using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace child_a_c.Crud
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void signupButton_Click(object sender, EventArgs e)
        {
            
            string UserType = userType.SelectedValue;
            string Username = username.Text;
            string Password = password.Text;
            string Email = email.Text;
            OrphanageCrud orphanageCrud = new OrphanageCrud();
            orphanageCrud.CreateOrphanage(Email, Username, Password);

        }
    }
}