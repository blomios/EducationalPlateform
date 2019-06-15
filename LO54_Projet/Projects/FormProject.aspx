<%@ Page Title="Création et modifications des UVs" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormProject.aspx.cs" Inherits="LO54_Projet.UVS.FormProject" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <br />
        <h3>Créer un nouveau projet</h3>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Nom</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Name" CssClass="form-control"/>
                <asp:CustomValidator ID="CustomValidator1"
                    runat="server" 
                    ErrorMessage="Le nom du projet ne peut être vide"
                    ValidateEmptyText="true"
                    ControlToValidate="Name" 
                    OnServerValidate="CustomValidatorName_ServerValidate" 
                    ForeColor="Red"
                    />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Description" CssClass="col-md-2 control-label">Description</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Description" CssClass="form-control"  TextMode="MultiLine"/>
                <asp:CustomValidator ID="CustomValidatorDescription"
                    runat="server" 
                    ErrorMessage="La description de L'UV ne peut être vide"
                    ValidateEmptyText="true"
                    ControlToValidate="Description" 
                    OnServerValidate="CustomValidatorDescription_ServerValidate" 
                    ForeColor="Red"
                    />
            </div>
        </div>
        <div class="form-group">
            <asp:Button ID="Button_Save" runat="server" BorderStyle="None" CssClass="btn active" Text="Enregistrer" OnClick="Button_Save_Click" />
            <asp:Button ID="Button_Annuler" runat="server" BorderStyle="None" CssClass="btn active" Text="Annuler" OnClick="Button_Back" />
        </div>
    </div>

</asp:Content>
