using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCU.Librerias.EntidadesNegocio
{
    public class beSistemaMenu
    {
        public string CodigoMoneda { get; set; }
        public string CodigoSistemaMenu { get; set; }
        public string CodigoSistemaPadre { get; set; }
        public string CodigoUsuario { get; set; }
        public string ColorOpcion { get; set; }
        public string EstadoSistemaMenu { get; set; }
        public string NombreCortoSistemaMenu { get; set; }
        public string NombreSistemaMenu { get; set; }
        public int SistemaMenuId { get; set; }
        public decimal TarifaMaxima { get; set; }
        public decimal TarifaMinima { get; set; }
        public decimal TarifaSistemaMenu { get; set; }
        public string URLPagina { get; set; }
    }
}
