using PCU.Librerias.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCU.Librerias.AccesoDatos
{
    public class daSistemaMenu
    {
        public List<beSistemaMenu> listar(SqlConnection con)
        {
            List<beSistemaMenu> lbeSistemaMenu = null;
            SqlCommand cmd = new SqlCommand("uspSistemaMenuListar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lbeSistemaMenu = new List<beSistemaMenu>();
                int posSistemaMenuId = drd.GetOrdinal("SistemaMenuId");
                int posCodigoSistemaMenu = drd.GetOrdinal("CodigoSistemaMenu");
                int posNombreSistemaMenu = drd.GetOrdinal("NombreSistemaMenu");
                int posNombreCortoSistemaMenu = drd.GetOrdinal("NombreCortoSistemaMenu");
                int posCodigoMoneda = drd.GetOrdinal("CodigoMoneda");
                int posTarifaSistemaMenu = drd.GetOrdinal("TarifaSistemaMenu");
                int posTarifaMinima = drd.GetOrdinal("TarifaMinima");
                int posTarifaMaxima = drd.GetOrdinal("TarifaMaxima");
                int posURLPagina = drd.GetOrdinal("URLPagina");
                int posCodigoSistemaPadre = drd.GetOrdinal("CodigoSistemaPadre");
                int posEstadoSistemaMenu = drd.GetOrdinal("EstadoSistemaMenu");
                int posColorOpcion = drd.GetOrdinal("ColorOpcion");
                beSistemaMenu obeSistemaMenu;
                while (drd.Read())
                {
                    obeSistemaMenu = new beSistemaMenu();
                    obeSistemaMenu.SistemaMenuId = drd.GetInt32(posSistemaMenuId);
                    obeSistemaMenu.CodigoSistemaMenu = drd.GetString(posCodigoSistemaMenu);
                    obeSistemaMenu.NombreSistemaMenu = drd.GetString(posNombreSistemaMenu);
                    obeSistemaMenu.NombreCortoSistemaMenu = drd.GetString(posNombreCortoSistemaMenu);
                    obeSistemaMenu.CodigoMoneda = drd.GetString(posCodigoMoneda);
                    obeSistemaMenu.TarifaSistemaMenu = drd.GetDecimal(posTarifaSistemaMenu);
                    obeSistemaMenu.TarifaMinima = drd.GetDecimal(posTarifaMinima);
                    obeSistemaMenu.TarifaMaxima = drd.GetDecimal(posTarifaMaxima);
                    obeSistemaMenu.URLPagina = drd.GetString(posURLPagina);
                    obeSistemaMenu.CodigoSistemaPadre = drd.GetString(posCodigoSistemaPadre);
                    obeSistemaMenu.ColorOpcion = drd.GetString(posColorOpcion);
                    obeSistemaMenu.EstadoSistemaMenu = drd.GetString(posEstadoSistemaMenu);
                    lbeSistemaMenu.Add(obeSistemaMenu);
                }
                drd.Close();
            }
            return (lbeSistemaMenu);
        }

        public List<beSistemaMenu> listarPorCodigo(SqlConnection con, string codigoSistema)
        {
            List<beSistemaMenu> lbeSistemaMenu = null;
            SqlCommand cmd = new SqlCommand("uspSistemaMenuListarPorCodigo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par = cmd.Parameters.Add("@CodigoSistemaMenu", SqlDbType.VarChar, 10);
            par.Direction = ParameterDirection.Input;
            par.Value = codigoSistema;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lbeSistemaMenu = new List<beSistemaMenu>();
                int posSistemaMenuId = drd.GetOrdinal("SistemaMenuId");
                int posCodigoSistemaMenu = drd.GetOrdinal("CodigoSistemaMenu");
                int posNombreSistemaMenu = drd.GetOrdinal("NombreSistemaMenu");
                int posNombreCortoSistemaMenu = drd.GetOrdinal("NombreCortoSistemaMenu");
                int posCodigoMoneda = drd.GetOrdinal("CodigoMoneda");
                int posTarifaSistemaMenu = drd.GetOrdinal("TarifaSistemaMenu");
                int posTarifaMinima = drd.GetOrdinal("TarifaMinima");
                int posTarifaMaxima = drd.GetOrdinal("TarifaMaxima");
                int posURLPagina = drd.GetOrdinal("URLPagina");
                int posCodigoSistemaPadre = drd.GetOrdinal("CodigoSistemaPadre");
                int posColorOpcion = drd.GetOrdinal("ColorOpcion");
                beSistemaMenu obeSistemaMenu;
                while (drd.Read())
                {
                    obeSistemaMenu = new beSistemaMenu();
                    obeSistemaMenu.SistemaMenuId = drd.GetInt32(posSistemaMenuId);
                    obeSistemaMenu.CodigoSistemaMenu = drd.GetString(posCodigoSistemaMenu);
                    obeSistemaMenu.NombreSistemaMenu = drd.GetString(posNombreSistemaMenu);
                    obeSistemaMenu.NombreCortoSistemaMenu = drd.GetString(posNombreCortoSistemaMenu);
                    obeSistemaMenu.CodigoMoneda = drd.GetString(posCodigoMoneda);
                    obeSistemaMenu.TarifaSistemaMenu = drd.GetDecimal(posTarifaSistemaMenu);
                    obeSistemaMenu.TarifaMinima = drd.GetDecimal(posTarifaMinima);
                    obeSistemaMenu.TarifaMaxima = drd.GetDecimal(posTarifaMaxima);
                    obeSistemaMenu.URLPagina = drd.GetString(posURLPagina);
                    obeSistemaMenu.CodigoSistemaPadre = drd.GetString(posCodigoSistemaPadre);
                    obeSistemaMenu.ColorOpcion = drd.GetString(posColorOpcion);
                    lbeSistemaMenu.Add(obeSistemaMenu);
                }
                drd.Close();
            }
            return (lbeSistemaMenu);
        }

        public int adicionar(SqlConnection con, beSistemaMenu obeSistemaMenu)
        {
            int codigo = -1;
            SqlCommand cmd = new SqlCommand("uspSistemaMenuAdicionar", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter par1 = cmd.Parameters.Add("@CodigoSistemaMenu", SqlDbType.VarChar, 10);
            par1.Direction = ParameterDirection.Input;
            par1.Value = obeSistemaMenu.CodigoSistemaMenu;
            SqlParameter par2 = cmd.Parameters.Add("@NombreSistemaMenu", SqlDbType.VarChar, 50);
            par2.Direction = ParameterDirection.Input;
            par2.Value = obeSistemaMenu.NombreSistemaMenu;
            SqlParameter par3 = cmd.Parameters.Add("@NombreCortoSistemaMenu", SqlDbType.VarChar, 20);
            par3.Direction = ParameterDirection.Input;
            par3.Value = obeSistemaMenu.NombreCortoSistemaMenu;
            SqlParameter par4 = cmd.Parameters.Add("@CodigoMoneda", SqlDbType.VarChar, 3);
            par4.Direction = ParameterDirection.Input;
            par4.Value = obeSistemaMenu.CodigoMoneda;
            SqlParameter par5 = cmd.Parameters.Add("@TarifaSistemaMenu", SqlDbType.Decimal);
            par5.Direction = ParameterDirection.Input;
            par5.Value = obeSistemaMenu.TarifaSistemaMenu;
            SqlParameter par6 = cmd.Parameters.Add("@TarifaMinima", SqlDbType.Decimal);
            par6.Direction = ParameterDirection.Input;
            par6.Value = obeSistemaMenu.TarifaMinima;
            SqlParameter par7 = cmd.Parameters.Add("@TarifaMaxima", SqlDbType.Decimal);
            par7.Direction = ParameterDirection.Input;
            par7.Value = obeSistemaMenu.TarifaMaxima;
            SqlParameter par8 = cmd.Parameters.Add("@URLPagina", SqlDbType.VarChar, 100);
            par8.Direction = ParameterDirection.Input;
            par8.Value = obeSistemaMenu.URLPagina;
            SqlParameter par9 = cmd.Parameters.Add("@CodigoSistemaPadre", SqlDbType.VarChar, 10);
            par9.Direction = ParameterDirection.Input;
            par9.Value = obeSistemaMenu.CodigoSistemaPadre;
            SqlParameter par10 = cmd.Parameters.Add("@EstadoSistemaMenu", SqlDbType.VarChar, 3);
            par10.Direction = ParameterDirection.Input;
            par10.Value = obeSistemaMenu.EstadoSistemaMenu;
            SqlParameter par11 = cmd.Parameters.Add("@CodigoUsuario", SqlDbType.VarChar, 50);
            par11.Direction = ParameterDirection.Input;
            par11.Value = obeSistemaMenu.CodigoUsuario;
            SqlParameter par12 = cmd.Parameters.Add("@ColorOpcion", SqlDbType.VarChar, 50);
            par12.Direction = ParameterDirection.Input;
            par12.Value = obeSistemaMenu.ColorOpcion;
            SqlParameter par13 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
            par13.Direction = ParameterDirection.ReturnValue;

            int n = cmd.ExecuteNonQuery();
            if (n > 0) codigo = (int)par13.Value;

            return (codigo);
        }

        public bool actualizar(SqlConnection con, beSistemaMenu obeSistemaMenu)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("uspSistemaMenuActualizar", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter par0 = cmd.Parameters.Add("@SistemaMenuId", SqlDbType.Int);
            par0.Direction = ParameterDirection.Input;
            par0.Value = obeSistemaMenu.SistemaMenuId;
            SqlParameter par1 = cmd.Parameters.Add("@CodigoSistemaMenu", SqlDbType.VarChar, 10);
            par1.Direction = ParameterDirection.Input;
            par1.Value = obeSistemaMenu.CodigoSistemaMenu;
            SqlParameter par2 = cmd.Parameters.Add("@NombreSistemaMenu", SqlDbType.VarChar, 50);
            par2.Direction = ParameterDirection.Input;
            par2.Value = obeSistemaMenu.NombreSistemaMenu;
            SqlParameter par3 = cmd.Parameters.Add("@NombreCortoSistemaMenu", SqlDbType.VarChar, 20);
            par3.Direction = ParameterDirection.Input;
            par3.Value = obeSistemaMenu.NombreCortoSistemaMenu;
            SqlParameter par4 = cmd.Parameters.Add("@CodigoMoneda", SqlDbType.VarChar, 3);
            par4.Direction = ParameterDirection.Input;
            par4.Value = obeSistemaMenu.CodigoMoneda;
            SqlParameter par5 = cmd.Parameters.Add("@TarifaSistemaMenu", SqlDbType.Decimal);
            par5.Direction = ParameterDirection.Input;
            par5.Value = obeSistemaMenu.TarifaSistemaMenu;
            SqlParameter par6 = cmd.Parameters.Add("@TarifaMinima", SqlDbType.Decimal);
            par6.Direction = ParameterDirection.Input;
            par6.Value = obeSistemaMenu.TarifaMinima;
            SqlParameter par7 = cmd.Parameters.Add("@TarifaMaxima", SqlDbType.Decimal);
            par7.Direction = ParameterDirection.Input;
            par7.Value = obeSistemaMenu.TarifaMaxima;
            SqlParameter par8 = cmd.Parameters.Add("@URLPagina", SqlDbType.VarChar, 100);
            par8.Direction = ParameterDirection.Input;
            par8.Value = obeSistemaMenu.URLPagina;
            SqlParameter par9 = cmd.Parameters.Add("@CodigoSistemaPadre", SqlDbType.VarChar, 10);
            par9.Direction = ParameterDirection.Input;
            par9.Value = obeSistemaMenu.CodigoSistemaPadre;
            SqlParameter par10 = cmd.Parameters.Add("@EstadoSistemaMenu", SqlDbType.VarChar, 3);
            par10.Direction = ParameterDirection.Input;
            par10.Value = obeSistemaMenu.EstadoSistemaMenu;
            SqlParameter par11 = cmd.Parameters.Add("@CodigoUsuarioModificacion", SqlDbType.VarChar, 50);
            par11.Direction = ParameterDirection.Input;
            par11.Value = obeSistemaMenu.CodigoUsuario;
            SqlParameter par12 = cmd.Parameters.Add("@ColorOpcion", SqlDbType.VarChar, 50);
            par12.Direction = ParameterDirection.Input;
            par12.Value = obeSistemaMenu.ColorOpcion;

            int n = cmd.ExecuteNonQuery();
            exito = (n > 0);

            return (exito);
        }

        public bool anular(SqlConnection con, int sistemaMenuId, string codigoUsuario)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("uspSistemaMenuAnular", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter par1 = cmd.Parameters.Add("@SistemaMenuId", SqlDbType.Int);
            par1.Direction = ParameterDirection.Input;
            par1.Value = sistemaMenuId;
            SqlParameter par2 = cmd.Parameters.Add("@CodigoUsuarioModificacion", SqlDbType.VarChar, 50);
            par2.Direction = ParameterDirection.Input;
            par2.Value = codigoUsuario;

            int n = cmd.ExecuteNonQuery();
            exito = (n > 0);

            return (exito);
        }

    }
}
