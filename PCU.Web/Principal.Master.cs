using PCU.Librerias.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using General.Librerias.CodigoUsuarioWeb;
using PCU.Librerias.EntidadesNegocio;
using PCU.Web.Code;
using PCU.Librerias.ReglasNegocio;
namespace PCU.Web
{
    public partial class Principal : System.Web.UI.MasterPage
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


        protected void Page_Load(object sender, EventArgs e)
        {
            //mnuConfiguraUsuario.Attributes.Add("style", "display:none");
            dlsSistemaMenu.DataSource = Menus.FindAll(x => x.CodigoSistemaPadre.Equals("10"));

            dlsSistemaMenu.DataBind();
            if (!Page.IsPostBack)
            {
                hdfContador.Value = "0";
                hdfTiempoSesion.Value = Session.Timeout.ToString();
                beUsuario obeUsuario = (beUsuario)Session["Usuario"];
                lblNombreSistema.Text = "ADMINISTRACIÓN DE EMPRESAS";
                lblUsuario.Text = obeUsuario.NombrePreferidoUsuario;
                lblEmpresa.Text = obeUsuario.NombreCliente;
                lblSede.Text = obeUsuario.NombreSucursal;
                hdfTiempoUsuario.Value = obeUsuario.TiempoExpiracionSesion.ToString();
                imgEmpresa.Src = Imagen.obtenerUrl("11", "SistemaMenu");
                imgEmpresa.Attributes.Add("title", obeUsuario.NombreCliente);
                imgUsuario.Src = Imagen.obtenerUrl(obeUsuario.UsuarioId, "Usuarios");
                imgUsuario.Attributes.Add("title", obeUsuario.NombreCompleto);
            }
            string nombreControlPost = Request.Form["__EVENTTARGET"];
            if (nombreControlPost != null && nombreControlPost.Equals(""))
            {
                foreach (string nombreControlForm in Request.Form)
                {
                    if (nombreControlForm.Contains("btn") || nombreControlForm.Contains("ibn"))
                    {
                        if (!nombreControlForm.Contains("btnContinuarSesion"))
                        {
                            hdfContador.Value = "0";
                        }
                    }
                }
            }
            Page.MaintainScrollPositionOnPostBack = true;
        }
        protected void configurarOpcionesUsuario(object sender, MenuEventArgs e)
        {
            if (e.Item.Value.Equals("1"))
            {
                Response.Redirect("CambioConfiguracion");
            }
            else
            {
                if (e.Item.Value.Equals("2"))
                {
                    Response.Redirect("~/Account/CambioClave");
                }
                else
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/Account/Login");
                }
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Account/Login");
        }

        //protected void btnContinuarSesion_Click(object sender, EventArgs e)
        //{
        //    beUsuario obeUsuario = (beUsuario)Session["Usuario"];
        //}
    }
}