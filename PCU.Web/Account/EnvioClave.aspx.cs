using System;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using General.Librerias.CodigoUsuario;
using General.Librerias.CodigoUsuarioWeb;
using General.Librerias.EntidadesNegocio;
using PCU.Librerias.ReglasNegocio;

namespace PCU.Web
{
    public partial class EnvioClave : System.Web.UI.Page
    {
        private static Random oAzar = new Random();
        private string claveNormal;
        private string claveCifrada;
        private beCampo2 obeCampo;

        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void btnRestablecerClave_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            claveNormal = abcde.Value;
            claveCifrada = vwxyz.Value;
            brPersona obrPersona = new brPersona();
            obeCampo = obrPersona.obtenerUsuarioPorCorreo(txtCorreo.Text, claveCifrada);
            if (obeCampo != null) enviarCorreo();
            //else Pagina.mostrarMensaje("El correo electrónico No existe");
        }

        private void enviarCorreo()
        {
            beMensaje obeMensaje = new beMensaje();
            //obeMensaje.De = Constantes.CorreoDe;
            //obeMensaje.Clave = Constantes.CorreoClave;
            string[] para = new string[] { txtCorreo.Text };
            obeMensaje.Para = para;
            obeMensaje.Asunto = "Solicitud de Cambio de Contraseña";
            StringBuilder sb = new StringBuilder();
            sb.Append("Estimado: <br><b>");
            sb.Append(obeCampo.Campo1);
            sb.Append("</b><br><br>");
            sb.Append("Tu usuario del sistema es: <b>");
            sb.Append(obeCampo.Campo2);
            sb.Append("</b><br>Tu nuevo numero de clave es: <b>");
            sb.Append(claveNormal);
            sb.Append("</b><br><br>Puede ingresar a la siguiente ruta para verificarlo:<br>http://");
            sb.Append(System.Web.Hosting.HostingEnvironment.ApplicationHost.GetSiteName());
            sb.Append("/ACME/Sistemas/Administracion/Paginas/Login.aspx<br><br>");
            sb.Append("Administrador del sistema.");
            obeMensaje.Contenido = sb.ToString();
            bool exito = ucCorreo.enviar(obeMensaje);
            //if (exito) Pagina.mostrarMensaje("Correo enviado");
            //else Pagina.mostrarMensaje("No se pudo enviar correo");
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Login");
        }
    }
}