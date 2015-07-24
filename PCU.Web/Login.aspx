<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PCU.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="Cuadro">
        <table style="width:100%">
            <tr>
                <td class="Subtitulo" colspan="2">Ingreso al Sistema</td>
            </tr>
            <tr>
                <td style="width:50%">
                    <table style="width:100%">
                        <tr>
                            <td style="width:30%">Usuario:</td>
                            <td style="width:70%">
                                <asp:TextBox ID="txtUsuario" Width="150" MaxLength="20" runat="server"/>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:30%">Clave:</td>
                            <td style="width:70%">
                                <asp:TextBox ID="txtClave" Width="100" MaxLength="10" TextMode="Password" runat="server"/>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align:center">
                                <asp:LinkButton ID="lbnRecordarClave" Text="Olvido Contraseña" OnClick="lbnRecordarClave_Click" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align:center">
                                <asp:Button ID="btnAceptar" Text="Aceptar" OnClick="btnAceptar_Click" CssClass="Boton" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width:50%">
                    <table style="width:100%">
                        <tr>
                            <td style="width:50%">
                                <img id="imgCaptcha" src="" alt="" width="200" height="80" runat="server" />
                            </td>
                            <td style="width:50%">
                                <table style="width:100%">
                                    <tr>
                                        <td>Ingresa el Código Generado</td>
                                    </tr>
                                    <tr>
                                        <td><asp:TextBox ID="txtCodigo" Width="60" MaxLength="5" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <td><asp:LinkButton ID="lbnActualizarCaptcha" Text="Actualizar Captcha" OnClick="lbnActualizarCaptcha_Click" runat="server" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
