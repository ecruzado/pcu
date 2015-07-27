using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using General.Librerias.CodigoUsuarioWeb;
using PCU.Librerias.EntidadesNegocio;
using PCU.Librerias.ReglasNegocio;

namespace PCU.Web
{
    public partial class CambioClave : System.Web.UI.Page
    {
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            beUsuario obeUsuario = (beUsuario)Session["Usuario"];
            if (obeUsuario != null)
            {
                brUsuario obrUsuario = new brUsuario();
                bool exito = obrUsuario.actualizarClave(obeUsuario.UsuarioId, txtClaveAnterior.Text, txtClaveNueva.Text);
                if (exito)
                {
                    Response.Redirect("Index");
                }
                else
                {
                    //Pagina.mostrarMensaje("Verifique la Contraseña Anterior");
                }
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index");
        }
    }
}