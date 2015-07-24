using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //File
using System.Web; //HttpContext

namespace General.Librerias.CodigoUsuarioWeb
{
    public class Imagen
    {
        public static string obtenerUrl(int id, string carpeta)
        {
            string archivo = HttpContext.Current.Server.MapPath(String.Format("~/Imagenes/{0}/{1}.jpg", carpeta, id));
            string url = String.Format("../Imagenes/{0}/{1}.jpg?tiempo=" + DateTime.Now.Ticks, carpeta, id);
            if (!File.Exists(archivo)) url = String.Format("../Imagenes/{0}/No.jpg", carpeta);
            return (url);
        }

        public static string obtenerUrl(string id, string carpeta)
        {
            string archivo = HttpContext.Current.Server.MapPath(String.Format("~/Imagenes/{0}/{1}.jpg", carpeta, id));
            string url = String.Format("../Imagenes/{0}/{1}.jpg?tiempo=" + DateTime.Now.Ticks, carpeta, id);
            if (!File.Exists(archivo)) url = String.Format("../Imagenes/{0}/No.jpg", carpeta);
            return (url);
        }
    }
}
