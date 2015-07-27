using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail; //
using System.Net.NetworkInformation;
using System.Configuration;
using General.Librerias.EntidadesNegocio;

namespace General.Librerias.CodigoUsuario
{
    public class ucCorreo
    {
        public static bool enviar(beMensaje obeMensaje)
        {
            bool exito = false;
            string rutaLog = ConfigurationManager.AppSettings["rutaLog"];
            string archivo = String.Format("{0}{1}", rutaLog, ucCadena.fomatoAMD("LogError", ".txt"));
            try
            {
                string servidor = ConfigurationManager.AppSettings["CorreoServidor"];
                string puerto = ConfigurationManager.AppSettings["CorreoPuerto"];
                MailMessage eMail = new MailMessage();
                eMail.Subject = obeMensaje.Asunto;
                eMail.IsBodyHtml = true;
                eMail.Body = obeMensaje.Contenido;
                eMail.From = new MailAddress(obeMensaje.De);
                if (obeMensaje.Para != null && obeMensaje.Para.Length > 0)
                {
                    foreach (string para in obeMensaje.Para)
                    {
                        eMail.To.Add(new MailAddress(para));
                    }
                }
                if (obeMensaje.CC != null && obeMensaje.CC.Length > 0)
                {
                    foreach (string cc in obeMensaje.CC)
                    {
                        eMail.CC.Add(new MailAddress(cc));
                    }
                }
                SmtpClient smtp = new SmtpClient();
                smtp.Host = servidor;
                int n;
                bool res = int.TryParse(puerto, out n);
                if (!res) n = 25;
                smtp.Port = n;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(obeMensaje.De, obeMensaje.Clave);
                smtp.Send(eMail);
                exito = true;
            }
            catch (Exception ex)
            {
                ucObjeto<Exception>.grabarArchivoTexto(ex, archivo);
            }
            return (exito);
        }
    }
}
