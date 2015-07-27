using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCU.Librerias.EntidadesNegocio
{
    public class bePersonaTelefono
    {
        public int PersonaTelefonoId { get; set; }
        public int PersonaId { get; set; }
        public string NumeroTelefono { get; set; }
        public string IdTipoTelefono { get; set; }
        public string DesTipoTelefono { get; set; }
        public string IdOperadorTelefono { get; set; }
        public string DesOperadorTelefono { get; set; }
        public string NumeroAnexo { get; set; }
        public string EstadoPersonaTelefono { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public string CodigoUsuarioCreador { get; set; }
        public DateTime FechaHoraModificacion { get; set; }
        public string CodigoUsuarioModificacion { get; set; }
    }
}
