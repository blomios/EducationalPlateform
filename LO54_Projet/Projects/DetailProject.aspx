<%@ Page Title="Détails de l'UV" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetailProject.aspx.cs" Inherits="LO54_Projet.UVS.DetailProject" %>

<%@ Register src="../Controllers/Uploadfile.ascx" tagname="Uploadfile" tagprefix="uc1" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

    <div class="form-horizontal">
        <div style="text-align: right">
            <asp:Button ID="Button_Update" runat="server" BorderStyle="None" CssClass="btn active" Text="Modifier" OnClick="Button_Update_Click" />
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
        
        <%-- File list --%>
        <h3>Fichiers</h3>
        <hr />
        <div style="text-align: left">
            <uc1:uploadfile id="Uploadfile1" runat="server" />
        </div>
        <asp:Panel ID="FileList" runat="server" Height="300px" ScrollBars="Auto">
        </asp:Panel>
        <asp:Button ID="Button_RedirectToDetailUV" runat="server" BorderStyle="None" CssClass="btn active" Text="Retour" OnClick="Button_RedirectToDetailUV_Click" />
    </div>

</asp:Content>
