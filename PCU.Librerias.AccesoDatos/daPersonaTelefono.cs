using System;
using System.Data; //CommadType
using System.Data.SqlClient; //SqlConnection, SqlCommand, SqlDataReader
using System.Collections.Generic; //List
using PCU.Librerias.EntidadesNegocio; //bePersonaTelefono
using General.Librerias.EntidadesNegocio;

namespace PCU.Librerias.AccesoDatos
{
    public class daPersonaTelefono
    {
        public List<bePersonaTelefono> obtenerPorIdPersona(SqlConnection con, int personaId)
        {
            List<bePersonaTelefono> lbePersonaTelefono = null;
            SqlCommand cmd = new SqlCommand("uspPersonaTelefonoObtenerPorIdPersona", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter par1 = cmd.Parameters.Add("@PersonaId", SqlDbType.Int);
            par1.Direction = ParameterDirection.Input;
            par1.Value = personaId;

            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lbePersonaTelefono = new List<bePersonaTelefono>();
                int posPersonaTelefonoId = drd.GetOrdinal("PersonaTelefonoId");
                int posPersonaId = drd.GetOrdinal("PersonaId");
                int posNumeroTelefono = drd.GetOrdinal("NumeroTelefono");
                int posTipoTelefono = drd.GetOrdinal("TipoTelefono");
                int posOperadorTelefono = drd.GetOrdinal("OperadorTelefono");
                int posNumeroAnexo = drd.GetOrdinal("NumeroAnexo");
                int posEstadoPersonaTelefono = drd.GetOrdinal("EstadoPersonaTelefono");
                int posFechaHoraCreacion = drd.GetOrdinal("FechaHoraCreacion");
                int posCodigoUsuarioCreador = drd.GetOrdinal("CodigoUsuarioCreador");
                int posFechaHoraModificacion = drd.GetOrdinal("FechaHoraModificacion");
                int posCodigoUsuarioModificacion = drd.GetOrdinal("CodigoUsuarioModificacion");

                bePersonaTelefono obePersonaTelefono;
                while (drd.Read())
                {
                    obePersonaTelefono = new bePersonaTelefono();
                    obePersonaTelefono.PersonaTelefonoId = drd.GetInt32(posPersonaTelefonoId);
                    obePersonaTelefono.PersonaId = drd.GetInt32(posPersonaId);
                    obePersonaTelefono.NumeroTelefono = drd.GetString(posNumeroTelefono);
                    obePersonaTelefono.IdTipoTelefono = drd.GetString(posTipoTelefono);
                    obePersonaTelefono.IdOperadorTelefono = drd.GetString(posOperadorTelefono);
                    obePersonaTelefono.NumeroAnexo = drd.GetString(posNumeroAnexo);
                    obePersonaTelefono.EstadoPersonaTelefono = drd.GetString(posEstadoPersonaTelefono);
                    obePersonaTelefono.FechaHoraCreacion = drd.GetDateTime(posFechaHoraCreacion);
                    obePersonaTelefono.CodigoUsuarioCreador = drd.GetString(posCodigoUsuarioCreador);
                    obePersonaTelefono.FechaHoraModificacion = drd.GetDateTime(posFechaHoraModificacion);
                    obePersonaTelefono.CodigoUsuarioModificacion = drd.GetString(posCodigoUsuarioModificacion);
                    lbePersonaTelefono.Add(obePersonaTelefono);
                }
                drd.Close();
            }
            return (lbePersonaTelefono);
        }

        public bool adicionar(SqlTransaction trx, SqlConnection con, bePersonaTelefono obePersonaTelefono)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("uspPersonaTelefonoAdicionar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Transaction = trx;

            SqlParameter par1 = cmd.Parameters.Add("@PersonaId", SqlDbType.Int);
            par1.Direction = ParameterDirection.Input;
            par1.Value = obePersonaTelefono.PersonaId;

            SqlParameter par2 = cmd.Parameters.Add("@NumeroTelefono", SqlDbType.VarChar, 15);
            par2.Direction = ParameterDirection.Input;
            par2.Value = obePersonaTelefono.NumeroTelefono;

            SqlParameter par3 = cmd.Parameters.Add("@TipoTelefono", SqlDbType.VarChar, 2);
            par3.Direction = ParameterDirection.Input;
            par3.Value = obePersonaTelefono.IdTipoTelefono;

            SqlParameter par4 = cmd.Parameters.Add("@OperadorTelefono", SqlDbType.VarChar, 2);
            par4.Direction = ParameterDirection.Input;
            par4.Value = obePersonaTelefono.IdOperadorTelefono;

            SqlParameter par5 = cmd.Parameters.Add("@NumeroAnexo", SqlDbType.VarChar, 7);
            par5.Direction = ParameterDirection.Input;
            par5.Value = obePersonaTelefono.NumeroAnexo;

            SqlParameter par6 = cmd.Parameters.Add("@EstadoPersonaTelefono", SqlDbType.VarChar, 3);
            par6.Direction = ParameterDirection.Input;
            par6.Value = obePersonaTelefono.EstadoPersonaTelefono;

            SqlParameter par7 = cmd.Parameters.Add("@CodigoUsuarioCreador", SqlDbType.VarChar, 50);
            par7.Direction = ParameterDirection.Input;
            par7.Value = obePersonaTelefono.CodigoUsuarioCreador;

            SqlParameter par8 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
            par8.Direction = ParameterDirection.ReturnValue;

            int n = cmd.ExecuteNonQuery();
            exito = (n > 0);
            return (exito);
        }

        public bool actualizar(SqlTransaction trx, SqlConnection con, bePersonaTelefono obePersonaTelefono)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("uspPersonaTelefonoActualizar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Transaction = trx;

            SqlParameter par0 = cmd.Parameters.Add("@PersonaTelefonoId", SqlDbType.Int);
            par0.Direction = ParameterDirection.Input;
            par0.Value = obePersonaTelefono.PersonaTelefonoId;

            SqlParameter par1 = cmd.Parameters.Add("@PersonaId", SqlDbType.Int);
            par1.Direction = ParameterDirection.Input;
            par1.Value = obePersonaTelefono.PersonaId;

            SqlParameter par2 = cmd.Parameters.Add("@NumeroTelefono", SqlDbType.VarChar, 15);
            par2.Direction = ParameterDirection.Input;
            par2.Value = obePersonaTelefono.NumeroTelefono;

            SqlParameter par3 = cmd.Parameters.Add("@TipoTelefono", SqlDbType.VarChar, 2);
            par3.Direction = ParameterDirection.Input;
            par3.Value = obePersonaTelefono.IdTipoTelefono;

            SqlParameter par4 = cmd.Parameters.Add("@OperadorTelefono", SqlDbType.VarChar, 2);
            par4.Direction = ParameterDirection.Input;
            par4.Value = obePersonaTelefono.IdOperadorTelefono;

            SqlParameter par5 = cmd.Parameters.Add("@NumeroAnexo", SqlDbType.VarChar, 7);
            par5.Direction = ParameterDirection.Input;
            par5.Value = obePersonaTelefono.NumeroAnexo;

            SqlParameter par6 = cmd.Parameters.Add("@EstadoPersonaTelefono", SqlDbType.VarChar, 3);
            par6.Direction = ParameterDirection.Input;
            par6.Value = obePersonaTelefono.EstadoPersonaTelefono;

            SqlParameter par7 = cmd.Parameters.Add("@CodigoUsuarioModificacion", SqlDbType.VarChar, 50);
            par7.Direction = ParameterDirection.Input;
            par7.Value = obePersonaTelefono.CodigoUsuarioModificacion;

            int n = cmd.ExecuteNonQuery();
            exito = (n > 0);
            return (exito);
        }

        public bool eliminar(SqlConnection con, beCampo3 obePersonaTelefono)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("uspPersonaTelefonoEliminar", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter par1 = cmd.Parameters.Add("@PersonaTelefonoId", SqlDbType.Int);
            par1.Direction = ParameterDirection.Input;
            par1.Value = int.Parse(obePersonaTelefono.Campo1);

            SqlParameter par2 = cmd.Parameters.Add("@EstadoPersonaTelefono", SqlDbType.VarChar, 3);
            par2.Direction = ParameterDirection.Input;
            par2.Value = obePersonaTelefono.Campo2;

            SqlParameter par3 = cmd.Parameters.Add("@CodigoUsuarioModificacion", SqlDbType.VarChar, 50);
            par3.Direction = ParameterDirection.Input;
            par3.Value = obePersonaTelefono.Campo3;

            int n = cmd.ExecuteNonQuery();
            exito = (n > 0);
            return (exito);
        }
    }
}
