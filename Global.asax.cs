using System;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Routing;
using System.Web.Security;

namespace Dlcenter.Hcm.Web
{
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// Global variable almacen sociedad.
        /// </summary>
        
        /// <summary>
        /// Global variable almacena id de menu lateral.
        /// </summary>
        static int? idMenuVerticalPadre = null;

        /// <summary>
        /// Get o set de Sociedad global
        /// </summary>
        

        /// <summary>
        /// Get or set Id Menu vertical
        /// </summary>
        public static int? IdMenuVerticalPadre
        {
            get
            {
                return idMenuVerticalPadre;
            }
            set
            {
                idMenuVerticalPadre = value;
            }
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("TablasSecurity",
                "gop/Administracion/Tabla/Security/{entity}", "~/GOP/Administracion/AbstracTableEditor.aspx");

            routes.MapPageRoute("DialogTablas",
                "gop/Administracion/dialog/{entity}", "~/GOP/Administracion/dialog/AbstracTableEditor.aspx");

            routes.MapPageRoute("Tablas",
                "gop/Administracion/Tabla/{entity}", "~/GOP/Administracion/AbstracTableEditor.aspx");

            routes.MapPageRoute("PersonaEstudios",
                "gop/personas/estudios", "~/GOP/Personas/Estudios.aspx");

            routes.MapPageRoute("InformacionBasica",
                "gop/personas/informacion_basica", "~/GOP/Personas/InformacionBasica.aspx");
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
 
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest()
        {
            System.Console.Write(Request.Url);
            
            //Fires upon attempting to authenticate the use
            if (!(HttpContext.Current.User == null))
            {               
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity.GetType() == typeof(FormsIdentity))
                    {
                        FormsIdentity fi = (FormsIdentity)HttpContext.Current.User.Identity;
                        FormsAuthenticationTicket fat = fi.Ticket;

                        String[] astrRoles = fat.UserData.Split('|');
                        HttpContext.Current.User = new GenericPrincipal(fi, astrRoles);
                    }
                }
            }
        }

        protected void Application_AuthorizeRequest()
        {

        }

        protected void Application_ResolveRequestCache()
        {
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            
            Session["MenuArmado"] = false;
            Uri uri = Request.Url;
            string[] arrUri = uri.Host.Split('.');

            
        }

        protected void Application_AcquireRequestState()
        {
        }

        protected void Application_PreRequestHandlerExecute()
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
           
        }

        protected void Application_PostRequestHandlerExecute()
        {
        }

        protected void Application_ReleaseRequestState()
        {
        }

        protected void Application_UpdateRequestCache()
        {
        }

        protected void Application_EndRequest()
        {
            System.Web.UI.Page page = System.Web.HttpContext.Current.Handler as System.Web.UI.Page;
            if (page != null)
            {

                page.PreRender += new EventHandler(PagePreRender);

            }
        }

        void PagePreRender(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
 
        }

        protected void Application_Disposed()
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }

        protected void Application_Init()
        {
        }

        protected void Applcation_PreSendRequestHeaders()
        {
        }

        protected void Application_PreSendContent()
        {
        }
    }
}