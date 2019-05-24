<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuestionQuizzForm.ascx.cs" Inherits="LO54_Projet.Controllers.QuestionQuizzForm" %>
<%@ Register src="AnswereTypeForm.ascx" tagname="AnswereTypeForm" tagprefix="uc1" %>
<asp:Panel ID="QuestionPanel" runat="server">
    <p>Question:</p>
    <asp:TextBox ID="QuestionText" runat="server"></asp:TextBox>
    &nbsp;<br />
    <br />
    <uc1:AnswereTypeForm ID="AnswereTypeForm1" runat="server" />
    <br />
    <p>
        réponses:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; V:</p>
    <asp:Panel ID="Panel1" runat="server" Width="191px">
    </asp:Panel>
    &nbsp;<br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ajouter une réponse" />
    <br />
</asp:Panel>