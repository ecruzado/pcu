using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCU.Librerias.EntidadesNegocio
{
    public class bePersona
    {
        public int PersonaId { get; set; }
        public string NombreRazonSocial { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string TipoPersona { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string TipoVia { get; set; }
        public string NombreVia { get; set; }
        public string NumeroVia { get; set; }
        public string Interior { get; set; }
        public string TipoZona { get; set; }
        public string NombreZona { get; set; }
        public string ReferenciaDireccion { get; set; }
        public string Direccion { get; set; }
        public int UbigeoId { get; set; }
        public string UbigeoCod { get; set; }
        public string UbigeoDes { get; set; }
        public string CorreoElectronico { get; set; }
        public string PaginaWeb { get; set; }
        public bool IndicadorPublicidad { get; set; }
        public bool IndicadorCliente { get; set; }
        public bool IndicadorUsuario { get; set; }
        public bool IndicadorContacto { get; set; }
        public string EstadoPersona { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public string CodigoUsuarioCreador { get; set; }
        public DateTime FechaHoraModificacion { get; set; }
        public string CodigoUsuarioModificacion { get; set; }
    }
}
