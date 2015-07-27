using System;
using System.Data; //CommandType
using System.Data.SqlClient; //SqlConnection, SqlCommand, SqlDataReader
using System.Collections.Generic; //List
using General.Librerias.EntidadesNegocio; //beCampo
using PCU.Librerias.EntidadesNegocio; //bePersonaGrid

namespace PCU.Librerias.AccesoDatos
{
    public class daPersona
    {
        public beCampo2 obtenerUsuarioPorCorreo(SqlConnection con, string correoElectronico, string contrasenaUsuario)
        {
            beCampo2 obeCampo = null;
            SqlCommand cmd = new SqlCommand("uspPersonaObtenerUsuarioPorCorreo", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter par1 = cmd.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar, 100);
            par1.Direction = ParameterDirection.Input;
            par1.Value = correoElectronico;

            SqlParameter par2 = cmd.Parameters.Add("@ContrasenaUsuario", SqlDbType.VarChar, 50);
            par2.Direction = ParameterDirection.Input;
            par2.Value = contrasenaUsuario;

            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleRow);
            if (drd != null)
            {
                int posNombreRazonSocial = drd.GetOrdinal("NombreRazonSocial");
                int posCodigoUsuario = drd.GetOrdinal("CodigoUsuario");
                if (drd.HasRows)
                {
                    obeCampo = new beCampo2();
                    drd.Read();
                    obeCampo.Campo1 = drd.GetString(posNombreRazonSocial);
                    obeCampo.Campo2 = drd.GetString(posCodigoUsuario);
                }
                drd.Close();
            }
            return (obeCampo);
        }

        public List<bePersonaGrid> listarGrid(SqlConnection con)
        {
            List<bePersonaGrid> lbePersona = null;

            SqlCommand cmd = new SqlCommand("uspPersonaListarGrid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                int posPersonaId = drd.GetOrdinal("PersonaId");
                int posNombreRazonSocial = drd.GetOrdinal("NombreRazonSocial");
                int posApellidoPaterno = drd.GetOrdinal("ApellidoPaterno");
                int posApellidoMaterno = drd.GetOrdinal("ApellidoMaterno");
                int posTipoDocumento = drd.GetOrdinal("TipoDocumento");
                int posNumeroDocumento = drd.GetOrdinal("NumeroDocumento");
                int posIndicadorCliente = drd.GetOrdinal("IndicadorCliente");
                int posEstadoPersona = drd.GetOrdinal("EstadoPersona");
                lbePersona = new List<bePersonaGrid>();
                bePersonaGrid obePersonaGrid;
                while (drd.Read())
                {
                    obePersonaGrid = new bePersonaGrid();
                    obePersonaGrid.PersonaId = drd.GetInt32(posPersonaId);
                    obePersonaGrid.NombreRazonSocial = drd.GetString(posNombreRazonSocial);
                    obePersonaGrid.ApellidoPaterno = drd.GetString(posApellidoPaterno);
                    obePersonaGrid.ApellidoMaterno = drd.GetString(posApellidoMaterno);
                    obePersonaGrid.TipoDocumento = drd.GetString(posTipoDocumento);
                    obePersonaGrid.NumeroDocumento = drd.GetString(posNumeroDocumento);
                    obePersonaGrid.IndicadorCliente = drd.GetBoolean(posIndicadorCliente);
                    obePersonaGrid.EstadoPersona = drd.GetString(posEstadoPersona);
                    lbePersona.Add(obePersonaGrid);
                }
                drd.Close();
            }

            return (lbePersona);
        }

        //Creado por Arturo
        public bePersona obtenerPorId(SqlConnection con, int personaId)
        {
            bePersona obePersona = null;
            SqlCommand cmd = new SqlCommand("uspPersonaObtenerPorId", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter par1 = cmd.Parameters.Add("@PersonaId", SqlDbType.Int);
            par1.Direction = ParameterDirection.Input;
            par1.Value = personaId;

            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                int posPersonaId = drd.GetOrdinal("PersonaId");
                int posNombreRazonSocial = drd.GetOrdinal("NombreRazonSocial");
                int posApellidoPaterno = drd.GetOrdinal("ApellidoPaterno");
                int posApellidoMaterno = drd.GetOrdinal("ApellidoMaterno");
                int posTipoPersona = drd.GetOrdinal("TipoPersona");
                int posTipoDocumento = drd.GetOrdinal("TipoDocumento");
                int posNumeroDocumento = drd.GetOrdinal("NumeroDocumento");
                int posFechaNacimiento = drd.GetOrdinal("FechaNacimiento");
                int posSexo = drd.GetOrdinal("Sexo");
                int posEstadoCivil = drd.GetOrdinal("EstadoCivil");
                int posTipoVia = drd.GetOrdinal("TipoVia");
                int posNombreVia = drd.GetOrdinal("NombreVia");
                int posNumeroVia = drd.GetOrdinal("NumeroVia");
                int posInterior = drd.GetOrdinal("Interior");
                int posTipoZona = drd.GetOrdinal("TipoZona");
                int posNombreZona = drd.GetOrdinal("NombreZona");
                int posReferenciaDireccion = drd.GetOrdinal("ReferenciaDireccion");
                int posDireccion = drd.GetOrdinal("Direccion");
                int posUbigeoId = drd.GetOrdinal("UbigeoId");
                int posCorreoElectronico = drd.GetOrdinal("CorreoElectronico");
                int posPaginaWeb = drd.GetOrdinal("PaginaWeb");
                int posIndicadorPublicidad = drd.GetOrdinal("IndicadorPublicidad");
                int posIndicadorCliente = drd.GetOrdinal("IndicadorCliente");
                int posIndicadorUsuario = drd.GetOrdinal("IndicadorUsuario");
                int posIndicadorContacto = drd.GetOrdinal("IndicadorContacto");
                int posEstadoPersona = drd.GetOrdinal("EstadoPersona");
                int posFechaHoraCreacion = drd.GetOrdinal("FechaHoraCreacion");
                int posCodigoUsuarioCreador = drd.GetOrdinal("CodigoUsuarioCreador");
                int posFechaHoraModificacion = drd.GetOrdinal("FechaHoraModificacion");
                int posCodigoUsuarioModificacion = drd.GetOrdinal("CodigoUsuarioModificacion");
                drd.Read();
                obePersona = new bePersona();
                obePersona.PersonaId = drd.GetInt32(posPersonaId);
                obePersona.NombreRazonSocial = drd.GetString(posNombreRazonSocial);
                obePersona.ApellidoPaterno = drd.GetString(posApellidoPaterno);
                obePersona.ApellidoMaterno = drd.GetString(posApellidoMaterno);
                obePersona.TipoPersona = drd.GetString(posTipoPersona);
                obePersona.TipoDocumento = drd.GetString(posTipoDocumento);
                obePersona.NumeroDocumento = drd.GetString(posNumeroDocumento);
                obePersona.FechaNacimiento = drd.GetDateTime(posFechaNacimiento);
                obePersona.Sexo = drd.GetString(posSexo);
                obePersona.EstadoCivil = drd.GetString(posEstadoCivil);
                obePersona.TipoVia = drd.GetString(posTipoVia);
                obePersona.NombreVia = drd.GetString(posNombreVia);
                obePersona.NumeroVia = drd.GetString(posNumeroVia);
                obePersona.Interior = drd.GetString(posInterior);
                obePersona.TipoZona = drd.GetString(posTipoZona);
                obePersona.NombreZona = drd.GetString(posNombreZona);
                obePersona.ReferenciaDireccion = drd.GetString(posReferenciaDireccion);
                obePersona.Direccion = drd.GetString(posDireccion);
                obePersona.UbigeoId = drd.GetInt32(posUbigeoId);
                obePersona.CorreoElectronico = drd.GetString(posCorreoElectronico);
                obePersona.PaginaWeb = drd.GetString(posPaginaWeb);
                obePersona.IndicadorPublicidad = drd.GetBoolean(posIndicadorPublicidad);
                obePersona.IndicadorCliente = drd.GetBoolean(posIndicadorCliente);
                obePersona.IndicadorUsuario = drd.GetBoolean(posIndicadorUsuario);
                obePersona.IndicadorContacto = drd.GetBoolean(posIndicadorContacto);
                obePersona.EstadoPersona = drd.GetString(posEstadoPersona);
                obePersona.FechaHoraCreacion = drd.GetDateTime(posFechaHoraCreacion);
                obePersona.CodigoUsuarioCreador = drd.GetString(posCodigoUsuarioCreador);
                obePersona.FechaHoraModificacion = drd.GetDateTime(posFechaHoraModificacion);
                obePersona.CodigoUsuarioModificacion = drd.GetString(posCodigoUsuarioModificacion);
                drd.Close();
            }
            return (obePersona);
        }

        public int adicionar(SqlTransaction trx, SqlConnection con, bePersona obePersona)
        {
            int codigo = -1;
            SqlCommand cmd = new SqlCommand("uspPersonaAdicionar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Transaction = trx;

            SqlParameter par1 = cmd.Parameters.Add("@NombreRazonSocial", SqlDbType.VarChar, 80);
            par1.Direction = ParameterDirection.Input;
            par1.Value = obePersona.NombreRazonSocial;

            SqlParameter par2 = cmd.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar, 50);
            par2.Direction = ParameterDirection.Input;
            par2.Value = obePersona.ApellidoPaterno;

            SqlParameter par3 = cmd.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar, 50);
            par3.Direction = ParameterDirection.Input;
            par3.Value = obePersona.ApellidoMaterno;

            SqlParameter par4 = cmd.Parameters.Add("@TipoPersona", SqlDbType.VarChar, 1);
            par4.Direction = ParameterDirection.Input;
            par4.Value = obePersona.TipoPersona;

            SqlParameter par5 = cmd.Parameters.Add("@TipoDocumento", SqlDbType.VarChar, 2);
            par5.Direction = ParameterDirection.Input;
            par5.Value = obePersona.TipoDocumento;

            SqlParameter par6 = cmd.Parameters.Add("@NumeroDocumento", SqlDbType.VarChar, 20);
            par6.Direction = ParameterDirection.Input;
            par6.Value = obePersona.NumeroDocumento;

            SqlParameter par7 = cmd.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime);
            par7.Direction = ParameterDirection.Input;
            par7.Value = obePersona.FechaNacimiento;

            SqlParameter par8 = cmd.Parameters.Add("@Sexo", SqlDbType.VarChar, 1);
            par8.Direction = ParameterDirection.Input;
            par8.Value = obePersona.Sexo;

            SqlParameter par9 = cmd.Parameters.Add("@EstadoCivil", SqlDbType.VarChar, 1);
            par9.Direction = ParameterDirection.Input;
            par9.Value = obePersona.EstadoCivil;

            SqlParameter par10 = cmd.Parameters.Add("@TipoVia", SqlDbType.VarChar, 2);
            par10.Direction = ParameterDirection.Input;
            par10.Value = obePersona.TipoVia;

            SqlParameter par11 = cmd.Parameters.Add("@NombreVia", SqlDbType.VarChar, 50);
            par11.Direction = ParameterDirection.Input;
            par11.Value = obePersona.NombreVia;

            SqlParameter par12 = cmd.Parameters.Add("@NumeroVia", SqlDbType.VarChar, 4);
            par12.Direction = ParameterDirection.Input;
            par12.Value = obePersona.NumeroVia;

            SqlParameter par13 = cmd.Parameters.Add("@Interior", SqlDbType.VarChar, 4);
            par13.Direction = ParameterDirection.Input;
            par13.Value = obePersona.Interior;

            SqlParameter par14 = cmd.Parameters.Add("@TipoZona", SqlDbType.VarChar, 2);
            par14.Direction = ParameterDirection.Input;
            par14.Value = obePersona.TipoZona;

            SqlParameter par15 = cmd.Parameters.Add("@NombreZona", SqlDbType.VarChar, 50);
            par15.Direction = ParameterDirection.Input;
            par15.Value = obePersona.NombreZona;

            SqlParameter par16 = cmd.Parameters.Add("@ReferenciaDireccion", SqlDbType.VarChar, 100);
            par16.Direction = ParameterDirection.Input;
            par16.Value = obePersona.ReferenciaDireccion;

            SqlParameter par18 = cmd.Parameters.Add("@UbigeoId", SqlDbType.Int);
            par18.Direction = ParameterDirection.Input;
            par18.Value = obePersona.UbigeoId;

            SqlParameter par19 = cmd.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar, 100);
            par19.Direction = ParameterDirection.Input;
            par19.Value = obePersona.CorreoElectronico;

            SqlParameter par20 = cmd.Parameters.Add("@PaginaWeb", SqlDbType.VarChar, 40);
            par20.Direction = ParameterDirection.Input;
            par20.Value = obePersona.PaginaWeb;

            SqlParameter par21 = cmd.Parameters.Add("@IndicadorPublicidad", SqlDbType.Bit);
            par21.Direction = ParameterDirection.Input;
            par21.Value = obePersona.IndicadorPublicidad;

            SqlParameter par22 = cmd.Parameters.Add("@IndicadorCliente", SqlDbType.Bit);
            par22.Direction = ParameterDirection.Input;
            par22.Value = obePersona.IndicadorCliente;

            SqlParameter par23 = cmd.Parameters.Add("@IndicadorUsuario", SqlDbType.Bit);
            par23.Direction = ParameterDirection.Input;
            par23.Value = obePersona.IndicadorUsuario;

            SqlParameter par24 = cmd.Parameters.Add("@IndicadorContacto", SqlDbType.Bit);
            par24.Direction = ParameterDirection.Input;
            par24.Value = obePersona.IndicadorContacto;

            SqlParameter par25 = cmd.Parameters.Add("@EstadoPersona", SqlDbType.VarChar, 3);
            par25.Direction = ParameterDirection.Input;
            par25.Value = obePersona.EstadoPersona;

            SqlParameter par26 = cmd.Parameters.Add("@CodigoUsuarioCreador", SqlDbType.VarChar, 50);
            par26.Direction = ParameterDirection.Input;
            par26.Value = obePersona.CodigoUsuarioCreador;

            SqlParameter par27 = cmd.Parameters.Add("@@identity", SqlDbType.Int);
            par27.Direction = ParameterDirection.ReturnValue;

            int n = cmd.ExecuteNonQuery();
            if (n > 0) codigo = (int)par27.Value;
            return (codigo);
        }

        public bool actualizar(SqlTransaction trx, SqlConnection con, bePersona obePersona)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("uspPersonaActualizar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Transaction = trx;

            SqlParameter par1 = cmd.Parameters.Add("@PersonaId", SqlDbType.Int);
            par1.Direction = ParameterDirection.Input;
            par1.Value = obePersona.PersonaId;

            SqlParameter par2 = cmd.Parameters.Add("@NombreRazonSocial", SqlDbType.VarChar, 80);
            par2.Direction = ParameterDirection.Input;
            par2.Value = obePersona.NombreRazonSocial;

            SqlParameter par3 = cmd.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar, 50);
            par3.Direction = ParameterDirection.Input;
            par3.Value = obePersona.ApellidoPaterno;

            SqlParameter par4 = cmd.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar, 50);
            par4.Direction = ParameterDirection.Input;
            par4.Value = obePersona.ApellidoMaterno;

            SqlParameter par5 = cmd.Parameters.Add("@TipoPersona", SqlDbType.VarChar, 1);
            par5.Direction = ParameterDirection.Input;
            par5.Value = obePersona.TipoPersona;

            SqlParameter par6 = cmd.Parameters.Add("@TipoDocumento", SqlDbType.VarChar, 2);
            par6.Direction = ParameterDirection.Input;
            par6.Value = obePersona.TipoDocumento;

            SqlParameter par7 = cmd.Parameters.Add("@NumeroDocumento", SqlDbType.VarChar, 20);
            par7.Direction = ParameterDirection.Input;
            par7.Value = obePersona.NumeroDocumento;

            SqlParameter par8 = cmd.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime);
            par8.Direction = ParameterDirection.Input;
            par8.Value = obePersona.FechaNacimiento;

            SqlParameter par9 = cmd.Parameters.Add("@Sexo", SqlDbType.VarChar, 1);
            par9.Direction = ParameterDirection.Input;
            par9.Value = obePersona.Sexo;

            SqlParameter par10 = cmd.Parameters.Add("@EstadoCivil", SqlDbType.VarChar, 1);
            par10.Direction = ParameterDirection.Input;
            par10.Value = obePersona.EstadoCivil;

            SqlParameter par11 = cmd.Parameters.Add("@TipoVia", SqlDbType.VarChar, 2);
            par11.Direction = ParameterDirection.Input;
            par11.Value = obePersona.TipoVia;

            SqlParameter par12 = cmd.Parameters.Add("@NombreVia", SqlDbType.VarChar, 50);
            par12.Direction = ParameterDirection.Input;
            par12.Value = obePersona.NombreVia;

            SqlParameter par13 = cmd.Parameters.Add("@NumeroVia", SqlDbType.VarChar, 4);
            par13.Direction = ParameterDirection.Input;
            par13.Value = obePersona.NumeroVia;

            SqlParameter par14 = cmd.Parameters.Add("@Interior", SqlDbType.VarChar, 4);
            par14.Direction = ParameterDirection.Input;
            par14.Value = obePersona.Interior;

            SqlParameter par15 = cmd.Parameters.Add("@TipoZona", SqlDbType.VarChar, 2);
            par15.Direction = ParameterDirection.Input;
            par15.Value = obePersona.TipoZona;

            SqlParameter par16 = cmd.Parameters.Add("@NombreZona", SqlDbType.VarChar, 50);
            par16.Direction = ParameterDirection.Input;
            par16.Value = obePersona.NombreZona;

            SqlParameter par17 = cmd.Parameters.Add("@ReferenciaDireccion", SqlDbType.VarChar, 100);
            par17.Direction = ParameterDirection.Input;
            par17.Value = obePersona.ReferenciaDireccion;

            SqlParameter par19 = cmd.Parameters.Add("@UbigeoId", SqlDbType.Int);
            par19.Direction = ParameterDirection.Input;
            par19.Value = obePersona.UbigeoId;

            SqlParameter par20 = cmd.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar, 100);
            par20.Direction = ParameterDirection.Input;
            par20.Value = obePersona.CorreoElectronico;

            SqlParameter par21 = cmd.Parameters.Add("@PaginaWeb", SqlDbType.VarChar, 40);
            par21.Direction = ParameterDirection.Input;
            par21.Value = obePersona.PaginaWeb;

            SqlParameter par22 = cmd.Parameters.Add("@IndicadorPublicidad", SqlDbType.Bit);
            par22.Direction = ParameterDirection.Input;
            par22.Value = obePersona.IndicadorPublicidad;

            SqlParameter par23 = cmd.Parameters.Add("@IndicadorCliente", SqlDbType.Bit);
            par23.Direction = ParameterDirection.Input;
            par23.Value = obePersona.IndicadorCliente;

            SqlParameter par24 = cmd.Parameters.Add("@IndicadorUsuario", SqlDbType.Bit);
            par24.Direction = ParameterDirection.Input;
            par24.Value = obePersona.IndicadorUsuario;

            SqlParameter par25 = cmd.Parameters.Add("@IndicadorContacto", SqlDbType.Bit);
            par25.Direction = ParameterDirection.Input;
            par25.Value = obePersona.IndicadorContacto;

            SqlParameter par26 = cmd.Parameters.Add("@EstadoPersona", SqlDbType.VarChar, 3);
            par26.Direction = ParameterDirection.Input;
            par26.Value = obePersona.EstadoPersona;

            SqlParameter par27 = cmd.Parameters.Add("@CodigoUsuarioModificacion", SqlDbType.VarChar, 50);
            par27.Direction = ParameterDirection.Input;
            par27.Value = obePersona.CodigoUsuarioModificacion;

            int n = cmd.ExecuteNonQuery();
            exito = (n > 0);
            return (exito);
        }

        public bool anular(SqlConnection con, int PersonaId, string CodigoUsuarioModificacion)
        {
            bool exito = false;
            SqlCommand cmd = new SqlCommand("uspPersonaAnular", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter par1 = cmd.Parameters.Add("@PersonaId", SqlDbType.Int);
            par1.Direction = ParameterDirection.Input;
            par1.Value = PersonaId;

            SqlParameter par2 = cmd.Parameters.Add("@CodigoUsuarioModificacion", SqlDbType.VarChar, 50);
            par2.Direction = ParameterDirection.Input;
            par2.Value = CodigoUsuarioModificacion;

            int n = cmd.ExecuteNonQuery();
            exito = (n > 0);
            return (exito);
        }
    }
}