using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Validator
{
    public partial class Validator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Check if all validation controls passed
            if (Page.IsValid)
            {
                // Display a success message if the form is valid
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Your submission was successful!');", true);
            }
            else
            {
                // Display an error message if the form is not valid
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please review the errors and correct them before submitting again.');", true);
            }
        }

    }
}