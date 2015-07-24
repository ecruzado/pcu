using General.Librerias.CodigoUsuario;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCU.Librerias.ReglasNegocio
{
    public class brGeneral
    {
        //Propiedad
        public string Conexion { get; set; }
        public string Archivo { get; set; }
        private string rutaLog;

        //Constructor
        public brGeneral()
        {
            Conexion = ConfigurationManager.ConnectionStrings["conDesarrollo"].ConnectionString;
            rutaLog = ConfigurationManager.AppSettings["rutaLog"];
            Archivo = String.Format("{0}{1}", rutaLog, ucCadena.fomatoAMD("LogError", ".txt"));
        }
    }
}
