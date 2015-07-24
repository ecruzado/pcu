using General.Librerias.CodigoUsuario;
using PCU.Librerias.AccesoDatos;
using PCU.Librerias.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCU.Librerias.ReglasNegocio
{
    public class brUsuario : brGeneral
    {
        public beUsuario validarLogin(string usuario, string clave)
        {
            beUsuario obeUsuario = null;
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                try
                {
                    con.Open();
                    daUsuario odaUsuario = new daUsuario();
                    obeUsuario = odaUsuario.validarLogin(con, usuario, clave);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError err in ex.Errors)
                    {
                        ucObjeto<SqlError>.grabarArchivoTexto(err, Archivo);
                    }
                }
                catch (Exception ex)
                {
                    ucObjeto<Exception>.grabarArchivoTexto(ex, Archivo);
                }
            }
            return (obeUsuario);
        }

        public bool actualizarClave(int usuarioId, string contrasenaAnterior, string contrasenaNueva)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                try
                {
                    con.Open();
                    daUsuario odaUsuario = new daUsuario();
                    exito = odaUsuario.actualizarClave(con, usuarioId, contrasenaAnterior, contrasenaNueva);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError err in ex.Errors)
                    {
                        ucObjeto<SqlError>.grabarArchivoTexto(err, Archivo);
                    }
                }
                catch (Exception ex)
                {
                    ucObjeto<Exception>.grabarArchivoTexto(ex, Archivo);
                }
            }
            return (exito);
        }

        public bool actualizarConfiguracion(int usuarioId, string nombrePreferidoUsuario, string tipoEstiloWeb, int tiempoExpiracionSesion)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                try
                {
                    con.Open();
                    daUsuario odaUsuario = new daUsuario();
                    exito = odaUsuario.actualizarConfiguracion(con, usuarioId, nombrePreferidoUsuario, tipoEstiloWeb, tiempoExpiracionSesion);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError err in ex.Errors)
                    {
                        ucObjeto<SqlError>.grabarArchivoTexto(err, Archivo);
                    }
                }
                catch (Exception ex)
                {
                    ucObjeto<Exception>.grabarArchivoTexto(ex, Archivo);
                }
            }
            return (exito);
        }
    }
}
