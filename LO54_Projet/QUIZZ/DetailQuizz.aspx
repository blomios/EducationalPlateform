<%@ Page Title="Details du Quizz" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetailQuizz.aspx.cs" Inherits="LO54_Projet.QUIZZ.DetailQuizz" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <br />
    <div>
        <h3>Définition du quizz</h3>
        <hr /> 

        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="QuizzName" CssClass="col-md-2 control-label" Enabled="false">Nom du quizz</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="QuizzName" CssClass="form-control"/>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">UV associée</asp:Label>
            <div class="col-md-10">
                <asp:RadioButtonList ID="RadioButtonList_ChoixUV" runat="server" Enabled="false" CssClass="radio">
                </asp:RadioButtonList>
            </div>
        </div>
        <div class ="form-group" ID ="listQuestions">
            <asp:Panel runat="server" ID ="panel_container">
                <asp:Label runat="server" CssClass="col-md-2 control-label" ID ="labelRef">Questions du QCM</asp:Label>
                <div class="col-md-10" ID ="Questions_Container">
                    <asp:Panel runat="server" ID="panel_Questions_Container">

                    </asp:Panel>
                </div>
            </asp:Panel>
        </div>
    </div>

   

</asp:Content>

