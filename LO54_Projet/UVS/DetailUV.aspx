<%@ Page Title="Détails de l'UV" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetailUV.aspx.cs" Inherits="LO54_Projet.UVS.DetailUV" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

    <div class="form-horizontal">
        <h3>Informations</h3>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Dénomination</asp:Label>
            <asp:Label runat="server" CssClass="col-md-10 control-label" style="text-align:left" ID="LB_Denom"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Description</asp:Label>
            <asp:Label runat="server" CssClass="col-md-10 control-label" style="text-align:left" ID="LB_Desc"></asp:Label>
        </div>
    </div>

</asp:Content>
