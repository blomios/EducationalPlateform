<%@ Page Title="Confirmation du compte" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" Inherits="LO54_Projet.Account.Confirm" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successPanel" ViewStateMode="Disabled" Visible="true">
            <p>
                Merci d'avoir confirmé votre compte. Cliquez <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">ici</asp:HyperLink> pour vous connecter
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="errorPanel" ViewStateMode="Disabled" Visible="false">
            <p class="text-danger">
                Une erreur s'est produite lors de la confirmation de votre compte.
            </p>
        </asp:PlaceHolder>
    </div>
</asp:Content>
