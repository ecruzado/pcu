using PCU.Librerias.EntidadesNegocio;
using PCU.Librerias.ReglasNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PCU.Web
{
    public partial class Index : System.Web.UI.Page
    {
        protected List<beSistemaMenu> lbeSistemaMenu;

        private void listarSistemaMenu()
        {
            
            brSistemaMenu obrSistemaMenu = new brSistemaMenu();
            lbeSistemaMenu = obrSistemaMenu.listarPorCodigo("10");
            Session["SistemaMenuUsuario"] = lbeSistemaMenu;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                listarSistemaMenu();
                lbeSistemaMenu = (List<beSistemaMenu>)Session["SistemaMenuUsuario"];
                string codigoSistema = "10";
                dlsSistemaMenu.DataSource = lbeSistemaMenu.FindAll(x => x.CodigoSistemaPadre.Equals(codigoSistema));
                dlsSistemaMenu.DataBind();
            }
        }
    }
}