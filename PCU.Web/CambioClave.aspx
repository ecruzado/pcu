<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambioClave.aspx.cs" Inherits="PCU.Web.CambioClave" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../Estilos/001.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/Rutinas.js"></script>
    <script type="text/javascript" src="../Scripts/md5.js"></script>
    <script>cargarCambioClave();</script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="Cuadro">
        <table style="width:100%">
            <tr>
                <td class="Subtitulo" colspan="2">Cambio de clave</td>
            </tr>
            <tr>
                <td style="width:30%">Clave Anterior:</td>
                <td style="width:70%">
                    <asp:TextBox ID="txtClaveAnterior" Width="100" MaxLength="20" TextMode="Password" runat="server"/>
                </td>
            </tr>
            <tr>
                <td style="width:30%">Clave Nueva:</td>
                <td style="width:70%">
                    <asp:TextBox ID="txtClaveNueva" Width="100" MaxLength="20" TextMode="Password" runat="server"/>
                </td>
            </tr>
            <tr>
                <td style="width:30%">Repita Clave Nueva:</td>
                <td style="width:70%">
                    <asp:TextBox ID="txtClaveRepetida" Width="100" MaxLength="20" TextMode="Password" runat="server"/>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:Button ID="btnAceptar" Text="Aceptar" OnClick="btnAceptar_Click" CssClass="Boton" runat="server" />&nbsp;&nbsp;
                    <asp:Button ID="btnCerrar" Text="Cerrar" OnClick="btnCerrar_Click" 
                        CssClass="Boton" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
