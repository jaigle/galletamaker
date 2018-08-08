using System;
using System.Linq;
using System.Web;
using System.IO;


namespace Dlcenter.Hcm.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {        
            Response.Redirect("Login.aspx", false);
        }
    }
}