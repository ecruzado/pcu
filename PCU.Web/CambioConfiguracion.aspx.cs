using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using General.Librerias.CodigoUsuarioWeb;
using PCU.Librerias.EntidadesNegocio;
using PCU.Librerias.ReglasNegocio;

namespace PCU.Web
{
    public partial class CambioConfiguracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                beUsuario obeUsuario = (beUsuario)Session["Usuario"];
                if (obeUsuario != null)
                {
                    txtUsuario.Text = obeUsuario.NombreCompleto;
                    txtNombrePreferido.Text = obeUsuario.NombrePreferidoUsuario;
                    string ruta = Server.MapPath("~/Estilos/");
                    string[] archivos = Directory.GetFiles(ruta, "*.css");
                    string nombre = "";
                    foreach (string archivo in archivos)
                    {
                        nombre = Path.GetFileNameWithoutExtension(archivo);
                        ddlEstiloWeb.Items.Add(new ListItem(nombre, nombre));
                    }
                    ddlEstiloWeb.SelectedValue = obeUsuario.TipoEstiloWeb;
                    imgFoto.Src = Imagen.obtenerUrl(obeUsuario.UsuarioId, "Usuarios");
                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            beUsuario obeUsuario = (beUsuario)Session["Usuario"];
            if (obeUsuario != null)
            {
                int tiempo = int.Parse(txtTiempo.Text);
                brUsuario obrUsuario = new brUsuario();
                bool exito = obrUsuario.actualizarConfiguracion(obeUsuario.UsuarioId, txtNombrePreferido.Text, ddlEstiloWeb.SelectedValue, tiempo);
                if (exito)
                {
                    obeUsuario.NombrePreferidoUsuario = txtNombrePreferido.Text;
                    obeUsuario.TipoEstiloWeb = ddlEstiloWeb.SelectedValue;
                    Session["Usuario"] = obeUsuario;
                    if (fupFoto.PostedFile.ContentLength > 0)
                    {
                        string archivo = Server.MapPath(String.Format("~/Imagenes/Usuarios/{0}.jpg", obeUsuario.UsuarioId));
                        if (File.Exists(archivo)) File.Delete(archivo);
                        fupFoto.PostedFile.SaveAs(archivo);
                    }
                    Response.Redirect("MenuPrincipal.aspx");
                }
                else
                {
                    //Pagina.mostrarMensaje("Ocurrio un error al actualizar la configuración");
                }
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuPrincipal.aspx");
        }
    }
}