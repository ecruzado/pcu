<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambioConfiguracion.aspx.cs" Inherits="PCU.Web.CambioConfiguracion" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../Estilos/001.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/Rutinas.js">
    </script>
    <script>cargarCambioConfiguracion();</script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="Cuadro">
        <table style="width:100%">
            <tr>
                <td class="Subtitulo" colspan="2">Configuración de Usuario</td>
            </tr>
            <tr>
                <td style="width:50%">
                    <table style="width:100%">
                        <tr>
                            <td style="width:30%">Usuario:</td>
                            <td style="width:70%">
                                <asp:TextBox ID="txtUsuario" ReadOnly="true" Width="150" MaxLength="20" runat="server"/>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:30%">Nombre Preferido:</td>
                            <td style="width:70%">
                                <asp:TextBox ID="txtNombrePreferido" Width="100" MaxLength="20" runat="server"/>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:30%">Estilo Web:</td>
                            <td style="width:70%">
                                <asp:DropDownList ID="ddlEstiloWeb" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width:30%">Tiempo Exp Sesión:</td>
                            <td style="width:70%">
                                <asp:TextBox ID="txtTiempo" Width="40" MaxLength="3" runat="server"/>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align:center">
                                <asp:Button ID="btnAceptar" Text="Guardar" OnClientClick="return validarLogin();" 
                                    OnClick="btnAceptar_Click" CssClass="Boton" runat="server" />&nbsp;&nbsp;
                                <asp:Button ID="btnCerrar" Text="Cerrar" OnClick="btnCerrar_Click"
                                    CssClass="Boton" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width:50%;text-align:center">
                    <table style="width:100%">
                        <tr>
                            <td>
                                <img id="imgFoto" alt="" width="100" height="80" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:FileUpload ID="fupFoto" runat="server" />
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
