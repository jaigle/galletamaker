using Dlcenter.Hcm.Bll;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;

namespace Dlcenter.Hcm.Web
{
    /// <summary>
    /// Summary description for Persona
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Persona : System.Web.Services.WebService
    {

        [WebMethod]
        public string changeImage(string idSociedad, string idPersona, string link)
        {
            try {
                Uri uri = new Uri(link);

                string filename = "";
                Guid guid = Guid.NewGuid();
                string name = guid.ToString().Substring(0, 10).Replace("-", "");
                filename = name + System.IO.Path.GetExtension(uri.LocalPath);
                BllInformacionPersonal bi = new BllInformacionPersonal();
                
                bi.updateFoto(Convert.ToInt32(idPersona), Convert.ToInt32(idSociedad), filename);
                
                    
                    string route = this.Context.Request.PhysicalApplicationPath + Constantes.Paths.PhysicalPathAvatarImage + filename;

                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(link, route);
                    }

                    
                

                return "0";
            }
            catch (Exception e) {
                return e.Message;
            }
            

        }
    }
}
