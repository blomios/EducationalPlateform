<%@ Page Title="Détails de l'UV" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetailUV.aspx.cs" Inherits="LO54_Projet.UVS.DetailUV" %>

<%@ Register src="../Controllers/Uploadfile.ascx" tagname="Uploadfile" tagprefix="uc1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

    <div class="form-horizontal">
        <div style="text-align: right">
            <asp:Button ID="Button_Update_UV" runat="server" BorderStyle="None" CssClass="btn active" Text="Modifier" OnClick="Button_Update_UV_Click" />
        </div>
        <h3>Informations</h3>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Responsable</asp:Label>
            <asp:Label runat="server" CssClass="col-md-10 control-label" style="text-align:left" ID="LB_Owner"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Description</asp:Label>
            <asp:Label runat="server" CssClass="col-md-10 control-label" style="text-align:left" ID="LB_Desc"></asp:Label>
        </div>
        <div style="text-align: left">
            <uc1:Uploadfile ID="Uploadfile1" runat="server"/>
        </div>
        <asp:Button ID="Button_RedirectToListUV" runat="server" BorderStyle="None" CssClass="btn active" Text="Retour" OnClick="Button_RedirectToListUV_Click" />
    </div>

</asp:Content>
