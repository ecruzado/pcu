using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Configuration; //ConfigurationManager
using General.Librerias.EntidadesNegocio;

namespace PCU.Librerias.AgentesServicio
{
    public class saListaValores
    {
        public string Archivo { get; set; }
        public string RutaListaValores { get; set; }

        //Constructor
        public saListaValores()
        {
            RutaListaValores = ConfigurationManager.AppSettings["rutaListaValores"];
        }

        public List<beCampo3> listarDeArchivoTxt(string NombreArchivo)
        {
            List<beCampo3> lbeMoneda = null;
            Archivo = String.Format("{0}{1}.txt", RutaListaValores, NombreArchivo);
            if (File.Exists(Archivo))
            {
                using (StreamReader sr = new StreamReader(Archivo, Encoding.Default))
                {
                    string[] moneda;
                    lbeMoneda = new List<beCampo3>();
                    beCampo3 obeMoneda;
                    while (!sr.EndOfStream)
                    {
                        moneda = sr.ReadLine().Split(',');
                        obeMoneda = new beCampo3();
                        obeMoneda.Campo1 = moneda[0];
                        obeMoneda.Campo2 = moneda[1];
                        obeMoneda.Campo3 = moneda[2];
                        lbeMoneda.Add(obeMoneda);
                    }
                }
            }
            return (lbeMoneda);
        }
    }
}
