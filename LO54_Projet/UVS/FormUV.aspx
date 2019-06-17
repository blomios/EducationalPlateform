<%@ Page Title="Création et modifications des UVs" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormUV.aspx.cs" Inherits="LO54_Projet.UVS.FormUV" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <br />
        <h3>Créer une nouvelle UV</h3>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Denomination" CssClass="col-md-2 control-label">Dénomination</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Denomination" CssClass="form-control"/>
                <asp:CustomValidator ID="CustomValidatorDenomination"
                    runat="server" 
                    ErrorMessage="La dénomination de L'UV doit être composée de 4 charactères (2 lettres 2 chiffres ou 3 lettres 1 chiffre)"
                    ValidateEmptyText="true"
                    ControlToValidate="Denomination" 
                    OnServerValidate="CustomValidatorDenomination_ServerValidate"
                    ForeColor="Red"
                    />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Nom</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Name" CssClass="form-control"/>
                <asp:CustomValidator ID="CustomValidator1"
                    runat="server" 
                    ErrorMessage="Le nom de L'UV ne peut être vide"
                    ValidateEmptyText="true"
                    ControlToValidate="Name" 
                    OnServerValidate="CustomValidatorDescription_ServerValidate" 
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
            <asp:Button ID="Button_Creer_UV" runat="server" BorderStyle="None" CssClass="btn active" Text="Enregistrer" OnClick="Button_Creer_UV_Click" />
            <asp:Button ID="Button_Annuler" runat="server" BorderStyle="None" CssClass="btn active" Text="Annuler" OnClick="Button_Back" />
        </div>
    </div>

</asp:Content>
