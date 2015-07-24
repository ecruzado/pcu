using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCU.Librerias.EntidadesNegocio
{
    public class beUsuario
    {
        public int UsuarioId { get; set; }
        public int PersonaId { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NombreRazonSocial { get; set; }
        public string CorreoElectronico { get; set; }
        public string CodigoUsuario { get; set; }
        public string NombrePreferidoUsuario { get; set; }
        public int ClienteId { get; set; }
        public string NombreCliente { get; set; }
        public int ClienteSucursalId { get; set; }
        public string NombreSucursal { get; set; }
        public string IndicadorVisualizaSedes { get; set; }
        public string TipoEstiloWeb { get; set; }
        public int TiempoExpiracionSesion { get; set; }
        public string EstadoUsuario { get; set; }
        public string NombreCompleto
        {
            get
            {
                return (ApellidoPaterno + " " + ApellidoMaterno + ", " + NombreRazonSocial);
            }
        }
    }
}
