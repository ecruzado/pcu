<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CambioClave.aspx.cs" Inherits="PCU.Web.CambioClave" %>
<%@ Import Namespace="PCU.Librerias.EntidadesNegocio" %>
<%@ Import Namespace="General.Librerias.CodigoUsuarioWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainBody" runat="server">
    <div class="container">
        <h4 class="docs-header">Cambiar contrasena</h4>
        <br />
        <div class="row">
            <div class="four columns">
                <label for="txtClaveAnterior">Clave Anterior:</label>
            </div>
            <div class="eight columns">
                <asp:TextBox ID="txtClaveAnterior" MaxLength="20" TextMode="Password" runat="server" CssClass="u-full-width"/>
            </div>
        </div>
        <div class="row">
            <div class="four columns">
                <label for="txtClaveAnterior">Clave Anterior:</label>
            </div>
            <div class="eight columns">
                <asp:TextBox ID="txtClaveNueva" MaxLength="20" TextMode="Password" runat="server" CssClass="u-full-width"/>
            </div>
        </div>
        <div class="row">
            <div class="four columns">
                <label for="txtClaveAnterior">Clave Anterior:</label>
            </div>
            <div class="eight columns">
                <asp:TextBox ID="txtClaveRepetida" MaxLength="20" TextMode="Password" runat="server" CssClass="u-full-width"/>
            </div>
        </div>
        <div class="row">
            <div class="four columns">&nbsp;
            </div>
            <div class="eight columns">
                <asp:Button ID="btnAceptar" Text="Aceptar" OnClick="btnAceptar_Click" CssClass="button-primary" runat="server" />
                <asp:Button ID="btnCerrar" Text="Cerrar" OnClick="btnCerrar_Click" 
                    CssClass="" runat="server" />
            </div>
        </div>
        <div class="clear"></div>
    </div>
</asp:Content>