using PCU.Librerias.EntidadesNegocio;
using PCU.Librerias.ReglasNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCU.Web.Code
{
    public class PaginaBase : System.Web.UI.Page
    {
        protected List<beSistemaMenu> Menus 
        {
            get 
            {
                List<beSistemaMenu> menus = (List<beSistemaMenu>)Session[VariableSesion.Menus];
                if (menus == null) 
                {
                    brSistemaMenu obrSistemaMenu = new brSistemaMenu();
                    menus = obrSistemaMenu.listarPorCodigo("10");
                    Session[VariableSesion.Menus] = menus;
                }
                return menus;

            }
            set 
            {
                Session[VariableSesion.Menus] = value;
            }
        } 
    }
}