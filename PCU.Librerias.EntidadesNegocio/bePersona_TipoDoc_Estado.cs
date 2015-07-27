using General.Librerias.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCU.Librerias.EntidadesNegocio
{
    public class bePersona_TipoDoc_Estado
    {
        public List<bePersonaGrid> ListaPersona { get; set; }
        public List<beCampo3> ListaTipoDoc { get; set; }
        public List<beCampo3> ListaEstado { get; set; }
    }
}
