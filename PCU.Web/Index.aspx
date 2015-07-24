<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="PCU.Web.Index" %>
<%@ Import Namespace="PCU.Librerias.EntidadesNegocio" %>
<%@ Import Namespace="General.Librerias.CodigoUsuarioWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:DataList ID="dlsSistemaMenu" Width="1200px" RepeatColumns="3" RepeatDirection="Horizontal"
        CellPadding="10" CellSpacing="10" runat="server">
        <ItemTemplate>
            <div style="width:400px;height:220px;background-color:lightblue;border:solid;border-color:red;border-width:3px;overflow:auto">
                <%#((beSistemaMenu)Container.DataItem).NombreSistemaMenu%>
                <asp:DataList ID="dlsSistemaSubMenu" Width="300px" RepeatColumns="2" RepeatDirection="Horizontal"
                    DataSource="<%#lbeSistemaMenu.FindAll(x=>x.CodigoSistemaPadre.Equals(((beSistemaMenu)Container.DataItem).CodigoSistemaMenu))%>"
                    CellPadding="5" CellSpacing="5" runat="server">
                    <ItemTemplate>
                        <a href="<%#((beSistemaMenu)Container.DataItem).URLPagina%>">
                            <table style="width:120px;border:solid;border-color:yellow;border-width:3px;cursor:pointer;background-color:<%#((beSistemaMenu)Container.DataItem).ColorOpcion%>">
                                <tr>
                                    <td style="text-align:center">
                                        <img src="<%#Imagen.obtenerUrl(((beSistemaMenu)Container.DataItem).CodigoSistemaMenu,"SistemaMenu")%>" width="30" height="30" alt="" title="" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:center;vertical-align:central">
                                            <asp:Label ID="lblNombre" Text="<%#((beSistemaMenu)Container.DataItem).NombreCortoSistemaMenu%>" ToolTip="<%#((beSistemaMenu)Container.DataItem).NombreSistemaMenu%>" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </a>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
