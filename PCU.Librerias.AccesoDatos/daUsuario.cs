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
    public class daUsuario
    {
        public beUsuario validarLogin(SqlConnection con, string usuario, string clave)
        {
            beUsuario obeUsuario = null;
            SqlCommand cmd = new SqlCommand("uspUsuarioValidarLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter par1 = cmd.Parameters.Add("@CodigoUsuario", SqlDbType.VarChar, 50);
            par1.Direction = ParameterDirection.Input;
            par1.Value = usuario;

            SqlParameter par2 = cmd.Parameters.Add("@ContrasenaUsuario", SqlDbType.VarChar, 50);
            par2.Direction = ParameterDirection.Input;
            par2.Value = clave;

            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleRow);
            if (drd != null)
            {
                int posUsuarioId = drd.GetOrdinal("UsuarioId");
                int posPersonaId = drd.GetOrdinal("PersonaId");
                int posApellidoPaterno = drd.GetOrdinal("ApellidoPaterno");
                int posApellidoMaterno = drd.GetOrdinal("ApellidoMaterno");
                int posNombreRazonSocial = drd.GetOrdinal("NombreRazonSocial");
                int posCorreoElectronico = drd.GetOrdinal("CorreoElectronico");
                int posCodigoUsuario = drd.GetOrdinal("CodigoUsuario");
                int posNombrePreferidoUsuario = drd.GetOrdinal("NombrePreferidoUsuario");
                int posClienteId = drd.GetOrdinal("ClienteId");
                int posNombreCliente = drd.GetOrdinal("NombreCliente");
                int posClienteSucursalId = drd.GetOrdinal("ClienteSucursalId");
                int posNombreSucursal = drd.GetOrdinal("NombreSucursal");
                int posIndicadorVisualizaSedes = drd.GetOrdinal("IndicadorVisualizaSedes");
                int posTipoEstiloWeb = drd.GetOrdinal("TipoEstiloWeb");
                int posTiempoExpiracionSesion = drd.GetOrdinal("TiempoExpiracionSesion");
                int posEstadoUsuario = drd.GetOrdinal("EstadoUsuario");
                if (drd.HasRows)
                {
                    obeUsuario = new beUsuario();
                    drd.Read();
                    obeUsuario.UsuarioId = drd.GetInt32(posUsuarioId);
                    obeUsuario.PersonaId = drd.GetInt32(posPersonaId);
                    obeUsuario.ApellidoPaterno = drd.GetString(posApellidoPaterno);
                    obeUsuario.ApellidoMaterno = drd.GetString(posApellidoMaterno);
                    obeUsuario.NombreRazonSocial = drd.GetString(posNombreRazonSocial);
                    obeUsuario.CorreoElectronico = drd.GetString(posCorreoElectronico);
                    obeUsuario.CodigoUsuario = drd.GetString(posCodigoUsuario);
                    obeUsuario.NombrePreferidoUsuario = drd.GetString(posNombrePreferidoUsuario);
                    obeUsuario.ClienteId = drd.GetInt32(posClienteId);
                    obeUsuario.NombreCliente = drd.GetString(posNombreCliente);
                    obeUsuario.ClienteSucursalId = drd.GetInt32(posClienteSucursalId);
                    obeUsuario.NombreSucursal = drd.GetString(posNombreSucursal);
                    obeUsuario.IndicadorVisualizaSedes = drd.GetString(posIndicadorVisualizaSedes);
                    obeUsuario.TipoEstiloWeb = drd.GetString(posTipoEstiloWeb);
                    obeUsuario.TiempoExpiracionSesion = drd.GetInt32(posTiempoExpiracionSesion);
                    obeUsuario.EstadoUsuario = drd.GetString(posEstadoUsuario);
                }
                drd.Close();
            }
            return (obeUsuario);
        }

        public bool actualizarClave(SqlConnection con, int usuarioId, string contrasenaAnterior, string contrasenaNueva)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("uspUsuarioActualizarClave", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter par1 = cmd.Parameters.Add("@UsuarioId", SqlDbType.Int);
            par1.Direction = ParameterDirection.Input;
            par1.Value = usuarioId;

            SqlParameter par2 = cmd.Parameters.Add("@ContrasenaAnterior", SqlDbType.VarChar, 50);
            par2.Direction = ParameterDirection.Input;
            par2.Value = contrasenaAnterior;

            SqlParameter par3 = cmd.Parameters.Add("@ContrasenaNueva", SqlDbType.VarChar, 50);
            par3.Direction = ParameterDirection.Input;
            par3.Value = contrasenaNueva;

            int n = cmd.ExecuteNonQuery();
            exito = (n > 0);

            return (exito);
        }

        public bool actualizarConfiguracion(SqlConnection con, int usuarioId, string nombrePreferidoUsuario, string tipoEstiloWeb, int tiempoExpiracionSesion)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("uspUsuarioActualizarConfiguracion", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter par1 = cmd.Parameters.Add("@UsuarioId", SqlDbType.Int);
            par1.Direction = ParameterDirection.Input;
            par1.Value = usuarioId;

            SqlParameter par2 = cmd.Parameters.Add("@NombrePreferidoUsuario", SqlDbType.VarChar, 50);
            par2.Direction = ParameterDirection.Input;
            par2.Value = nombrePreferidoUsuario;

            SqlParameter par3 = cmd.Parameters.Add("@TipoEstiloWeb", SqlDbType.VarChar, 3);
            par3.Direction = ParameterDirection.Input;
            par3.Value = tipoEstiloWeb;

            SqlParameter par4 = cmd.Parameters.Add("@TiempoExpiracionSesion", SqlDbType.Int);
            par4.Direction = ParameterDirection.Input;
            par4.Value = tiempoExpiracionSesion;

            int n = cmd.ExecuteNonQuery();
            exito = (n > 0);

            return (exito);
        }
    }

}
