<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PCU.Web.Login" %>

<!DOCTYPE html>

<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login</title>

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
                <h6 class="docs-header">Ingreso al Sistema</h6>
                <label>Usuario</label>
                <asp:TextBox ID="txtUsuario" MaxLength="20" runat="server" CssClass="u-full-width"/>

                <label>Clave</label>
                <asp:TextBox ID="txtClave" MaxLength="10" TextMode="Password" runat="server" CssClass="u-full-width"/>

                <img id="imgCaptcha" src="" alt="" width="200" height="80" runat="server" />
                <asp:LinkButton ID="lbnActualizarCaptcha" Text="Actualizar Captcha" OnClick="lbnActualizarCaptcha_Click" runat="server" />
                <br />
                <label>Ingresa el Código Generado</label>
                <asp:TextBox ID="txtCodigo" MaxLength="5" runat="server" CssClass="u-full-width"/>
                
                <asp:Button ID="btnAceptar" Text="Aceptar" OnClick="btnAceptar_Click" CssClass="button-primary u-full-width" runat="server" />
                <asp:LinkButton ID="lbnRecordarClave" Text="Olvido Contraseña" OnClick="lbnRecordarClave_Click" runat="server" />


            </div>
            <div class="four columns">&nbsp;</div>
        </div>
    </form>
</body>
</html>
