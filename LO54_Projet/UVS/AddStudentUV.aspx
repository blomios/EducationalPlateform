<%@ Page Title="Importation des élèves" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddStudentUV.aspx.cs" Inherits="LO54_Projet.UVS.AddStudentUV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <br />
        <h3>Importer des élèves</h3>
        
        <div class="form-group">
            <asp:FileUpload id="FileUploadControl" runat="server" />
             <asp:Button runat="server" id="UploadButton" text="Upload" onclick="UploadButton_Click" />
            <br /><br />
            <asp:Label runat="server" id="StatusLabel" text="Upload status: " />
            <br /><br />
            <asp:Button ID="Button_Annuler" runat="server" BorderStyle="None" CssClass="btn active" Text="Annuler" OnClick="Button_Redirect" />
        </div>
    </div>
</asp:Content>
