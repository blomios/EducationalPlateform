<%@ Page Title="Détails de l'UV" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetailUV.aspx.cs" Inherits="LO54_Projet.UVS.DetailUV" EnableEventValidation="false" %>

<%@ Register src="../Controllers/Uploadfile.ascx" tagname="Uploadfile" tagprefix="uc1" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

    <div class="form-horizontal">
        <div style="text-align: right">
            <asp:Button ID="Button_Update_UV" runat="server" BorderStyle="None" CssClass="btn btn-warning" Text="Modifier" OnClick="Button_Update_UV_Click" />
            <asp:Button ID="Button_Add_Teacher" runat="server" BorderStyle="None" CssClass="btn btn-success" Text="Ajouter responsable" OnClick="Button_Add_Teacher_Click" />
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
            <uc1:Uploadfile ID="Uploadfile1" runat="server"/>
        </div>
        <asp:Panel ID="FileList" runat="server">
        </asp:Panel>

         <%-- QCM list --%>
        <div class="row">
            <h3 class="col-md-6">Quizzes</h3>
            <div class="col-md-6" style="text-align: right; position: relative; top: 20px">
                <asp:Button ID="Button_AddQuizz" runat="server" BorderStyle="None" CssClass="btn btn-success" Text="Ajouter un quizz" OnClick="Button_AddQuizz_Click" />
            </div>
        </div>
        <asp:Panel ID="QuizzPanel" runat="server" CssClass="mb-2">
        </asp:Panel>

        <%-- Project list --%>
        <div class="row">
            <h3 class="col-md-6">Projets</h3>
            <div class="col-md-6" style="text-align: right; position: relative; top: 20px">
                <asp:Button ID="Button_Add_Project" runat="server" BorderStyle="None" CssClass="btn btn-success" Text="Ajouter un Projet" OnClick="Button_Add_Project_Click" />
            </div>
        </div>
        <hr style="margin-top: 5px" />
        <asp:Panel ID="ProjectList" runat="server" CssClass="mb-2"></asp:Panel>
        
        <asp:Button ID="Button_RedirectToListUV" runat="server" BorderStyle="None" CssClass="btn btn-danger" Text="Retour" OnClick="Button_RedirectToListUV_Click" />
    </div>

</asp:Content>
