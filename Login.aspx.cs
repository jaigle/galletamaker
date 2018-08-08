using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dlcenter.Hcm.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                FormsAuthentication.Initialize();
                //txtUsuario.Text + "|" + Variables.IdPersonaLoggins + "|" + Variables.IdSociedad Agregar esta linea cuando se agregue becas
                //
                //El metodo AddMinutes determina que tan larga sera la sesion del usuario
                FormsAuthenticationTicket fat = new FormsAuthenticationTicket(
                    1,
                    "admin|0|1",// Agregar esta linea cuando se agregue becas
                    DateTime.Now,
                    DateTime.Now.AddMinutes(Session.Timeout),
                    false,
                    "Administrador Sistemas",//TODO: Definir obtencion de roles, pendiente del modelo de seguridad admin|user
                    FormsAuthentication.FormsCookiePath);
                var cookie = new HttpCookie(
                    FormsAuthentication.FormsCookieName,
                    FormsAuthentication.Encrypt(fat));
                cookie.Domain = ConfigurationManager.AppSettings["cookieDomain"];
                Response.Cookies.Add(cookie);
                Response.Redirect("~/CookieOK.aspx", false);
            }
            catch (Exception ex)
            {
               Response.Redirect("~/Error/Error.aspx", false);
            }
        }
    }
}