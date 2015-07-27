using General.Librerias.CodigoUsuario;
using General.Librerias.EntidadesNegocio;
using PCU.Librerias.EntidadesNegocio;
using PCU.Librerias.ReglasNegocio;
using PCU.Web.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PCU.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Context.IsDebuggingEnabled) 
            //{
            //    if (Session[VariableSesion.Usuario] == null)
            //    {
            //        brUsuario obrUsuario = new brUsuario();
            //        beUsuario obeUsuario = obrUsuario.validarLogin("Enrique Espinal", "");
            //        Session[VariableSesion.Usuario] = obeUsuario;
            //        FormsAuthentication.RedirectFromLoginPage("Enrique Espinal", false);
            //        Response.Redirect("Index");
            //    }
            //    else 
            //    {
            //        FormsAuthentication.RedirectFromLoginPage("Enrique Espinal", false);
            //        Response.Redirect("Index");
            //    }
            //}

            txtUsuario.Focus();
            if (!Page.IsPostBack)
            {
                generarCaptcha();
            }
        }

        private void generarCaptcha()
        {
            beCaptcha obeCaptcha = ucImagen.crearCaptcha(imgCaptcha.Width, imgCaptcha.Height, "Arial", 40);
            ViewState["Captcha"] = obeCaptcha.Codigo;
            imgCaptcha.Src = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(obeCaptcha.Imagen));
        }

        protected void lbnActualizarCaptcha_Click(object sender, EventArgs e)
        {
            generarCaptcha();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string codigoIngresado = txtCodigo.Text;
            string codigoGenerado = ViewState["Captcha"].ToString();
            if (!codigoIngresado.Equals(codigoGenerado))
            {
                //Pagina.mostrarMensaje("Codigo ingresado No coincide con el Captcha");
            }
            else
            {
                brUsuario obrUsuario = new brUsuario();
                beUsuario obeUsuario = obrUsuario.validarLogin(txtUsuario.Text, txtClave.Text);
                if (obeUsuario == null)
                {
                    //Pagina.mostrarMensaje("Login invalido. Intenta de nuevo");
                }
                else
                {

                    Session[VariableSesion.Usuario] = obeUsuario;
                    FormsAuthentication.RedirectFromLoginPage(txtUsuario.Text, false);
                    if (obeUsuario.EstadoUsuario.Equals("ACT")) Response.Redirect("~/Index");
                    else Response.Redirect("~/Account/CambioClave");
                }
            }
        }

        protected void lbnRecordarClave_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/EnvioClave.aspx");
        }
    }
}