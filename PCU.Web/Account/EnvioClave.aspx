<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnvioClave.aspx.cs" Inherits="PCU.Web.EnvioClave" %>

<!DOCTYPE html>

<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Envio de Clave</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
</head>
<body>
    <form id="form" runat="server">
        <div class="container">
            <div class="four columns">&nbsp;</div>
            <div class="four columns">
                <br />
                <h6 class="docs-header">Olvido su contraseña</h6>
                <p>Ingreso su correo electrónico para recibir un mensaje con las instrucciones para generar una nueva clave.</p>
                
                <label>Correo</label>
                <asp:TextBox ID="txtCorreo" MaxLength="100" runat="server" CssClass="u-full-width"/>
                 
                <img id="imgCaptcha" src="" alt="" width="200" height="80" runat="server" />
                
                <asp:LinkButton ID="lbnActualizarCaptcha" Text="Actualizar Captcha" OnClick="lbnActualizarCaptcha_Click" runat="server" />
                <label>Ingresa el Código Generado</label>
                <asp:TextBox ID="txtCodigo" MaxLength="5" runat="server" CssClass="u-full-width" />


                <asp:Button ID="btnRestablecerClave" Text="Restablecer" OnClick="btnRestablecerClave_Click" CssClass="button-primary u-full-width" runat="server" />
                <asp:Button ID="btnCerrar" Text="Cerrar" OnClick="btnCerrar_Click" CssClass="u-full-width" runat="server" CausesValidation="False" />
                

                <asp:HiddenField ID="abcde" runat="server" />
                <asp:HiddenField ID="vwxyz" runat="server" />
            </div>
            <div class="four columns">&nbsp;</div>
        </div>
    </form>
</body>
</html>