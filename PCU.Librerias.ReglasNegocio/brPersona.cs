using System;
using System.Collections.Generic; //List
using System.Data.SqlClient; //SqlConnection
using General.Librerias.EntidadesNegocio; //beCampo
using PCU.Librerias.AccesoDatos; //daPersona
using General.Librerias.CodigoUsuario; //ucObjeto
using PCU.Librerias.EntidadesNegocio; //bePersonaGrid
using PCU.Librerias.AgentesServicio; //saListaValores

namespace PCU.Librerias.ReglasNegocio
{
    public class brPersona : brGeneral
    {
        public beCampo2 obtenerUsuarioPorCorreo(string correoElectronico, string contrasenaUsuario)
        {
            beCampo2 obeCampo = null;
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                try
                {
                    con.Open();
                    daPersona odaPersona = new daPersona();
                    obeCampo = odaPersona.obtenerUsuarioPorCorreo(con, correoElectronico, contrasenaUsuario);
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
            return (obeCampo);
        }

        public bePersona_TipoDoc_Estado listarGrid()
        {
            bePersona_TipoDoc_Estado obePersona_TipoDoc_Estado = new bePersona_TipoDoc_Estado();
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                try
                {
                    con.Open();
                    daPersona odaPersona = new daPersona();
                    List<bePersonaGrid> lbePersona = null;
                    lbePersona = odaPersona.listarGrid(con);

                    saListaValores osaListaValores = new saListaValores();
                    List<beCampo3> lbeTipoDocumento = null;
                    lbeTipoDocumento = osaListaValores.listarDeArchivoTxt("TipoDocumento");
                    List<beCampo3> lbeEstadoPersona = null;
                    lbeEstadoPersona = osaListaValores.listarDeArchivoTxt("EstadoPersona");

                    foreach (bePersonaGrid obePersona in lbePersona)
                    {
                        int posTipoDoc = lbeTipoDocumento.FindIndex(x => x.Campo1.Equals(obePersona.TipoDocumento));
                        if (posTipoDoc > -1) obePersona.TipoDocumento = lbeTipoDocumento[posTipoDoc].Campo3;
                        int posEstado = lbeEstadoPersona.FindIndex(x => x.Campo1.Equals(obePersona.EstadoPersona));
                        if (posEstado > -1) obePersona.EstadoPersona = lbeEstadoPersona[posEstado].Campo3;
                    }
                    beCampo3 obeCampo3 = new beCampo3 { Campo1 = "", Campo2 = "", Campo3 = "Todos" };
                    lbeTipoDocumento.Insert(0, obeCampo3);
                    lbeEstadoPersona.Insert(0, obeCampo3);
                    obePersona_TipoDoc_Estado.ListaPersona = lbePersona;
                    obePersona_TipoDoc_Estado.ListaTipoDoc = lbeTipoDocumento;
                    obePersona_TipoDoc_Estado.ListaEstado = lbeEstadoPersona;
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
            return (obePersona_TipoDoc_Estado);
        }

        public bePersonaListas obtenerListas()
        {
            bePersonaListas obePersonaListas = new bePersonaListas();
            try
            {
                saListaValores osaListaValores = new saListaValores();
                List<beCampo3> lbeTipoDocumento = null;
                lbeTipoDocumento = osaListaValores.listarDeArchivoTxt("TipoDocumento");
                List<beCampo3> lbeTipoVia = null;
                lbeTipoVia = osaListaValores.listarDeArchivoTxt("TipoVia");
                List<beCampo3> lbeTipoZona = null;
                lbeTipoZona = osaListaValores.listarDeArchivoTxt("TipoZona");
                List<beCampo3> lbeSexo = null;
                lbeSexo = osaListaValores.listarDeArchivoTxt("Sexo");
                List<beCampo3> lbeEstadoCivil = null;
                lbeEstadoCivil = osaListaValores.listarDeArchivoTxt("EstadoCivil");
                List<beCampo3> lbeTipoTelefono = null;
                lbeTipoTelefono = osaListaValores.listarDeArchivoTxt("TipoTelefono");
                List<beCampo3> lbeOperadorTelefono = null;
                lbeOperadorTelefono = osaListaValores.listarDeArchivoTxt("OperadorTelefono");
                beCampo3 obeCampo3 = new beCampo3 { Campo1 = "", Campo2 = "", Campo3 = "Seleccione" };
                lbeTipoDocumento.Insert(0, obeCampo3);
                lbeTipoVia.Insert(0, obeCampo3);
                lbeTipoZona.Insert(0, obeCampo3);
                lbeSexo.Insert(0, obeCampo3);
                lbeEstadoCivil.Insert(0, obeCampo3);
                lbeTipoTelefono.Insert(0, obeCampo3);
                lbeOperadorTelefono.Insert(0, obeCampo3);

                obePersonaListas.ListaTipoDocumento = lbeTipoDocumento;
                obePersonaListas.ListaTipoVia = lbeTipoVia;
                obePersonaListas.ListaTipoZona = lbeTipoZona;
                obePersonaListas.ListaSexo = lbeSexo;
                obePersonaListas.ListaEstadoCivil = lbeEstadoCivil;
                obePersonaListas.ListaTipoTelefono = lbeTipoTelefono;
                obePersonaListas.ListaOperadorTelefono = lbeOperadorTelefono;

                brUbigeo obrUbigeo = new brUbigeo();
                List<beUbigeo> lbeUbigeo = obrUbigeo.listar();
                obePersonaListas.ListaUbigeo = lbeUbigeo;
            }
            catch (Exception ex)
            {
                ucObjeto<Exception>.grabarArchivoTexto(ex, Archivo);
            }
            return (obePersonaListas);
        }

        public bePersonaDetalle obtenerDetalle(int personaId)
        {
            bePersonaDetalle obePersonaDetalle = new bePersonaDetalle();
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                try
                {
                    con.Open();
                    //Llenar el objeto Persona
                    daPersona odaPersona = new daPersona();
                    bePersona obePersona = odaPersona.obtenerPorId(con, personaId);
                    daPersonaTelefono odaPersonaTelefono = new daPersonaTelefono();
                    List<bePersonaTelefono> lbePersonaTelefono = odaPersonaTelefono.obtenerPorIdPersona(con, personaId);
                    saListaValores osaListaValores = new saListaValores();
                    List<beCampo3> lbeTipoDocumento = null;
                    lbeTipoDocumento = osaListaValores.listarDeArchivoTxt("TipoDocumento");
                    List<beCampo3> lbeTipoVia = null;
                    lbeTipoVia = osaListaValores.listarDeArchivoTxt("TipoVia");
                    List<beCampo3> lbeTipoZona = null;
                    lbeTipoZona = osaListaValores.listarDeArchivoTxt("TipoZona");
                    List<beCampo3> lbeSexo = null;
                    lbeSexo = osaListaValores.listarDeArchivoTxt("Sexo");
                    List<beCampo3> lbeEstadoCivil = null;
                    lbeEstadoCivil = osaListaValores.listarDeArchivoTxt("EstadoCivil");
                    List<beCampo3> lbeTipoTelefono = null;
                    lbeTipoTelefono = osaListaValores.listarDeArchivoTxt("TipoTelefono");
                    List<beCampo3> lbeOperadorTelefono = null;
                    lbeOperadorTelefono = osaListaValores.listarDeArchivoTxt("OperadorTelefono");
                    foreach (bePersonaTelefono obePersonaTelefono in lbePersonaTelefono)
                    {
                        int posTipoTelefono = lbeTipoTelefono.FindIndex(x => x.Campo1.Equals(obePersonaTelefono.IdTipoTelefono));
                        if (posTipoTelefono > -1) obePersonaTelefono.DesTipoTelefono = lbeTipoTelefono[posTipoTelefono].Campo3;
                        int posOperadorTelefono = lbeOperadorTelefono.FindIndex(x => x.Campo1.Equals(obePersonaTelefono.IdOperadorTelefono));
                        if (posOperadorTelefono > -1) obePersonaTelefono.DesOperadorTelefono = lbeOperadorTelefono[posOperadorTelefono].Campo3;
                    }
                    beCampo3 obeCampo3 = new beCampo3 { Campo1 = "", Campo2 = "", Campo3 = "Seleccione" };
                    lbeTipoTelefono.Insert(0, obeCampo3);
                    lbeOperadorTelefono.Insert(0, obeCampo3);
                    //Llenar el objeto con las Listas
                    bePersonaListas obeListas = new bePersonaListas();
                    obeListas.ListaTipoDocumento = lbeTipoDocumento;
                    obeListas.ListaTipoVia = lbeTipoVia;
                    obeListas.ListaTipoZona = lbeTipoZona;
                    obeListas.ListaSexo = lbeSexo;
                    obeListas.ListaEstadoCivil = lbeEstadoCivil;
                    obeListas.ListaTelefono = lbePersonaTelefono;
                    obeListas.ListaTipoTelefono = lbeTipoTelefono;
                    obeListas.ListaOperadorTelefono = lbeOperadorTelefono;
                    //Llenar el Ubigeo
                    daUbigeo odaUbigeo = new daUbigeo();
                    List<beUbigeo> lbeUbigeo = odaUbigeo.listar(con);
                    obeListas.ListaUbigeo = lbeUbigeo;
                    int pos = lbeUbigeo.FindIndex(x => x.UbigeoId.Equals(obePersona.UbigeoId));
                    if (pos > -1)
                    {
                        obePersona.UbigeoCod = lbeUbigeo[pos].CodigoUbigeo;
                        obePersona.UbigeoDes = String.Format("{0} - {1} - {2}", lbeUbigeo[pos].NombreDepartamento, lbeUbigeo[pos].NombreProvincia, lbeUbigeo[pos].NombreDistrito);
                    }
                    //Llenar el objeto principal
                    obePersonaDetalle.Persona = obePersona;
                    obePersonaDetalle.Listas = obeListas;
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
            return (obePersonaDetalle);
        }

        public List<bePersonaTelefono> listarTelefonos(int personaId)
        {
            List<bePersonaTelefono> lbePersonaTelefono = new List<bePersonaTelefono>();
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                try
                {
                    con.Open();
                    daPersonaTelefono odaPersonaTelefono = new daPersonaTelefono();
                    lbePersonaTelefono = odaPersonaTelefono.obtenerPorIdPersona(con, personaId);
                    saListaValores osaListaValores = new saListaValores();
                    List<beCampo3> lbeTipoTelefono = null;
                    lbeTipoTelefono = osaListaValores.listarDeArchivoTxt("TipoTelefono");
                    List<beCampo3> lbeOperadorTelefono = null;
                    lbeOperadorTelefono = osaListaValores.listarDeArchivoTxt("OperadorTelefono");
                    foreach (bePersonaTelefono obePersonaTelefono in lbePersonaTelefono)
                    {
                        int posTipoTelefono = lbeTipoTelefono.FindIndex(x => x.Campo1.Equals(obePersonaTelefono.IdTipoTelefono));
                        if (posTipoTelefono > -1) obePersonaTelefono.DesTipoTelefono = lbeTipoTelefono[posTipoTelefono].Campo3;
                        int posOperadorTelefono = lbeOperadorTelefono.FindIndex(x => x.Campo1.Equals(obePersonaTelefono.IdOperadorTelefono));
                        if (posOperadorTelefono > -1) obePersonaTelefono.DesOperadorTelefono = lbeOperadorTelefono[posOperadorTelefono].Campo3;
                    }
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
            return (lbePersonaTelefono);
        }

        public int adicionar(bePersonaTelefonos obePersonaTelefonos)
        {
            int idPersona = -1;
            bool exito = true;
            SqlTransaction trx = null;
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                try
                {
                    con.Open();
                    trx = con.BeginTransaction();
                    daPersona odaPersona = new daPersona();
                    idPersona = odaPersona.adicionar(trx, con, obePersonaTelefonos.Persona);
                    if (idPersona > 0)
                    {
                        daPersonaTelefono odaPersonaTelefono = new daPersonaTelefono();
                        foreach (bePersonaTelefono obePersonaTelefono in obePersonaTelefonos.ListaTelefono)
                        {
                            obePersonaTelefono.PersonaId = idPersona;
                            exito = odaPersonaTelefono.adicionar(trx, con, obePersonaTelefono);
                            if (!exito) break;
                        }
                    }
                    else exito = false;

                    if (exito) trx.Commit();
                    else
                    {
                        idPersona = -1;
                        trx.Rollback();
                    }
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
            return (idPersona);
        }

        public bool actualizar(bePersonaTelefonos obePersonaTelefonos)
        {
            bool exito = true;
            SqlTransaction trx = null;
            daPersonaTelefono odaPersonaTelefono = new daPersonaTelefono();
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                try
                {
                    con.Open();
                    trx = con.BeginTransaction();
                    daPersona odaPersona = new daPersona();
                    exito = odaPersona.actualizar(trx, con, obePersonaTelefonos.Persona);
                    if (exito)
                    {
                        foreach (bePersonaTelefono obePersonaTelefono in obePersonaTelefonos.ListaTelefono)
                        {
                            if (obePersonaTelefono.PersonaTelefonoId > 0)
                            {
                                exito = odaPersonaTelefono.actualizar(trx, con, obePersonaTelefono);
                            }
                            else
                            {
                                exito = odaPersonaTelefono.adicionar(trx, con, obePersonaTelefono);
                            }
                            if (!exito) break;
                        }
                    }

                    if (exito) trx.Commit();
                    else trx.Rollback();
                }
                catch (SqlException ex)
                {
                    exito = false;
                    foreach (SqlError err in ex.Errors)
                    {
                        ucObjeto<SqlError>.grabarArchivoTexto(err, Archivo);
                    }
                }
                catch (Exception ex)
                {
                    exito = false;
                    ucObjeto<Exception>.grabarArchivoTexto(ex, Archivo);
                }
            }
            return (exito);
        }

        public bool eliminarTelefono(beCampo3 obePersonaTelefono)
        {
            bool exito = false;
            using (SqlConnection con = new SqlConnection(Conexion))
            {
                try
                {
                    con.Open();
                    daPersonaTelefono odaPersonaTelefono = new daPersonaTelefono();
                    exito = odaPersonaTelefono.eliminar(con, obePersonaTelefono);
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
