using System;
using System.Data; //CommadType
using System.Data.SqlClient; //SqlConnection, SqlCommand, SqlDataReader
using System.Collections.Generic; //List
using PCU.Librerias.EntidadesNegocio; //beSistemaMenu

namespace PCU.Librerias.AccesoDatos
{
    public class daUbigeo
    {
        public List<beUbigeo> listar(SqlConnection con)
        {
            List<beUbigeo> lbeUbigeo = null;
            SqlCommand cmd = new SqlCommand("uspUbigeoListar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                lbeUbigeo = new List<beUbigeo>();
                int posUbigeoId = drd.GetOrdinal("UbigeoId");
                int posCodigoUbigeo = drd.GetOrdinal("CodigoUbigeo");
                int posNombreDepartamento = drd.GetOrdinal("NombreDepartamento");
                int posNombreProvincia = drd.GetOrdinal("NombreProvincia");
                int posNombreDistrito = drd.GetOrdinal("NombreDistrito");
                beUbigeo obeUbigeo;
                while (drd.Read())
                {
                    obeUbigeo = new beUbigeo();
                    obeUbigeo.UbigeoId = drd.GetInt32(posUbigeoId);
                    obeUbigeo.CodigoUbigeo = drd.GetString(posCodigoUbigeo);
                    obeUbigeo.NombreDepartamento = drd.GetString(posNombreDepartamento);
                    obeUbigeo.NombreProvincia = drd.GetString(posNombreProvincia);
                    obeUbigeo.NombreDistrito = drd.GetString(posNombreDistrito);
                    lbeUbigeo.Add(obeUbigeo);
                }
                drd.Close();
            }
            return (lbeUbigeo);
        }
    }
}
