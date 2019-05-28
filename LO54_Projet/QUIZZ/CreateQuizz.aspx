<%@ Page Title="Création d'un QUIZZ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateQuizz.aspx.cs" Inherits="LO54_Projet.QUIZZ.WebForm2" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <br />
   

    <div>
        <h3>Définition du quizz</h3>
        <hr /> 
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="QuizzName" CssClass="col-md-2 control-label">Nom du quizz</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="QuizzName" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="QuizzName"
                    CssClass="text-danger" ErrorMessage="Le champ nom est obligatoire." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">UV associée</asp:Label>
            <div class="col-md-10">
                <asp:RadioButtonList ID="RadioButtonList_ChoixUV" runat="server" CssClass="radio">
                </asp:RadioButtonList>
            </div>
        </div>
        <div class ="form-group" ID ="listQuestions">
            <asp:Panel runat="server" ID ="panel_container">
                <asp:Label runat="server" CssClass="col-md-2 control-label" ID ="labelRef">Questions du QCM</asp:Label>
                <div class="col-md-10" ID ="Questions_Container">
                    
                    <asp:Panel runat="server" ID="panel_Questions_Container">

                    </asp:Panel>
                    <div>
                        <asp:Button ID="Button_Add" runat="server" BorderStyle="None" AutoPostBack="true" OnClientClick="Button_Add_Click" CssClass="btn active" Text="+" UseSubmitBehavior="true"  OnClick="Button_Add_Click" CausesValidation="False" EnableViewState="True" />
                    </div>
               
                </div>
            </asp:Panel>
        </div>
        <div class="form-group">
            <asp:Button ID="Button_Creer_UV" runat="server" BorderStyle="None" CssClass="btn active" Text="Créer" />
        </div>
    </div>

   

</asp:Content>
