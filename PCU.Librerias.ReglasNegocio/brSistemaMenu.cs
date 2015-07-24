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
    public class brSistemaMenu : brGeneral
    {
        public List<beSistemaMenu> listar()
        {
            List<beSistemaMenu> lbeSistemaMenu = null;
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                try
                {
                    con.Open();
                    daSistemaMenu odaSistemaMenu = new daSistemaMenu();
                    lbeSistemaMenu = odaSistemaMenu.listar(con);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError err in ex.Errors)
                    {
                        ucObjeto<SqlError>.grabarArchivoTexto(err, Archivo);
                    }
                }
            }
            return (lbeSistemaMenu);
        }

        public List<beSistemaMenu> listarPorCodigo(string codigoSistema)
        {
            List<beSistemaMenu> lbeSistemaMenu = null;
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                try
                {
                    con.Open();
                    daSistemaMenu odaSistemaMenu = new daSistemaMenu();
                    lbeSistemaMenu = odaSistemaMenu.listarPorCodigo(con, codigoSistema);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError err in ex.Errors)
                    {
                        ucObjeto<SqlError>.grabarArchivoTexto(err, Archivo);
                    }
                }
            }
            return (lbeSistemaMenu);
        }

        public int adicionar(beSistemaMenu obeSistemaMenu)
        {
            int codigo = -1;
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                try
                {
                    con.Open();
                    daSistemaMenu odaSistemaMenu = new daSistemaMenu();
                    codigo = odaSistemaMenu.adicionar(con, obeSistemaMenu);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError err in ex.Errors)
                    {
                        ucObjeto<SqlError>.grabarArchivoTexto(err, Archivo);
                    }
                }
            }
            return (codigo);
        }

        public bool actualizar(beSistemaMenu obeSistemaMenu)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                try
                {
                    con.Open();
                    daSistemaMenu odaSistemaMenu = new daSistemaMenu();
                    exito = odaSistemaMenu.actualizar(con, obeSistemaMenu);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError err in ex.Errors)
                    {
                        ucObjeto<SqlError>.grabarArchivoTexto(err, Archivo);
                    }
                }
            }
            return (exito);
        }

        public bool anular(int sistemaMenuId, string codigoUsuario)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                try
                {
                    con.Open();
                    daSistemaMenu odaSistemaMenu = new daSistemaMenu();
                    exito = odaSistemaMenu.anular(con, sistemaMenuId, codigoUsuario);
                }
                catch (SqlException ex)
                {
                    foreach (SqlError err in ex.Errors)
                    {
                        ucObjeto<SqlError>.grabarArchivoTexto(err, Archivo);
                    }
                }
            }
            return (exito);
        }
    }

}
