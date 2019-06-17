<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="LO54_Projet.QUIZZ.WebForm1" %>


<%@ Register src="../Controllers/QuestionQuizzForm.ascx" tagname="QuestionQuizzForm" tagprefix="uc1" %>


<%@ Register src="../Controllers/AnswereForm.ascx" tagname="AnswereForm" tagprefix="uc2" %>




<%@ Register src="../Controllers/Uploadfile.ascx" tagname="Uploadfile" tagprefix="uc3" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WebForm1</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR"/>
    <meta content="C#" name="CODE_LANGUAGE"/>
    <meta content="JavaScript" name="vs_defaultClientScript"/>
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            QUIZZ Creation</div>
        <p>
            </p>
        <uc3:Uploadfile ID="Uploadfile1" runat="server" />
        <p>
            Nom du quizz</p>
        <p>
            <asp:TextBox ID="QuizzName" runat="server"></asp:TextBox>
        </p>
        <p>
            Création d&#39;une question:<p>
        <asp:Button ID="Button2" runat="server" Text="Creation d'une question" OnClick="Button2_Click"  />
        <asp:Button ID="Button3" runat="server" Text="Sauvegarde Quizz" OnClick="Button3_Click"  />
        </p>
        <asp:Panel ID="Panel2" runat="server" Direction="LeftToRight" Height="10000px" HorizontalAlign="Left" Width="500px">
            <uc1:QuestionQuizzForm ID="QuestionQuizzForm1" runat="server" />
        </asp:Panel>
    </form>
</body>
</html>
