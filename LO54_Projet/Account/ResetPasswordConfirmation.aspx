<%@ Page Title="Mot de passe modifié" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPasswordConfirmation.aspx.cs" Inherits="LO54_Projet.Account.ResetPasswordConfirmation" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <div>
        <p>Votre mot de passe a été modifié. Cliquez sur <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">ici</asp:HyperLink> se connecter </p>
    </div>
</asp:Content>
