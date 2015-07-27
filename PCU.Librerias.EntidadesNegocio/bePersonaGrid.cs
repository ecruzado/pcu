using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCU.Librerias.EntidadesNegocio
{
    public class bePersonaGrid
    {
        public int PersonaId { get; set; }
        public string NombreRazonSocial { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public bool IndicadorCliente { get; set; }
        public string EstadoPersona { get; set; }
    }
}
