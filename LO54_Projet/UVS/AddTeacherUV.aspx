<%@ Page Title="Ajout d'un responsable" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddTeacherUV.aspx.cs" Inherits="LO54_Projet.UVS.AddTeacherUV" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <br />
        <h3>Nouveau responsable</h3>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="Veuillez renseigner l'adresse email du responsable à ajouter" />
            </div>
        </div>
        <div class="form-group">
            <asp:Button ID="Button_Add" runat="server" BorderStyle="None" CssClass="btn active" Text="Enregistrer" OnClick="Button_Add_Click" />
            <asp:Button ID="Button_Annuler" runat="server" BorderStyle="None" CssClass="btn active" Text="Annuler" OnClick="Button_Back" />
        </div>
    </div>

</asp:Content>
