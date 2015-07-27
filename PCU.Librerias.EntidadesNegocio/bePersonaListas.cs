using System;
using System.Collections.Generic;
using General.Librerias.EntidadesNegocio;

namespace PCU.Librerias.EntidadesNegocio
{
    public class bePersonaListas
    {
        public List<beCampo3> ListaTipoDocumento { get; set; }
        public List<beCampo3> ListaTipoVia { get; set; }
        public List<beCampo3> ListaTipoZona { get; set; }
        public List<beCampo3> ListaSexo { get; set; }
        public List<beCampo3> ListaEstadoCivil { get; set; }
        public List<bePersonaTelefono> ListaTelefono { get; set; }
        public List<beCampo3> ListaTipoTelefono { get; set; }
        public List<beCampo3> ListaOperadorTelefono { get; set; }
        public List<beUbigeo> ListaUbigeo { get; set; }
    }
}
