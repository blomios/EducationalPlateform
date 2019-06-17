<%@ Page Title="Statistiques du quiz" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StatsQuizz.aspx.cs" Inherits="LO54_Projet.QUIZZ.StatsQuizz" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <asp:GridView ID="GridView_Quizz" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="10" CssClass="table" DataSourceID="SqlDataSource_Quizz" ForeColor="#333333" 
                    OnSelectedIndexChanged="GridView_OnSelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="UserName" HeaderText="Nom" SortExpression="Name" />
            <asp:BoundField DataField="Score" HeaderText="Note" SortExpression="Score" />
            <asp:BoundField DataField="ScoreMax" HeaderText="Maximum" SortExpression="ScoreMax" />
        </Columns>
        <HeaderStyle BackColor="#5D7B9D" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource_Quizz" runat="server" ConnectionString="<%$ ConnectionStrings:TestReel %>" >
    </asp:SqlDataSource>
    
    <asp:Button ID="Button_Back" runat="server" BorderStyle="None" CssClass="btn btn-danger" Text="Retour" OnClick="Button_Back_Click" />
</asp:Content>
