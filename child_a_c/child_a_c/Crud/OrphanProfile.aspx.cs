using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace child_a_c.Crud
{
    public partial class OrphanProfile : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!User.Identity.IsAuthenticated)
                {
                    Response.Redirect("~/Crud/Login.aspx");
                }

                LoadOrphanageProfile();
            }
        }

        private void LoadOrphanageProfile()
        {
            // Retrieve orphanage details from Session
            lblName.Text = Session["OrphanageName"]?.ToString() ?? "N/A";
            lblAddress.Text = Session["OrphanageAddress"]?.ToString() ?? "N/A";
            lblPhoneNumber.Text = Session["OrphanagePhone"]?.ToString() ?? "N/A";
            lblEmail.Text = Session["OrphanageEmail"]?.ToString() ?? "N/A";
            lblContactPerson.Text = Session["OrphanageContactPerson"]?.ToString() ?? "N/A";
            lblCapacity.Text = Session["OrphanageCapacity"]?.ToString() ?? "N/A";
            lblNumberOfChildren.Text = Session["OrphanageNumberOfChildren"]?.ToString() ?? "N/A";
            lblLicenseNumber.Text = Session["OrphanageLicenseNumber"]?.ToString() ?? "N/A";
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditOrphanage.aspx"); // Redirect to a page where they can edit their profile
        }
    }
}
