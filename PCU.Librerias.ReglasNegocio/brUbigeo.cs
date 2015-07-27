using System;
using System.Collections.Generic; //List
using System.Data.SqlClient; //SqlConnection
using PCU.Librerias.EntidadesNegocio; //beSistemaMenu
using PCU.Librerias.AccesoDatos; //daSistemaMenu
using General.Librerias.CodigoUsuario; //ucObjeto

namespace PCU.Librerias.ReglasNegocio
{
    public class brUbigeo : brGeneral
    {
        public List<beUbigeo> listar()
        {
            List<beUbigeo> lbeUbigeo = null;
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                try
                {
                    con.Open();
                    daUbigeo odaUbigeo = new daUbigeo();
                    lbeUbigeo = odaUbigeo.listar(con);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError err in ex.Errors)
                    {
                        ucObjeto<SqlError>.grabarArchivoTexto(err, Archivo);
                    }
                }
            }
            return (lbeUbigeo);
        }
    }
}
