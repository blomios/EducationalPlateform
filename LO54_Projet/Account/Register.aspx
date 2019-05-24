<%@ Page Title="Inscription" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LO54_Projet.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Créer un nouveau compte</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="Veuillez renseigner une adresse email." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Nom" CssClass="col-md-2 control-label">Nom</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Nom" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Nom"
                    CssClass="text-danger" ErrorMessage="Veuillez renseigner votre nom." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Prenom" CssClass="col-md-2 control-label">Prénom</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Prenom" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Prenom"
                    CssClass="text-danger" ErrorMessage="Veuillez renseigner votre prénom." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Mot de passe</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="Veuillez renseigner un mot de passe." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirmer le mot de passe </asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Veuillez confirmer votre mot de passe." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Le mot de passe et le mot de passe de confirmation ne correspondent pas." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="S'inscrire" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
